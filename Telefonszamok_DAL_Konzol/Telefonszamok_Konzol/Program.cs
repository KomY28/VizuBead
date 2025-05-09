using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telefonszamok_DAL_Konzol;

namespace Telefonszamok_Konzol
{
    internal class Program
    {
        static cnTelefonszamok cnTelefonszamok;
        static void Main(string[] args)
        {
            cnTelefonszamok = new cnTelefonszamok();
            Adatfelvitel();
        }
        private static void Lekerdez()
        {
            Console.WriteLine("Összes adat\r\n-------");
            foreach (var x in cnTelefonszamok.enSzemelyek)
            {
                var s = x.Vezeteknev + " " + x.Utonev + " " + x.enHelyseg.Irsz + " " +
                x.enHelyseg.Nev + " " + x.Lakcim + ", ";
                foreach (var y in x.enTelefonszam)
                {
                    s += y.Szam;
                    if (y != x.enTelefonszam.Last())
                        s += ", ";
                }
                Console.WriteLine(s);
            }
        }

        private static void Adatfelvitel()
        {
            var h = new enHelyseg { Irsz = 2090, Nev = "Remeteszőlős" };
            var sz = new enSzemely
            {
                Vezeteknev = "Argon",
                Utonev = "Géze",
                Lakcim = "Ordas Köz 6.",
                enHelyseg = h
            };
            h.enSzemely.Add(sz);
            var t1 = new enTelefonszam
            {
                Szam = "+36-555-555",
                enSzemely = sz
            };
            var t2 = new enTelefonszam
            {
                Szam = "+36-666-666",
                enSzemely = sz
            };
            sz.enTelefonszam.Add(t1);
            sz.enTelefonszam.Add(t2);
            cnTelefonszamok.enHelysegSet.Add(h);
            cnTelefonszamok.enSzemelyek.Add(sz);
            cnTelefonszamok.enTelefonszamok.Add(t1);
            cnTelefonszamok.enTelefonszamok.Add(t2);
            cnTelefonszamok.SaveChanges();

        }
    }
}
