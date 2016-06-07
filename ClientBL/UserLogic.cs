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

        public static event Exseptions NoServer;


        public static List<UserData> listofUserfortheUsers;

        public static bool ipandportvalid;






        public static void MainClienFinction(UserData uData)


        {
            
         Task t1 = Task.Run(() =>   ConnecttoServer(uData));

        }


        public static void  IPAndPortValidation(MessageData premesData)

        {
            MessageData returning;
            premesData.Userdat.Username = "IPandportTest";
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
                    ipandportvalid = true;
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




        public static void ConnecttoServer (UserData uData)
        {
            TcpClient client = new TcpClient();

            try
            {
                client.Connect(IPAddress.Parse (uData.IPadress), uData.Portnumber );

                using (NetworkStream usernetstream = client.GetStream())
                {

                    BinaryFormatter Bformat = new BinaryFormatter();
                        Bformat.Serialize(usernetstream, uData);
                   
                }

            }


            finally
            {
                client.Close();
            }
        }

        public static void SendMessage(MessageData mData)
        {

        }

        public void Disconnect()
        {

        }

        public event EventHandler MessageRecieved;

        public static void ColorwasChanged(UserData uData)
        {


        }

        public static void FontwasChanged(UserData uData)
        {

        }
    }
}
