using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Ftp_Client.Controllers;

namespace Ftp_Client.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public SecurityController SecurityCredentialsManager { get; set; }

        public MainWindowViewModel()
        {
            SecurityCredentialsManager = new SecurityController();
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if(PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
