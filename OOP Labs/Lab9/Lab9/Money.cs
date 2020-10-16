﻿using System;

namespace Lab9
{
    class Money
    {
        private const int c_iDevide = 100;

        private static int s_iCount = 0;

        private int m_iRuble = 0;
        private int m_iPenny = 0;

        public Money(int p) : this(0, p) { }

        public Money(int r, int p)
        {
            if (r < 0 || p < 0)
                throw new ArgumentException();
            ++s_iCount;
            m_iRuble = r + p / c_iDevide;
            m_iPenny = p % c_iDevide;
        }

        ~Money() { --s_iCount; }

        public static int Count
        {
            get { return s_iCount; }
            set { s_iCount = value; }
        }

        public int Ruble
        {
            get { return m_iRuble; }
            set { m_iRuble = value; }
        }

        public int Penny
        {
            get { return m_iPenny; }
            set { m_iPenny = value; }
        }

        public override string ToString()
            => "" + m_iRuble + "," + ((m_iPenny < 10) ? "0" : "") + m_iPenny;

        public override bool Equals(object obj)
            => this == (Money)obj;

        public override int GetHashCode()
            => base.GetHashCode();

        public static bool operator ==(Money left, Money right)
            => left.m_iRuble == right.m_iRuble
                && left.m_iPenny == right.m_iPenny;

        public static bool operator !=(Money left, Money right)
            => !(left == right);

        public static bool operator <(Money left, Money right)
            => left.m_iRuble * c_iDevide + left.m_iPenny
                < right.m_iRuble * c_iDevide + right.m_iPenny;

        public static bool operator >(Money left, Money right)
            => left != right && !(left < right);

        public static bool operator <=(Money left, Money right)
            => left == right || left < right;

        public static bool operator >=(Money left, Money right)
            => left == right || left > right;

        public static Money operator ++(Money money)
        {
            Money result = new Money(money.m_iRuble, money.m_iPenny);
            if (++result.m_iPenny == c_iDevide)
            {
                result.m_iPenny = 0;
                if (result.m_iRuble == Core.MaxInt)
                    throw new InvalidOperationException();
                else
                    ++result.m_iRuble;
            }
            return result;
        }

        public static Money operator --(Money money)
        {
            Money result = new Money(money.m_iRuble, money.m_iPenny);
            if(--result.m_iPenny < 0)
            {
                result.m_iPenny = 99;
                if (--result.m_iRuble < 0)
                    throw new InvalidOperationException();
            }
            return result;
        }

        public static implicit operator int(Money money)
            => money.m_iRuble;

        public static explicit operator double(Money money)
            => (double)money.m_iPenny / c_iDevide;

        public static Money operator -(Money money, int penny)
            => new Money(money.m_iRuble * c_iDevide + money.m_iPenny - penny);

        public static Money operator -(int penny, Money money)
            => new Money(penny - (money.m_iRuble * c_iDevide + money.m_iPenny));
    }
}
