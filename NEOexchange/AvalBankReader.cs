using System.Net;

namespace NEUexchange
{
    public class AvalBankReader : Reader
    {
        public AvalBankReader() => Refresh();
        int id = 0;
        public override void Refresh()
        {
            WebClient wc = new WebClient();
            resp = wc.DownloadString("https://ex.aval.ua/personal/everyday/exchange/exchange/");

            id = IndexOf(resp, "<td class=\"name\">Долари&nbsp;США</td>");
            
            
        }

        public static int IndexOf(string s, string f, int start = 0, int stop = 0)
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
       
    }
}
