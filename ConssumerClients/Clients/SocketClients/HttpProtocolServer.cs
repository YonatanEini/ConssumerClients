using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConssumerClients.AlertMessagesEnum;
using SimpleHttp;


namespace ConssumerClients.Clients.SocketClients
{
    /// <summary>
    /// creates Http Server With Post And Get Requests
    /// </summary>
    public class HttpProtocolServer : SocketClientBase
    {
        public CancellationTokenSource ServerToken { get; set; }
        public HttpProtocolServer(int portNmber) : base(portNmber)
        {
            this.ServerToken = new CancellationTokenSource();
        }
        public void AddPostRequest()
        {
            Route.Add("/", (req, res, props) =>
            {
                string jsonData = new StreamReader(req.InputStream).ReadToEnd();
                Console.WriteLine($"data from http client: {jsonData}");
                res.StatusCode = 201;
                res.AsText("Receive");
            }, "POST");
        }
        public void AddGetRequest()
        {
            Route.Add("/", (req, res, props) =>
            {
                res.StatusCode = 201;
                res.AsText("Http server is Active! Send Some Decoded Frames!");
            });
        }
        public override AlertsMessagEnum ActivateServer()
        {
            try
            {
                AddGetRequest();
                AddPostRequest();
                Task.Factory.StartNew(() => HttpServer.ListenAsync(base.Port, ServerToken.Token, Route.OnHttpRequestAsync).Wait());
                Console.WriteLine($"Activating Http Server on Port {base.Port}");
                return AlertsMessagEnum.ok;
            }
            catch (AggregateException)
            {
                return AlertsMessagEnum.Error;
            }
        }
        public void StopHttpServer()
        {
            this.ServerToken.Cancel();
        }
    }
}
