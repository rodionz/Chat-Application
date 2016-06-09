using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using CommonTypes;
using System.IO;

namespace ClientBL
{
    public class UserLogic
    {

        public  delegate void Exseptions();
        public delegate void ClientBLEvents(MessageData mDAta);
        public static event Exseptions NoServer;
        public static event ClientBLEvents MessageRecieved;
        public static List<UserData> listofUserfortheUsers;
        public static bool GlobalValidIpandPort;
        public static  ClientAction LolacAction;
        public static MessageData LockalmesData;






        public static void MainClienFinction(MessageData mesData)

        {            
         Task t1 = Task.Run(() =>   ConnecttoServer(mesData));
        }




        public static void  IPAndPortValidation(MessageData premesData)

        {
            MessageData returning;
            
            TcpClient preclient = new TcpClient();

            try
            {
                preclient.Connect(premesData.Userdat.IPadress, premesData.Userdat.Portnumber);

                using (NetworkStream netStream = preclient.GetStream())
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(netStream, premesData);
                    returning = (MessageData)bFormat.Deserialize(netStream);
                    listofUserfortheUsers = returning.listofUsers;
                    GlobalValidIpandPort = true;
                }
            }

            catch (SocketException SE)
            {
                NoServer();
            }

            finally
            {
                preclient.Close();
            }

        }




        public static void ConnecttoServer (MessageData mData)
        {
            TcpClient client = new TcpClient();
            MessageData returning;
            client.Connect(IPAddress.Parse (mData.Userdat.IPadress), mData.Userdat.Portnumber );
            //NetworkStream usernetstream = client.GetStream();            
            BinaryFormatter Bformat = new BinaryFormatter();
            //Bformat.Serialize(usernetstream, mData);
            //returning = (MessageData)Bformat.Deserialize(usernetstream);

            Task Serverisonline = Task.Run(() =>
            {


                while (true)
                {
                    NetworkStream usernetstream = client.GetStream();

                    switch (LolacAction)
                    {
                        case ClientAction.Connection:
                            Bformat.Serialize(usernetstream, mData);
                            returning = (MessageData)Bformat.Deserialize(usernetstream);
                            LolacAction = ClientAction.None;
                            break;

                        case ClientAction.Sendmessage:
                            MessageRecieved(mData);
                            break;

                        case ClientAction.ReceiveMesg:

                            break;

                        case ClientAction.None:
                            break;

                    }



                }
            });
        }

        public static void SendMessage(MessageData mData)
        {
            
         
           
        }



        public static void UserisOnline(NetworkStream online)
        {
            
           
         

        }



























        public void Disconnect()
        {

        }

      

        public static void ColorwasChanged(UserData uData)
        {


        }

        public static void FontwasChanged(UserData uData)
        {

        }
    }
}
