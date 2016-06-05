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

        //public string IPadress
        //{ get; set; }

        //public int UserPort
        //{ get; set; }

        //public UserData Ud
        //{ get; set; }


        //public MessageData Md
        //{ get; set; }









            public static void MainClienFinction(UserData uData)


        {
            
            ConnecttoServer(uData);

        }


        public static void IPAndPortValidation(UserData preuData)

        {
            preuData.Username = "IPandportTest";
            TcpClient preclient = new TcpClient();

            try
            {
                preclient.Connect(preuData.UserIP, preuData.UserPort);

                using (Stream str = preclient.GetStream())
                {
                    BinaryFormatter bFormat = new BinaryFormatter();
                    bFormat.Serialize(str, preuData);
                }
               
            }

            catch
            {

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
                client.Connect(IPAddress.Loopback, uData.UserPort );

                using (Stream str = client.GetStream())
                {

                    BinaryFormatter Bformat = new BinaryFormatter();
                    //Bformat.Serialize(str,object)

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
