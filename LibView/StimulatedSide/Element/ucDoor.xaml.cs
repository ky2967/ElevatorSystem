using System;
using System.Collections.Generic;
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
    /// ucDoor.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ucDoor : UserControl
    {
        public ucDoor()
        {
            InitializeComponent();
        }

        public ucDoor(double dWidth, double dHeight)
        {
            InitializeComponent();

            linDoor.X1 = dWidth / 2;
            linDoor.X2 = dWidth / 2;
            linDoor.Y2 = dHeight;
        }
    }
}
