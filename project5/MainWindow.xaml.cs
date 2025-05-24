using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using Microsoft.VisualBasic; // for InputBox
using project4.Models;

namespace project4
{
    public partial class MainWindow : Window
    {
        List<Student> students = new List<Student>();
        List<Teacher> teachers = new List<Teacher>();
        List<Course> courses = new List<Course>();

        public MainWindow()
        {
            InitializeComponent();

            CommandBindings.Add(new CommandBinding(ApplicationCommands.Copy, CopyStudent, CanCopyStudent));
        }

        private void CanCopyStudent(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = StudentList.SelectedItem is Student;
        }

        private void CopyStudent(object sender, ExecutedRoutedEventArgs e)
        {
            if (StudentList.SelectedItem is Student student)
            {
                Clipboard.SetData("Student", student); // Custom format
            }
        }


        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            string name = Interaction.InputBox("Enter student name:");
            if (!string.IsNullOrWhiteSpace(name))
            {
                var student = new Student { Name = name };
                students.Add(student);
                StudentList.Items.Add(student);
            }
        }

        private void RemoveStudent_Click(object sender, RoutedEventArgs e)
        {
            if (StudentList.SelectedItem is Student student)
            {
                students.Remove(student);
                StudentList.Items.Remove(student);
            }
        }

        private void AddTeacher_Click(object sender, RoutedEventArgs e)
        {
            string name = Interaction.InputBox("Enter teacher name:");
            if (!string.IsNullOrWhiteSpace(name))
            {
                var teacher = new Teacher { Name = name };
                teachers.Add(teacher);
                TeacherList.Items.Add(teacher);
            }
        }

        private void RemoveTeacher_Click(object sender, RoutedEventArgs e)
        {
            if (TeacherList.SelectedItem is Teacher teacher)
            {
                teachers.Remove(teacher);
                TeacherList.Items.Remove(teacher);
            }
        }

        private void AddCourse_Click(object sender, RoutedEventArgs e)
        {
            var courseWindow = new CourseWindow(students, teachers);
            if (courseWindow.ShowDialog() == true)
            {
                courses.Add(courseWindow.Course);
                CourseList.Items.Add(courseWindow.Course);
            }
        }

        private void EditCourse_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (CourseList.SelectedItem is Course selectedCourse)
            {
                var courseWindow = new CourseWindow(students, teachers, selectedCourse);
                if (courseWindow.ShowDialog() == true)
                {
                    CourseList.Items.Refresh();
                }
            }
        }

        private void RemoveCourse_Click(object sender, RoutedEventArgs e)
        {
            if (((FrameworkElement)sender).DataContext is Course course)
            {
                courses.Remove(course);
                CourseList.Items.Remove(course);
            }
        }
    }
}
