namespace Entity
{
    class EngineFinder
    {
        public int FindByIndex(IEngine[] engines, int key)
        {
            int mid, left = 0, right = engines.Length - 1;
            while (true)
            {
                if (left > right)
                    return -1;
                mid = left + (right - left) / 2;
                if (key > engines[mid].Index)
                    left = mid + 1;
                else if (key < engines[mid].Index)
                    right = mid - 1;
                else
                    return mid;
            }
        }

        public int FindByPower(IEngine[] engines, int key)
        {
            int mid, left = 0, right = engines.Length - 1;
            while (true)
            {
                if (left > right)
                    return -1;
                mid = left + (right - left) / 2;
                if (key > engines[mid].Power)
                    left = mid + 1;
                else if (key < engines[mid].Power)
                    right = mid - 1;
                else
                    return mid;
            }
        }

        public string FindByPseudonym(string[] pseudonyms, string key)
        {
            int i = 0, n = pseudonyms.Length;
            bool flag = false;
            while (!flag && i < n)
                flag = pseudonyms[i++] == key;
            if (flag)
                return pseudonyms[i - 1];
            else
                return "";
        }
    }
}
