using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using ManagerM;
using LibrarieModele;
using NivelAccesDate;

namespace ProiectMasini_FormsT9
{
    public partial class Modifica : Form
    {

        ArrayList optiuniSelectate = new ArrayList();

        public int idMasinaModificata{ get; set; }

        public Modifica(int id)
        {
            InitializeComponent();

            

            idMasinaModificata = id;

            Masina masina = ManagerMasini.getMasina(id);

            masina.Optiuni = new ArrayList();
            masina.Optiuni.AddRange(optiuniSelectate);

            firmaTxt.Text = masina.firmaProp;
            modelTxt.Text = masina.modelProp;
            anFTxt.Text = masina.anFabricatie.ToString();
            if (masina.culoareProp.Trim().Equals("alb"))
                albRdb.Checked = true;
            else if (masina.culoareProp.Trim().Equals("albastru"))
                albastruRdb.Checked = true;
            else if (masina.culoareProp.Trim().Equals("mov"))
                movRdb.Checked = true;
            else if (masina.culoareProp.Trim().Equals("galben"))
                galbenRdb.Checked = true;
            else if (masina.culoareProp.Trim().Equals("portocaliu"))
                portocaliuRdb.Checked = true;
            else if (masina.culoareProp.Trim().Equals("rosu"))
                rosuRdb.Checked = true;
            else if (masina.culoareProp.Trim().Equals("verde"))
                verdeRdb.Checked = true;
            else if (masina.culoareProp.Trim().Equals("maro"))
                maroRdb.Checked = true;
            else if (masina.culoareProp.Trim().Equals("negru"))
                negruRdb.Checked = true;

            numeCumparatorTxt.Text = masina.numeCumparator;
            numeVanzatorTxt.Text = masina.numeVanzator;
            pretTxt.Text = masina.pretProp.ToString();
            dataTxt.Text = masina.dataTranzactie;
            tipCmbBox.Text = masina.tipMasina.ToString();

            string[] optiuniMasinaCautata = masina.OptiuniAsString.Split(',');
            foreach (string opt in optiuniMasinaCautata)
            {
                if (tipCmbBox.Text.Trim().Equals("Sedan")){
                    if (opt.Trim().Equals("ABS"))
                        absCheck.Checked = true;
                    if (opt.Trim().Equals("Airbaguri laterale"))
                        airbagCheck.Checked = true;
                    if (opt.Trim().Equals("Cruise Control"))
                        cruiseCheck.Checked = true;
                    if (opt.Trim().Equals("Solar Roof"))
                        solarCheck.Checked = true;
                    if (opt.Trim().Equals("Conectivitate Bluetooth"))
                        bluetoothCheck.Checked = true;
                    if (opt.Trim().Equals("Proiectoare ceata"))
                        proiectoareCheck.Checked = true;
                    if (opt.Trim().Equals("Pilot automat"))
                        pilotCheck.Checked = true;
                    if (opt.Trim().Equals("Scaune masaj"))
                        masajCheck.Checked = true;
                    if (opt.Trim().Equals("Full Leather"))
                        leatherCheck.Checked = true;
                }else if (tipCmbBox.Text.Trim().Equals("Sport"))
                {
                    
                    if (opt.Trim().Equals("WiFi Hotspot"))
                        absCheck.Checked = true;
                    if (opt.Trim().Equals("Pachet Alcantara"))
                        airbagCheck.Checked = true;
                    if (opt.Trim().Equals("Cruise Control"))
                        cruiseCheck.Checked = true;
                    if (opt.Trim().Equals("Solar Roof"))
                        solarCheck.Checked = true;
                    if (opt.Trim().Equals("Fibra de carbon"))
                        bluetoothCheck.Checked = true;
                    if (opt.Trim().Equals("Frane ceramice"))
                        proiectoareCheck.Checked = true;
                    if (opt.Trim().Equals("Camere laterale"))
                        pilotCheck.Checked = true;
                    if (opt.Trim().Equals("Smart Suspension"))
                        masajCheck.Checked = true;
                    if (opt.Trim().Equals("Volan piele"))
                        leatherCheck.Checked = true;
                }else if (tipCmbBox.Text.Trim().Equals("SUV"))
                {
                    
                    if (opt.Trim().Equals("Track Pace"))
                        absCheck.Checked = true;
                    if (opt.Trim().Equals("Airbaguri laterale"))
                        airbagCheck.Checked = true;
                    if (opt.Trim().Equals("Full Leather"))
                        cruiseCheck.Checked = true;
                    if (opt.Trim().Equals("Keyless Entry"))
                        solarCheck.Checked = true;
                    if (opt.Trim().Equals("Conectivitate Bluetooth"))
                        bluetoothCheck.Checked = true;
                    if (opt.Trim().Equals("Head-Up Display"))
                        proiectoareCheck.Checked = true;
                    if (opt.Trim().Equals("Power Tailgate"))
                        pilotCheck.Checked = true;
                    if (opt.Trim().Equals("Scaune masaj"))
                        masajCheck.Checked = true;
                    if (opt.Trim().Equals("Volan piele"))
                        leatherCheck.Checked = true;
                }else if (tipCmbBox.Text.Trim().Equals("Lux"))
                {
                    
                    if (opt.Trim().Equals("Bara spate"))
                        absCheck.Checked = true;
                    if (opt.Trim().Equals("Airbaguri laterale"))
                        airbagCheck.Checked = true;
                    if (opt.Trim().Equals("Cruise Control"))
                        cruiseCheck.Checked = true;
                    if (opt.Trim().Equals("Solar Roof"))
                        solarCheck.Checked = true;
                    if (opt.Trim().Equals("Head-Up Display"))
                        bluetoothCheck.Checked = true;
                    if (opt.Trim().Equals("Keyless Entry"))
                        proiectoareCheck.Checked = true;
                    if (opt.Trim().Equals("Pilot automat"))
                        pilotCheck.Checked = true;
                    if (opt.Trim().Equals("Scaune masaj"))
                        masajCheck.Checked = true;
                    if (opt.Trim().Equals("Full Leather"))
                        leatherCheck.Checked = true;
                }

            }
        }

        

