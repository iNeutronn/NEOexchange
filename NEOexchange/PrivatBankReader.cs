using System.Net;

namespace NEUexchange
{
    public class PrivatBankReader : Reader
    {
        private decimal Pars(string teg)
        {
            int id = resp.IndexOf(teg);
            string course = "";
            id += teg.Length;
            while (!char.IsDigit(resp[id])) id++;
            for (int i = id; resp[i]=='.' | char.IsDigit(resp[i]); i++)
                course += resp[i];
            
            return decimal.Parse(course.Replace('.', ','));
        }
        public PrivatBankReader() => Refresh();
        public override void Refresh()
        {
            WebClient wc = new WebClient();
            resp = wc.DownloadString("https://privatbank.ua/");

            ToSellAdd(BaseСurrency.EUR, Pars("<td id=\"EUR_sell\">"));
            ToSellAdd(BaseСurrency.USD, Pars("<td id=\"USD_sell\">"));
            ToSellAdd(BaseСurrency.RUB, Pars("<td id=\"RUB_sell\">"));

            ToBuyAdd(BaseСurrency.EUR , Pars("<td id=\"EUR_buy\">"));
            ToBuyAdd(BaseСurrency.USD , Pars("<td id=\"USD_buy\">"));
            ToBuyAdd(BaseСurrency.RUB , Pars("<td id=\"RUB_buy\">"));
        }
    }
}
