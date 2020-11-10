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
            SymbolListBox.ItemsSource = m_Facade.Symbols;
            ExpressionListBox.ItemsSource = m_Facade.Expressions;
            UpdateActiveExpression();
        }

        private void UpdateActiveExpression()
        {
            ExpressionConstructor.DataContext = m_Facade.ActiveExpression;
            RunExpression.DataContext = m_Facade.ActiveExpression;
            ExpressionConstructor.InvalidateArrange();
        }

        private void InvertValueClick(object sender, RoutedEventArgs e)
        {
            m_Facade.InvertBySymbol((((sender as Button).Parent as StackPanel).Children[0] as TextBlock).Text);
            SymbolListBox.Items.Refresh();
        }

        private void AddSymbolClick(object sender, RoutedEventArgs e)
            => m_Facade.AddSymbol();

        private void ChangeSymbolLeftClick(object sender, RoutedEventArgs e)
            => m_Facade.ChangeSymbol((sender as Button).Content.ToString(), true);

        private void ChangeSymbolRightClick(object sender, RoutedEventArgs e)
            => m_Facade.ChangeSymbol((sender as Button).Content.ToString(), false);

        private void AddExpressionClick(object sender, RoutedEventArgs e)
        {
            m_Facade.AddExpression();
            UpdateActiveExpression();
        }

        private void ChangeExpressionClick(object sender, RoutedEventArgs e)
        {
            m_Facade.ChangeExpression((sender as Button).Content.ToString());
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
