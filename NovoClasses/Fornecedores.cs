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
        Models.Validacao Funcoes = new Models.Validacao();


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
                lblOperacao.Text = "INCLUSÃO";
                gpoDados.Enabled = true;  // habilita o grupo de dados

            } else
            {
              
                if(Forn.Consulta(int.Parse(txtID.Text)))
                {
                    BuscaDados();
                    
                    // variavel para alterar
                    wp_Incluir = false; // (false atualizar dados > update)
                    lblOperacao.Text = "ALTERAÇÃO";
                    gpoDados.Enabled = true;  // habilita o grupo de dados
                    txtNome.Focus();

                } else
                {
                    MessageBox.Show("Fornecedor não encontrado !");
                    txtID.Focus();
                }

            }
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
                if(txtID.Text!="")
                {
                    SendKeys.SendWait("{TAB}");
                }
                
            }
        }


        private void BuscaDados() // Busca dados da classe
        {
            txtNome.Text = Forn.Nome.ToString();
            txtEndereco.Text = Forn.Endereco.ToString();
            txtBairro.Text = Forn.Bairro.ToString();
            txtCidade.Text = Forn.Cidade.ToString();
            cmbUF.Text = Forn.Estado.ToString();
            txtCep.Text = Forn.Cep.ToString();
            txtTelefone.Text = Forn.Telefone.ToString();
            txtCelular.Text = Forn.Celular.ToString();
            txtEmail.Text = Forn.Email.ToString();
            txtCNPJ.Text = Forn.Cnpj.ToString();
            txtIE.Text = Forn.Ie.ToString();
            txtOBS.Text = Forn.Obs.ToString();

            if (string.IsNullOrEmpty(Forn.Pessoa.ToString()))
            {
                cmbPessoa.Text = "JURÍDICA";
            } else
            {
                cmbPessoa.Text = Forn.Pessoa.ToString();
            }


        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtID_Enter(object sender, EventArgs e)
        {
            LimpaDados();
            gpoDados.Enabled = false;
            
        }

        private void LimpaDados()
        {
            txtNome.Text = "";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            cmbUF.Text = "";
            txtTelefone.Text = "";
            txtCelular.Text = "";
            txtEmail.Text = "";
            txtOBS.Text = "";
            txtCep.Text = "";
            txtCNPJ.Text = "";
            txtIE.Text = "";
            cmbPessoa.Text = "";


        }

        private void cmdSalvar_Click(object sender, EventArgs e)
        {
            if(Verifica())
            {
                Transporta_Dados_Classe();

                if (Forn.Salvar_Dados(wp_Incluir))
                {
                    MessageBox.Show("Dados Salvos com Sucesso !");
                    txtID.Focus();
                } else
                {
                    MessageBox.Show("Erro, problema sao salvar dados !");
                    gpoDados.Enabled = true;
                    txtNome.Focus();
                    return;
                }


            } else {
                MessageBox.Show("Alguns dados importantes não foram preenchidos !");
                txtID.Focus();
            }

            txtID.Focus();

        }

        private void Transporta_Dados_Classe()
        {
            if(!string.IsNullOrEmpty(txtID.Text))
            {
                Forn.Id = int.Parse(txtID.Text);
            }
            
            Forn.Nome = txtNome.Text;
            Forn.Endereco = txtEndereco.Text;
            Forn.Bairro = txtBairro.Text;
            Forn.Cidade = txtCidade.Text;
            Forn.Cep = txtCep.Text;
            Forn.Estado = cmbUF.Text;
            Forn.Telefone = txtTelefone.Text;
            Forn.Celular = txtCelular.Text;
            Forn.Email = txtEmail.Text;
            Forn.Pessoa = cmbPessoa.Text;
            Forn.Cnpj = txtCNPJ.Text;
            Forn.Ie = txtIE.Text;
            Forn.Obs = txtOBS.Text;

        }

        private bool Verifica()
        {
            bool xret = true;
            if(string.IsNullOrEmpty(txtNome.Text))
            {
                xret = false;
            } else if(string.IsNullOrEmpty(txtEndereco.Text))
            {
                xret = false;
            } else if (string.IsNullOrEmpty(txtBairro.Text))
            {
                xret = false;
            } else if (string.IsNullOrEmpty(txtCidade.Text))
            {
                xret = false;
            } else if (string.IsNullOrEmpty(txtCep.Text))
            {
                xret = false;
            }
            else if (string.IsNullOrEmpty(cmbUF.Text))
            {
                xret = false;
            }

            return xret;
        }

        private void Fornecedores_KeyDown(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode==Keys.Escape)
            {
            
                if (ActiveControl.Name.ToUpper() == "TXTID")
                {
                    e.Handled = true;
                    this.Close();

                } else
                {
                    LimpaDados();
                    gpoDados.Enabled = false;
                    txtID.Focus();

                }
            }
            


        }

        private void cmdExcluir_Click(object sender, EventArgs e)
        {
            if(Confirma("Posso Excluir esse Fornecedor ?"))
            {
                Forn.Apaga(int.Parse(txtID.Text));
                LimpaDados();
                gpoDados.Enabled = false;
                txtID.Focus();
            }
        }

        private bool Confirma(string Mensagem)
        {
            bool ret = true;
            DialogResult exemplo1 = MessageBox.Show(Mensagem.ToString(), "Confirme" , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exemplo1 == DialogResult.Yes)
            {
                ret = true;
            } else
            {
                ret = false;
            }
            return ret;
            
        }

        private void txtCNPJ_TextChanged(object sender, EventArgs e)
        {

            if (cmbPessoa.Text == "FÍSICA")
            {
                txtCNPJ.Text = Funcoes.Formata_CPF(txtCNPJ.Text);
                SendKeys.Send("{END}");
            }

            if (cmbPessoa.Text == "JURÍDICA")
            {
               txtCNPJ.Text = Funcoes.Formata_CNPJ(txtCNPJ.Text);
               SendKeys.Send("{END}");
            }

        }

        private void cmbPessoa_Click(object sender, EventArgs e)
        {

        }

        private void cmbPessoa_TextChanged(object sender, EventArgs e)
        {
            txtCNPJ.Focus();
        }

        private void cmbPessoa_Leave(object sender, EventArgs e)
        {
            if(cmbPessoa.Text == "FÍSICA")
            {
                lblCNPJ.Text = "CPF";
                lblIE.Text = "RG/CNH";
            } else
            {
                lblCNPJ.Text = "CNPJ";
                lblIE.Text = "I. Estadual";
            }
        }

        private void txtCep_TextChanged(object sender, EventArgs e)
        {
            txtCep.Text = Funcoes.Formata_Cep(txtCep.Text);
            SendKeys.SendWait("{END}");

        }

        private void txtTelefone_TextChanged(object sender, EventArgs e)
        {
            txtTelefone.Text = Funcoes.Formata_TelefoneFixo(txtTelefone.Text);
            SendKeys.SendWait("{END}");
        }

        private void txtCelular_TextChanged(object sender, EventArgs e)
        {
            txtCelular.Text = Funcoes.Formata_Celular(txtCelular.Text);
            SendKeys.SendWait("{END}");
        }
    }
}
