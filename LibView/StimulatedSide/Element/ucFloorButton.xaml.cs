using System;
using System.Collections.Generic;
using System.Event;
using System.Linq;
using System.Text;
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
using System.Windows.Threading;

namespace LibView
{
    /// <summary>
    /// ucFloorButton.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucFloorButton : UserControl
    {
        private bool _bChoiceState = false;

        public string FloorText { get { return tblFloor.Text; } set { tblFloor.Text = value; } }

        public ucFloorButton()
        {
            InitializeComponent();
        }

        public ucFloorButton(int iFloor)
        {
            InitializeComponent();
            FloorText = iFloor.ToString();

            Evt.Instance(FloorText + "ClearButtonUI").Event += ClearButtonUI;
        }

        private void UserControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Name.Contains("Floor"))
            {
                ButtonColorUI();
                Evt_Y2.Instance(FloorText + "FloorClick").Invoke(_bChoiceState, Convert.ToInt32(tblFloor.Text));
            }
        }

        internal void ButtonColorUI()
        {
            if (_bChoiceState)
            {
                _bChoiceState = false;
                rtgFloor.Fill = null;
            }
            else
            {
                _bChoiceState = true;
                rtgFloor.Fill = (Brush)new BrushConverter().ConvertFrom("#FF456FFF");
            }
        }

        private void ClearButtonUI()
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
            {
                _bChoiceState = false;
                rtgFloor.Fill = null;
            }));
        }

    }
}
