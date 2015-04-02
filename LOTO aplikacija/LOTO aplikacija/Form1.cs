using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LOTO_aplikacija
{
    public partial class FrmLoto : Form
    {
        private Loto loto;
        public FrmLoto()

        {
            InitializeComponent();
            loto = new Loto();
        }

    class Loto {  
        public List<int> DobitniBrojevi { get; set; }
        public List<int> UplaceniBrojevi { get; set; }
        /// <summary> 
        /// Konstruktor klase. 
        /// </summary>
        public Loto() 
        { 
          UplaceniBrojevi = new List<int>(); 
          DobitniBrojevi = new List<int>(); 

        
        }
        public bool UnesiUplaceneBrojeve(List<string> korisnickeVrijednosti)
        {
            bool ispravni = false;
            UplaceniBrojevi.Clear();
            foreach (string v in korisnickeVrijednosti)
            {
                int broj = 0;
                if (int.TryParse(v, out broj) == true)
                {
                    if (broj >= 1 && broj <= 39)
                    {
                        if (UplaceniBrojevi.Contains(broj) == false)
                        {
                            UplaceniBrojevi.Add(broj);
                        }
                    }
                }
            }
            if (UplaceniBrojevi.Count == 7)
            {
                ispravni = true;
            }
            return ispravni;
        }

        public void GenerirajDobitnuKombinaciju() 
        { 
            DobitniBrojevi.Clear();
            Random generatorBrojeva = new Random();
            while (DobitniBrojevi.Count < 7) 
            { 
                int broj = generatorBrojeva.Next(1, 39); 
                if (DobitniBrojevi.Contains(broj) == false) 
                { 
                    DobitniBrojevi.Add(broj); 
                } 
            } 
        }
        public int IzracunajBrojPogodaka() 
        { 
            int brojPogodaka = 0;
            foreach (int broj in UplaceniBrojevi) 
            { 
                if (DobitniBrojevi.Contains(broj) == true) 
                { 
                    brojPogodaka++; 
                } 
            } 
            return brojPogodaka; 
        }
    } 
    
    

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnUplati_Click(object sender, EventArgs e)
        {
            List<string> vrijednosti = new List<string>();
            vrijednosti.Add(txtUplaceniBroj1.Text);
            vrijednosti.Add(txtUplaceniBroj2.Text);
            vrijednosti.Add(txtUplaceniBroj3.Text);
            vrijednosti.Add(txtUplaceniBroj4.Text);
            vrijednosti.Add(txtUplaceniBroj5.Text);
            vrijednosti.Add(txtUplaceniBroj6.Text);
            vrijednosti.Add(txtUplaceniBroj7.Text);
            bool ispravnaKombinacija = loto.UnesiUplaceneBrojeve(vrijednosti);
            if (ispravnaKombinacija == true)
            { 
                btnOdigraj.Enabled = true; 
            } 
            else 
            { 
                btnOdigraj.Enabled = false; 
                MessageBox.Show("Kombinacija uplaćenih brojeva nije ispravna!"); 
            }
        }

        private void btnOdigraj_Click(object sender, EventArgs e)
        {
            loto.GenerirajDobitnuKombinaciju();
            txtDobitniBroj1.Text = loto.DobitniBrojevi[0].ToString();
            txtDobitniBroj2.Text = loto.DobitniBrojevi[1].ToString();
            txtDobitniBroj3.Text = loto.DobitniBrojevi[2].ToString();
            txtDobitniBroj4.Text = loto.DobitniBrojevi[3].ToString();
            txtDobitniBroj5.Text = loto.DobitniBrojevi[4].ToString();
            txtDobitniBroj6.Text = loto.DobitniBrojevi[5].ToString();
            txtDobitniBroj7.Text = loto.DobitniBrojevi[6].ToString();
            int brojPogodaka = loto.IzracunajBrojPogodaka();
            lblBrojPogodaka.Text = brojPogodaka.ToString();
        }
    }
}
