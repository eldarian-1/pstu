using Model.Entities;
using System.Windows.Input;
using System.Windows.Controls;

namespace WpfUi.Blocks.Tables
{
    public partial class SubjectTable : UserControl
    {
        public SubjectTable()
        {
            InitializeComponent();
        }

        public new MainWindow Parent { get; set; }

        public Subject SelectedSubject => SubjectList.SelectedItem as Subject;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            Subject obj = SelectedSubject;
            if (obj != null)
            {
                switch (e.Key)
                {
                    case Key.E:
                        Parent.EditSubject(obj);
                        break;
                    case Key.D:
                        Parent.RemoveSubject(obj);
                        break;
                }
            }
        }
    }
}
