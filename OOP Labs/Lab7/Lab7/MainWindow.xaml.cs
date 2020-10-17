using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab7
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Array1D> Array1Ds { get;set; }
        public ObservableCollection<ObservableCollection<Array1D>> Array2Ds { get;set; }

        public MainWindow()
        {
            InitializeComponent();
            Array1Ds = new ObservableCollection<Array1D>()
            {
                new Array1D{Text = "Хуита"},
                new Array1D{Text = "Хуита"},
                new Array1D{Text = "Хуита"}
            };
            Array2Ds = new ObservableCollection<ObservableCollection<Array1D>>()
            {
                new ObservableCollection<Array1D>()
            {
                new Array1D{Text = "Хуита"},
                new Array1D{Text = "Хуита"},
                new Array1D{Text = "Хуита"}
            },
                new ObservableCollection<Array1D>()
            {
                new Array1D{Text = "Хуита"},
                new Array1D{Text = "Хуита"},
                new Array1D{Text = "Хуита"}
            },
                new ObservableCollection<Array1D>()
            {
                new Array1D{Text = "Хуита"},
                new Array1D{Text = "Хуита"},
                new Array1D{Text = "Хуита"}
            }
            };
            DataContext = this;

            JaggedArray.Children.Add(new TextBox { Text = "Custom" });
        }

        private void ChangeArray1Size(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(Array1Size.Text, out int size))
            {
                int count = Array1Ds.Count;
                if (count > size)
                    for (int i = 0, n = count - size; i < n; ++i)
                        Array1Ds.RemoveAt(Array1Ds.Count - 1);
                else if (count < size)
                    for (int i = 0, n = size - count; i < n; ++i)
                        Array1Ds.Add(new Array1D { Text = "Хуита" });
            }
        }
    }
}
