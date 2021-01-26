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

        public void Clear()
        {
            _IsEdit = false;
            SubjectName.Text = "";
        }

        public void SetAddListener()
        {
            ActionButton.Click -= EditButton_Click;
            ActionButton.Click += AddButton_Click;
            ActionButton.Content = "Добавить";
        }

        public void SetEditListener()
        {
            ActionButton.Click -= AddButton_Click;
            ActionButton.Click += EditButton_Click;
            ActionButton.Content = "Обновить";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Parent.AddSubject(SubjectName.Text);
            Clear();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Parent.UpdateSubject(new Subject
            {
                SubjectId = _EditId,
                Name = SubjectName.Text});
            Clear();
            SetAddListener();
        }
    }
}
