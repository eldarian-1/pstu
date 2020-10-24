using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Input;

namespace Lab8
{
    public partial class MainWindow : Window
    {
        private ClientList clients { get; set; }
        private int updateIndex = -1;

        public MainWindow()
        {
            InitializeComponent();
            clients = new ClientList();
            ListClient.ItemsSource = clients;
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            int index = ListClient.SelectedIndex;
            if (index != -1)
            {
                switch (e.Key)
                {
                    case Key.W:
                        MoveClient(index, index - 1);
                        break;
                    case Key.S:
                        MoveClient(index, index + 1);
                        break;
                    case Key.E:
                        UpdateClient(index);
                        break;
                    case Key.D:
                    case Key.Delete:
                        DeleteClient(index);
                        break;
                }
            }
        }

        private void MoveClient(int oldIndex, int newIndex)
        {
            if (newIndex >= 0 && newIndex < clients.Count)
            {
                clients.Move(oldIndex, newIndex);
                ListClient.SelectedIndex = newIndex;
            }
        }

        private void ClearFields()
        {
            ClientName.Text = "";
            ClientSumm.Text = "";
            ClientType.Text = "Микрозайм";
            ClientPeriod.Text = "3 м";
        }

        private void ButtonToUpdate(int index)
        {
            if (updateIndex == -1)
            {
                ButtonClient.Click -= ButtonAddClient;
                ButtonClient.Click += ButtonUpdateClient;
                ButtonClient.Content = "Обновить";
            }
            updateIndex = index;
        }

        private void ButtonToAdd()
        {
            if (updateIndex != -1)
            {
                updateIndex = -1;
                ButtonClient.Click -= ButtonUpdateClient;
                ButtonClient.Click += ButtonAddClient;
                ButtonClient.Content = "Добавить";
            }
        }

        private void UpdateClient(int index)
        {
            ButtonToUpdate(index);
            Client client = clients[updateIndex];
            ClientName.Text = client.Name;
            ClientSumm.Text = client.Summ.ToString();
            ClientType.Text = client.Type;
            ClientPeriod.Text = client.Period;
        }

        private void DeleteClient(int index)
        {
            clients.RemoveAt(index);
            ListClient.ItemsSource = clients;
            ButtonToAdd();
            ClearFields();
        }

        private void ButtonAddClient(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ClientSumm.Text, out int summ) && summ > 0)
            {
                clients.Add(new Client
                {
                    Name = ClientName.Text,
                    Summ = summ,
                    Type = (ClientType.SelectedItem as ComboBoxItem).Content.ToString(),
                    Period = (ClientPeriod.SelectedItem as ComboBoxItem).Content.ToString()
                });
                ClearFields();
            }
            else
                MessageBox.Show("Некорректное значение поля суммы!");
        }

        private void ButtonUpdateClient(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ClientSumm.Text, out int summ) && summ > 0)
            {
                Client client = clients[updateIndex];
                client.Name = ClientName.Text;
                client.Summ = summ;
                client.Type = (ClientType.SelectedItem as ComboBoxItem).Content.ToString();
                client.Period = (ClientPeriod.SelectedItem as ComboBoxItem).Content.ToString();

                ButtonToAdd();
                ClearFields();
                ListClient.Items.Refresh();
            }
            else
                MessageBox.Show("Некорректное значение поля суммы!");
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
                    ListClient.ItemsSource = clients;
                }
            }
        }

        private void ClickFindName(object sender, RoutedEventArgs e)
            => ListClient.ItemsSource = clients.GetListByName(BoxFindName.Text);

        private void ClickFindPeriod(object sender, RoutedEventArgs e)
            => ListClient.ItemsSource = clients.GetListByPeriod(
                (BoxFindPeriod.SelectedItem as ComboBoxItem).Content.ToString());

        private void ClickReset(object sender, RoutedEventArgs e)
            => ListClient.ItemsSource = clients;
    }
}
