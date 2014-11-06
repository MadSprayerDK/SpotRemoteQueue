using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotRemoteQueue.Socket
{
    public interface ISocketCommunication
    {
        int Start();
        int Open();
        int Close();
        int Stop();

        string Recive();
        string Send();
    }
}
