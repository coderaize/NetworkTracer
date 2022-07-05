using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetworkTracer
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grid.Rows)
            {
                if (dgvRow.IsNewRow) continue;
                var IP = dgvRow.Cells["IP"]?.Value?.ToString().Replace("\n", "").Replace("\r", "");
                if (File.Exists(textBox1.Text + "\\" + IP + ".txt"))
                {
                    var lines = File.ReadAllLines(textBox1.Text + "\\" + IP + ".txt");
                    int i = 1;
                    foreach (string line in lines)
                    {
                        if (line != "" && line.StartsWith("  " + i) && !line.Contains("Trac"))
                        {
                            string IPFound = ScalarFuntions.GetFirstRegexMatch(@"((?:[0-9]{1,3}\.){3}[0-9]{1,3})", line);
                            dgvRow.Cells[i].Value = IPFound;
                            i++;
                        }
                    }
                }
            }
        }
    }
}
