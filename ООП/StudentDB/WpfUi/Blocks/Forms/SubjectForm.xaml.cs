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

        public Mediator Mediator { get; set; }

        public void SetEditItem(Subject subject)
        {
            _IsEdit = true;
            _EditId = subject.SubjectId;
            SubjectName.Text = subject.SubjectName;
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
            Mediator.AddSubject(SubjectName.Text);
            Clear();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Mediator.UpdateSubject(new Subject
            {
                SubjectId = _EditId,
                SubjectName = SubjectName.Text});
            Clear();
            SetAddListener();
        }
    }
}
