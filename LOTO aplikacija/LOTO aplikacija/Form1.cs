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
    
    public partial class FrmLoto : Form
    {
        public FrmLoto()
        {
            InitializeComponent();
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
    }
}
