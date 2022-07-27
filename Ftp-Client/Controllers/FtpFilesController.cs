using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ftp_Client.Controllers
{
    public class FtpFilesController
    {
        private string _ftp_url;
        private string _ftp_username;
        private string _ftp_password;

        private string _currentDirectory;
        public string CurrentDirectory
        {
            get { return _currentDirectory; }
            set { GoToDirectory(value); }
        }
        //Directories variables
        private List<string> _directoriesName;
        public List<string> DirectoriesName
        {
            get { return _directoriesName; }
        }
        //-------------------------
        //Files variables
        private List<string> _filesName;
        public List<string> FilesName
        {
            get { return _filesName; }
        }
        //-------------------------

        public FtpFilesController(string url, string username, string password)
        {
            _ftp_url = url;
            _ftp_username = username;
            _ftp_password = password;
        }

        public bool GoToDirectory(string path)
        {

            return false;
        }

        private void UpdateFiles()
        {

        }
    }
}
