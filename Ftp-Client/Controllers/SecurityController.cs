using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ftp_Client.Controllers
{
    public class SecurityController : INotifyPropertyChanged
    {
        private string _host;
        public string Host { 
            get { return _host; }
            set { 
                string tmp = value.Replace(":", "");

                _host = tmp;
                OnPropertyChanged("Host");
                UpdateData(); }
            }
        private string _username;
        public string Username { 
            get { return _username;}
            set {

                string tmp = value.Replace(":", "");

                _username = tmp; 
                OnPropertyChanged("Username"); 
                UpdateData(); }
        
        }
        private string _password;
        public string Password {
            get { return _password; }
            set {
                string tmp = value.Replace(":", "");

                _password = tmp;
                OnPropertyChanged("Password");
                UpdateData(); }
        }

        private const string _securityFilePath = @"..\..\Security\LoginPassword.txt";
        
        public SecurityController()
        {
            FileStream fs;
            if (!(File.Exists(_securityFilePath))) fs = File.Create(_securityFilePath);
            else fs = File.OpenRead(_securityFilePath);
            string fileData="";

                StreamReader sr = new StreamReader(fs);
                fileData = sr.ReadToEnd();

            fs.Close();
            string[] splittedData = fileData.Split(':');
            if (splittedData.Length == 3)
            {
                _host = splittedData[0];
                _username = splittedData[1];
                _password = splittedData[2];
            }
            
        }


        public void SetNewCredentials(string host, string username, string password)
        {
            Host = host;
            Username = username;
            Password = password;
        }

        private void UpdateData()
        {
            using(FileStream fs = File.OpenWrite(_securityFilePath))
            {
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine($"{Host}:{Username}:{Password}");
                sw.Close();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
