using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfProgrammers
{
    public partial class MainWindow : Window
    {
        public class Programmer
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public string Gender { get; set; }
            public string Nationality { get; set; }
            public DateTime BirthDate { get; set; }
            public string Education { get; set; }
            public string PhoneNumber { get; set; }

            public override string ToString()
            {
                return $"{LastName} {FirstName} {MiddleName}, {BirthDate.ToShortDateString()}";
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            LoadProgrammers();
        }

        private void LoadProgrammers()
        {
            List<Programmer> programmers = new List<Programmer>()
            {
                new Programmer { LastName = "Иванов", FirstName = "Иван", MiddleName = "Иванович", Gender = "Мужской", Nationality = "Русский", BirthDate = new DateTime(2000, 05, 10), Education = "Высшее", PhoneNumber = "123-456-7890" },
                new Programmer { LastName = "Петров", FirstName = "Петр", MiddleName = "Петрович", Gender = "Мужской", Nationality = "Русский", BirthDate = new DateTime(1990, 10, 15), Education = "Среднее", PhoneNumber = "987-654-3210" },
                new Programmer { LastName = "Сидоров", FirstName = "Сидор", MiddleName = "Сидорович", Gender = "Мужской", Nationality = "Русский", BirthDate = new DateTime(2002, 01, 20), Education = "Незаконченное высшее", PhoneNumber = "555-123-4567" }
            };

            var youngProgrammers = programmers.Where(p => DateTime.Now.Year - p.BirthDate.Year < 25).ToList();

            ProgrammersListBox.ItemsSource = youngProgrammers;
        }
    }
}