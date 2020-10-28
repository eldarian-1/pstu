using System.Collections;

namespace Task1
{
    class CompareByPower : IComparer
    {
        public int Compare(object x, object y)
        {
            IExecutable left = (IExecutable)x;
            IExecutable right = (IExecutable)y;
            if (left.Power > right.Power)
                return 1;
            if (left.Power < right.Power)
                return -1;
            else
                return 0;
        }
    }
}
