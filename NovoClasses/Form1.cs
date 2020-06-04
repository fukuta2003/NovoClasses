using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NovoClasses.Models;

namespace NovoClasses
{
    public partial class Form1 : Form
    {
        Clientes cli = new Clientes("ETEC JULIO CARDOSO", "RUA TAL", "FRANCA");

        Clientes cl2 = new Clientes("FERNANDO", "R 5", "RIBEIRAO PRETO");
        Clientes cl3 = new Clientes("RONALDO", "R 4", "RIBEIRAO PRETO");
        Clientes cl4 = new Clientes("LEANDRO", "R 3", "RIBEIRAO PRETO");
        Clientes cl5 = new Clientes("RICARDO", "R 2", "RIBEIRAO PRETO");
        Clientes cl6 = new Clientes("JOSE", "R 1", "GUAIRA");

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cli.Limite = 500;
            cli.Estado = "SP";
            cli.Telefone = "(16)99388-4682";
            MessageBox.Show(cli.Telefone);
            txtNome.Text = cl6.Nome;
            cl6.SemLimite();
            txtLimite.Text = cl6.Limite.ToString();

            // 08-05-2020 - finalizamos aqui !!!

            comboBox1.Items.Add(cli.Nome);
            comboBox1.Items.Add(cl2.Nome);
            comboBox1.Items.Add(cl3.Nome);
            comboBox1.Items.Add(cl4.Nome);
            comboBox1.Items.Add(cl5.Nome);
            comboBox1.Items.Add(cl6.Nome);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            cl6.DefinirLimite(double.Parse(txtLimite.Text));
            double wlLimite = cl6.DefinirLimite(double.Parse(txtLimite.Text));
            MessageBox.Show(wlLimite.ToString());
            // MessageBox.Show(cl6.Limite.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cl6.AumentarLimite();
            txtLimite.Text = cl6.Limite.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
