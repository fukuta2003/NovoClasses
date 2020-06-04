using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using NovoClasses.Models;


namespace NovoClasses
{
    public partial class fContasPagar : Form
    {

        public SqlDataReader dr;

        DateTime DataHoje;

        // ***********
        // variavel para controlar se vai incluir dados ou somente consultar / alterar
        // caso o usuario clique no botão salvar

        bool wpIncluir = true;
        
        // quando ela estiver TRUE vai incluir, se tiver FALSE vai somente alterar
        // esse controle TRUE ou FALSE é alterado no EVENTO txtID_LEAVE

        // *************

        ContasPagar cp3 = new ContasPagar();  // instancia um objeto da  classe sem argumentos

        public fContasPagar()
        {
            InitializeComponent();
        }

        private void fContasPagar_Load(object sender, EventArgs e)
        {
            cp3.CarregaFornecedores();
            cp3.CarregaCentroCustos();

            cmbFornecedores.Items.AddRange(cp3.wlFornecedores.ToArray());
            cmbCentroCustos.Items.AddRange(cp3.wlCentroCustos.ToArray());


            /*
            foreach (string i in cp3.wlFornecedores)
            {
                if (i != null)
                {
                    cmbFornecedores.Items.Add(i);
                }
             }
             */


            /*
            cmbCentroCustos.Items.Add("001.001 - DESPESAS DIVERSAS");
            cmbCentroCustos.Items.Add("001.002 - ENERGIA ELÉTRICA");
            cmbCentroCustos.Items.Add("001.003 - TELEFONIA E INTERNET");
            cmbCentroCustos.Items.Add("001.004 - ÁGUA - SABESP");
            cmbCentroCustos.Items.Add("001.005 - AUTOMÓVEIS");
            */


          
            DataHoje = DateTime.Today;
            txtData.Text = DataHoje.ToString("dd/MM/yyyy");
            cp3.Documento = "";
            txtDocumento.Text = cp3.Documento.ToString();
            
        }

              

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
          
           
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
                        
            if (Verifica()==true)
            {
                InsereDadosnaClasse();
                cp3.InserirDados(wpIncluir);
                
            } else
            {
                MessageBox.Show("Erro, existem campos obrigatórios em Branco !");
                txtDocumento.Focus();
            }


        }

        private void InsereDadosnaClasse()
        {
            cp3.Data = DateTime.Parse(txtData.Text);
            cp3.Documento = txtDocumento.Text;
            cp3.Fornecedor = int.Parse(txtFornecedor.Text);
            cp3.Fornecedor_Nome = lblFornecedor.Text;
            cp3.DataEmissao = DateTime.Parse(txtEmissao.Text);
            cp3.DataVencimento = DateTime.Parse(txtVencimento.Text);
            
            // data pagamento nao utiliza na inclusao

            cp3.ValorBruto = double.Parse(txtValorBruto.Text);
            cp3.Desconto = double.Parse(txtDesconto.Text);
            cp3.Juros = double.Parse(txtJuros.Text);
            cp3.ValorDocumento = double.Parse(lblTotalDocumento.Text);

            cp3.CentroCusto = txtCentrodeCustos.Text;
            cp3.CentroCusto_Descricao = lblCentrodeCustos.Text;

            cp3.Historico = txtHistorico.Text;


        }

