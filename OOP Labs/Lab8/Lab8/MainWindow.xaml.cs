using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters.Binary;

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
