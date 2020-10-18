using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Media;
using System.Windows.Controls;

namespace Lab7
{
    public partial class MainWindow : Window
    {
        private int[] Array1D;
        private int[,] Array2D;
        private int[][] ArrayJagged;

        public MainWindow()
        {
            InitializeComponent();
            Array1D = Kernel.Array1D;
            Array2D = Kernel.Array2D;
            ArrayJagged = Kernel.ArrayJagged;
            SetArray1D();
            SetArray2D();
            SetArrayJagged();
        }

        private void ChangeArray1DSize(object sender, RoutedEventArgs e)
        {
            FixArray1D();
            if (int.TryParse(Array1DSize.Text, out int size))
            {
                Array1D = new int[size];
                for (int i = 0; i < size; i++)
                    Array1D[i] = i;
                SetArray1D();
            }
            else
                MessageBox.Show($"Некорректное значение поля!");
        }

        private void ChangeArray2DSize(object sender, RoutedEventArgs e)
        {
            FixArray2D();
            if (int.TryParse(Array2SizeN.Text, out int n) &&
                int.TryParse(Array2SizeM.Text, out int m))
            {
                Array2D = new int[n, m];
                for (int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                        Array2D[i, j] = i * m + j;
                SetArray2D();
            }
            else
                MessageBox.Show($"Некорректное значение поля!");
        }

        private void ChangeArrayJaggedSize(object sender, RoutedEventArgs e)
        {
            FixArrayJagged();
            string tempString = ((Button)sender).Name.ToString().Remove(0, 1);
            if (int.TryParse(tempString, out int index))
            {

                TextBox tempTextBox = FindChild<TextBox>(Application.Current.MainWindow, "t" + index);
                if (int.TryParse(tempTextBox.Text, out int m))
                    ChangeArrayJaggedByIndex(index, m);
            }
            else if (int.TryParse(ArrayJaggedSize.Text, out int size))
                ChangeArrayJaggedToSize(size);
            else
            {
                MessageBox.Show($"Некорректное значение поля!");
                return;
            }
            SetArrayJagged();
        }

        private void ChangeArray1DField(object sender, RoutedEventArgs e)
        {
            FixArray1D();
        }

        private void ChangeArray2DField(object sender, RoutedEventArgs e)
        {
            FixArray2D();
        }

        private void ChangeArrayJaggedField(object sender, RoutedEventArgs e)
        {
            FixArrayJagged();
        }

        private void ChangeArrayJaggedByIndex(int index, int m)
        {
            int len = ArrayJagged[index].Length;
            int[] tempArray = ArrayJagged[index];
            ArrayJagged[index] = new int[m];
            if (len > m)
                for (int i = 0; i < m; ++i)
                    ArrayJagged[index][i] = tempArray[i];
            else
                for (int i = 0; i < len; ++i)
                    ArrayJagged[index][i] = tempArray[i];
        }

        private void ChangeArrayJaggedToSize(int m)
        {
            int len = ArrayJagged.Length;
            int[][] tempArray = ArrayJagged;
            ArrayJagged = new int[m][];
            if (len > m)
                for (int i = 0; i < m; ++i)
                    ArrayJagged[i] = tempArray[i];
            else
            {
                for (int i = 0; i < len; ++i)
                    ArrayJagged[i] = tempArray[i];
                for (int i = len; i < m; ++i)
                    ArrayJagged[i] = new int[1];
            }
        }

        private void FixArray1D()
        {
            for (int i = 0, n = Array1D.Length; i < n; ++i)
            {
                TextBox tempTextBox = FindChild<TextBox>(Application.Current.MainWindow, "A1D" + i);
                if (int.TryParse(tempTextBox.Text, out int num))
                    Array1D[i] = num;
                else
                {
                    MessageBox.Show($"Некорректное поле под индексом [{i}]!");
                    break;
                }
            }
        }

        private void FixArray2D()
        {
            int n = Array2D.GetUpperBound(0) + 1;
            int m = Array2D.Length / n;
            for (int i = 0; i < n; ++i)
                for (int j = 0; j < m; ++j)
                {
                    TextBox tempTextBox = FindChild<TextBox>(Application.Current.MainWindow, "A2D" + i + "_" + j);
                    if (int.TryParse(tempTextBox.Text, out int num))
                        Array2D[i, j] = num;
                    else
                    {
                        MessageBox.Show($"Некорректное поле под индексом [{i},{j}]!");
                        break;
                    }
                }
        }

        private void FixArrayJagged()
        {
            for (int i = 0, n = ArrayJagged.Length; i < n; ++i)
                for (int j = 0, m = ArrayJagged[i].Length; j < m; ++j)
                {
                    TextBox tempTextBox = FindChild<TextBox>(Application.Current.MainWindow, "AJG" + i + "_" + j);
                    if (int.TryParse(tempTextBox.Text, out int num))
                        ArrayJagged[i][j] = num;
                    else
                    {
                        MessageBox.Show($"Некорректное поле под индексом [{i}][{j}]!");
                        break;
                    }
                }
        }

        private void AddLineArray1D(object sender, RoutedEventArgs e)
        {
            FixArray1D();
            if (int.TryParse(Array1DN.Text, out int n) && int.TryParse(Array1DK.Text, out int k))
                Kernel.Addition(ref Array1D, n, k);
            else
            {
                MessageBox.Show($"Некорректное значение поля!");
                return;
            }
            SetArray1D();
        }

        private void DropEvenArray2D(object sender, RoutedEventArgs e)
        {
            FixArray2D();
            Kernel.DropEven(ref Array2D);
            SetArray2D();
        }

        private void AddLineArrayJagged(object sender, RoutedEventArgs e)
        {
            FixArrayJagged();
            Kernel.AdditionLine(ref ArrayJagged);
            SetArrayJagged();
        }

        private void SaveToFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Текстовый документ (*.txt)|*.txt";
            if (dialog.ShowDialog() == true)
            {
                using (FileStream fstream = new FileStream(dialog.FileName, FileMode.OpenOrCreate))
                {
                    int Sum = 16,
                        n1d = Array1D.Length,
                        n2d = Array2D.GetUpperBound(0) + 1,
                        m2d = Array2D.Length / n2d,
                        n2j = ArrayJagged.Length;
                    int[] m2j = new int[n2j];
                    for (int i = 0; i < n2j; ++i)
                    {
                        m2j[i] = ArrayJagged[i].Length;
                        Sum += m2j[i] * 4;
                    }
                    Sum += (n1d + n2d + m2d + n2j) * 4;

                    byte[] A = new byte[Sum];
                    SetByteArray(A, 0, n1d);
                    SetByteArray(A, 4, n2d);
                    SetByteArray(A, 8, m2d);
                    SetByteArray(A, 12, n2j);
                    for(int i = 0; i < n2j; ++i)
                        SetByteArray(A, (4 + i) * 4, m2j[i]);
                    for (int i = 0; i < n1d; ++i)
                        SetByteArray(A, (4 + n2j + i) * 4, Array1D[i]);
                    for (int i = 0; i < n2d; ++i)
                        for (int j = 0; j < m2d; ++j)
                            SetByteArray(A, (4 + n2j + n1d + i + j) * 4, Array2D[i, j]);
                    for (int i = 0; i < n2j; ++i)
                        for (int j = 0; j < m2j[i]; ++j)
                            SetByteArray(A, (4 + n2j + n1d + n2d + m2d + i + j) * 4, ArrayJagged[i][j]);

                    fstream.Write(A, 0, Sum);
                    fstream.Close();
                }
            }
        }