        private void Modifica_Load(object sender, EventArgs e)
        {

        }
        private Culori GetCuloareSelectata()
        {
            if (albRdb.Checked)
                return Culori.alb;
            if (albastruRdb.Checked)
                return Culori.albastru;
            if (movRdb.Checked)
                return Culori.mov;
            if (maroRdb.Checked)
                return Culori.maro;
            if (portocaliuRdb.Checked)
                return Culori.portocaliu;
            if (negruRdb.Checked)
                return Culori.negru;
            if (galbenRdb.Checked)
                return Culori.galben;
            if (verdeRdb.Checked)
                return Culori.verde;
            if (rosuRdb.Checked)
                return Culori.rosu;

            return Culori.culoare_inexistenta;
        }

        public string OptiuniAsString()
        {

            string strOptiuni = string.Empty;

            foreach (string optiune in optiuniSelectate)
            {
                if (strOptiuni != string.Empty)
                {
                    strOptiuni += ", ";
                }
                strOptiuni += optiune;
            }

            return strOptiuni;

        }

        private void editareBtn_Click(object sender, EventArgs e)
        {
            Masina masina = ManagerMasini.getMasina(idMasinaModificata);
            masina.firmaProp = firmaTxt.Text;
            masina.modelProp = modelTxt.Text;
            masina.anFabricatie = Convert.ToInt32(anFTxt.Text);
            masina.CuloareMasina = GetCuloareSelectata();
            masina.identificaCuloare();
            masina.numeVanzator = numeVanzatorTxt.Text;
            masina.numeCumparator = numeCumparatorTxt.Text;
            masina.dataTranzactie = dataTxt.Text;
            masina.pretProp = Convert.ToDouble(pretTxt.Text);
            masina.tipMasina = tipCmbBox.Text;
            if (OptiuniAsString() != string.Empty)
                masina.setOptiuni(OptiuniAsString());

            this.Close();
        }

        private void ckbDiscipline_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBoxControl = sender as CheckBox; //operator 'as'
            //sau
            //CheckBox checkBoxControl = (CheckBox)sender;  //operator cast

            string optiuneSelectata = checkBoxControl.Text;

            //verificare daca checkbox-ul asupra caruia s-a actionat este selectat
            if (checkBoxControl.Checked == true)
                optiuniSelectate.Add(optiuneSelectata);
            else
                optiuniSelectate.Remove(optiuneSelectata);
        }

        private void tipCmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int optiuneCmb = tipCmbBox.SelectedIndex;

            if (optiuneCmb == 0)
            {
                absCheck.Text = "ABS";
                airbagCheck.Text = "Airbaguri laterale";
                cruiseCheck.Text = "Cruise Control";
                solarCheck.Text = "Solar Roof";
                bluetoothCheck.Text = "Conectivitate Bluetooth";
                proiectoareCheck.Text = "Proiectoare ceata";
                pilotCheck.Text = "Pilot automat";
                masajCheck.Text = "Scaune masaj";
                leatherCheck.Text = "Full Leather";
            }
            if (optiuneCmb == 1)
            {
                absCheck.Text = "WiFi Hotspot";
                airbagCheck.Text = "Pachet Alcantara";
                cruiseCheck.Text = "Cruise Control";
                solarCheck.Text = "Solar Roof";
                bluetoothCheck.Text = "Fibra de carbon";
                proiectoareCheck.Text = "Frane ceramice";
                pilotCheck.Text = "Camere laterale";
                masajCheck.Text = "Smart Suspension";
                leatherCheck.Text = "Volan piele";
            }
            if (optiuneCmb == 2)
            {
                absCheck.Text = "Track Pace";
                airbagCheck.Text = "Airbaguri laterale";
                cruiseCheck.Text = "Full Leather";
                solarCheck.Text = "Keyless Entry";
                bluetoothCheck.Text = "Conectivitate Bluetooth";
                proiectoareCheck.Text = "Head-Up Display";
                pilotCheck.Text = "Power Tailgate";
                masajCheck.Text = "Scaune masaj";
                leatherCheck.Text = "Volan piele";
            }
            if (optiuneCmb == 3)
            {
                absCheck.Text = "Bara spate";
                airbagCheck.Text = "Airbaguri laterale";
                cruiseCheck.Text = "Cruise Control";
                solarCheck.Text = "Solar Roof";
                bluetoothCheck.Text = "Head-Up Display";
                proiectoareCheck.Text = "Keyless Entry";
                pilotCheck.Text = "Pilot automat";
                masajCheck.Text = "Scaune masaj";
                leatherCheck.Text = "Full Leather";
            }
        }
    }
}
