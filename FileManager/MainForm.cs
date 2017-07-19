using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileManager
{
    public partial class MainForm : Form
    {
        private string _computerName;
        private string _nameFile = "";
        private string _actionNameFile = "";
        private string _actionStartRoute = "";
        private string _startRoute = "";
        private string _finishRoute = "";
        private string[] _drives;

        private bool _isDirectory = false;
        private bool _isDirectory2 = false;
        private bool _isCopy = false;
        private bool _isMove = false;      

        private int _activeViewIndex;
        private int _cutViewIndex;
        private int _pastActiveViewIndex;

        PropertiesInfo _property;
        WithNewNameActions _newNameActions;

        List<FileManagerView> _viewList;

        public MainForm()
        {
            _computerName = InfoAndNavigationUtilities.GetComputerName();
            _property = new PropertiesInfo();
            _newNameActions = new WithNewNameActions();           

            InitializeComponent();
            cbInitialLogicalDrives();

            _viewList = new List<FileManagerView>();
            _viewList.Add(new FileManagerView() { ListBox = lbLeftTree, TextBox = tbRouteLeft });
            _viewList.Add(new FileManagerView() { ListBox = lbRightTree, TextBox = tbRouteRight });

            InitialPath();

            _activeViewIndex = 0;
            ColoringView();            
        }

        public void cbInitialLogicalDrives()
        {
            _drives = System.IO.Directory.GetLogicalDrives();
            foreach (string str in _drives)
            {
                cbLogicalDrivers.Items.Add(str);
            }
        }

        // Инициализация во Вьюхах начальных директорий и их содержимого
        public void InitialPath()
        {
            int lDrives = _drives.Length;
            int lView = _viewList.Count;

            if (lView <= lDrives)
            {
                for (int i = 0; i < lView; i++)
                {
                    _viewList[i].TextBox.Text = _drives[i];
                    UpdateListBox(_drives[i], _viewList[i].ListBox);
                }
            }
            else //Если логических устройств меньше, чем вьюх
            {
                for (int i = 0; i < lDrives; i++) // заполняем всеми логическими устройствами
                {
                    _viewList[i].TextBox.Text = _drives[i];
                    UpdateListBox(_drives[i], _viewList[i].ListBox);
                }
                for (int i = lDrives; i < lView; i++)// оставшиеся вьюхи инициализируем нулевым логическим диском
                {
                    _viewList[i].TextBox.Text = _drives[0];
                    UpdateListBox(_drives[0], _viewList[i].ListBox);
                }
            }
        }

        public void GetLogicalDiskInListBox()
        {
            _viewList[_activeViewIndex].TextBox.Text = _computerName; //возвращаем в путь имя компьютера            
            _viewList[_activeViewIndex].ListBox.Items.Clear();

            foreach (var item in _drives) //выводим все логические диски в листбокс
            {
                _viewList[_activeViewIndex].ListBox.Items.Add(item);
            }
        }

        public void UpdateListBox(string path, ListBox listBox)
        {
            if (path != _computerName) // Если path = _computerName - в listBox уже содержится список логических утройств.
            {
                listBox.Items.Clear(); // очищаем листбокс 

                _property.GetDirsAndFiles(path);

                if (_property.tempDirs.Length > 0)
                    UpdateListBoxValue(_property.tempDirs, listBox);
                if (_property.tempFiles.Length > 0)
                    UpdateListBoxValue(_property.tempFiles, listBox);
            }
            else
            {
                _isDirectory = true;
                GetLogicalDiskInListBox();
            }
        }

        private void UpdateListBoxValue(FileSystemInfo[] array, ListBox listBox)
        {
            try
            {
                foreach (var item in array)
                {
                    listBox.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private bool GetIsDirectory(FileSystemInfo file = null)
        {
            bool isDirectory = false;

            if (string.Equals(_viewList[_activeViewIndex].TextBox.Text, _computerName))
            {
                _isDirectory = true;
                return true;
            }

            if (file == null)
                isDirectory = (_viewList[_activeViewIndex].ListBox.SelectedItem is DirectoryInfo) ? true : false;
            else
                isDirectory = (file is DirectoryInfo) ? true : false;

            _isDirectory = isDirectory;
            return isDirectory;
        }

        private void cbLogicalDrivers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string path = cbLogicalDrivers.SelectedItem.ToString();

            UpdateListBox(path, _viewList[_activeViewIndex].ListBox);
            _viewList[_activeViewIndex].TextBox.Text = path;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string path = _viewList[_activeViewIndex].TextBox.Text;
            UpdateListBox(path, _viewList[_activeViewIndex].ListBox);
        }

        private void lbLeftTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MyDoubleClick();          
        }

        private void lbRightTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MyDoubleClick();           
        }

        // открытие по двойному щелчку папок и файлов
        private void MyDoubleClick()
        {
            string path = _viewList[_activeViewIndex].TextBox.Text;
            try
            {
                if (_viewList[_activeViewIndex].ListBox.SelectedIndex != -1) // Идем дальше, если двойной щелчок не на пустом месте вьюхи
                {
                    var path2 = _viewList[_activeViewIndex].ListBox.SelectedItem.ToString();
                    GetFileAndPath(true);
                    if (GetIsDirectory())
                    {
                        if (path.ToString().Count(c => c == '\\') >= 1)
                            // добавляем к пути '\', чтобы было удобнее возвращаться на уровень выше
                            path2 = Path.Combine(path, _viewList[_activeViewIndex].ListBox.SelectedItem.ToString() + '\\');

                        UpdateListBox(path2, _viewList[_activeViewIndex].ListBox);
                        _viewList[_activeViewIndex].TextBox.Text = path2;
                    }
                    else
                    {
                        Process.Start(Path.Combine(path, _viewList[_activeViewIndex].ListBox.SelectedItem.ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        // Получаем название и путь файла для дальнейшего копирования или перемещения
        private bool GetFileAndPath(bool neednameFile = false)
        {
            try
            {
                    if (neednameFile == true)
                        _nameFile = _viewList[_activeViewIndex].ListBox.SelectedItem.ToString();

                _startRoute = _viewList[_activeViewIndex].TextBox.Text;

                if (Equals(_startRoute, _computerName))
                    _isDirectory = true;
                else
                    GetIsDirectory();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("GetFileAndPath \n" + ex.ToString());
                return false;
            }
        }

        // Вернуться на уровень выше
        private void btnBack_Click(object sender, EventArgs e)
        {
            string path = InfoAndNavigationUtilities.BackFolder(_viewList[_activeViewIndex].TextBox.Text, _computerName);

            _viewList[_activeViewIndex].TextBox.Text = path;
            UpdateListBox(path, _viewList[_activeViewIndex].ListBox);
        }

        public bool InitializeFile()
        {
            bool isSuccess = false;
            if (_viewList[_activeViewIndex].ListBox.SelectedIndex != -1)
            {
                try
                {
                    _actionNameFile = string.Copy(_viewList[_activeViewIndex].ListBox.SelectedItem.ToString());
                    _actionStartRoute = string.Copy(_viewList[_activeViewIndex].TextBox.Text);
                    _isDirectory2 = GetIsDirectory();
                    isSuccess = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
                MessageBox.Show("Choose the file, please");
            return isSuccess;
        }

        // Обработка нажатия на кнопку Copy
        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (InitializeFile())
            {
                _isCopy = true;
                _isMove = false;
            }
        }

        // Обработка нажатия на кнопку Cut
        private void btnCut_Click(object sender, EventArgs e)
        {
            if (InitializeFile())
            {
                _isMove = true;
                _isCopy = false;
                _cutViewIndex = _activeViewIndex; //запоминаем индекс вьюхи, из которой вырезаем, чтобы после вставки на другую вьюху обновилась и первая
            }
        }

        private static bool PathAndFileNameCorrect(string nameFile, string pathStart, string pathFinish)
        {
            if (pathStart == "" || nameFile == "")
            {
                MessageBox.Show("File is not found");
                return false;
            }
            if (pathStart == pathFinish)
            {
                MessageBox.Show("The start and end folders are the same");
                return false;
            }
            return true;
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            _finishRoute = _viewList[_activeViewIndex].TextBox.Text;

            bool _isCopyOrMove = false;

            if (_isCopy == true)
                _isCopyOrMove = true;
            else if (_isMove == true)
                _isCopyOrMove = false;

            bool isSuccess = FileActionUtilities.Paste(_actionNameFile, _actionStartRoute, _finishRoute, _isCopyOrMove, _isDirectory2);

            if (isSuccess)
            {
                UpdateListBox(_viewList[_activeViewIndex].TextBox.Text, _viewList[_activeViewIndex].ListBox);
                if (_isMove == true && _cutViewIndex != _activeViewIndex)
                    UpdateListBox(_viewList[_cutViewIndex].TextBox.Text, _viewList[_cutViewIndex].ListBox);
            }
            CleanFileParameters();
        }

        private void CleanFileParameters()
        {
            _startRoute = "";
            _finishRoute = "";
            _nameFile = "";
            _isCopy = false;
            _isMove = false;
        }

        private void btnCreateFolder_Click(object sender, EventArgs e)
        {
            _newNameActions.CurrentRoute = _viewList[_activeViewIndex].TextBox.Text;
            if (_newNameActions.CreateFolder())
                UpdateListBox(_viewList[_activeViewIndex].TextBox.Text, _viewList[_activeViewIndex].ListBox);
            else
                MessageBox.Show("Could not create folder");
        }

        private void btnProperties_Click(object sender, EventArgs e)
        {
            if (_viewList[_activeViewIndex].ListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Choose the file, please");
                return;
            }

            if (GetFileAndPath(true))
            {
                string propetiesText = "";
                object obj = _property.GetProperties(_viewList[_activeViewIndex].TextBox.Text, _nameFile, _isDirectory);
                propetiesText = (string)obj;
                tbProperties.Text = propetiesText;
            }
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            if (_viewList[_activeViewIndex].ListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Choose the file, please");
                return;
            }
            _newNameActions.CurrentRoute = _viewList[_activeViewIndex].TextBox.Text;
            if (_newNameActions.MyRename(_viewList[_activeViewIndex].ListBox.SelectedItem.ToString(), GetIsDirectory()))
                UpdateListBox(_viewList[_activeViewIndex].TextBox.Text, _viewList[_activeViewIndex].ListBox);
        }

        //Закрашиваем активную Вьюху в LightSkyBlue цвет
        private void ColoringView()
        {
            _viewList[_pastActiveViewIndex].ListBox.BackColor = System.Drawing.Color.White;
            _viewList[_activeViewIndex].ListBox.BackColor = System.Drawing.Color.LightSkyBlue;
        }      

        private void InitialazeView(int activeViewNumber)
        {
            if (_activeViewIndex != activeViewNumber)
            {
                _pastActiveViewIndex = _activeViewIndex;
                _activeViewIndex = activeViewNumber;
               
                ColoringView();
            }
        }

        private void tbRouteRight_MouseClick(object sender, MouseEventArgs e)
        {
            int activeViewNumber = 1; // activeViewNumber равен индексу вьюхи в листе viewList
            InitialazeView(activeViewNumber);           
        }

        private void lbRightTree_MouseClick(object sender, MouseEventArgs e)
        {
            int activeViewNumber = 1;
            InitialazeView(activeViewNumber);
        }

        private void lbLeftTree_MouseClick(object sender, MouseEventArgs e)
        {
            int activeViewNumber = 0; // activeViewNumber равен индексу вьюхи в листе viewList
            InitialazeView(activeViewNumber);          
        }

        private void tbRouteLeft_MouseClick(object sender, MouseEventArgs e)
        {
            int activeViewNumber = 0;
            InitialazeView(activeViewNumber);
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            GetIsDirectory();
            string message = InfoAndNavigationUtilities.GetAboutProgramText();
            MessageBox.Show(this, message, "About Program");
        }
    }
}