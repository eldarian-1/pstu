using System.Collections;

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
}
