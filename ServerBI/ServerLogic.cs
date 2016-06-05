using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using CommonTypes;
using System.IO;

namespace ServerBI
{
    public class ServerLogic
    {
        public delegate void Something();
        public static event Something somethinghappend ; 

   
        public static void ServerOnline(ServerData sData)

          {

            TcpListener server = new TcpListener( IPAddress.Parse(sData.IPofServer), sData.PortofServer);

            
            Task t1 = Task.Run(() => StartListening(server));
          
            //Task t2 = new Task();

          }



        public static void StartListening(TcpListener serv)
        {
            try
            {
                serv.Start();

                while (true)

                {
                  TcpClient client =  serv.AcceptTcpClient();
                    using (Stream s = client.GetStream())
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                            bf.Deserialize(s);


                    }


                }
            }
            finally
            {
                serv.Stop();

            }

            //TcpListener listener = new TcpListener(IPAddress.Parse(Sdat.IPofServer), Sdat.PortofServer);
           

            //try
            //{
            //    listener.Start();
            //    TcpClient talker = listener.AcceptTcpClient();
            //    //    TcpClient talker = listener.AcceptTcpClientAsync();
            //    using (Stream str = talker.GetStream())
            //    {


            //    }

            //}

            //finally
            //{
            //    listener.Stop();
            //}


        }


        public static void StopListening()

        {


        }

    }
}
