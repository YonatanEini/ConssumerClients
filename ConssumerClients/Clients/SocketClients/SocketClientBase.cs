using ConssumerClients.AlertMessagesEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConssumerClients.Clients.SocketClients
{
    /// <summary>
    /// Base Class For Socket Clients
    /// </summary>
    public abstract class SocketClientBase
    {
        public int Port { get; set; }
        public SocketClientBase()
        {
            Port = 0;
        }
        public SocketClientBase(int portNumber)
        {
            Port = portNumber;
        }
        public abstract AlertsMessagEnum ActivateServer();

    }
}
