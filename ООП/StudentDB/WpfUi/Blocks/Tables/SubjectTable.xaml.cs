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

        public Mediator Mediator { get; set; }

        public Subject SelectedSubject => SubjectList.SelectedItem as Subject;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            Subject obj = SelectedSubject;
            if (obj != null)
            {
                switch (e.Key)
                {
                    case Key.E:
                        Mediator.EditSubject(obj);
                        break;
                    case Key.D:
                        Mediator.RemoveSubject(obj);
                        break;
                }
            }
        }
    }
}
