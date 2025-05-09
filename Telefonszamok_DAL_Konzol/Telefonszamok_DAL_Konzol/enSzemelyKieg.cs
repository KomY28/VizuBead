using System.Linq;

namespace Telefonszamok_DAL_Konzol
{
    public partial class enSzemely
    {
        public string Telefonszamok
        {
            get
            {
                var s = "";
                foreach (var x in enTelefonszam)
                {
                    s = s + x.Szam;
                    if (x != enTelefonszam.Last())
                        s = s + ", ";
                }
                return s;
            }
        }
    }
}
