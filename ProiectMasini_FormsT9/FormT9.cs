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
using System.IO;
using LibrarieModele;
using NivelAccesDate;
using ManagerM; 

namespace ProiectMasini_FormsT9
{
    public partial class FormT9 : Form
    {

        IStocareData adminMasini;
        ArrayList optiuniSelectate = new ArrayList();

        public FormT9()
        {
            InitializeComponent();
            adminMasini = ManagerMasini.GetAdministratorStocare();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormT9_Load(object sender, EventArgs e)
        {

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

        private int getTipMasina()
        {
            int optiuneCmb = tipCmbBox.SelectedIndex;

            return optiuneCmb;
        }

        private void adaugaBtn_Click(object sender, EventArgs e)
        {
            Masina masina;

            firmaLbl.ForeColor = Color.Black;
            modelLbl.ForeColor = Color.Black;
            anFLbl.ForeColor = Color.Black;
            culoareLbl.ForeColor = Color.Black;
            numeVanzatorLbl.ForeColor = Color.Black;
            numeCumparatorLbl.ForeColor = Color.Black;
            dataLbl.ForeColor = Color.Black;
            pretLbl.ForeColor = Color.Black;
            optiuniLbl.ForeColor = Color.Black;

            firmaTxt.ForeColor = Color.Black;
            modelTxt.ForeColor = Color.Black;
            anFTxt.ForeColor = Color.Black;
            //culoareTxt.ForeColor = Color.Black;
            numeVanzatorTxt.ForeColor = Color.Black;
            numeCumparatorTxt.ForeColor = Color.Black;
            dataTxt.ForeColor = Color.Black;
            pretTxt.ForeColor = Color.Black;
            //optiuniTxt.ForeColor = Color.Black;
            CodEroare valideaza = Validare(firmaTxt.Text, modelTxt.Text,
                //culoareTxt.Text,
                anFTxt.Text, numeVanzatorTxt.Text, numeCumparatorTxt.Text, dataTxt.Text, pretTxt.Text
                //, optiuniTxt.Text
                );
            if (GetCuloareSelectata() == Culori.culoare_inexistenta)
            {
                culoareLbl.ForeColor = Color.Red;
            }
            else
            if (validareOptiuni() == 0)
            {
                optiuniLbl.ForeColor = Color.Red;
            }
            else
            if (valideaza != CodEroare.CORECT)
            {
                switch (valideaza)
                {
                    case CodEroare.FIRMA_INCORECTA:
                        firmaTxt.ForeColor = Color.Red;
                        if (firmaTxt.Text == string.Empty)
                            firmaLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.MODEL_INCORECT:
                        modelTxt.ForeColor = Color.Red;
                        if (modelTxt.Text == string.Empty)
                            modelLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.AN_FABRICATIE_INCORECT:
                        anFTxt.ForeColor = Color.Red;
                        if (anFTxt.Text == string.Empty)
                            anFLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.NUME_VANZATOR_INCORECT:
                        numeVanzatorTxt.ForeColor = Color.Red;
                        if (numeVanzatorTxt.Text == string.Empty)
                            numeVanzatorLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.NUME_CUMPARATOR_INCORECT:
                        numeCumparatorTxt.ForeColor = Color.Red;
                        if (numeCumparatorTxt.Text == string.Empty)
                            numeCumparatorLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.DATA_INCORECTA:
                        dataTxt.ForeColor = Color.Red;
                        if (dataTxt.Text == string.Empty)
                            dataLbl.ForeColor = Color.Red;
                        break;
                    case CodEroare.PRET_INCORECT:
                        pretTxt.ForeColor = Color.Red;
                        if (pretTxt.Text == string.Empty)
                            pretLbl.ForeColor = Color.Red;
                        break;
                }
            }
            else
            {
                string tip = tipCmbBox.Text.Trim();
                string optiuniMasinaForm = OptiuniAsString();
                masina = new Masina(numeVanzatorTxt.Text.ToString(), numeCumparatorTxt.Text.ToString()
                , firmaTxt.Text.ToString(), modelTxt.Text.ToString(), Convert.ToInt32(anFTxt.Text.ToString()),
                "rosu", optiuniMasinaForm, dataTxt.Text.ToString(), Convert.ToDouble(pretTxt.Text.ToString()),tip,DateTime.Now);


                masina.CuloareMasina = GetCuloareSelectata();
                masina.identificaCuloare();

                


                masina.Optiuni = new ArrayList();
                masina.Optiuni.AddRange(optiuniSelectate);
                




                ManagerMasini.addMasina(masina);
                afisareLbl.Text = "Masina a fost adaugata";

                //ResetareControale();
            }
            ResetareControale();
        }

        private CodEroare Validare(string firma, string model,
            //string culoare,
            string anFabricatie,
                      string numeVanzator, string numeCumparator, string dataTranzactie, string pret
            //, string optiuni
            )
        {

            if (firma == string.Empty)
            {
                return CodEroare.FIRMA_INCORECTA;
            }
            else if (model == string.Empty)
            {
                return CodEroare.MODEL_INCORECT;
            }
            //else if (culoare == string.Empty)
            //{
            //    return CodEroare.CULOARE_INCORECTA;
            //}
            else if (anFabricatie == string.Empty)
            {
                return CodEroare.AN_FABRICATIE_INCORECT;
            }
            else if (numeVanzator == string.Empty)
            {
                return CodEroare.NUME_VANZATOR_INCORECT;
            }
            else if (numeCumparator == string.Empty)
            {
                return CodEroare.NUME_CUMPARATOR_INCORECT;
            }
            else if (dataTranzactie == string.Empty)
            {
                return CodEroare.DATA_INCORECTA;
            }
            else if (pret == string.Empty)
            {
                return CodEroare.PRET_INCORECT;
            }
            //else if (optiuni == string.Empty)
            //{
            //    return CodEroare.OPTIUNI_INCORECTE;
            //}


            return CodEroare.CORECT;
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

        private int validareOptiuni()
        {
            if (absCheck.Checked == false && airbagCheck.Checked == false && cruiseCheck.Checked == false &&
                solarCheck.Checked == false && bluetoothCheck.Checked == false && proiectoareCheck.Checked == false &&
                pilotCheck.Checked == false && masajCheck.Checked == false && leatherCheck.Checked == false)
                return 0;
            return 1;
        }

        private void ResetareControale()
        {
            firmaTxt.Text = string.Empty;
            modelTxt.Text = string.Empty;
            anFTxt.Text = string.Empty;
            numeVanzatorTxt.Text = string.Empty;
            numeCumparatorTxt.Text = string.Empty;
            dataTxt.Text = string.Empty;
            pretTxt.Text = string.Empty;
            albRdb.Checked = false;
            albastruRdb.Checked = false;
            rosuRdb.Checked = false;
            portocaliuRdb.Checked = false;
            negruRdb.Checked = false;
            verdeRdb.Checked = false;
            maroRdb.Checked = false;
            movRdb.Checked = false;
            galbenRdb.Checked = false;
            absCheck.Checked = false;
            airbagCheck.Checked = false;
            cruiseCheck.Checked = false;
            solarCheck.Checked = false;
            bluetoothCheck.Checked = false;
            proiectoareCheck.Checked = false;
            pilotCheck.Checked = false;
            masajCheck.Checked = false;
            leatherCheck.Checked = false;
            optiuniSelectate.Clear();
            //lblMesaj.Text = string.Empty;
        }

        private void afisareListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetareControale();
            Masina mas = adminMasini.GetMasinaByIndex(afisareListBox.SelectedIndex - 1);

            if (mas != null)
            {
                idLbl.Text = mas.getIdMasina().ToString();

                firmaTxt.Text = mas.firmaProp;
                modelTxt.Text = mas.modelProp;
                anFTxt.Text = mas.anFabricatie.ToString();

                if (mas.culoareProp == "alb")
                    albRdb.Checked = true;
                else
                    if (mas.culoareProp == "albastru")
                    albastruRdb.Checked = true;
                else
                    if (mas.culoareProp == "mov")
                    movRdb.Checked = true;
                else
                    if (mas.culoareProp == "galben")
                    galbenRdb.Checked = true;
                else
                    if (mas.culoareProp == "portocaliu")
                    portocaliuRdb.Checked = true;
                else
                    if (mas.culoareProp == "rosu")
                    rosuRdb.Checked = true;
                else
                    if (mas.culoareProp == "verde")
                    verdeRdb.Checked = true;
                else
                    if (mas.culoareProp == "maro")
                    maroRdb.Checked = true;
                else
                    if (mas.culoareProp == "negru")
                    negruRdb.Checked = true;
                numeVanzatorTxt.Text = mas.numeVanzator;
                numeCumparatorTxt.Text = mas.numeCumparator;
                dataTxt.Text = mas.dataTranzactie;
                pretTxt.Text = mas.pretProp.ToString();
                //tipCmbBox.Text = mas.tipMasina;
                

                foreach (var culoare in culoareGrpBox.Controls)
                {
                    if (culoare is RadioButton)
                    {
                        var culoareBox = culoare as RadioButton;
                        if (culoareBox.Text == mas.culoareProp.ToString())
                        {
                            culoareBox.Checked = true;
                        }
                    }
                }

                tipCmbBox.Text = mas.tipMasina.ToString();

                

                string[] optiuniSt = mas.OptiuniAsString.Split(',');

                if (mas.tipMasina.Trim().Equals("Sedan"))
                {
                    foreach (string opt in optiuniSt)
                    {
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
                    }

                }
                else if (mas.tipMasina.Trim().Equals("Sport"))
                {
                    foreach (string opt in optiuniSt)
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


                    }
                }
                else if (mas.tipMasina.Trim().Equals("SUV"))
                {
                    foreach (string opt in optiuniSt)
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
                    }



                }
                else if (mas.tipMasina.Trim().Equals("Lux"))
                {
                    foreach (string opt in optiuniSt)
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


                //txtNote.Text = String.Join(" ", s.GetNote());
            }
        }

        private void afisareBrn_Click(object sender, EventArgs e)
        {
            
            List<Masina> masini = new List<Masina>(ManagerMasini.getMasiniList());
            File.WriteAllText(@"C:\Users\sebyg\source\repos\ProiectMasiniPIU\ProiectMasiniPIU\MasiniSalvate.txt", String.Empty);

            afisareListBox.Items.Clear();
            var antetTabel = String.Format("{0,-8}{1,-30}{2,-30}{3,-20}{4,-15}{5,-15}{6,-14}{7,-20}{8,-10}\n", "Id", "Nume vanzator", "Nume cumparator", "Data tranzactie", "Firma", "Model", "Culoare", "An fabricatie", "Pret");
            afisareListBox.Items.Add(antetTabel);

            
            foreach (Masina m in masini)
            {
                int calculId = -8 - m.getIdMasina().ToString().Length + 1;
                int calculNumeVanzator = -30 - m.numeVanzator.Length + 10;
                int calculNumeCumparator = -30 - m.numeCumparator.Length + 7;
                int calculData = -20 - m.dataTranzactie.Length + 6;
                int calculFirma = -15 - m.firmaProp.Length + 4;
                int calculModel = -15 - m.modelProp.Length + 3;
                int calculCuloare = -14 - m.culoareProp.Length + 4;
                int calculAn = -20 - m.anFabricatie.ToString().Length + 2;
                int calculPret = -10 - m.pretProp.ToString().Length + 1;

                var mAfisare = String.Format("\n{0," + calculId.ToString() + "}{1," + calculNumeVanzator.ToString() + "}{2," + calculNumeCumparator.ToString() + "}{3," + calculData.ToString() + "}{4," + calculFirma.ToString() + "}{5," + calculModel.ToString() + "}{6," + calculCuloare.ToString() + "}{7," + calculAn.ToString() + "}{8," + calculPret.ToString() + "}\n",
                    m.getIdMasina().ToString(), m.numeVanzator, m.numeCumparator, m.dataTranzactie, m.firmaProp, m.modelProp, m.culoareProp, m.anFabricatie.ToString(), m.pretProp.ToString());
                afisareListBox.Items.Add(mAfisare);
                //afisareListBox.Items.Add("\t\t" + m.OptiuniAsString);
                //afisareListBox.Items.Add(Environment.NewLine);
                adminMasini.AddMasina(m);
                
            }
            afisareLbl.Text = "Lista cu masini a fost afisata";
        }

        private string getCuloareCautata()
        {
            if (albRdb.Checked == true)
                return "alb";
            if (albastruRdb.Checked == true)
                return "albastru";
            if (movRdb.Checked == true)
                return "mov";
            if (galbenRdb.Checked == true)
                return "galben";
            if (portocaliuRdb.Checked == true)
                return "portocaliu";
            if (rosuRdb.Checked == true)
                return "rosu";
            if (verdeRdb.Checked == true)
                return "verde";
            if (maroRdb.Checked == true)
                return "maro";
            if (negruRdb.Checked == true)
                return "negru";
            return string.Empty;
        }

        private void cautareBtn_Click(object sender, EventArgs e)
        {
            if (firmaTxt.Text == string.Empty && modelTxt.Text == string.Empty && numeVanzatorTxt.Text == string.Empty && numeCumparatorTxt.Text == string.Empty && GetCuloareSelectata() == Culori.culoare_inexistenta && dataTxt.Text == string.Empty && anFTxt.Text == string.Empty && pretTxt.Text == string.Empty && validareOptiuni() == 0)
            {
                afisareLbl.Text = "Introduceti datele corespunzatoare cautarii...";
            }
            else
            {
                afisareListBox.Items.Clear();
                List<Masina> cautari = new List<Masina>(ManagerMasini.CautareMasiniForms(firmaTxt.Text, modelTxt.Text,
                                        getCuloareCautata(), anFTxt.Text, numeVanzatorTxt.Text, numeCumparatorTxt.Text,
                                        dataTxt.Text, pretTxt.Text, "ABS"));

                var antetTabel = String.Format("{0,-8}{1,-30}{2,-30}{3,-20}{4,-15}{5,-15}{6,-14}{7,-20}{8,-10}\n", "Id", "Nume vanzator", "Nume cumparator", "Data tranzactie", "Firma", "Model", "Culoare", "An fabricatie", "Pret");
                afisareListBox.Items.Add(antetTabel);

                foreach (Masina m in cautari)
                {
                    int calculId = -8 - m.getIdMasina().ToString().Length + 1;
                    int calculNumeVanzator = -30 - m.numeVanzator.Length + 1;
                    int calculNumeCumparator = -30 - m.numeCumparator.Length + 1;
                    int calculData = -20 - m.dataTranzactie.Length + 9;
                    int calculFirma = -15 - m.firmaProp.Length + 4;
                    int calculModel = -15 - m.modelProp.Length + 6;
                    int calculCuloare = -14 - m.culoareProp.Length + 4;
                    int calculAn = -20 - m.anFabricatie.ToString().Length + 2;
                    int calculPret = -10 - m.pretProp.ToString().Length + 1;

                    var mAfisare = String.Format("\n{0," + calculId.ToString() + "}{1," + calculNumeVanzator.ToString() + "}{2," + calculNumeCumparator.ToString() + "}{3," + calculData.ToString() + "}{4," + calculFirma.ToString() + "}{5," + calculModel.ToString() + "}{6," + calculCuloare.ToString() + "}{7," + calculAn.ToString() + "}{8," + calculPret.ToString() + "}\n",
                        m.getIdMasina().ToString(), m.numeVanzator, m.numeCumparator, m.dataTranzactie, m.firmaProp, m.modelProp, m.culoareProp, m.anFabricatie.ToString(), m.pretProp.ToString());
                    afisareListBox.Items.Add(mAfisare);
                    //afisareRichTextBox.AppendText("\t\t" + m.OptiuniAsString);
                    afisareListBox.Items.Add(Environment.NewLine);
                }
                afisareLbl.Text = "Cautarile au fost efectuate";
                ResetareControale();
            }
        }

        private void editareBtn_Click(object sender, EventArgs e)
        {
            List<Masina> listaMasini = new List<Masina>(ManagerMasini.getMasiniList());

            afisareListBox.Items.Clear();
            var antetTabel = String.Format("{0,-8}{1,-30}{2,-30}{3,-20}{4,-15}{5,-15}{6,-14}{7,-20}{8,-10}\n", "Id", "Nume vanzator", "Nume cumparator", "Data tranzactie", "Firma", "Model", "Culoare", "An fabricatie", "Pret");
            afisareListBox.Items.Add(antetTabel);

            foreach (Masina m in listaMasini)
            {
                int calculId = -8 - m.getIdMasina().ToString().Length + 1;
                int calculNumeVanzator = -30 - m.numeVanzator.Length + 10;
                int calculNumeCumparator = -30 - m.numeCumparator.Length + 7;
                int calculData = -20 - m.dataTranzactie.Length + 6;
                int calculFirma = -15 - m.firmaProp.Length + 4;
                int calculModel = -15 - m.modelProp.Length + 3;
                int calculCuloare = -14 - m.culoareProp.Length + 4;
                int calculAn = -20 - m.anFabricatie.ToString().Length + 2;
                int calculPret = -10 - m.pretProp.ToString().Length + 1;

                var mAfisare = String.Format("\n{0," + calculId.ToString() + "}{1," + calculNumeVanzator.ToString() + "}{2," + calculNumeCumparator.ToString() + "}{3," + calculData.ToString() + "}{4," + calculFirma.ToString() + "}{5," + calculModel.ToString() + "}{6," + calculCuloare.ToString() + "}{7," + calculAn.ToString() + "}{8," + calculPret.ToString() + "}\n",
                    m.getIdMasina().ToString(), m.numeVanzator, m.numeCumparator, m.dataTranzactie, m.firmaProp, m.modelProp, m.culoareProp, m.anFabricatie.ToString(), m.pretProp.ToString());
                afisareListBox.Items.Add(mAfisare);
                afisareListBox.Items.Add("\t\t" + m.OptiuniAsString);
                afisareListBox.Items.Add(Environment.NewLine);
            }

            IdModifica idModifica = new IdModifica();
            idModifica.ShowDialog();
            int id = Convert.ToInt32(idModifica.getId());
            Masina masina = ManagerMasini.getMasina(id);

            afisareListBox.Items.Clear();

            int calculId1 = -8 - masina.getIdMasina().ToString().Length + 1;
            int calculNumeVanzator1 = -30 - masina.numeVanzator.Length + 10;
            int calculNumeCumparator1 = -30 - masina.numeCumparator.Length + 7;
            int calculData1 = -20 - masina.dataTranzactie.Length + 6;
            int calculFirma1 = -15 - masina.firmaProp.Length + 4;
            int calculModel1 = -15 - masina.modelProp.Length + 3;
            int calculCuloare1 = -14 - masina.culoareProp.Length + 4;
            int calculAn1 = -20 - masina.anFabricatie.ToString().Length + 2;
            int calculPret1 = -10 - masina.pretProp.ToString().Length + 1;

            var mAfisare1 = String.Format("\n{0," + calculId1.ToString() + "}{1," + calculNumeVanzator1.ToString() + "}{2," + calculNumeCumparator1.ToString() + "}{3," + calculData1.ToString() + "}{4," + calculFirma1.ToString() + "}{5," + calculModel1.ToString() + "}{6," + calculCuloare1.ToString() + "}{7," + calculAn1.ToString() + "}{8," + calculPret1.ToString() + "}\n",
                masina.getIdMasina().ToString(), masina.numeVanzator, masina.numeCumparator, masina.dataTranzactie, masina.firmaProp, masina.modelProp, masina.culoareProp, masina.anFabricatie.ToString(), masina.pretProp.ToString());
            afisareListBox.Items.Add(mAfisare1);
            afisareListBox.Items.Add("\t\t" + masina.OptiuniAsString);
            afisareListBox.Items.Add(Environment.NewLine);
        }

        private void ckbDiscipline_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBoxControl = sender as CheckBox; 

            string optiuneS = checkBoxControl.Text;

            if (checkBoxControl.Checked == true)
                optiuniSelectate.Add(optiuneS);
            else
                optiuniSelectate.Remove(optiuneS);
        }
    }
}
