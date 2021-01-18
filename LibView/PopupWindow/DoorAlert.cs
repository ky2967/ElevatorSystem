
using System;
using System.Collections.Generic;
using System.Event;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibView
{
    public class CDoorAlert : LibSingleton.CSingleton<DoorAlert> { }
    public class DoorAlert
    {
        public DoorAlert()
        {
            Evt.Instance("EvtDoorOpen").Event += DoorOpen;
            Evt.Instance("EvtDoorClose").Event += DoorClose;
        }

        public void DoorOpen()
        {
            MessageBox.Show("문이 열렸습니다.");
        }

        public void DoorClose()
        {
            MessageBox.Show("문아 닫힙니다.");
        }
    }
}
