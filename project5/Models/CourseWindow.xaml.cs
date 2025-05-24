using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using project4.Models;

namespace project4
{
    public partial class CourseWindow : Window
    {
        public Course Course { get; private set; }
        private List<Student> availableStudents;

        public CourseWindow(List<Student> allStudents, List<Teacher> teachers, Course editingCourse = null)
        {
            InitializeComponent();
            CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, PasteStudent, CanPasteStudent));
            TeacherComboBox.ItemsSource = teachers;

            if (editingCourse != null)
            {
                Course = editingCourse;
                CourseNameTextBox.Text = Course.Name;
                TeacherComboBox.SelectedItem = Course.AssignedTeacher;
                SaveButton.Content = "Save";

                availableStudents = allStudents.Except(Course.Students).ToList();
                SelectedStudentsListBox.ItemsSource = Course.Students.ToList();
            }
            else
            {
                Course = new Course();
                availableStudents = new List<Student>(allStudents);
                SelectedStudentsListBox.ItemsSource = new List<Student>();
            }

            AvailableStudentsListBox.ItemsSource = availableStudents;
        }

        private void AvailableStudentsListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MoveToSelected_Click(sender, e);
        }

        private void SelectedStudentsListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            MoveToAvailable_Click(sender, e);
        }

        private void MoveToSelected_Click(object sender, RoutedEventArgs e)
        {
            if (AvailableStudentsListBox.SelectedItem is Student student)
            {
                availableStudents.Remove(student);
                Course.Students.Add(student);
                RefreshLists();
            }
        }

        private void MoveToAvailable_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedStudentsListBox.SelectedItem is Student student)
            {
                Course.Students.Remove(student);
                availableStudents.Add(student);
                RefreshLists();
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Course.Name = CourseNameTextBox.Text;
            Course.AssignedTeacher = TeacherComboBox.SelectedItem as Teacher;
            DialogResult = true;
        }

        private void RefreshLists()
        {
            AvailableStudentsListBox.Items.Refresh();
            SelectedStudentsListBox.Items.Refresh();
        }

        private void CanPasteStudent(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = Clipboard.ContainsData("Student");
        }

        private void PasteStudent(object sender, ExecutedRoutedEventArgs e)
        {
            if (Clipboard.GetData("Student") is Student student)
            {
                if (availableStudents.Contains(student))
                {
                    availableStudents.Remove(student);
                    Course.Students.Add(student);
                    RefreshLists();
                }
            }
        }

    }

}
