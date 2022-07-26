using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ftp_Client.Controllers
{
    public class LocalFilesController
    {
        //Current directory -> path to current direcory that automaticly updates Directories and Files variables
        private string _currentDirectory;
        public string CurrentDirectory
        {
            get { return _currentDirectory; }
            set {
                if (Directory.Exists(value)) { _currentDirectory = value; UpdateFiles(); }
                else throw new Exception("Wrong directory");
            }
        }
        //Directories variables
        private List<DirectoryInfo> _directoriesInfo;  
        public List<DirectoryInfo> DirectoriesInfo
        {
            get { return _directoriesInfo; }
        }
        //-------------------------
        //Files variables
        private List<FileInfo> _filesInfo;
        public List<FileInfo> FilesInfo
        {
            get { return _filesInfo; }
        }
        //-------------------------

        public LocalFilesController()
        {
            CurrentDirectory = @"C:\";
        }

        public LocalFilesController(string path)
        {
            CurrentDirectory = path;
        }

        //Methods

        //Function accept two input formats: Just folder name or full path.
        //Return false if directory was not find. Return true if directory was changed to path
        public bool GoToDirectory(string path)
        {
            if (!(path.Contains(@"\"))){
                foreach (DirectoryInfo di in DirectoriesInfo)
                {
                    if (di.Name == path) { CurrentDirectory += @"path\"; return true; }
                }
                return false;
            }
            else
            {
                try
                {
                    CurrentDirectory = path;
                }catch (Exception) { return false; }

                return true;
            }
        }

        //Privat methods
        private void UpdateFiles()
        {
            _directoriesInfo.Clear();
            _filesInfo.Clear();
            _directoriesInfo = GetDirectoriesInfo(_currentDirectory);
            _filesInfo = GetFilesInfo(_currentDirectory);
        }
        private List<DirectoryInfo> GetDirectoriesInfo(string path)
        {
            List<DirectoryInfo> directorysInfos = new List<DirectoryInfo>();
            string[] directoriesPaths = Directory.GetDirectories(path);

            foreach (string directoryPath in directoriesPaths)
                directorysInfos.Add(new DirectoryInfo(directoryPath));

            return directorysInfos;
        }
        private List<FileInfo> GetFilesInfo(string path)
        {
            List<FileInfo> filesInfo = new List<FileInfo>();
            string[] filesPaths = Directory.GetFiles(path);

            foreach (string filePath in filesPaths)
                filesInfo.Add(new FileInfo(filePath));

            return filesInfo;
        }

    }
}
