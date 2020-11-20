using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Input;
using System.Windows.Controls;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab8
{
    public partial class MainWindow : Window
    {
        private enum FindType
        {
            None,
            ByName,
            ByPeriod
        }

        private const string c_sIncorrectSumm = "Некорректное значение поля суммы!";
        private const string c_sTypeDocument = "Документ CLI (*.cli)|*.cli";
        private const string c_sEmptyList = "Поиск выдал пустой список";

        private ClientList clients { get; set; }
        private int updateIndex = -1;
        private FindType m_FindState;

        public MainWindow()
        {
            InitializeComponent();
            clients = new ClientList();
            ListClient.ItemsSource = clients;
            m_FindState = FindType.None;
        }

        private void CheckFindState()
        {
            if (m_FindState == FindType.ByName)
                ClickFindName(null, null);
            else if (m_FindState == FindType.ByPeriod)
                ClickFindPeriod(null, null);
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
                ButtonToAdd();
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
                ClearFields();
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
            ButtonToAdd();
            ClientList list = ListClient.ItemsSource as ClientList;
            Client client = list[index];
            list.Remove(client);
            if (m_FindState != FindType.None)
                clients.Remove(client);
        }

        private void ButtonAddClient(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(ClientSumm.Text, out int summ) && summ > 0)
            {
                Client client = new Client
                {
                    Name = ClientName.Text,
                    Summ = summ,
                    Type = (ClientType.SelectedItem as ComboBoxItem).Content.ToString(),
                    Period = (ClientPeriod.SelectedItem as ComboBoxItem).Content.ToString()
                };
                clients.Add(client);
                CheckFindState();
                ClearFields();
            }
            else
                MessageBox.Show(c_sIncorrectSumm);
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
                CheckFindState();
                ButtonToAdd();
                ListClient.Items.Refresh();
            }
            else
                MessageBox.Show(c_sIncorrectSumm);
        }

        private void ClickSave(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = c_sTypeDocument;
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
            dialog.Filter = c_sTypeDocument;
            if (dialog.ShowDialog() == true)
            {
                using (FileStream fstream = new FileStream(dialog.FileName, FileMode.Open))
                {
                    BinaryFormatter buffer = new BinaryFormatter();
                    clients = (ClientList)buffer.Deserialize(fstream);
                    fstream.Close();
                    ListClient.ItemsSource = clients;
                    if (clients.Count == 0)
                        MessageBox.Show(c_sEmptyList);
                }
            }
        }

        private void ClickFindName(object sender, RoutedEventArgs e)
        {
            ClientList list = clients.GetListByName(BoxFindName.Text);
            ListClient.ItemsSource = list;
            if (list.Count == 0)
                MessageBox.Show(c_sEmptyList);
            m_FindState = FindType.ByName;
        }

        private void ClickFindPeriod(object sender, RoutedEventArgs e)
        {
            ClientList list = clients.GetListByPeriod(
                (BoxFindPeriod.SelectedItem as ComboBoxItem).Content.ToString());
            ListClient.ItemsSource = list;
            if (list.Count == 0)
                MessageBox.Show(c_sEmptyList);
            m_FindState = FindType.ByPeriod;
        }

        private void ClickReset(object sender, RoutedEventArgs e)
        {
            ListClient.ItemsSource = clients;
            m_FindState = FindType.None;
        }
    }
}
