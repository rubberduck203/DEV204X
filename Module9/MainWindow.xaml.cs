using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mod_9_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Student> _students;
        private int _currentIndex;

        private const int startIndex = -1; //use an out of bounds index to reset and adjust for first item added

        public MainWindow()
        {
            InitializeComponent();

            _students = new List<Student>();
            _currentIndex = startIndex;

            this.btnCreateStudent.Click += btnCreateStudent_Click;
            this.btnNext.Click += btnNext_Click;
            this.btnPrevious.Click += btnPrevious_Click;
        }

        void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            _currentIndex -= 1;
            DisplayCurrentStudent();
        }

        void btnNext_Click(object sender, RoutedEventArgs e)
        {
            _currentIndex += 1;
            DisplayCurrentStudent();
        }

        void btnCreateStudent_Click(object sender, RoutedEventArgs e)
        {
            _students.Add(CreateStudent());
            ClearText();
        }

        void DisplayCurrentStudent()
        {
            if (_currentIndex > startIndex && _currentIndex < _students.Count)
            {
                DisplayStudent(_students.ElementAt(_currentIndex));
            }
        }

        void DisplayStudent(Student student)
        {
            this.txtFirstName.Text = student.FistName;
            this.txtLastName.Text = student.LastName;
            this.txtCity.Text = student.City;
        }

        Student CreateStudent()
        {
            _currentIndex = startIndex; 
            return new Student(this.txtFirstName.Text, this.txtLastName.Text, this.txtCity.Text);
        }

        void ClearText()
        {
            this.txtFirstName.Clear();
            this.txtLastName.Clear();
            this.txtCity.Clear();
        }
    }
}
