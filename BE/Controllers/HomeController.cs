using BE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BE.Controllers
{
    public class HomeController : Controller
    {
        private List<Produkt> produkty = null;
        private List<KeyValuePair<Produkt, string>> koszyk = null;
        private List<Uzytkownik> Uzytkownicy = null;
        private void Init()
        {
            if (Session["produkty"] == null)
            {
                produkty = new List<Produkt>();
                produkty.Add(new Produkt(1, 1, "czapka LAL", new List<string>(new string[] { "1", "2", "3", "4", "5", "6" }), "fiolet", "new era", 50.0f, "welna", "Content/czapka.png", "czapki", "Czapka full-cap drużyny Los Angeles Lakers. Niezbędna dla każdego fana koszykówki."));
                Session["produkty"] = produkty;
            }
            else
            {
                produkty = (List<Produkt>)Session["produkty"];
            }
            if (Session["koszyk"] == null)
            {
                koszyk = new List<KeyValuePair<Produkt, string>>();
                Session["koszyk"] = koszyk;
            }
            else
            {
                koszyk = (List<KeyValuePair<Produkt, string>>)Session["koszyk"];
            }
            if(Session["uzytkownicy"]==null)
            {
                Uzytkownicy = new List<Uzytkownik>();
                Uzytkownicy.Add(new Uzytkownik(1, "razdwatrzy1", "Przyklad", "PrzykladoweImie", "PrzykladoweNazwisko",
                            "PrzykladowaUlica", "111222333", "PrzykladoweMiasto", "11-111", 2, 2));
                Session["uzytkownicy"] = Uzytkownicy;
                Session["zalogowanyuzytkownik"] = null;
            }
            else
            {
                Uzytkownicy = (List < Uzytkownik >)Session["uzytkownicy"];
            }
        }
        public ActionResult Index()
        {
            Init();
            ViewBag.Produkty = produkty;
            float wartoscKoszyka = 0;
            foreach (KeyValuePair<Produkt, string> p in koszyk)
            {
                wartoscKoszyka += p.Key.Cena;
            }
            ViewBag.Uzytkownik = (Uzytkownik)Session["zalogowanyuzytkownik"];
            ViewBag.Koszyk = wartoscKoszyka;
            return View();
        }

        public ActionResult About()
        {
            Init();
            ViewBag.Produkty = produkty;
            float wartoscKoszyka = 0;
            foreach (KeyValuePair<Produkt, string> p in koszyk)
            {
                wartoscKoszyka += p.Key.Cena;
            }
            ViewBag.Uzytkownik = (Uzytkownik)Session["zalogowanyuzytkownik"];
            ViewBag.Koszyk = wartoscKoszyka;

            return View();
        }

        public ActionResult Contact()
        {
            Init();
            ViewBag.Produkty = produkty;
            float wartoscKoszyka = 0;
            foreach (KeyValuePair<Produkt, string> p in koszyk)
            {
                wartoscKoszyka += p.Key.Cena;
            }
            ViewBag.Uzytkownik = (Uzytkownik)Session["zalogowanyuzytkownik"];
            ViewBag.Koszyk = wartoscKoszyka;

            return View();
        }

        public ActionResult AddKoszyk(string name, int id = -1, string rozmiar=null)
        {
            Init();
            if (rozmiar != null)
            {
                koszyk.Add(new KeyValuePair<Produkt, string>(produkty.Find((p) => p.ID == id), rozmiar));
                Session["koszyk"] = koszyk;
            }
            return View();
        }

        public ActionResult UsunKoszyk(string name, int id = -1, string rozmiar = null)
        {
            Init();
            if (rozmiar != null)
            {
                koszyk.Remove(koszyk.Find((p)=>p.Key.ID==id));
                Session["koszyk"] = koszyk;
            }
            return View();
        }

        public ActionResult Koszyk()
        {
            Init();
            ViewBag.Produkty = produkty;
            ViewBag.ZawartoscKoszyka = koszyk;
            float wartoscKoszyka = 0;
            foreach (KeyValuePair<Produkt, string> p in koszyk)
            {
                wartoscKoszyka += p.Key.Cena;
            }
            ViewBag.Uzytkownik = (Uzytkownik)Session["zalogowanyuzytkownik"];
            ViewBag.Koszyk = wartoscKoszyka;
            return View();
        }

        public ActionResult ZrealizujKoszyk()
        {
            Init();
            ViewBag.Produkty = produkty;
            ViewBag.ZawartoscKoszyka = koszyk;
            float wartoscKoszyka = 0;
            foreach (KeyValuePair<Produkt, string> p in koszyk)
            {
                wartoscKoszyka += p.Key.Cena;
            }
            ViewBag.Uzytkownik = (Uzytkownik)Session["zalogowanyuzytkownik"];
            ViewBag.Koszyk = wartoscKoszyka;
            return View();
        }

        public ActionResult Details(string name, int id=-1)
        {
            Init();
            ViewBag.Produkty = produkty;
            if (id != -1)
            {
                ViewBag.WybranyProdukt = produkty.Find(p => p.ID == id);
            }
            float wartoscKoszyka = 0;
            foreach (KeyValuePair<Produkt, string> p in koszyk)
            {
                wartoscKoszyka += p.Key.Cena;
            }
            ViewBag.Uzytkownik = (Uzytkownik)Session["zalogowanyuzytkownik"];
            ViewBag.Koszyk = wartoscKoszyka;
            return View();
        }

        public ActionResult PrzeslijZamowienie(string name, int id = -1, string rozmiar = null, int dom = -1, string kod = null,
             string ulica=null, string miasto=null, string nazwisko=null, string imie=null)
        {
            int mieszkanie = id;
            string telefon = rozmiar;
            Init();
            Random rand = new Random();
            Uzytkownik nowyuzytkownik = new Uzytkownik(rand.Next(900000000), "nieznany", "nieznany", imie, nazwisko,
                            ulica, telefon, miasto, kod, dom, mieszkanie);
            Session["uzytkownik"]=nowyuzytkownik;
            Zamowienie nowezamowienie = new Zamowienie(rand.Next(900000000), koszyk, nowyuzytkownik, null);
            Session["zamowienie"]=nowezamowienie;
            return View();
        }
        public ActionResult Zrealizowano()
        {
            Init();
            Session["koszyk"] =null;
            ViewBag.Produkty = produkty;
            ViewBag.ZawartoscKoszyka = koszyk;
            ViewBag.Koszyk = 0;
            ViewBag.Uzytkownik = (Uzytkownik)Session["zalogowanyuzytkownik"];
            ViewBag.numerzamowienia = ((Zamowienie)Session["zamowienie"]).ID;
            return View();
        }

        public ActionResult Zaloguj(string name, string id = "brak")
        {
            Init();
            ViewBag.Produkty = produkty;
            ViewBag.ZawartoscKoszyka = koszyk;
            float wartoscKoszyka = 0;
            foreach (KeyValuePair<Produkt, string> p in koszyk)
            {
                wartoscKoszyka += p.Key.Cena;
            }
            if(id=="blad")
            {
                ViewBag.Blad = true;
            }
            else {
                ViewBag.Blad = false;
            }
            ViewBag.Uzytkownik = (Uzytkownik)Session["zalogowanyuzytkownik"];
            ViewBag.Koszyk = wartoscKoszyka;
            return View();
        }

        public ActionResult WeryfikujLogowanie(string name, string id = "brak", string rozmiar="brak")
        {
            string nick = id;
            string haslo = rozmiar;
            Init();
            ViewBag.Produkty = produkty;
            ViewBag.ZawartoscKoszyka = koszyk;
            ViewBag.Uzytkownik = Uzytkownicy.Find((u) => u.Nick == nick && u.Haslo == haslo);
            Session["zalogowanyuzytkownik"] = (Uzytkownik)ViewBag.Uzytkownik;
            float wartoscKoszyka = 0;
            foreach (KeyValuePair<Produkt, string> p in koszyk)
            {
                wartoscKoszyka += p.Key.Cena;
            }
            ViewBag.Koszyk = wartoscKoszyka;
            return View();
        }

        public ActionResult Wyloguj()
        {
            Init();
            ViewBag.Produkty = produkty;
            float wartoscKoszyka = 0;
            foreach (KeyValuePair<Produkt, string> p in koszyk)
            {
                wartoscKoszyka += p.Key.Cena;
            }
            Session["zalogowanyuzytkownik"] = null;
            ViewBag.Uzytkownik = (Uzytkownik)Session["zalogowanyuzytkownik"];
            ViewBag.Koszyk = wartoscKoszyka;
            return View();
        }

        public ActionResult Zarejestruj()
        {
            Init();
            ViewBag.Produkty = produkty;
            float wartoscKoszyka = 0;
            foreach (KeyValuePair<Produkt, string> p in koszyk)
            {
                wartoscKoszyka += p.Key.Cena;
            }
            ViewBag.Uzytkownik = (Uzytkownik)Session["zalogowanyuzytkownik"];
            ViewBag.Koszyk = wartoscKoszyka;
            return View();
        }

        public ActionResult PrzeslijRejestracje(string name, int id = -1, string rozmiar = null, int dom = -1, string kod = null,
             string ulica = null, string miasto = null, string nazwisko = null, string imie = null, string nick = null, string haslo=null)
        {
            int mieszkanie = id;
            string telefon = rozmiar;
            Init();
            Random rand = new Random();
            Uzytkownik nowyuzytkownik = new Uzytkownik(rand.Next(900000000), haslo, nick, imie, nazwisko,
                            ulica, telefon, miasto, kod, dom, mieszkanie);
            Session["uzytkownik"] = nowyuzytkownik;
            Uzytkownicy.Add(nowyuzytkownik);
            return View();
        }
    }
}