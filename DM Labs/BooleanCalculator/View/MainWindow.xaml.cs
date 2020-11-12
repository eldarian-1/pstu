using Logic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace BooleanCalculator
{
    public partial class MainWindow : Window
    {
        private LogicFacade m_Facade;
        private bool m_Inversion;

        public MainWindow()
        {
            InitializeComponent();
            m_Inversion = false;
            m_Facade = new LogicFacade();
            SymbolListBox.ItemsSource = m_Facade.Symbols;
            ExpressionListBox.ItemsSource = m_Facade.Expressions;
            UpdateActiveExpression();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.LeftShift || e.Key == Key.RightShift)
            {
                if (m_Inversion)
                {
                    ChangeSymbolLeft.Click -= InvertSymbolLeftClick;
                    ChangeSymbolRight.Click -= InvertSymbolRightClick;
                    ChangeSymbolLeft.Click += ChangeSymbolLeftClick;
                    ChangeSymbolRight.Click += ChangeSymbolRightClick;
                }
                else
                {
                    ChangeSymbolLeft.Click -= ChangeSymbolLeftClick;
                    ChangeSymbolRight.Click -= ChangeSymbolRightClick;
                    ChangeSymbolLeft.Click += InvertSymbolLeftClick;
                    ChangeSymbolRight.Click += InvertSymbolRightClick;
                }
                m_Inversion = !m_Inversion;
            }
        }

        private void UpdateActiveExpression()
        {
            ExpressionConstructor.DataContext = m_Facade.ActiveExpression;
            RunExpression.DataContext = m_Facade.ActiveExpression;
            ChangeSymbolLeft.Content = m_Facade.ActiveExpression.Left.Name;
            ChangeSymbolLeft.InvalidateMeasure();
            ChangeSymbolRight.Content = m_Facade.ActiveExpression.Right.Name;
            ChangeSymbolRight.InvalidateMeasure();
            ChangeExpression.Content = m_Facade.ActiveExpression.Symbol;
            ChangeExpression.InvalidateMeasure();
            RunExpression.Content = m_Facade.ActiveExpression.ToString();
            RunExpression.InvalidateMeasure();
        }

        private void SetActiveExpression(object sender)
            => m_Facade.SetActiveExpression((((sender as Button).Parent as StackPanel).Children[0] as TextBlock).Text);

        private void InvertValueClick(object sender, RoutedEventArgs e)
        {
            m_Facade.InvertSymbol((((sender as Button).Parent as StackPanel).Children[0] as TextBlock).Text);
            SymbolListBox.Items.Refresh();
        }

        private void AddSymbolClick(object sender, RoutedEventArgs e)
            => m_Facade.AddSymbol();

        private void ChangeSymbolLeftClick(object sender, RoutedEventArgs e)
        {
            m_Facade.ChangeSymbol((sender as Button).Content.ToString(), true);
            SetActiveExpression(sender);
            UpdateActiveExpression();
        }

        private void ChangeSymbolRightClick(object sender, RoutedEventArgs e)
        {
            m_Facade.ChangeSymbol((sender as Button).Content.ToString(), false);
            SetActiveExpression(sender);
            UpdateActiveExpression();
        }

        private void InvertSymbolLeftClick(object sender, RoutedEventArgs e)
        {
            m_Facade.InvertExpression(true);
            SetActiveExpression(sender);
            UpdateActiveExpression();
        }

        private void InvertSymbolRightClick(object sender, RoutedEventArgs e)
        {
            m_Facade.InvertExpression(false);
            SetActiveExpression(sender);
            UpdateActiveExpression();
        }

        private void AddExpressionClick(object sender, RoutedEventArgs e)
        {
            m_Facade.AddExpression();
            UpdateActiveExpression();
        }

        private void ChangeExpressionClick(object sender, RoutedEventArgs e)
        {
            m_Facade.ChangeExpression();
            SetActiveExpression(sender);
            UpdateActiveExpression();
        }

        private void RunExpressionClick(object sender, RoutedEventArgs e)
            => MessageBox.Show(m_Facade.RunExpression());

        private void ChooseExpressionClick(object sender, RoutedEventArgs e)
        {
            m_Facade.SetActiveExpression((sender as Button).Content.ToString());
            UpdateActiveExpression();
        }
    }
}
