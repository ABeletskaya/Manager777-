using System;
using System.IO;
using System.Windows.Forms;

namespace FileManager
{
    class PropertiesInfo
    {
        
        public FileInfo[] tempFiles;
        public DirectoryInfo[] tempDirs;
        private DirectoryInfo _folder;
        private DirectoryInfo _dir;

         public object GetProperties(string route, string nameFile, bool isDirectory)
        {
            double sizeInKB = -2.0; // задаем размер файла по умолчанию 
            string propetiesText = "Property text";

            GetDirsAndFiles(route);

            try
            {
                string path = Path.Combine(route, nameFile);
                if (!isDirectory)
                {
                    sizeInKB = GetFileSize(nameFile);
                }
                else
                {
                    bool isSuccess = GetDirectoryInfo(nameFile);
                    if (isSuccess)                      
                    sizeInKB = GetDirSize(_dir) / 1024.0;                    
                }
                
                propetiesText = $@"Name: {nameFile}
Parent directory: {route}
Root directory: {route.Split('\\')[0] + '\\'}    
Last read time: {File.GetLastAccessTime(path)}
Last write time: {File.GetLastWriteTime(path)}
Size: { Math.Round(sizeInKB, 2)} KB
";
                if (isDirectory)
                {
                    GetDirsAndFiles(path);
                    string propetiesFolderText = $@" Files: {tempFiles.Length}
folders: {tempDirs.Length}";
                    propetiesText += "\n" + propetiesFolderText;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }           
             return (object)propetiesText;
        }

        public double GetFileSize(string path)
        {
            double l = -1;
            for (int i = 0; i < tempFiles.Length; i++)
            {
                if (tempFiles[i].Name == path)
                     l = tempFiles[i].Length / 1024.0;// приводим к КБ
            }
            return l;
        }

        public bool GetDirectoryInfo(string fileName)
        {
            try
            {
                foreach (DirectoryInfo di in tempDirs)
                {
                    if (di.Name == fileName)
                    {
                       _dir = di;                        
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return false;
        }

        public static long GetDirSize(DirectoryInfo dir)
        {
            long Size = 0;            
            FileInfo[] fis = dir.GetFiles();
            foreach (FileInfo fi in fis)
            {
                Size += fi.Length;
            }
           
           DirectoryInfo[] dis = dir.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                Size += GetDirSize(di);
            }
            return (Size);
        }


        public void GetDirsAndFiles(string path)
        {
            string computerName = InfoAndNavigationUtilities.GetComputerName();
            if (path != computerName)
            {
                _folder = new DirectoryInfo(path);
                tempDirs = _folder.GetDirectories();
                tempFiles = _folder.GetFiles();
            }
        }       
    }
}
