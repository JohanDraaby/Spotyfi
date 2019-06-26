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

namespace Spotyfi.View
{
    /// <summary>
    /// Interaction logic for AlbumPageView.xaml
    /// </summary>
    public partial class AlbumPageView : Page
    {
        public AlbumPageView()
        {
            InitializeComponent();
        }

        private void DataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString().ToUpper() == "ID" || e.Column.Header.ToString().ToUpper() == "PATH")
            {
                e.Cancel = true;
            }
        }
    }
}
