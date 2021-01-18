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

namespace LibView
{
    /// <summary>
    /// Outside.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucOutside : UserControl
    {
        public ucOutside()
        {
            InitializeComponent();

            InitDoor();

            //Property Binding
            MainGrid.DataContext = EvtR_Y.Instance(1 + "EvtElevator").Invoke().controller.model;
        }

        private void InitDoor()
        {
            ucDoor cUcDoor = new ucDoor(grdDoor.Width, grdDoor.Height);
            grdDoor.Children.Add(cUcDoor);
        }
    }
}
