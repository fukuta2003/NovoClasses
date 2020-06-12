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
    public partial class fContasPagar_Baixa : Form
    {

        ContasPagar cp = new ContasPagar();
        Validacao Funcoes = new Validacao();

        public String ParametroID
        {
            get { return txtID.Text; }
            set { txtID.Text = value; }
        }

        public fContasPagar_Baixa()
        {
            InitializeComponent();
        }

        private void fContasPagar_Baixa_Load(object sender, EventArgs e)
        {
            cp.Id = int.Parse(txtID.Text);

            if (cp.ConsultaPagarID())
            {
                if(cp.Pago=="S")
                {
                    cmdBaixa.Text = "DEVOLVER";
                    txtPagamento.Text = cp.DataPagamento.ToString();

                } else
                {
                    cmdBaixa.Text = "BAIXAR";
                }

                txtEmissao.Text = cp.DataEmissao.ToString();
                txtVencimento.Text = cp.DataVencimento.ToString();
                lblFornecedor.Text = cp.Fornecedor_Nome.ToString();
                lblCentroCustos.Text = cp.CentroCusto_Descricao.ToString();
               
                txtJuros.Text = cp.Juros.ToString("N");
                txtDesconto.Text = cp.Desconto.ToString("N");
                txtValorBruto.Text = cp.ValorBruto.ToString("N");
                txtValorDocumento.Text = cp.ValorDocumento.ToString("N");
                txtJuros.Focus();

            } else
            {
                MessageBox.Show("ID de contas a pagar não encontrado !");
            }
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
            }
            else
            {
                xDesconto = double.Parse(txtDesconto.Text);
            }

            if (txtJuros.Text == "")
            {
                xJuros = 0;

            }
            else
            {
                xJuros = double.Parse(txtJuros.Text);
            }

            xBruto = double.Parse(txtValorBruto.Text);

            xTotal = (xBruto + xJuros) - xDesconto;

            txtValorDocumento.Text = xTotal.ToString("n");

        }

        private bool AnalisaMoeda(KeyPressEventArgs e)
        {
            //MessageBox.Show(e.KeyChar.ToString());
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
                MessageBox.Show("este campo aceita somente numero e virgula");
            }
            return e.Handled;
        }

        private void txtValorPago_Leave(object sender, EventArgs e)
        {
            txtValorPago.Text = Funcoes.Formata_Moeda(txtValorPago.Text);
         //   CalculaValorDocumento();
        }

        private void txtJuros_Leave(object sender, EventArgs e)
        {
            txtJuros.Text = Funcoes.Formata_Moeda(txtJuros.Text);
            CalculaValorDocumento();
        }

        private void txtDesconto_Leave(object sender, EventArgs e)
        {
            txtDesconto.Text = Funcoes.Formata_Moeda(txtDesconto.Text);
            CalculaValorDocumento();
        }

        private void txtJuros_KeyPress(object sender, KeyPressEventArgs e)
        {
            AnalisaMoeda(e);
            
        }

        private void txtDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            AnalisaMoeda(e);
            
        }

        private void txtValorPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            AnalisaMoeda(e);
            
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmdBaixa_Click(object sender, EventArgs e)
        {
            DialogResult xSimNao = MessageBox.Show("Confirma a Baixa ?", "Atenção", MessageBoxButtons.YesNo);
            if(xSimNao == DialogResult.Yes) 
            {
                TransfereDadosClasse();
                cp.Baixar();
            }

        }

        private void TransfereDadosClasse()
        {
            cp.DataPagamento = DateTime.Parse(txtPagamento.Text);
            cp.ValorDocumento = double.Parse(txtValorDocumento.Text);
            cp.Juros = double.Parse(txtJuros.Text);
            cp.Desconto = double.Parse(txtDesconto.Text);
            cp.ValorPago = double.Parse(txtValorPago.Text);
            cp.Pago = "S";
        }

    }
}
