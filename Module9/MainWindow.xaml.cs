using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Mod_9_Homework
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly List<Student> _students;
        private int _currentIndex;

        private const int StartIndex = -1; //use an out of bounds index to reset and adjust for first item added

        public MainWindow()
        {
            InitializeComponent();

            _students = new List<Student>();
            _currentIndex = StartIndex;

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
            // adjust index to "wrap around" the _students list
            if (_currentIndex >= _students.Count)
            {
                _currentIndex = 0;
            }
            else if (_currentIndex < 0)
            {
                _currentIndex = _students.Count - 1;
            }

            DisplayStudent(_students.ElementAt(_currentIndex));
        }

        void DisplayStudent(Student student)
        {
            this.txtFirstName.Text = student.FistName;
            this.txtLastName.Text = student.LastName;
            this.txtCity.Text = student.City;
        }

        Student CreateStudent()
        {
            _currentIndex = StartIndex; 
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
