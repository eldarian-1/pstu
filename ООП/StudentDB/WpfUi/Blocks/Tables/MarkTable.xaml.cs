using Model.Entities;
using System.Windows.Input;
using System.Windows.Controls;

namespace WpfUi.Blocks.Tables
{
    public partial class MarkTable : UserControl
    {
        public MarkTable()
        {
            InitializeComponent();
        }

        public new MainWindow Parent { get; set; }

        public Mark SelectedMark => MarkList.SelectedItem as Mark;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            Mark obj = SelectedMark;
            if (obj != null)
            {
                switch (e.Key)
                {
                    case Key.E:
                        Parent.EditMark(obj);
                        break;
                    case Key.D:
                        Parent.RemoveMark(obj);
                        break;
                }
            }
        }
    }
}
