using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Event;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibModel
{
    public partial class Model : INotifyPropertyChanged
    {
        private int iNowFloor = 1;

        public int NowFloor
        {
            get { return iNowFloor; }
            set
            {
                iNowFloor = value;
                PropertyChange("NowFloor");
            }
        }

        private enDoorState eDoorState = enDoorState.Close;
        public enDoorState DoorState
        {
            get { return eDoorState; }
            set
            {
                eDoorState = value;
                PropertyChange("DoorState");
            }
        }

        private enMoveState eMoveState = enMoveState.Idle;
        public enMoveState MoveState
        {
            get { return eMoveState; }
            set
            {
                eMoveState = value;
                switch(eMoveState)
                {
                    case enMoveState.Up:
                        UpUI = "▲";
                        DownUI = "▽";
                        break;
                    case enMoveState.Down:
                        UpUI = "△";
                        DownUI = "▼";
                        break;
                    case enMoveState.Idle:
                        UpUI = "△";
                        DownUI = "▽";
                        break;
                }
            }
        }

        private string sUpUI = "△";
        public string UpUI
        {
            get { return sUpUI; }
            set 
            { 
                sUpUI = value;
                PropertyChange("UpUI");
            }
        }


        private string sDownUI = "▽";
        public string DownUI
        {
            get { return sDownUI; }
            set 
            { 
                sDownUI = value;
                PropertyChange("DownUI");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void PropertyChange(string sPropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(sPropertyName));
        }
    }
}