        private void SetByteArray(byte[] array, int pos, int num)
        {
            byte[] numA = BitConverter.GetBytes(num);
            for (int i = 0; i < 4; ++i)
                array[pos + i] = numA[i];
        }

        private void LoadFromFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Текстовые документы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                using (FileStream fstream = new FileStream(dialog.FileName, FileMode.OpenOrCreate))
                {
                    byte[] A = new byte[fstream.Length];
                    fstream.Read(A, 0, A.Length);
                    SetIntFromByteArray(A, 0, out int n1d);
                    SetIntFromByteArray(A, 4, out int n2d);
                    SetIntFromByteArray(A, 8, out int m2d);
                    SetIntFromByteArray(A, 12, out int n2j);
                    int[] m2j = new int[n2j];
                    for(int i = 0; i < n2j; ++i)
                        SetIntFromByteArray(A, (4 + i) * 4, out m2j[i]);
                    Array1D = new int[n1d];
                    Array2D = new int[n2d, m2d];
                    ArrayJagged = new int[n2j][];
                    for (int i = 0; i < n1d; ++i)
                        SetIntFromByteArray(A, (4 + n2j + i) * 4, out Array1D[i]);
                    for (int i = 0; i < n2d; ++i)
                        for (int j = 0; j < m2d; ++j)
                            SetIntFromByteArray(A, (4 + n2j + n1d + i + j) * 4, out Array2D[i, j]);
                    for (int i = 0; i < n2j; ++i)
                    {
                        ArrayJagged[i] = new int[m2j[i]];
                        for (int j = 0; j < m2j[i]; ++j)
                            SetIntFromByteArray(A, (4 + n2j + n1d + n2d + m2d + i + j) * 4, out ArrayJagged[i][j]);
                    }
                    fstream.Close();
                    SetArray1D();
                    SetArray2D();
                    SetArrayJagged();
                }
            }
        }

        private void SetIntFromByteArray(byte[] array, int pos, out int num)
        {
            num = BitConverter.ToInt32(array, pos);
        }

        private void SetArray1D()
        {
            ListBoxArray1D.Items.Clear();
            for (int i = 0, n = Array1D.Length; i < n; ++i)
            {
                TextBox textBox = new TextBox { Name = "A1D" + i, Text = Array1D[i].ToString() };
                textBox.TextChanged += ChangeArray1DField;
                ListBoxArray1D.Items.Add(new ListBoxItem { Content = textBox });
            }
        }

        private void SetArray2D()
        {
            TreeViewArray2D.Items.Clear();
            int n = Array2D.GetUpperBound(0) + 1;
            int m = Array2D.Length / n;
            for (int i = 0; i < n; ++i)
            {
                WrapPanel tempWrapPanel = new WrapPanel();
                TreeViewItem tempItem = new TreeViewItem { Header = "Строка " + i};
                TreeViewArray2D.Items.Add(tempItem);
                TreeViewArray2D.Items.Add(tempWrapPanel);
                for (int j = 0; j < m; ++j)
                {
                    string tempText = Array2D[i, j].ToString();
                    TextBox tempTextBox = new TextBox { Name = "A2D" + i + "_" + j, Text = tempText };
                    tempTextBox.TextChanged += ChangeArray2DField;
                    tempWrapPanel.Children.Add(tempTextBox);
                }
            }
        }

        private void SetArrayJagged()
        {
            TreeViewArrayJagged.Items.Clear();
            int n = ArrayJagged.Length;
            for (int i = 0; i < n; ++i)
            {
                int m = ArrayJagged[i].Length;
                WrapPanel tempWrapPanel = new WrapPanel();
                Label tempLabel = new Label { Content = $"Строка {i} M:" };
                TextBox tempTextBox = new TextBox { Name = "t" + i, Text = m.ToString() };
                Button tempButton = new Button { Name = "b" + i, Content = "Изменить" };
                StackPanel tempStackPanel = new StackPanel { Orientation = Orientation.Horizontal };
                TreeViewItem tempItem = new TreeViewItem { Name = "i" + i, Header = tempStackPanel };
                tempButton.Click += ChangeArrayJaggedSize;
                tempStackPanel.Children.Add(tempLabel);
                tempStackPanel.Children.Add(tempTextBox);
                tempStackPanel.Children.Add(tempButton);
                TreeViewArrayJagged.Items.Add(tempItem);
                TreeViewArrayJagged.Items.Add(tempWrapPanel);
                for (int j = 0; j < m; ++j)
                {
                    string tempText = ArrayJagged[i][j].ToString();
                    TextBox tempEdit = new TextBox { Name = "AJG" + i + "_" + j, Text = tempText };
                    tempEdit.TextChanged += ChangeArrayJaggedField;
                    tempWrapPanel.Children.Add(tempEdit);
                }
            }
        }

        public static T FindChild<T>(DependencyObject parent, string childName)
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
