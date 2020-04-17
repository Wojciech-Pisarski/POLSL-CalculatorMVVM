using lab_1C.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lab_1C.ViewModel
{
    class VMFunctionality : VMBaseClass
    {
        #region Core components
        public VMFunctionality()
        {
            mFunctionalityObject.CzytajPilkarzyZPliku();
            aktualizacja();            
        }
        private void aktualizacja()
        {            
            SelectedIndex = -1;
            Imie = null;
            Nazwisko = null;
            Wiek = 35;
            Waga = 75;
            Pilkarze = mFunctionalityObject.getLudzie();
            mFunctionalityObject.ZapisPilkarzyDoPliku();
        }

        private MFunctionality mFunctionalityObject = new MFunctionality();
        #endregion

        #region Player's properties + Text box item management
        private string _imie = "";
        public string Imie
        {
            get
            {
                return _imie;
            }
            set
            {
                if(_imie != value)
                {
                    _imie = value;
                    onPropertyChanged(nameof(Imie));
                }
            }
        }

        private string _nazwisko = "";
        public string Nazwisko
        {
            get
            {
                return _nazwisko;
            }
            set
            {
                if (_nazwisko != value)
                {
                    _nazwisko = value;
                    onPropertyChanged(nameof(Nazwisko));
                }
            }
        }

        private uint _wiek = 35;
        public uint Wiek
        {
            get
            {
                return _wiek;
            }
            set
            {
                if (_wiek != value)
                {
                    _wiek = value;
                    onPropertyChanged(nameof(Wiek));
                }
            }
        }

        private uint _waga = 75;
        public uint Waga
        {
            get
            {
                return _waga;
            }
            set
            {
                if (_waga != value)
                {
                    _waga = value;
                    onPropertyChanged(nameof(Waga));
                }
            }
        }

        private string[] _pilkarze;
        public string[] Pilkarze
        {
            get
            {
                return _pilkarze;
            }
            set
            {
                if(_pilkarze != value)
                {
                    _pilkarze = value;
                    onPropertyChanged(nameof(Pilkarze));
                }
            }
        }

        private int _selectedIndex = -1;
        public int SelectedIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                if (_selectedIndex != -1)
                {                    
                    Imie = mFunctionalityObject.getImie(SelectedIndex);
                    Nazwisko = mFunctionalityObject.getNazwisko(SelectedIndex);
                    Wiek = mFunctionalityObject.getWiek(SelectedIndex);
                    Waga = mFunctionalityObject.getWaga(SelectedIndex);
                }
                onPropertyChanged(nameof(SelectedIndex));
            }
        }
        #endregion

        #region Player's commands
        private ICommand _dodaj = null;
        public ICommand Dodaj
        {
            get
            {
                if(_dodaj == null)
                {
                    _dodaj = new VMRelayCommand(
                        x =>
                        {
                            mFunctionalityObject.dodajPilkarza(Imie, Nazwisko, Wiek, Waga);
                            aktualizacja();
                        },
                        x =>
                        {
                            bool pomocniczy = true;
                            if ((Imie == null) || (Imie == "") || (Imie.Contains(" ")))
                                pomocniczy = false;
                            return pomocniczy;
                        }
                        );
                }
                return _dodaj;
            }
        }

        private ICommand _edytuj = null;
        public ICommand Edytuj
        {
            get
            {
                if (_edytuj == null)
                {
                    _edytuj = new VMRelayCommand(
                        x =>
                        {                            
                            mFunctionalityObject.edytujPilkarza(SelectedIndex, Imie, Nazwisko, Wiek, Waga);
                            aktualizacja();
                        },
                        x =>
                        {
                            if (SelectedIndex != -1)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        );
                }                
                return _edytuj;
            }
        }

        private ICommand _usun = null;
        public ICommand Usun
        {
            get 
            {
                if(_usun == null)
                {
                    _usun = new VMRelayCommand(
                        x =>
                        {
                            mFunctionalityObject.usunPilkarza(SelectedIndex);
                            aktualizacja();
                        },
                        x =>
                        {
                            if (SelectedIndex != -1)
                                return true;
                            else
                                return false;
                        }
                    );
                }
                return _usun;
            }
        }
        #endregion        
    }
}
