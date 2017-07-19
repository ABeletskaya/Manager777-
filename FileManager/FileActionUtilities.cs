using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileManager
{
    static class FileActionUtilities
    {
        public static bool MyCreateFolder(string folder)
        {
            try
            {
                if (Directory.Exists(folder))
                {
                    MessageBox.Show("Directory already exists");
                    return false;
                }
                else
                {
                    Directory.CreateDirectory(folder);
                  //  MessageBox.Show("Directory was created");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Could not create directory");
                MessageBox.Show(ex.ToString());
                return false;
            }
            return true;
        }

        public static void MyRenameFile(string folder, string fileName, string newFileName, bool isDirectory)
        {
            string path = Path.Combine(folder, fileName);
            string newPath = Path.Combine(folder, newFileName);

            if (File.Exists(newPath))
            {
                MessageBox.Show($"File with name {newFileName} already exists");
                return;
            }

            if (isDirectory)                
                Directory.Move(path, newPath);
            else               
                File.Move(path, newPath);
        }

       
        public static bool Paste(string nameFile, string pathStart, string pathFinish, bool isCopy, bool isDirectory)
        {            
                string sourceFileName = Path.Combine(pathStart, nameFile);
                string destFileName = Path.Combine(pathFinish, nameFile);

                try
                {
                    if (isCopy)
                    {
                        if (isDirectory)
                        {
                            CopyDirectory(sourceFileName, destFileName);
                        }
                        else
                        {
                            File.Copy(sourceFileName, destFileName); 
                        }
                    }
                    else // если isCopy ложно - перемещаем
                    {
                        if (isDirectory)
                        {
                            CopyDirectory(sourceFileName, destFileName);
                            Directory.Delete(sourceFileName, true);
                        }
                        else
                            File.Move(sourceFileName, destFileName);
                    }                  
                }
                catch (Exception ex)
                {                   
                    MessageBox.Show(ex.ToString());// здесь можно поробовать throw;
                    return false;
                }
           
            return true;
        }

        private static void CopyDirectory(string startRoute, string finishRoute)
        {
            try
            {
                Directory.CreateDirectory(finishRoute);
                foreach (string s1 in Directory.GetFiles(startRoute))
                {
                    string s2 = finishRoute + "\\" + Path.GetFileName(s1);
                    File.Copy(s1, s2);
                }
                foreach (string s in Directory.GetDirectories(startRoute))
                {
                    CopyDirectory(s, finishRoute + "\\" + Path.GetFileName(s));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($" CopyDirectory  catch: startRoute - {startRoute}, finishRoute - {finishRoute} ");
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
