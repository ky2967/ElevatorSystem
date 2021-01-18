using LibModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Event;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibMove
{
    public partial class Controller
    {
        public void DoorControl()
        {
            // UI의 FloorButton 색깔 제거 및 눌린 층 List에서 제거
            Evt.Instance(model.NowFloor + "ClearButtonUI").Invoke();
            model.ReservedFloorList.Remove(model.NowFloor);

            DoorOpenAndDelayCloseThread();
        }

        public void DoorOpenAndDelayCloseThread()
        {
            model.DoorState = enDoorState.Open;

            _cCloseDoorThread = new Thread(new ThreadStart(DelayCloseDoor));
            _cCloseDoorThread.Start();
        }

        private void DelayCloseDoor()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            // 문이 열리고 닫히기 전까지의 대기시간
            while (sw.ElapsedMilliseconds < model.CloseDoorDelayTime)
            {
                Thread.Sleep(100);

                // 닫힘 버튼이 눌리면 
                if (model.DoorState == enDoorState.Close)
                    break;
            }

            model.DoorState = enDoorState.Close;
        }
    }
}
