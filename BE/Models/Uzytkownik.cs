using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BE.Models
{
    public class Uzytkownik
    {
        public int ID { get; set; }
        public string Haslo  { get; set; }
        public string Nick { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Ulica { get; set; }
        public string Telefon { get; set; }
        public string Miasto { get; set; }
        public string Kod_Pocztowy { get; set; }
        public int nr_domu { get; set; }
        public int? nr_mieszkania { get; set; }
        public Uzytkownik(int _id, string _haslo, string _nick, string _imie, string _nazwisko, string _ulica, string _telefon, string _miasto, string _kod_pocztowy, int _nrdomu, int? _nrmieszkania)
        {
            ID = _id;
            Imie = _imie;
            Nazwisko = _nazwisko;
            Haslo = _haslo;
            Nick = _nick;
            Ulica = _ulica;
            Telefon = _telefon;
            Miasto = _miasto;
            Kod_Pocztowy = _kod_pocztowy;
            nr_domu = _nrdomu;
            nr_mieszkania = _nrmieszkania;
        }
    }
}