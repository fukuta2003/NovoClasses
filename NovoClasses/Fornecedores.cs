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
    public partial class Fornecedores : Form
    {
        // como a classe e o formulario tem mesmo nome tive que referenciar
        // o models para diferenciar no estanciamento abaixo

        Models.Fornecedores Forn = new Models.Fornecedores();

        public bool wp_Incluir;

        public Fornecedores()
        {
            InitializeComponent();
        }

        private void Fornecedores_Load(object sender, EventArgs e)
        {

        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            if (txtID.Text=="")
            {
                gpoDados.Enabled = true;
                txtNome.Focus();
                // colocar variavel para incluir
                wp_Incluir = true; // (true inclui dados no banco de dados)

            } else
            {
              
                if(Forn.Consulta(int.Parse(txtID.Text)))
                {
                    txtNome.Text = Forn.Nome.ToString();
                    // variavel para alterar
                    wp_Incluir = false; // (false atualizar dados > update)
                    txtNome.Focus();
                } else
                {
                    MessageBox.Show("Fornecedor não encontrado !");
                    txtID.Focus();
                }

            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==13)
            {
                e.Handled = true;
                SendKeys.SendWait("{TAB}");
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                
                fShow fsw = new fShow("FORNECEDORES",
                    new string[] { "Id", "Nome", "Endereco", "Cidade" , "Cnpj", "Telefone", "Email"},"Nome");
                fsw.ShowDialog();
                txtID.Text = fsw.ParametroID.ToString();
                SendKeys.SendWait("{TAB}");
            }
        }
    }
}
