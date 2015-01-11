using System.Collections.Generic;
using System.Data.Entity;

namespace BE.Models
{
    public class ProduktDBContext : DbContext
    {
        public DbSet<Produkt> Produkty { get; set; }
    }
    public class Produkt
    {
        public int ID { get; set; }
        public int NrProduktu { get; set; }
        public string Nazwa { get; set; }
        public List<string> DostepneRozmiary { get; set; }
        public string Kolor { get; set; }
        public string Marka { get; set; }
        public float Cena { get; set; }
        public string Material { get; set; }
        public string SciezkaDoZdjecia { get; set; }
        public string Kategoria { get; set; }

        public string Opis { get; set; }
        public Produkt(int _ID, int _nr, string _nazwa, List<string> _dostepneRozmiary, string _kolor, string _marka, float _cena, string _material, string _sciezka, string _kategoria, string _opis)
        {
            ID = _ID;
            NrProduktu = _nr;
            Nazwa = _nazwa;
            DostepneRozmiary = _dostepneRozmiary;
            Kolor = _kolor;
            Marka = _marka;
            Cena = _cena;
            Material = _material;
            SciezkaDoZdjecia = _sciezka;
            Kategoria = _kategoria;
            Opis = _opis;
        }
    }
     
}