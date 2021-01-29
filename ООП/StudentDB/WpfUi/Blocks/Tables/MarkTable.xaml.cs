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

        public Mediator Mediator { get; set; }

        public Mark SelectedMark => MarkList.SelectedItem as Mark;

        protected override void OnKeyDown(KeyEventArgs e)
        {
            Mark obj = SelectedMark;
            if (obj != null)
            {
                switch (e.Key)
                {
                    case Key.E:
                        Mediator.EditMark(obj);
                        break;
                    case Key.D:
                        Mediator.RemoveMark(obj);
                        break;
                }
            }
        }
    }
}
