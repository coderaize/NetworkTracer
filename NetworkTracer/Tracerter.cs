using System;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace NetworkTracer
{
	public partial class ListTracer
	{
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
	}
}
