using Model.Entities;
using System.Windows;
using System.Windows.Controls;

namespace WpfUi.Blocks.Forms
{
    public partial class SubjectForm : UserControl
    {
        private bool _IsEdit;
        private long _EditId;

        public SubjectForm()
        {
            InitializeComponent();
        }

        public new MainWindow Parent { get; set; }

        public void SetEditItem(Subject subject)
        {
            _IsEdit = true;
            _EditId = subject.SubjectId;
            SubjectName.Text = subject.Name;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Parent.AddSubject(SubjectName.Text);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Parent.UpdateSubject(new Subject
            {
                SubjectId = _EditId,
                Name = SubjectName.Text
            });
        }
    }
}
