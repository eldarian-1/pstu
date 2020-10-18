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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
                    TextBox tempTextBox = FindChild<TextBox>(Application.Current.MainWindow, "AJ" + i + "_" + j);
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
            FixArray1D();
            FixArray2D();
            FixArrayJagged();
        }

        private void LoadFromFile(object sender, RoutedEventArgs e)
        {
            
        }

        private void SetArray1D()
        {
            ListBoxArray1D.Items.Clear();
            for (int i = 0, n = Array1D.Length; i < n; ++i)
                ListBoxArray1D.Items.Add(new ListBoxItem { Content = new TextBox { Name = "A1D" + i, Text = Array1D[i].ToString() } });
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
                    TextBox tempEdit = new TextBox { Name = "AJ" + i + "_" + j, Text = tempText };
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
