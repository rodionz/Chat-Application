using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientInterface
{
    class NewUserEventArgs : EventArgs
    {

        public string MessageText
        { get; set; }
    }
}
