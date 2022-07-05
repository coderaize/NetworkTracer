using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetworkTracer
{
    public class CommandPrompt
    {
        /// <summary>
        /// Get Result as Current Rights
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string GetResult(string command)
        {

            string FileName = "Cache" + ScalarFuntions.GetRandomString(5) + ".bat";

            File.WriteAllText(FileName, command);
            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = FileName;
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            if (File.Exists(FileName))
                File.Delete(FileName);
            return output;
        }


        /// <summary>
        /// Get Result as Current Rights as ASync
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static void GetResultAsync(string command, Action<string> CallBack, Control f)
        {
            Thread T = new Thread(new ThreadStart(delegate
            {
                string FileName = "Cache_" + ScalarFuntions.GetRandomString(5) + "_" + DateTime.Now.ToString("mm-ss") + ".bat";
                File.WriteAllText(FileName, command);
                // Start the child process.
                Process p = new Process();
                // Redirect the output stream of the child process.
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = FileName;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                // Do not wait for the child process to exit before
                // reading to the end of its redirected stream.
                p.WaitForExit();
                // Read the output stream first and then wait.
                string output = p.StandardOutput.ReadToEnd();
                if (File.Exists(FileName))
                    File.Delete(FileName);
                f.Invoke(new Action(delegate
                {
                    CallBack(output);
                }));

            }));
            T.IsBackground = true;
            T.SetApartmentState(ApartmentState.STA);
            T.Start();
        }


        /// <summary>
        /// Get Result as Admin Rights
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string GetResultAsAdmin(string command)
        {
            string FileName = "Cache" + ScalarFuntions.GetRandomString(5) + ".bat";
            File.WriteAllText(FileName, command);
            // Start the child process.
            Process p = new Process();
            // Redirect the output stream of the child process.
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.FileName = FileName;
            //Executes As Admin
            p.StartInfo.Verb = "runas";
            p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            p.Start();
            // Do not wait for the child process to exit before
            // reading to the end of its redirected stream.
            // p.WaitForExit();
            // Read the output stream first and then wait.
            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            if (File.Exists(FileName))
                File.Delete(FileName);
            return output;
        }

    }
}
