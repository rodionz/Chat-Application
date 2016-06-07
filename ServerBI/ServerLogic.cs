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
        public delegate void Something(MessageData delMesData);
        public static event Something newuserconnected ;


        public static List<UserData> listofUsersontheserver;





   
        public static void ServerOnline(ServerData sData)

            

          {

            TcpListener server = new TcpListener( IPAddress.Parse(sData.IPadress), sData.Portnumber);

            
            Task t1 = Task.Run(() => StartListening(server));
          
            //Task t2 = new Task();

          }



        public static void StartListening(TcpListener serv)
        {
            listofUsersontheserver = new List<UserData>();

            try
            {
                serv.Start();

                while (true)

                {
                    //TcpClient client = serv.AcceptTcpClientAsync()
                  //Task start =  Task.Run(() =>
                  //  {
                        TcpClient client = serv.AcceptTcpClient();
                        //Task<TcpClient> client = serv.AcceptTcpClientAsync();
                        NetworkStream netStream = client.GetStream();

                        //NetworkStream netStream = client.GetAwaiter();


                        BinaryFormatter bf = new BinaryFormatter();
                        MessageData mData = (MessageData)bf.Deserialize(netStream);
                        mData.listofUsers = listofUsersontheserver;

                        // IP and Port Validation
                      if  (mData.Userdat.Username == "IPandportTest")
                        {
                            bf.Serialize(netStream, mData);
                           
                        }

                        else
                        {
                        mData.Time = DateTime.Now;
                            mData.Textmessage = mData.Userdat.Username.ToString() + " Connected: ";
                            newuserconnected(mData);
                            bf.Serialize(netStream, mData);                     
                        }


                    //});
                }
            }
            finally
            {
                serv.Stop();

            }

        }
            
        public static void StopListening()

        {


        }

    }
}
