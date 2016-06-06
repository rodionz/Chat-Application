using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClientInterface
{
  public  class UserEvenHandlers
    {
        
        public static void NoServerHandler()
        {
            MessageBox.Show("Server is Offline", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
