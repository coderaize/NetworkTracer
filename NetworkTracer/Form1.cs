using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace NetworkTracer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int completedThreads { get; set; } = 0;


        private void button1_Click(object sender, EventArgs e)
        {
            int TotatCount = (myDataGridView1.Rows.Count - 1);
            string dirNAme = "Result " + DateTime.Now.ToString("[yyyy MM dd] HH-mm-ss");
            Directory.CreateDirectory(dirNAme);
            ///
            this.Text = "Started[]" + TotatCount;
            foreach (DataGridViewRow dgvRow in myDataGridView1.Rows)
            {
                if (!dgvRow.IsNewRow && !string.IsNullOrEmpty(dgvRow.Cells["IP"].Value?.ToString()))
                {
                    //
                    var IP = dgvRow.Cells["IP"]?.Value?.ToString();
                    var MaxHops = dgvRow.Cells["MaxHops"]?.Value?.ToString();
                    var TimeOut = dgvRow.Cells["TimeOut"]?.Value?.ToString();
                    ///
                    Tracerter.GetTracerterAsync(this, IP, TimeOut, MaxHops, (tracertResp, pingResp) =>
                     {
                         completedThreads++;
                         //
                         File.WriteAllText(dirNAme + "\\" + IP + ".txt", tracertResp);
                         dgvRow.Cells["Status"].Value = pingResp;
                         //
                         this.Text = "[] " + TotatCount + "[]" + completedThreads;
                         //
                         if (TotatCount == completedThreads)
                             this.Text = "Completed";
                     });
                }
            }

        }




        public class Tracerter
        {
            /// <summary>
            /// First Param Gets Response of Tracert
            /// Second Param Gets Ping Response
            /// </summary>
            /// <param name="IP"></param>
            /// <param name="TimeOut"></param>
            /// <param name="Hops"></param>
            /// <param name="CallBack"></param>
            public static void GetTracerterAsync(Control f, string IP, string TimeOut, string Hops, Action<string, string> CallBack)
            {
                var command = " tracert ";
                if (!string.IsNullOrEmpty(TimeOut) && TimeOut != "0")
                    command += " -w " + TimeOut + " ";
                if (!string.IsNullOrEmpty(Hops) && Hops != "0")
                    command += " -h " + Hops + " ";
                command += " " + IP;

                string pingReply = "STARTED";
                try
                {
                    Ping p1 = new Ping();
                    PingReply PR = p1.Send(IP);
                    pingReply = PR.Status.ToString();
                }
                catch (Exception t) { pingReply = t.Message; }
                // execute after fetching it completely

                CommandPrompt.GetResultAsync(command, (result) =>
                {
                    CallBack(result, pingReply);
                }, f);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new Form2().Show();
        }

        private void portStart_Click(object sender, EventArgs e)
        {
            int port = int.Parse(portNum.Text);
            foreach (DataGridViewRow dgRow in myDataGridView1.Rows)
            {
                if (dgRow.Cells[1].Value != null && dgRow.Cells[1].Value?.ToString() != "")
                {
                    new Thread(new ThreadStart(delegate
                    {
                        string statusResult = "";
                        statusResult += "PING\t" + PingTest.GetPingStatus(dgRow.Cells[1]?.Value?.ToString());
                        statusResult += "\tPORT(" + port + ")\t";
                        try
                        {
                            TcpClient tClient = new TcpClient();
                            tClient.Connect(dgRow.Cells[1]?.Value?.ToString(), port);
                            if (tClient.Connected)
                            { statusResult += "CONNECTED"; }
                            else { statusResult += "NONE"; }
                        }
                        catch { }
                        Invoke(new Action(delegate { dgRow.Cells[4].Value = statusResult; }));
                    })).Start();
                }
                Application.DoEvents();

            }
        }
    }
}
