using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pastic
{
    public partial class Form1 : Form
    {
        cakes Cakes = new cakes();
        public Form1()
        {
            InitializeComponent();
            Cakes.DataSource = Cakes.GetDolci();
        }

       
        //the add button adds the details that are required and saved in the pasticerria database
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Cakes.cakeID = cakeID.Text;
            Cakes.cakeName = priceTxt.Text;
            Cakes.cakeIngredients = buyTxt.Text;
            Cakes.cakePrice = totalTx.Text;
            
            
            var success = Cakes.Insertcakes(Cakes);
            
            //if else to display if the adding of the value was succesfull
            if (success)
                MessageBox.Show("Dolce aggiunto");
            else 
                MessageBox.Show("Riprova");


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Cakes.cakeID = cakeID.Text;
            Cakes.cakeName = priceTxt.Text;
            Cakes.cakeIngredients = buyTxt.Text;
            Cakes.cakePrice = btnUpdate.Text;


            var success = Cakes.Insertcakes(Cakes);
            Cakes.DataSource = Cakes.GetDolci();

            if (success)
                MessageBox.Show("Dolce aggiunto");
            else
                MessageBox.Show("Riprova");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
