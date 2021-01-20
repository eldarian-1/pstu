using Controller;
using Model.Entities;
using System.Collections;
using System.Windows;

namespace WpfUi
{
    public partial class MainWindow : Window
    {
        private Facade _Facade;

        public MainWindow()
        {
            InitializeComponent();
            _Facade = new Facade();
            SubjectFormItem.Parent = this;
            UpdateData();
        }

        public void UpdateData()
        {
            SubjectTableItem.SubjectList.ItemsSource = _Facade.Subjects.SelectAll(new Subject());
            StudentTableItem.StudentList.ItemsSource = _Facade.Students.SelectAll(new Student());
            MarkTableItem.MarkList.ItemsSource = _Facade.Marks.SelectAll(new MarkEntry());
        }

        public void AddSubject(string name)
        {
            _Facade.Subjects.Insert(new Subject { Name = name });
        }
    }
}
