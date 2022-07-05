using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NetworkTracer
{
    public class PingTest
    {

        /// <summary>
        /// Get Ping Reponse
        /// </summary>
        /// <param name="hostNameOrIPAddress"></param>
        /// <returns></returns>
        public static PingResultData GetPingResult(string hostNameOrIPAddress)
        {
            Ping p1 = new Ping();
            PingReply PR = p1.Send(hostNameOrIPAddress);
            return new PingResultData(PR.RoundtripTime, PR.Status.ToString(),PR.Options.Ttl);
        }

        public static string GetPingStatus(string hostNameOrIPAddress) 
        {
            Ping p1 = new Ping();
            PingReply PR = p1.Send(hostNameOrIPAddress);
            return PR.Status.ToString();
        }



        public class PingResultData
        {
            public PingResultData(long roundTripTime, string pingStatus, int tTL)
            {
                RoundTripTime = roundTripTime;
                PingStatus = pingStatus;
                TTL = tTL;
            }
            public long RoundTripTime { get; set; }
            public string PingStatus { get; set; }
            public int TTL { get; set; }
        }

    }
}
