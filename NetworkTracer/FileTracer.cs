using System;
using System.IO;
using System.Windows.Forms;

namespace NetworkTracer
{

	// Main form for tracing IPs from files and displaying results in a DataGridView
	public partial class FileTracer : Form
	{
		public FileTracer()
		{
			InitializeComponent();
		}

		// Handles the click event for button1
		private void button1_Click(object sender, EventArgs e)
		{
			// Iterate through each row in the DataGridView
			foreach (DataGridViewRow dgvRow in grid.Rows)
			{
				// Skip the new row placeholder
				if (dgvRow.IsNewRow)
				{
					continue;
				}

				// Get the IP value from the row and sanitize it
				var ip = dgvRow.Cells["IP"]?.Value?.ToString().Replace("\n", "").Replace("\r", "");
				var path = Path.Combine(textBox1.Text, ip + ".txt");

				// Check if the file exists for the given IP
				if (File.Exists(path))
				{
					var lines = File.ReadAllLines(path);
					int i = 1;

					// Process each line in the file
					foreach (string line in lines)
					{
						// Check for non-empty lines that start with the expected index and do not contain "Trac"
						if (!string.IsNullOrEmpty(line) && line.StartsWith("  " + i) && !line.Contains("Trac"))
						{
							// Extract the first IP address found in the line using regex
							string ipFound = ScalarFuntions.GetFirstRegexMatch(@"((?:[0-9]{1,3}\.){3}[0-9]{1,3})", line);

							// Set the found IP in the corresponding cell
							dgvRow.Cells[i].Value = ipFound;
							i++;
						}
					}
				}
			}
		}
	}
}
