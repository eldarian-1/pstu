using System.Windows;
using Microsoft.Win32;
using System.Windows.Media;
using System.Windows.Controls;

namespace Lab7
{
    public partial class MainWindow : Window
    {
        private Array1D m_Array1D;
        private Array2D m_Array2D;
        private Array2J m_Array2J;
        private GetNumber GetNum;

        public MainWindow()
        {
            InitializeComponent();
            m_Array1D = new Array1D();
            m_Array2D = new Array2D();
            m_Array2J = new Array2J();
            GetNum = Kernel.GetNull;
            SetArray1D();
            SetArray2D();
            SetArray2J();
        }

        private void ComboBoxNullSelected(object sender, RoutedEventArgs e)
            => GetNum = Kernel.GetNull;

        private void ComboBoxRandSelected(object sender, RoutedEventArgs e)
            => GetNum = Kernel.GetRand;

        private void ResizeArray1D(object sender, RoutedEventArgs e)
        {
            try
            {
                FixArray1D();
                if (int.TryParse(Array1DSize.Text, out int size))
                    m_Array1D.Resize(size, GetNum);
                else
                    throw new IncorrectNewSize();
                SetArray1D();
            }
            catch (IncorrectNewSize)
            {
                MessageBox.Show($"Некорректное значение поля ввода размера!");
            }
            catch (AlreadySet)
            {
                MessageBox.Show($"Заданная размерность уже установлена.");
            }
        }

        private void ResizeArray2D(object sender, RoutedEventArgs e)
        {
            try
            {
                FixArray2D();
                if (int.TryParse(Array2SizeN.Text, out int n) &&
                    int.TryParse(Array2SizeM.Text, out int m))
                    m_Array2D.Resize(n, m, GetNum);
                else
                    throw new IncorrectNewSize();
                SetArray2D();
            }
            catch (IncorrectNewSize)
            {
                MessageBox.Show($"Некорректные значения полей ввода размера!");
            }
            catch (AlreadySet)
            {
                MessageBox.Show($"Заданная размерность уже установлена.");
            }
        }

        private void ResizeArray2J(object sender, RoutedEventArgs e)
        {
            try
            {
                FixArray2J();
                if (int.TryParse(Array2JSize.Text, out int n))
                    m_Array2J.Resize(n);
                else
                    throw new IncorrectNewSize();
                SetArray2J();
            }
            catch (IncorrectNewSize)
            {
                MessageBox.Show($"Некорректное значение поля ввода размера!");
            }
            catch (AlreadySet)
            {
                MessageBox.Show($"Заданная размерность уже установлена.");
            }
        }

        private void ResizeArray2JByIndex(object sender, RoutedEventArgs e)
        {
            try
            {
                FixArray2J();
                string sIndex = (sender as Button).Name.Remove(0, 1);
                int.TryParse(sIndex, out int n);
                TextBox tempTextBox = FindChild<TextBox>(Application.Current.MainWindow, "t" + n);
                if (int.TryParse(tempTextBox.Text, out int m))
                    m_Array2J.ResizeByIndex(n, m, GetNum);
                else
                    throw new IncorrectField { I = n };
                SetArray2J();
            }
            catch (IncorrectField ex)
            {
                MessageBox.Show($"Некорректное значение поля [{ex.I}]!");
            }
            catch (AlreadySet)
            {
                MessageBox.Show($"Заданная размерность уже установлена.");
            }
        }

        private void ChangeArray1DField(object sender, RoutedEventArgs e)
            => FixArray1D();

        private void ChangeArray2DField(object sender, RoutedEventArgs e)
            => FixArray2D();

        private void ChangeArray2JField(object sender, RoutedEventArgs e)
            => FixArray2J();

        private void FixArray1D()
        {
            try
            {
                for (int i = 0, n = m_Array1D.Length; i < n; ++i)
                {
                    TextBox tempTextBox = FindChild<TextBox>(Application.Current.MainWindow, "A1D" + i);
                    if (int.TryParse(tempTextBox.Text, out int num))
                        m_Array1D[i] = num;
                    else
                        throw new IncorrectField { I = i };
                }
            }
            catch (IncorrectField ex)
            {
                MessageBox.Show($"Некорректное значение поля [{ex.I}]!");
            }
        }

        private void FixArray2D()
        {
            try
            {
                int n = m_Array2D.N;
                if (n == 0)
                    return;
                int m = m_Array2D.M;
                for (int i = 0; i < n; ++i)
                    for (int j = 0; j < m; ++j)
                    {
                        TextBox tempTextBox = FindChild<TextBox>(Application.Current.MainWindow, "A2D" + i + "_" + j);
                        if (int.TryParse(tempTextBox.Text, out int num))
                            m_Array2D[i, j] = num;
                        else
                            throw new IncorrectFields { N = i, M = j };
                    }
            }
            catch (IncorrectFields ex)
            {
                MessageBox.Show($"Некорректное значение поля [{ex.N}, {ex.M}]!");
            }
        }

