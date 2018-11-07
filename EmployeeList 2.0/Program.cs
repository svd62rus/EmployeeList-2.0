﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EmployeeList_2._0
{
    static class Program
    {
        public enum Действия {Добавить, Изменить, Удалить};
        public enum ФИО {Фамилия, Имя, Отчество};

        public enum Сортировка { Алфавит, Алфавитобратная, Позарплате, Позарплатеобратная };
        public const ushort digitInSalary = 7;
        public const ushort numOfLetter = 100;

        public const string mainLog = "mainlog.log";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
}
