using System.Collections.Generic;
using System.Data.Entity;

namespace BE.Models
{
    public class ZamowienieDBContext : DbContext
    {
        public DbSet<Zamowienie> Zamowienia { get; set; }
    }
    public class Zamowienie
    {
        public int ID { get; set; }
        public List<KeyValuePair<Produkt, string>> koszyk { get; set; }
        public Uzytkownik uzytkownik { get; set; }
        public string SciezkaDoFaktury { get; set; }

        public Zamowienie(int _id, List<KeyValuePair<Produkt, string>> _koszyk, Uzytkownik _uzytkownik, string _sciezka)
        {
            ID = _id;
            koszyk = _koszyk;
            uzytkownik = _uzytkownik;
            SciezkaDoFaktury = _sciezka;
        }
    }
}