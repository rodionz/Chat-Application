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

   

        //public  string IPAdress
        //{ get; set; }

        //public int Serverport
        //{ get; set; }

        //public List<UserData>  udl
        //{ get; set; }




        public static void ServerOnline(ServerData sData)

          {

            Task t1 = Task.Run(() => StartListening(sData));
          
            //Task t2 = new Task();

          }



        public static void StartListening(ServerData Sdat)
        {

            for (int i = 0; i < 10; i++)
            {
                somethinghappend();
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
