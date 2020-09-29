using System.Collections.Generic;

namespace NEUexchange
{
    public abstract class Reader
    {
        protected Dictionary<BaseСurrency, decimal> parsedToSell = new Dictionary<BaseСurrency, decimal>();
        protected Dictionary<BaseСurrency, decimal> parsedToBuy = new Dictionary<BaseСurrency, decimal>();
        protected string resp;
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
        public  decimal Get(BaseСurrency baseСurrency, bool ToSale)
        {
            if (ToSale)
                return parsedToSell[baseСurrency];
            else
                return parsedToBuy[baseСurrency];
        }

    }
}
