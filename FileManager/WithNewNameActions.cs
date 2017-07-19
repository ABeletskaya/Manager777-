using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileManager
{
    class WithNewNameActions
    {        
        public string CurrentRoute { get; set; }
        
        public bool MyRename(string fileName, bool isDirectory)
        {
            bool isSuccess = false;
            try
            {
                string newName;

                if (GetNameUtility.EnterName(out newName, fileName))
                {
                    FileActionUtilities.MyRenameFile(CurrentRoute, fileName, newName, isDirectory);
                    isSuccess = true;
                }
            }
            catch (Exception ex)
            {               
                MessageBox.Show(ex.ToString());
            }
            return isSuccess;
        }

        public bool CreateFolder()
        {
            bool isSuccess = false;      
            string name;
            bool isNewName = GetNameUtility.EnterName(out name);
            if (isNewName)
            {    
                if (name != "")
                {
                    isSuccess = FileActionUtilities.MyCreateFolder(Path.Combine(CurrentRoute, name + '\\'));                        
                }               
            }           
                return isSuccess;
        }       
    }
}
