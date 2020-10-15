using System;

namespace Lab9
{
    class Money
    {
        private const int c_iDevide = 100;

        private static int s_iCount = 0;

        private int m_iRubles;
        private int m_iPennies;

        public Money() : this(0, 0) { }

        public Money(int p) : this(0, p) {}

        public Money(int r, int p)
        {
            if (r < 0 || p < 0)
                throw new ArgumentException();
            ++s_iCount;
            m_iRubles = r + p / c_iDevide;
            m_iPennies = p % c_iDevide;
        }

        ~Money()
        {
            --s_iCount;
        }

        public static int Count
        {
            get { return s_iCount; }
            set { s_iCount = value; }
        }

        public int Rubles
        {
            get { return m_iRubles; }
            set { m_iRubles = value; }
        }

        public int Pennies
        {
            get { return m_iPennies; }
            set { m_iPennies = value; }
        }

        public static bool operator ==(Money left, Money right)
        {
            return left.m_iRubles == right.m_iRubles
                && left.m_iPennies == right.m_iPennies;
        }

        public static bool operator !=(Money left, Money right)
        {
            return !(left == right);
        }

        public static bool operator <(Money left, Money right)
        {
            return left.m_iRubles * c_iDevide + left.m_iPennies
                < right.m_iRubles * c_iDevide + right.m_iPennies;
        }

        public static bool operator >(Money left, Money right)
        {
            return left != right && !(left < right);
        }

        public static bool operator <=(Money left, Money right)
        {
            return left == right || left < right;
        }

        public static bool operator >=(Money left, Money right)
        {
            return left == right || left > right;
        }

        public static Money operator ++(Money money)
        {
            Money result = new Money(money.m_iRubles, money.m_iPennies);
            if (++result.m_iPennies == c_iDevide)
            {
                result.m_iPennies = 0;
                if (result.m_iRubles == Program.c_iMaxInt)
                    throw new InvalidOperationException();
                else
                    ++result.m_iRubles;
            }
            return result;
        }

        public static Money operator --(Money money)
        {
            Money result = new Money(money.m_iRubles, money.m_iPennies);
            if(--result.m_iPennies < 0)
            {
                result.m_iPennies = 99;
                if (--result.m_iRubles < 0)
                    throw new InvalidOperationException();
            }
            return result;
        }

        public static implicit operator int(Money money)
        {
            return money.m_iRubles;
        }

        public static explicit operator double(Money money)
        {
            return (double)money.m_iPennies / c_iDevide;
        }

        public static Money operator -(Money money, int pennies)
        {
            return new Money(
                money.m_iRubles * c_iDevide + money.m_iPennies - pennies);
        }

        public static Money operator -(int pennies, Money money)
        {
            return new Money(
                pennies - (money.m_iRubles * c_iDevide + money.m_iPennies));
        }

    }
}
