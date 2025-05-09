using System.Linq;
using Telefonszamok_DAL_Konzol;
namespace Telefonszamok_WPF
{
    public static class Bovito
    {
        public static string Telefonszamok(this enSzemely enSzemely)
        {
            var s = "";
            foreach (var x in enSzemely.enTelefonszam)
            {
                s = s + x.Szam;
                if (x != enSzemely.enTelefonszam.Last())
                    s = s + ", ";
            }
            return s;
        }
    }
}