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
            Array1D = new int[] { 13, 14, 15 };
            Array2D = new int[3, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } };
            ArrayJagged = new int[][] {
                new int[] { 1, 2, 3, 4 },
                new int[] { 1, 2, 3 },
                new int[] { 1, 2, 3, 4, 5 }
            };
            SetArray1D();
            SetArray2D();
            SetArrayJagged();
        }

        private void ChangeArray1DSize(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(Array1Size.Text, out int size))
            {
                Array1D = new int[size];
                for (int i = 0; i < size; i++)
                    Array1D[i] = i;
                SetArray1D();
            }
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

        private void SetArray1D()
        {
            ListBoxArray1D.Items.Clear();
            for (int i = 0, n = Array1D.Length; i < n; ++i)
                ListBoxArray1D.Items.Add(new ListBoxItem { Content = new TextBox { Text = Array1D[i].ToString() } });
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
                    TextBox tempTextBox = new TextBox { Text = tempText };
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
                    TextBox tempEdit = new TextBox { Text = tempText };
                    tempWrapPanel.Children.Add(tempEdit);
                }
            }
        }

        private ListBox GetListBox()
        {
            string xaml = @"<ListBox
                                xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'
                                xmlns:x='http://schemas.microsoft.com/winfx/2006/xaml'
                                Grid.Column='1' ScrollViewer.HorizontalScrollBarVisibility='Disabled'>
                                <ListBox.ItemsPanel>
                                    <ItemsPanelTemplate>
                                        <WrapPanel />
                                    </ItemsPanelTemplate>
                                </ListBox.ItemsPanel>
                            </ListBox >";
            return XamlReader.Parse(xaml) as ListBox;
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