        private void FixArray2J()
        {
            try
            {
                for (int i = 0, n = m_Array2J.Length; i < n; ++i)
                    for (int j = 0, m = m_Array2J[i].Length; j < m; ++j)
                    {
                        TextBox tempTextBox = FindChild<TextBox>(Application.Current.MainWindow, "AJG" + i + "_" + j);
                        if (int.TryParse(tempTextBox.Text, out int num))
                            m_Array2J[i][j] = num;
                        else
                            throw new IncorrectFields { N = i, M = j };
                    }
            }
            catch (IncorrectFields ex)
            {
                MessageBox.Show($"Некорректное значение поля [{ex.N}][{ex.M}]!");
            }
        }

        private void AddLineArray1D(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.TryParse(Array1DN.Text, out int n) && int.TryParse(Array1DK.Text, out int k))
                    m_Array1D.AddLine(n, k, GetNum);
                else
                    throw new IncorrectValue();
                SetArray1D();
            }
            catch (IncorrectValue)
            {
                MessageBox.Show($"Некорректное значение поля!");
            }
        }

        private void DropEvenArray2D(object sender, RoutedEventArgs e)
        {
            try
            {
                m_Array2D.DropEven();
                SetArray2D();
            }
            catch (EmptyArray)
            {
                MessageBox.Show($"Массив уже пуст.");
            }
        }

        private void AddLineArray2J(object sender, RoutedEventArgs e)
        {
            m_Array2J.AddLine();
            SetArray2J();
        }

        private void SaveToFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Документ ARR (*.arr)|*.arr";
            if (dialog.ShowDialog() == true)
                Kernel.SaveToFile(dialog.FileName, m_Array1D, m_Array2D, m_Array2J);
        }

        private void LoadFromFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Документ ARR (*.arr)|*.arr";
            if (dialog.ShowDialog() == true)
            {
                Kernel.LoadFromFile(dialog.FileName, out m_Array1D, out m_Array2D, out m_Array2J);
                SetArray1D();
                SetArray2D();
                SetArray2J();
            }
        }

        private void SetArray1D()
        {
            ListBoxArray1D.Items.Clear();
            for (int i = 0, n = m_Array1D.Length; i < n; ++i)
            {
                TextBox textBox = new TextBox { Name = "A1D" + i, Text = m_Array1D[i].ToString() };
                textBox.TextChanged += ChangeArray1DField;
                ListBoxArray1D.Items.Add(new ListBoxItem { Content = textBox });
            }
            Array1DSize.Text = m_Array1D.Length.ToString();
        }

        private void SetArray2D()
        {
            TreeViewArray2D.Items.Clear();
            int n = m_Array2D.N;
            int m = m_Array2D.M;
            for (int i = 0; i < n; ++i)
            {
                WrapPanel tempWrapPanel = new WrapPanel();
                TreeViewItem tempItem = new TreeViewItem { Header = "Строка " + i };
                TreeViewArray2D.Items.Add(tempItem);
                TreeViewArray2D.Items.Add(tempWrapPanel);
                for (int j = 0; j < m; ++j)
                {
                    string tempText = m_Array2D[i, j].ToString();
                    TextBox tempTextBox = new TextBox { Name = "A2D" + i + "_" + j, Text = tempText };
                    tempTextBox.TextChanged += ChangeArray2DField;
                    tempWrapPanel.Children.Add(tempTextBox);
                }
            }
            Array2SizeN.Text = n.ToString();
            Array2SizeM.Text = m.ToString();
        }

        private void SetArray2J()
        {
            TreeViewArray2J.Items.Clear();
            int n = m_Array2J.Length;
            for (int i = 0; i < n; ++i)
            {
                int m = m_Array2J[i].Length;
                WrapPanel tempWrapPanel = new WrapPanel();
                Label tempLabel = new Label { Content = $"Строка {i} M:" };
                TextBox tempTextBox = new TextBox { Name = "t" + i, Text = m.ToString() };
                Button tempButton = new Button { Name = "b" + i, Content = "Изменить" };
                StackPanel tempStackPanel = new StackPanel { Orientation = Orientation.Horizontal };
                TreeViewItem tempItem = new TreeViewItem { Name = "i" + i, Header = tempStackPanel };
                tempButton.Click += ResizeArray2JByIndex;
                tempStackPanel.Children.Add(tempLabel);
                tempStackPanel.Children.Add(tempTextBox);
                tempStackPanel.Children.Add(tempButton);
                TreeViewArray2J.Items.Add(tempItem);
                TreeViewArray2J.Items.Add(tempWrapPanel);
                for (int j = 0; j < m; ++j)
                {
                    string tempText = m_Array2J[i][j].ToString();
                    TextBox tempEdit = new TextBox { Name = "AJG" + i + "_" + j, Text = tempText };
                    tempEdit.TextChanged += ResizeArray2JByIndex;
                    tempWrapPanel.Children.Add(tempEdit);
                }
            }
            Array2JSize.Text = n.ToString();
        }

        private static T FindChild<T>(DependencyObject parent, string childName)
            where T : DependencyObject
        {
            if (parent == null) return null;
            T foundChild = null;
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                T childType = child as T;
                if (childType == null)
                {
                    foundChild = FindChild<T>(child, childName);
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    foundChild = (T)child;
                    break;
                }
            }
            return foundChild;
        }
    }
}
