using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConssumerClients.Clients.CommandLineClients
{
    /// <summary>
    /// Activates Mongodb Server By Cmd Commands
    /// </summary>
    public class CommandLineMongodbServerListener
    {
        public Process MongodbProcess { get; set; }
        public CommandLineMongodbServerListener()
        {
            this.MongodbProcess = new Process();
            this.MongodbProcess.StartInfo.FileName = "cmd.exe";
            SetProcessSettings();
        }
        public void SetProcessSettings()
        {
            this.MongodbProcess.StartInfo.CreateNoWindow = true;
            this.MongodbProcess.StartInfo.RedirectStandardInput = true;
            this.MongodbProcess.StartInfo.RedirectStandardOutput = true;
            this.MongodbProcess.StartInfo.UseShellExecute = false;
        }
        public void ActivateCommand(string command)
        {
            this.MongodbProcess.StandardInput.WriteLine(command);
            this.MongodbProcess.StandardInput.Flush();
        }
        public void ActivateMongodbListener()
        {
            this.MongodbProcess.Start();
            //change to appsettings
            ActivateCommand(@"cd C:\Program Files\MongoDB\Server\5.0\bin");
            ActivateCommand("mongod");
            ActivateCommand("mongo");
            this.MongodbProcess.StandardInput.Close();
            Console.WriteLine(this.MongodbProcess.StandardOutput.ReadToEnd());
        }
    }
}
