using System;
using System.Linq;

namespace FileManager
{
    static class InfoAndNavigationUtilities
    {
        public static string GetAboutProgramText()
        {
            string message = @"О ПРОГРАММЕ

1. При запуске приложения по умолчанию активна левая сторона;
2. Активная сторона подсвечивается синим цветом;
3. При выборе устройства в выпадающем списке логических устройств,
    его название и список содержимого отобразятся в активной стороне;
4. При двойном клике на листе - выбранный элемент открывается;
5. Реализована функциональность непосредственного ввода адреса
    каталога в строки адресов каталогов (вверху формы),
    для отображения содержимого - нажмите НА ФОРМЕ кнопку Enter;
6. Чтобы вернуться на уровень выше - нажмите на форме кнопку Back.";
           
            return message;
        }


        public static string GetComputerName()
        {
            return $"This computer ({Environment.MachineName}):";
        }

        /// <summary>
        /// Вернуть папку на уровень выше
        /// </summary>
        public static string BackFolder(string path, string computerName)
        {
            if (path.ToString().Count(c => c == '\\') > 1) // Возвращаемся на уровень выше, если папка не корневая
            {
                if (path[path.Length - 1] == '\\')
                {
                    path = path.Remove(path.Length - 1, 1);
                }
                path = RemovePath(path);
            }
            else if (path != computerName) // Если папка корневая - в текстбокс пишем имя компьютера
            {
                path = computerName;
            }
            return path;
        }

        /// <summary>
        /// убираем по символу из переданного пути path, до следующего слеша
        /// </summary>
        /// <param name="path"></param>
        private static string RemovePath(string path)
        {
            while (path[path.Length - 1] != '\\')
            {
                path = path.Remove(path.Length - 1, 1);
            }
            return path;
        }     
    }
}
