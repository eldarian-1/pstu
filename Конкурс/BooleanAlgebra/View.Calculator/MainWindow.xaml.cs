using System.Windows;
using UseCase.Calculator;
using System.Windows.Input;
using System.Windows.Controls;

namespace View.Calculator
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
            VariablesBox.ItemsSource = m_Facade.Variables;
            FunctionsBox.ItemsSource = m_Facade.Functions;
            UpdateActiveFunction();
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

        private void UpdateActiveFunction()
        {
            FunctionConstructor.DataContext = m_Facade.ActiveFunction;
            RunFunction.DataContext = m_Facade.ActiveFunction;
            FunctionsBox.DataContext = m_Facade.Functions;
            FunctionsBox.Items.Refresh();
            ChangeSymbolLeft.Content = m_Facade.ActiveFunction.Left.Name;
            ChangeSymbolLeft.InvalidateMeasure();
            ChangeSymbolRight.Content = m_Facade.ActiveFunction.Right.Name;
            ChangeSymbolRight.InvalidateMeasure();
            ChangeOperator.Content = m_Facade.ActiveFunction.OperationSymbol;
            ChangeOperator.InvalidateMeasure();
            RunFunction.Content = m_Facade.ActiveFunction.ToString();
            RunFunction.InvalidateMeasure();
        }

        private void SetActiveFunction(object sender)
            => m_Facade.SetActiveFunction((((sender as Button).Parent as StackPanel).Children[0] as TextBlock).Text);

        private void InvertValueClick(object sender, RoutedEventArgs e)
        {
            m_Facade.InvertVariable((((sender as Button).Parent as StackPanel).Children[0] as TextBlock).Text);
            VariablesBox.Items.Refresh();
        }

        private void AddVariableClick(object sender, RoutedEventArgs e)
            => m_Facade.AddVariable();

        private void ChangeSymbolLeftClick(object sender, RoutedEventArgs e)
        {
            m_Facade.ChangeSymbol((sender as Button).Content.ToString(), true);
            SetActiveFunction(sender);
            UpdateActiveFunction();
        }

        private void ChangeSymbolRightClick(object sender, RoutedEventArgs e)
        {
            m_Facade.ChangeSymbol((sender as Button).Content.ToString(), false);
            SetActiveFunction(sender);
            UpdateActiveFunction();
        }

        private void InvertSymbolLeftClick(object sender, RoutedEventArgs e)
        {
            m_Facade.InvertSymbol(true);
            SetActiveFunction(sender);
            UpdateActiveFunction();
        }

        private void InvertSymbolRightClick(object sender, RoutedEventArgs e)
        {
            m_Facade.InvertSymbol(false);
            SetActiveFunction(sender);
            UpdateActiveFunction();
        }

        private void AddFunctionClick(object sender, RoutedEventArgs e)
        {
            m_Facade.AddFunction();
            UpdateActiveFunction();
        }

        private void ChangeOperatorClick(object sender, RoutedEventArgs e)
        {
            m_Facade.ChangeOperator();
            SetActiveFunction(sender);
            UpdateActiveFunction();
        }

        private void RunFunctionClick(object sender, RoutedEventArgs e)
            => MessageBox.Show(m_Facade.RunFunction());

        private void ChooseFunctionClick(object sender, RoutedEventArgs e)
        {
            m_Facade.SetActiveFunction((sender as Button).Content.ToString());
            UpdateActiveFunction();
        }
    }
}
