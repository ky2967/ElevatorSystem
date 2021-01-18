using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibModel
{
    public partial class Model
    {
        private int iCloseDoorDelayTime = 5000;

        public int CloseDoorDelayTime
        {
            get { return iCloseDoorDelayTime; }
            set { iCloseDoorDelayTime = value; }
        }
    }
}
