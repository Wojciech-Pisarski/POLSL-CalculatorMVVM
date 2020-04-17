using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1C.Model
{
    
    class MPilkarz
    {
        #region Player's properties
        public string Imie { get; private set; }
        public string Nazwisko { get; private set; }
        public uint Wiek { get; private set; }
        public uint Waga { get; private set; }
        #endregion

        #region Constructor
        public MPilkarz(string imie, string nazwisko, uint wiek, uint waga)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Waga = waga;           
        }        
        #endregion

        #region Methods                   
        public string getImie() {return this.Imie;}
        public string getNazwisko() {return this.Nazwisko;}
        public uint getWiek() {return this.Wiek;}
        public uint getWaga() {return this.Waga;}
        public override string ToString() {return $"{Nazwisko} {Imie} lat: {Wiek} waga: {Waga} kg";}                
        public void edycjaPilkarza(string imie, string nazwisko, uint wiek, uint waga)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Waga = waga;
        }
        #endregion
    }
}
