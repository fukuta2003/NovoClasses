using System;
using NovoClasses.Models;
using System.Windows.Forms;
using System.Collections.Generic;

namespace NovoClasses
{
    public partial class fContasPagar_Show : Form
    {
        ContasPagar cp = new ContasPagar();
        ListViewItem item;
        double TotalDocumentos = 0;
        int xId = 0;

        public String ParametroID
        {
            get { return txtID.Text; }
            set { txtID.Text = value;  }
        }

        public fContasPagar_Show()
        {
            InitializeComponent();
        }

        private void fContasPagar_Show_Load(object sender, EventArgs e)
        {

            cp.MontaGrade();
            
            CarregaDadosnaGrade();


        }


        public void CarregaDadosnaGrade()
        {
            
            foreach(ContasPagar c in cp.contas)
            {

                item = new ListViewItem(c.Id.ToString());

                item.SubItems.Add(c.Documento.ToString());
                item.SubItems.Add(c.Fornecedor.ToString());
                item.SubItems.Add(c.Fornecedor_Nome.ToString());
                item.SubItems.Add(c.DataEmissao.ToString("dd/MM/yyyy"));
                item.SubItems.Add(c.DataVencimento.ToString("dd/MM/yyyy"));
                item.SubItems.Add(c.DataPagamento.ToString("dd/MM/yyyy"));
                item.SubItems.Add(c.CentroCusto.ToString());
                item.SubItems.Add(c.ValorDocumento.ToString("n"));
                if(c.Pago=="SIM")
                {
                    item.SubItems.Add("Pago");

                } else
                {
                    item.SubItems.Add("Aberto");
                }
                TotalDocumentos += double.Parse(c.ValorDocumento.ToString());

                listView1.Items.Add(item);
            }

            lblTotalDocumentos.Text = TotalDocumentos.ToString("N");


            




        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            xId = int.Parse(listView1.SelectedItems[0].Text);
            txtID.Text = xId.ToString();

            this.Close();

                        // lblMensagem.Text += "   -  " + listView1.SelectedItems[0].SubItems[1].Text;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void txtFornecedor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFornecedor_Leave(object sender, EventArgs e)
        {


            if (cp.ConsultaFornecedorID(int.Parse(txtFornecedor.Text)))
            {
                lblFornecedor.Text = cp.Fornecedor_Nome.ToString();
            } else
            {
                MessageBox.Show("Fornecedor não encontrado !");
                txtFornecedor.Focus();

            }
            
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
