using System.Net;

namespace NEUexchange
{
    public class AvalBankReader : Reader
    {
        public AvalBankReader() => Refresh();

        public override void Refresh()
        {
            WebClient wc = new WebClient();
            resp = wc.DownloadString("https://ex.aval.ua/personal/everyday/exchange/exchange/");




            id = IndexOf(resp, "<td class=\"name\">");


            ToBuyAdd(BaseСurrency.USD, NextDigit());
            ToSellAdd(BaseСurrency.USD, NextDigit());

            ToBuyAdd(BaseСurrency.EUR, NextDigit());
            ToSellAdd(BaseСurrency.EUR, NextDigit());

            ToBuyAdd(BaseСurrency.RUB, NextDigit());
            ToSellAdd(BaseСurrency.RUB, NextDigit());

        }




    }
}
