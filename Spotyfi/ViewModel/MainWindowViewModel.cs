using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Spotyfi.Model;

namespace Spotyfi.ViewModel
{
    public class MainWindowViewModel
    {

        private ICommand _closeApp;
        public ICommand CloseApp
        {
            get { return _closeApp; }
            set { _closeApp = value; }
        }


        //--------------------------------------------------------


        public MainWindowViewModel()
        {
            CloseApp = new DelegateCommand(CloseSpotyfi);
        }


        //--------------------------------------------------------



        private void CloseSpotyfi(object args)
        {
            Environment.Exit(0);
        }



    }
}
