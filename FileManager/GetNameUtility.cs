using System;
using System.Windows.Forms;

namespace FileManager
{
    static class GetNameUtility
    {
        public static bool EnterName(out string fileName, string oldName = null)
        {
            bool isSuccess = true;
                                  
            try
            {
                EnterName nameDialog = new EnterName(oldName);
                nameDialog.ShowDialog();

                if (nameDialog.DialogResult == DialogResult.OK)
                {
                    fileName = nameDialog.FileName;
                    nameDialog.Dispose();
                }
                else
                {
                    fileName = "";
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                fileName = "";
                isSuccess = false;
                MessageBox.Show(ex.ToString());
            }            
            return isSuccess;
        }       
    }
}
