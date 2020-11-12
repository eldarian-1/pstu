using Entity;
using System;
using System.Collections.ObjectModel;

namespace Logic
{
    class ResultBuilder
    {
        private ObservableCollection<SymbolAdapter> m_Symbols;
        private StateExpression m_Expression;

        public ResultBuilder(Facade facade)
        {
            m_Symbols = facade.Symbols;
            m_Expression = facade.ActiveExpression;
        }

        public string Run()
        {
            string result
                = "Результат на заданном наборе: "
                + GetNum(m_Expression.Value)
                + "\n\nТаблица истинности:\n";

            int size = m_Symbols.Count;
            for (int i = 0; i < size; ++i)
                result += ((char)('A' + i)).ToString();
            result += " Res\n";

            int[] devide = new int[size];
            for (int i = 0; i < size; ++i)
                devide[i] = (int)Math.Pow(2, i);

            for (int i = 0, n = (int)Math.Pow(2, size); i < n; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    int num = (i & devide[size - 1 - j]) / devide[size - 1 - j];
                    m_Symbols[j].Value = num == 1;
                    result += num;
                }
                result += " " + GetNum(m_Expression.Value) + "\n";
            }

            return result;
        }

        private string GetNum(bool val)
        {
            if (val)
                return "1";
            else
                return "0";
        }
    }
}
