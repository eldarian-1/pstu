using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

namespace Lab8
{
    [Serializable]
    public class Client
    {
        public string Name { get; set; }
        public int Summ { get; set; }
        public string Type { get; set; }
        public int Period { get; set; }

        public override string ToString()
        {
            return "" + Name + " " + Summ + " " + Type + " " + Period;
        }
    }

    public partial class MainWindow : Window
    {
        public ObservableCollection<Client> clients { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            clients = new ObservableCollection<Client>
            {
                new Client{ Name="Mike", Summ = 15000, Type = "Year", Period = 5 }
            };
            clientsList.ItemsSource = clients;
        }

        private void ButtonAddClient(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(ClientSumm.Text, out int summ) &&
                int.TryParse(ClientPeriod.Text, out int period))
                clients.Add(new Client { Name = ClientName.Text, Summ = summ, Type = ClientType.Text, Period = period });
        }

        private void ClickSave(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Документ CLI (*.cli)|*.cli";
            if (dialog.ShowDialog() == true)
            {
                using (FileStream fstream = new FileStream(dialog.FileName, FileMode.OpenOrCreate))
                {
                    BinaryFormatter buffer = new BinaryFormatter();
                    buffer.Serialize(fstream, clients);
                    fstream.Close();
                }
            }
        }

        private void ClickLoad(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Документ CLI (*.cli)|*.cli";
            if (dialog.ShowDialog() == true)
            {
                using (FileStream fstream = new FileStream(dialog.FileName, FileMode.Open))
                {
                    BinaryFormatter buffer = new BinaryFormatter();
                    clients = (ObservableCollection<Client>)buffer.Deserialize(fstream);
                    fstream.Close();
                    clientsList.ItemsSource = clients;
                }
            }
        }
    }
}
