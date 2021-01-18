using LibModel;
using LibMove;
using System;
using System.Collections.Generic;
using System.Event;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibView
{
    /// <summary>
    /// ucInside.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucInside : UserControl
    {
        internal Controller controller = new Controller();

        public ucInside(int iKey)
        {
            InitializeComponent();

            EvtR_Y.Instance(iKey + "EvtElevator").Event += () => { return this; };

            //Property Binding
            MainGrid.DataContext = controller.model;

            //View Init
            InitDoor();
            InitFloorButton();
        }

        #region # Init

        private void InitDoor()
        {
            ucDoor cUcDoor = new ucDoor(grdDoor.Width, grdDoor.Height);
            grdDoor.Children.Add(cUcDoor);
        }

        private void InitFloorButton()
        {
            lblRepairing.Visibility = Visibility.Hidden;

            for (int i = controller.model.AllFloorCount; i > 0; i--)
            {
                ucFloorButton cUcFloorButton = new ucFloorButton(i)
                {
                    Name = "Floor" + i.ToString(),
                    Width = 12,
                    Margin = new Thickness(1, 2, 1, 2),
                };

                Evt_Y2.Instance(i.ToString() + "FloorClick").Event += (bChoiceState, iFloor) =>
                {
                    controller.FloorReserve(bChoiceState, iFloor);
                };

                wrpFloorButtons.Children.Add(cUcFloorButton);
            }
        }

        #endregion

        #region # Door Button Event

        private void btnDoor_MouseDown(object sender, MouseButtonEventArgs e)
        {

            ucFloorButton floorButton = (ucFloorButton)sender;

            if (floorButton.Name.Contains("Door"))
            {
                // 엘리베이터가 Move중일 때 Door기능 작동안됨
                if (controller.model.MoveState != enMoveState.Idle) return;

                floorButton.ButtonColorUI();

                if (floorButton.Name.Contains("Close"))
                {
                    controller.model.DoorState = enDoorState.Close;
                }
                else if (floorButton.Name.Contains("Open"))
                {

                    //Open 버튼을 계속 누르고 있으면 문이 열려있음
                    controller.model.DoorState = enDoorState.Open;
                    //Open 버튼을 계속 누르고 있으면 자동 문 닫힘 쓰레드 해제
                    controller._cCloseDoorThread.Abort();
                }
            }
        }

        private void btnDoor_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ucFloorButton floorButton = (ucFloorButton)sender;
            if (floorButton.Name.Contains("Door"))
            {
                // 엘리베이터가 Move중일 때 Door기능 작동안됨
                if (controller.model.MoveState != enMoveState.Idle) return;

                floorButton.ButtonColorUI();

                if (floorButton.Name.Contains("Open"))
                {                
                    // 문 열기 버튼을 땔 때 일정 시간 뒤 문 닫힘
                    controller.DoorOpenAndDelayCloseThread();
                }
            }
        }

        #endregion
    }
}
