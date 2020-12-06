using System.Collections;
using System.Collections.Generic;

namespace Entity
{
    internal class CompareByPower : IComparer
    {
        public int Compare(object x, object y)
        {
            IEngine left = (IEngine)x;
            IEngine right = (IEngine)y;
            if (left.Power > right.Power)
                return 1;
            if (left.Power < right.Power)
                return -1;
            else
                return 0;
        }
    }

    internal class CompareByIndexD : IComparer
    {
        public int Compare(object x, object y)
        {
            KeyValuePair<string, IEngine> left = (KeyValuePair<string, IEngine>)x;
            KeyValuePair<string, IEngine> right = (KeyValuePair<string, IEngine>)y;
            if (left.Value.Index > right.Value.Index)
                return 1;
            if (left.Value.Index < right.Value.Index)
                return -1;
            else
                return 0;
        }
    }

    internal class CompareByPowerD : IComparer
    {
        public int Compare(object x, object y)
        {
            KeyValuePair<string, IEngine> left = (KeyValuePair<string, IEngine>)x;
            KeyValuePair<string, IEngine> right = (KeyValuePair<string, IEngine>)y;
            if (left.Value.Power > right.Value.Power)
                return 1;
            if (left.Value.Power < right.Value.Power)
                return -1;
            else
                return 0;
        }
    }

    internal class CompareByPseudonymD : IComparer
    {
        public int Compare(object x, object y)
        {
            KeyValuePair<string, IEngine> left = (KeyValuePair<string, IEngine>)x;
            KeyValuePair<string, IEngine> right = (KeyValuePair<string, IEngine>)y;
            return string.Compare(left.Key, right.Key);
        }
    }
}
