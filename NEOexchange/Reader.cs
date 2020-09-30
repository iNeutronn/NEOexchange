using System.Collections.Generic;

namespace NEUexchange
{
    public abstract class Reader
    {
        protected Dictionary<BaseСurrency, decimal> parsedToSell = new Dictionary<BaseСurrency, decimal>();
        protected Dictionary<BaseСurrency, decimal> parsedToBuy = new Dictionary<BaseСurrency, decimal>();
        protected string resp;
        protected int id;
        protected decimal NextDigit()
        {
            while (!char.IsDigit(resp[id])) id++;

            string course = "";
            for (int i = id; resp[i] == ',' | resp[i] == '.' | char.IsDigit(resp[i]); i++)
                course += resp[i];
            id += course.Length;
            return decimal.Parse(course.Replace('.', ','));
        }

        protected int IndexOf(string s, string f, int start = 0, int stop = 0)
        {
            if (stop == 0)
                stop = s.Length;

            int i;
            for (i = start; i < stop; i++)
            {
                for (int j = 0; j < f.Length; j++)
                {
                    if (j == f.Length - 1 & s[i] == f[j])
                        return i++;
                    if (s[i] == f[j])
                    {
                        i++;
                        continue;
                    }
                    else
                        break;
                }

            }
            return -1;

        }
        public abstract void Refresh();
        protected void ToSellAdd(BaseСurrency b, decimal value)
        {
            if (parsedToSell.ContainsKey(b))
                parsedToSell[b] = value;
            else
                parsedToSell.Add(b, value);
        }
        protected void ToBuyAdd(BaseСurrency b, decimal value)
        {
            if (parsedToBuy.ContainsKey(b))
                parsedToBuy[b] = value;
            else
                parsedToBuy.Add(b, value);
        }
        public decimal Get(BaseСurrency baseСurrency, bool ToSale)
        {
            if (ToSale)
                return parsedToSell[baseСurrency];
            else
                return parsedToBuy[baseСurrency];
        }

    }
}
