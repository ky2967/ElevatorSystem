using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Event;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibModel
{
    public partial class Model
    {
        private int cAllFloorCount = 21;
        public int AllFloorCount
        {
            get { return cAllFloorCount; }
            set { cAllFloorCount = value; }
        }

        private List<int> cReservedFloorList = new List<int>();
        public List<int> ReservedFloorList
        {
            get { return cReservedFloorList; }
            set { cReservedFloorList = value; }
        }

        private bool bRun = false;
        public bool Run
        {
            get { return bRun; }
            set { bRun = value; }
        }
    }
}
