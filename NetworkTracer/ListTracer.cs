using System;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace NetworkTracer
{

	public partial class ListTracer : Form
	{
		public ListTracer()
		{
			InitializeComponent();
		}

		// Tracks the number of completed tracer threads
		private int completedThreads = 0;

		/// <summary>
		/// Handles the click event for starting tracer operations.
		/// </summary>
		private void button1_Click(object sender, EventArgs e)
		{
			int totalCount = myDataGridView1.Rows.Count - 1;
			string resultDir = $"Result {DateTime.Now:yyyy MM dd HH-mm-ss}";
			Directory.CreateDirectory(resultDir);

			this.Text = $"Started [{totalCount}]";

			foreach (DataGridViewRow row in myDataGridView1.Rows)
			{
				if (row.IsNewRow)
				{
					continue;
				}

				var ip = row.Cells["IP"].Value?.ToString();
				
				if (string.IsNullOrWhiteSpace(ip))
				{
					continue;
				}

				var maxHops = row.Cells["MaxHops"].Value?.ToString();
				var timeout = row.Cells["TimeOut"].Value?.ToString();

				// Start asynchronous tracer operation
				Tracerter.GetTracerterAsync(this, ip, timeout, maxHops, (tracertResp, pingResp) =>
				{
					Interlocked.Increment(ref completedThreads);

					// Save tracer response to file
					File.WriteAllText(Path.Combine(resultDir, $"{ip}.txt"), tracertResp);

					// Update status in DataGridView
					row.Cells["Status"].Value = pingResp;

					// Update form title with progress
					this.Text = $"[{totalCount}] [{completedThreads}]";

					// If all threads are completed, update title
					if (completedThreads == totalCount)
						this.Text = "Completed";
				});
			}
		}

		/// <summary>
		/// Opens Form2 when button2 is clicked.
		/// </summary>
		private void button2_Click(object sender, EventArgs e)
		{
			new FileTracer().Show();
		}

		/// <summary>
		/// Handles port connectivity and ping status for each row.
		/// </summary>
		private void portStart_Click(object sender, EventArgs e)
		{
			if (!int.TryParse(portNum.Text, out int port))
			{
				return;
			}

			foreach (DataGridViewRow row in myDataGridView1.Rows)
			{
				var ip = row.Cells[1].Value?.ToString();
				
				if (string.IsNullOrWhiteSpace(ip))
				{
					continue;
				}

				// Start a new thread for each row to avoid UI blocking
				new Thread(() =>
				{
					string statusResult = $"PING\t{PingTest.GetPingStatus(ip)}\tPORT({port})\t";
					try
					{
						using (var client = new TcpClient())
						{
							client.Connect(ip, port);
							statusResult += client.Connected ? "CONNECTED" : "NONE";
						}
					}
					catch
					{
						statusResult += "NONE";
					}

					// Update DataGridView safely from UI thread
					Invoke(new Action(() => row.Cells[4].Value = statusResult));
				}).Start();

				Application.DoEvents();
			}
		}
	}
}
