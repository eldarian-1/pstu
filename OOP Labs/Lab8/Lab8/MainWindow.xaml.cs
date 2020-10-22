using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab8
{
    

    public partial class MainWindow : Window
    {
        public ClientList clients { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            clients = new ClientList();
            clientsList.ItemsSource = clients;
        }

        private void ButtonAddClient(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ClientSumm.Text, out int summ))
                clients.Add(new Client
                {
                    Name = ClientName.Text,
                    Summ = summ,
                    Type = (ClientType.SelectedItem as ComboBoxItem).Content.ToString(),
                    Period = (ClientPeriod.SelectedItem as ComboBoxItem).Content.ToString()
                });
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
                    clients = (ClientList)buffer.Deserialize(fstream);
                    fstream.Close();
                    clientsList.ItemsSource = clients;
                }
            }
        }

        private void ClickFindName(object sender, RoutedEventArgs e)
        {
            clientsList.ItemsSource = clients.GetListByName(BoxFindName.Text);
        }

        private void ClickFindPeriod(object sender, RoutedEventArgs e)
        {
            clientsList.ItemsSource = clients.GetListByPeriod((BoxFindPeriod.SelectedItem as ComboBoxItem).Content.ToString());
        }

        private void ClickReset(object sender, RoutedEventArgs e)
        {
            clientsList.ItemsSource = clients;
        }
    }
}
