using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConssumerClients.Clients.HttpAnzlyzeAngular
{
    /// <summary>
    /// Activates The Angular App And Openes It In The Browser
    /// Setting The Angular App And Browser On Port 4401
    /// </summary>
    public class AnguarAppActivate
    {
        public Process AngularCmdActivateProcess { get; set; }
        public Process WebPageProcess { get; set; }
        public AnguarAppActivate()
        {
            this.AngularCmdActivateProcess = new Process();
            this.WebPageProcess = new Process();
        }
        public void SetProcessSetings()
        {
            //angular app process settings
            this.AngularCmdActivateProcess.StartInfo.FileName = "cmd.exe";
            this.AngularCmdActivateProcess.StartInfo.CreateNoWindow = false;
            this.AngularCmdActivateProcess.StartInfo.RedirectStandardInput = true;
            this.AngularCmdActivateProcess.StartInfo.RedirectStandardOutput = true;
            this.AngularCmdActivateProcess.StartInfo.UseShellExecute = false;
            this.WebPageProcess.StartInfo.UseShellExecute = true;
            //web page process settings
            //change to appsettings
            this.WebPageProcess.StartInfo.FileName = "http://localhost:4401";
        }
        /// <summary>
        /// Activates The Angular App (ng serve)
        /// </summary>
        /// <returns></returns>
        public async Task ActivateAngularProcessAsync()
        {
            //change path to appsettings
            await this.AngularCmdActivateProcess.StandardInput.WriteLineAsync(@"cd C:\Users\iaf\angular-project\client-app");
            this.AngularCmdActivateProcess.StandardInput.Flush();
            await this.AngularCmdActivateProcess.StandardInput.WriteLineAsync("ng serve --port 4401");
            this.AngularCmdActivateProcess.StandardInput.Close();
            Console.WriteLine(this.AngularCmdActivateProcess.StandardOutput.ReadToEnd());
        }
        /// <summary>
        /// Activates The Angular App (ng serve) And Opens The App In The Browser
        /// </summary>
        /// <returns></returns>
        public async Task StartingAngularAppProcessAsync()
        {
            SetProcessSetings();
            //opening the angular web page (in the browser)
            this.WebPageProcess.Start();
            _ = Task.Factory.StartNew(() => CheckIfAppLoaded());
            this.AngularCmdActivateProcess.Start();
            //cmd actions - cd to angular app path and activating the angular project (ng server in the cmd)
            await ActivateAngularProcessAsync();
        }
        /// <summary>
        /// Shows DialogBox When The Angular App Loaded
        /// </summary>
        /// <returns></returns>
        public async Task CheckIfAppLoaded()
        {
            HttpClient httpClient = new HttpClient();
            bool isLoaded = false;
            while (!isLoaded)
            {
                try
                {
                    //change to appSettings
                    _ = await httpClient.GetAsync("http://localhost:4401");
                    //STA thread to open dialogBox
                    Thread loginThread = new Thread(OpenDiaglogBox);
                    loginThread.SetApartmentState(ApartmentState.STA);
                    loginThread.Start();
                    isLoaded = true;
                }
                catch (HttpRequestException)
                {
                    //Checking Every 1Sec If App Loaded
                    await Task.Delay(1000);
                }
            }
        }
        public void OpenDiaglogBox()
        {
            DiaglogBox dBox = new DiaglogBox("Angular App Loaded!");
            dBox.ShowDialog();
        }
    }
}
