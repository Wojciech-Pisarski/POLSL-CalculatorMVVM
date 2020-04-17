using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace lab_1C.Model
{
    class MFunctionality
    {
        #region Player's data management
        private List<MPilkarz> spisPilkarzy = new List<MPilkarz>();
        public void dodajPilkarza(string imie, string nazwisko, uint wiek, uint waga) {spisPilkarzy.Add(new MPilkarz(imie, nazwisko, wiek, waga));}
        public void usunPilkarza(int wybranyIndex){spisPilkarzy.RemoveAt(wybranyIndex);}
        public void edytujPilkarza(int wybranyIndex, string imie, string nazwisko, uint wiek, uint waga) { spisPilkarzy[wybranyIndex].edycjaPilkarza(imie, nazwisko, wiek, waga);}
        #endregion

        #region Players' data getters
        public string getImie(int index)
        {
            return spisPilkarzy[index].getImie();
        }
        public string getNazwisko(int index)
        {
            return spisPilkarzy[index].getNazwisko();
        }
        public uint getWiek(int index)
        {
            return spisPilkarzy[index].getWiek();
        }
        public uint getWaga(int index)
        {
            return spisPilkarzy[index].getWaga();
        }
        public string[] getLudzie()
        {
            string[] tablicaLudzi = new string[spisPilkarzy.Count];
            
            for (int i = 0; i < tablicaLudzi.GetLength(0); i++)
                tablicaLudzi[i] = spisPilkarzy[i].ToString();
            return tablicaLudzi;            
        }
        #endregion

        #region File functionality
        private string plik = "zapisDanych.xml";
        public void ZapisPilkarzyDoPliku()
        {
            FileStream primaryStream = new FileStream(plik, FileMode.Truncate);
            StreamWriter stream = new StreamWriter(primaryStream);
            stream.WriteLine("<pilkarze>");

            foreach (var pilkarz in spisPilkarzy)
            {
                stream.WriteLine("<pilkarz>");
                    stream.WriteLine("<imie>");
                        stream.WriteLine(pilkarz.getImie());
                    stream.WriteLine("</imie>");
                    stream.WriteLine("<nazwisko>");
                        stream.WriteLine(pilkarz.getNazwisko());
                    stream.WriteLine("</nazwisko>");
                    stream.WriteLine("<wiek>");
                        stream.WriteLine(pilkarz.getWiek().ToString());
                    stream.WriteLine("</wiek>");
                    stream.WriteLine("<waga>");
                        stream.WriteLine(pilkarz.getWaga().ToString());
                    stream.WriteLine("</waga>");    
                stream.WriteLine("</pilkarz>");
            }
            stream.Write("</pilkarze>");

            stream.Close();
            primaryStream.Close();
        }
        public void CzytajPilkarzyZPliku()
        {
            int licznik = 0;
            string imie = "";
            string nazwisko = "";
            uint wiek = 0;
            uint waga = 0;

            XmlTextReader tool = new XmlTextReader(plik);
            while (tool.Read())
            {
                if(tool.NodeType == XmlNodeType.Text)
                {
                    switch (licznik)
                    {
                        case 0:
                            imie = tool.Value;
                            break;
                        case 1:
                            nazwisko = tool.Value;
                            break;
                        case 2:
                            wiek = uint.Parse(tool.Value);
                            break;
                        case 3:                            
                            waga = uint.Parse(tool.Value);
                            break;
                    }
                    licznik++;
                }

                if(licznik == 4)
                {
                    licznik = 0;
                    imie = imie.Replace(Environment.NewLine, "");
                    nazwisko = nazwisko.Replace(Environment.NewLine, "");
                    spisPilkarzy.Add(new MPilkarz(imie, nazwisko, wiek, waga));
                }             
            }
            tool.Close();
        }
        #endregion
    }
}
