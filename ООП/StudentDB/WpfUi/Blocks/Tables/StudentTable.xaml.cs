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

        public Mediator Mediator { get; set; }

        public Student SelectedStudent => StudentList.SelectedItem as Student;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            Student obj = SelectedStudent;
            if (obj != null)
            {
                switch (e.Key)
                {
                    case Key.E:
                        Mediator.EditStudent(obj);
                        break;
                    case Key.D:
                        Mediator.RemoveStudent(obj);
                        break;
                }
            }
        }
    }
}
