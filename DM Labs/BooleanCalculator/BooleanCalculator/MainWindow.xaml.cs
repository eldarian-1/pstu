using BooleanCalculator.Expression;
using System.Windows;
using System.Windows.Controls;

namespace BooleanCalculator
{
    public partial class MainWindow : Window
    {
        private Facade m_Facade;

        public MainWindow()
        {
            InitializeComponent();
            m_Facade = new Facade();
            SymbolListBox.ItemsSource = m_Facade.Simbols;
            ExpressionListBox.ItemsSource = m_Facade.Expressions;
            UpdateActiveExpression();
        }

        private void UpdateActiveExpression()
        {
            RunExpression.DataContext = m_Facade.ActiveExpression;
        }

        private void InvertValueClick(object sender, RoutedEventArgs e)
            => m_Facade.InvertBySymbol((((sender as Button).Parent as StackPanel).Children[0] as TextBlock).Text);

        private void AddSymbolClick(object sender, RoutedEventArgs e)
            => m_Facade.AddSymbol();

        private void ChangeSymbolClick(object sender, RoutedEventArgs e)
            => m_Facade.ChangeSymbol();

        private void AddExpressionClick(object sender, RoutedEventArgs e)
            => m_Facade.AddExpression();

        private void ChangeExpressionClick(object sender, RoutedEventArgs e)
            => m_Facade.AddExpression();

        private void RunExpressionClick(object sender, RoutedEventArgs e)
            => m_Facade.AddExpression();

        private void ChooseExpressionClick(object sender, RoutedEventArgs e)
        {
            m_Facade.SetActiveExpression((sender as Button).Content.ToString());
            UpdateActiveExpression();
        }
    }
}
