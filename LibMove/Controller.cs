using LibModel;
using System;
using System.Collections.Generic;
using System.Event;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibMove
{
    public partial class Controller
    {
        public Model model = new Model();

        public Thread _cCloseDoorThread;

        public Controller()
        {
            // Move
            Thread t = new Thread(new ThreadStart(ElevatorThread));
            t.Start();

            // Door
            _cCloseDoorThread = new Thread(new ThreadStart(DelayCloseDoor));
        }
    }
}