        private void btnBaixar_Click(object sender, EventArgs e)
        {

        }

       
        private void txtFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            if (e.KeyChar == 13)
            {
                cp3.Fornecedor_Nome = "";

               if (txtFornecedor.Text=="")
                {
                    MessageBox.Show("Fornecedor inválido !");
                    txtFornecedor.Focus();
                } else
                {
                    cp3.ConsultaFornecedorID(int.Parse(txtFornecedor.Text));
                    if(cp3.Fornecedor_Nome != "")
                    {
                        lblFornecedor.Text = cp3.Fornecedor_Nome.ToString();
                        txtEmissao.Focus();
                    } else
                    {
                        MessageBox.Show("Código não encontrado !");
                        txtFornecedor.Focus();
                        
                    }
                    
                }

                
            }
        }

        // PROXIMA AULA, ALTERAR O EVENTO PARA BOOLEAN, PARA CAPTARMOS SE HOUVE ALGUM ERRO
        // E NAO PERMITIR SALVAR OS DADOS.
        public Boolean Verifica()
        {
            Boolean xret = true;

            if (txtData.Text == "")
            {
                xret = false;
            }

            if (txtDocumento.Text == "")
            {
                xret = false;
            }

            if (txtFornecedor.Text == "")
            {
                xret = false;
            }

            if (txtEmissao.Text == "")
            {
                xret = false;
            }

            if (txtVencimento.Text == "")
            {
                xret = false;
            }

            if (txtValorBruto.Text == "")
            {
                xret = false;
            }
            
            
            if (lblTotalDocumento.Text == "")
            {
                xret = false;
            }
            

            if (txtCentrodeCustos.Text == "")
            {
                xret = false;
            }

            if (txtHistorico.Text == "")
            {
                xret = false;
            }

            return xret;

        }

        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 13)
            {
                cp3.Documento = txtDocumento.Text;
                txtFornecedor.Focus();
            }
        }

        private void txtDocumento_Leave(object sender, EventArgs e)
        {
            if (txtDocumento.Text == "") {
                MessageBox.Show("Documento em Branco !");
                txtDocumento.Focus();
            }
        }

        private void txtDocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            gpoDoc.Visible = false;
            txtDocumento.Focus();
        }

        private void fContasPagar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Escape)
            {
                MessageBox.Show("ESC PRESSIONADA NO FORMULARIO TODO");
            }
        }

        private void txtFornecedor_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {
                cmbFornecedores.Visible = true;
                cmbFornecedores.Focus();

            }
        }

        private void cmbCentroCustos_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtCentrodeCustos_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCentrodeCustos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                cmbCentroCustos.Visible = true;
                cmbCentroCustos.Focus();
            }
        }

        private void txtFornecedor_Click(object sender, EventArgs e)
        {
            cmbFornecedores.Visible = false;

        }

        private void txtCentrodeCustos_Click(object sender, EventArgs e)
        {
            cmbCentroCustos.Visible = false;
        }

        private void cmbCentroCustos_TextChanged(object sender, EventArgs e)
        {

            string xNome = cmbCentroCustos.Text;
            txtCentrodeCustos.Text = xNome.Substring(0, 7).ToString();
            lblCentrodeCustos.Text = xNome.Substring(8, xNome.Length - 8).ToString();
            cmbCentroCustos.Visible = false;
            txtHistorico.Focus();

           // lblCentrodeCustos.Text = cmbCentroCustos.Text;
           //  cmbCentroCustos.Visible = false;
        }

        private void txtDocumento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                MessageBox.Show("TECLA <F1> PRESSIONADA");
            }
            else if (e.KeyCode == Keys.F2)
            {
                MessageBox.Show("<F2> Abrindo GPO");
                gpoDoc.Visible = true;
            }
        }

        private void txtFornecedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmbFornecedores_TextChanged(object sender, EventArgs e)
        {
            string xNome = cmbFornecedores.Text;
            txtFornecedor.Text = xNome.Substring(0, 5).ToString();
            lblFornecedor.Text = xNome.Substring(6, xNome.Length - 6).ToString();
            cmbFornecedores.Visible = false;
            txtEmissao.Focus();
        }

        private void txtFornecedor_Leave(object sender, EventArgs e)
        {
            SendKeys.SendWait("{ENTER}");
        }

        private void txtEmissao_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmissao_Leave(object sender, EventArgs e)
        {
           txtEmissao.Text = string.Format("dd / MM / aaaa", txtEmissao.Text);
        }

        private void txtValorBruto_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void txtValorBruto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // (!Char.IsDigit(e.KeyChar) ---> se não foi um número ou seja de 0 a 9
            // e.KeyChar != (char)8  --> se tambem nao foi o BACKSPACE (CARACTER 8)
            // e.KeyChar == '.' -->


            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar == '.') {

                e.Handled = true;
            }
        }

        private void txtValorBruto_Leave(object sender, EventArgs e)
        {
            if (txtValorBruto.Text == "")
            {
                txtValorBruto.Text = "0.00";
            }

            txtValorBruto.Text = Convert.ToDouble(txtValorBruto.Text).ToString("n");
            CalculaValorDocumento();
        }

        private void txtCentrodeCustos_Leave(object sender, EventArgs e)
        {
            if(txtCentrodeCustos.Text != "") { 
                cp3.ConsultaCentroCustosID(txtCentrodeCustos.Text);
                lblCentrodeCustos.Text = cp3.CentroCusto_Descricao.ToString();
            }
            
        }

        private void cmbFornecedores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbCentroCustos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtJuros_Leave(object sender, EventArgs e)
        {
            if(txtJuros.Text=="")
            {
                txtJuros.Text = "0.00";
            }
            txtJuros.Text = Convert.ToDouble(txtJuros.Text).ToString("N");
            CalculaValorDocumento();
        }

        private void txtDesconto_Leave(object sender, EventArgs e)
        {
            if(txtDesconto.Text=="")
            {
                txtDesconto.Text = "0.00";
            }
            txtDesconto.Text = Convert.ToDouble(txtDesconto.Text).ToString("N");
            CalculaValorDocumento();
        }

        private void txtDesconto_TextChanged(object sender, EventArgs e)
        {

        }

        private void CalculaValorDocumento()
        {
            double xBruto = 0;
            double xJuros = 0;
            double xDesconto = 0;
            double xTotal = 0;
            if (txtDesconto.Text == "")
            {
                xDesconto = 0;
            } else
            {
                xDesconto = double.Parse(txtDesconto.Text);
            }

            if (txtJuros.Text == "")
            {
                xJuros = 0;

            } else
            {
                xJuros = double.Parse(txtJuros.Text);
            }

            xBruto = double.Parse(txtValorBruto.Text);

            xTotal = (xBruto + xJuros) - xDesconto;

            lblTotalDocumento.Text = xTotal.ToString("n");

        }

        private void txtID_Leave(object sender, EventArgs e)
        {
            // CRIAR O PROCEDIMENTO PARA DETECTAR 
            // CADASTRAR OU ALTERAR

            if(txtID.Text=="")
            {
                wpIncluir = true; // INCLUIR AO CLICAR EM SALVAR
            } else
            {
                cp3.Id = int.Parse(txtID.Text);
                cp3.ConsultaPagarID();
                // apos fazer a consulta devemos buscar os dados da classe e colocar no formulario
                // chamando a funcao BuscaDados();
                BuscaDados();
                wpIncluir = false; // ALTERAR AO CLICAR EM SALVAR
            }

        }


        private void BuscaDados()
        {
            txtData.Text = cp3.Data.ToString();
            txtDocumento.Text = cp3.Documento.ToString();
            txtFornecedor.Text = cp3.Fornecedor.ToString();
            lblFornecedor.Text = cp3.Fornecedor_Nome.ToString();
            txtEmissao.Text = cp3.DataEmissao.ToString();
            txtVencimento.Text = cp3.DataVencimento.ToString();
            txtValorBruto.Text = cp3.ValorBruto.ToString("n");
            txtJuros.Text = cp3.Juros.ToString("n");
            txtDesconto.Text = cp3.Desconto.ToString("n");
            lblTotalDocumento.Text = cp3.ValorDocumento.ToString("n");
            txtCentrodeCustos.Text = cp3.CentroCusto.ToString();
            lblCentrodeCustos.Text = cp3.CentroCusto_Descricao.ToString();
            txtHistorico.Text = cp3.Historico.ToString();

            

        }
        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
