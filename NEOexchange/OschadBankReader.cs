using System.Net;

namespace NEUexchange
{
    public class OschadBankReader : Reader
    {

        public override void Refresh()
        {
            WebClient wc = new WebClient();
            resp = wc.DownloadString("https://www.oschadbank.ua/ua");

            id = IndexOf(resp, "buy-USD");
            ToBuyAdd(BaseСurrency.USD, NextDigit());

            id = IndexOf(resp, "sell-USD", id);
            ToSellAdd(BaseСurrency.USD, NextDigit());

            id = IndexOf(resp, "buy-EUR", id);
            ToBuyAdd(BaseСurrency.EUR, NextDigit());

            id = IndexOf(resp, "sell-EUR", id);
            ToSellAdd(BaseСurrency.EUR, NextDigit());

            id = IndexOf(resp, "buy-RUB", id);
            ToBuyAdd(BaseСurrency.RUB, NextDigit());

            id = IndexOf(resp, "sell-RUB", id);
            ToSellAdd(BaseСurrency.RUB, NextDigit());
        }


        public OschadBankReader() => Refresh();
    }
}
