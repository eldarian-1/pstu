using Model.Entities;
using System.Windows.Input;
using System.Windows.Controls;

namespace WpfUi.Blocks.Tables
{
    public partial class StudentTable : UserControl
    {
        public StudentTable()
        {
            InitializeComponent();
        }

        public new MainWindow Parent { get; set; }

        public Student SelectedStudent => StudentList.SelectedItem as Student;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            Student obj = SelectedStudent;
            if (obj != null)
            {
                switch (e.Key)
                {
                    case Key.E:
                        Parent.EditStudent(obj);
                        break;
                    case Key.D:
                        Parent.RemoveStudent(obj);
                        break;
                }
            }
        }
    }
}
