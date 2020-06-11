using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using NovoClasses.Models;


namespace NovoClasses
{
    public partial class fShow : Form
    {

        ListViewItem item;
        public string Tabela { get; set; }
        public string[] Campos { get; set; }
        public string Ordem { get; set; }


        public SqlConnection conn;
        public SqlDataReader dr;

        public String ParametroID
        {
            get { return txtID.Text; }
            set { txtID.Text = value; }
        }

        public fShow()
        {
            InitializeComponent();
        }

        // criando um construtor de sobre-carga para passar argumentos da tabela
        // e campos da tabela

        public fShow(string tabela, string[] campos, string ordem)
        {
            Tabela = tabela;
            Campos = campos;
            Ordem = ordem;
            
            InitializeComponent();

          
        }

        private void fShow_Load(object sender, EventArgs e)
        {

            listView1.View = System.Windows.Forms.View.Details;

            // monta cabeçario
            //listView1.Columns.Add("CODIGO", 60, HorizontalAlignment.Left);
            //listView1.Columns.Add("FORNECEDOR", 160, HorizontalAlignment.Left);


            // conexao com o banco de dados

            Conexao();

            AbreTabela(Tabela,Campos);

            int x = 0;
            // Monta Cabeçario da Listview
            for(x=0; x < Campos.Length; x++)
            {
                listView1.Columns.Add(Campos[x].ToString(), 60, HorizontalAlignment.Left);
                cmbPesquisa.Items.Add(Campos[x].ToString().ToUpper()); // adicionar os campos na combobox de pesquisa
            }

            int cols = listView1.Columns.Count;
            
            x = Campos.Length;
            int y = 0;
            string TipoDados = "";
            string Mascara = "";
            
            
            while (dr.Read())
            {
                
                item = new ListViewItem(dr[Campos[0]].ToString());

                for (y=1;y < x;y++)
                {
                    Mascara = "";
                    TipoDados = dr.GetDataTypeName(y).ToString();
                    
                    if (TipoDados.ToString()=="Date" || TipoDados == "DateTime")
                    {
                        Mascara = "dd/MM/yyyy";
                    }


                    item.SubItems.Add(dr[Campos[y]].ToString());
       
                }
               

                listView1.Items.Add(item);

            }
            
            int tamColunas = 0;

            if (tamColunas < 150)
            {
                tamColunas = 150;
            }

            
            for (y = 1; y < cols ; y++)
            {
                listView1.AutoResizeColumn(y, ColumnHeaderAutoResizeStyle.HeaderSize);
                listView1.AutoResizeColumn(y, ColumnHeaderAutoResizeStyle.ColumnContent);
                tamColunas = tamColunas + listView1.Columns[y].Width;
            }

            
            listView1.Width = tamColunas;

            int z = (listView1.Width);

            listView1.Columns[cols-1].Width = z;


            listView1.Focus();
            SendKeys.Send("{HOME}");
            this.Width = tamColunas + 40;
            
            // centraliza a tela depois de ter a chamado

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point((Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                          (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2);
            this.Refresh();
            //this.StartPosition = FormStartPosition.CenterScreen;

            
        }


        private void Conexao()
        {
            string host = "192.168.1.250";

            // string host = "sqlserverflex.ddns.net"; // para acesso externo


            string DB = "OFICINA2";   // nome do banco de dados

            string user = "dev078";    // usuario do banco de dados
            string password = "etec078";  // senha do banco de dados

            string constring = "server=" + host + ";"
                             + "database=" + DB + ";"
                             + "user=" + user + ";"
                             + "password=" + password;

            conn = new SqlConnection(constring);
        }

        private void AbreTabela(string pTabela, string[] pCampos)
        {

            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            // montando a string de SELECT de dados
            string strQuery = "SELECT ";
            foreach(string p in pCampos)
            {
                strQuery += p.ToString() + ",";
            }
            int TamanhoQuery = strQuery.Length;
            strQuery = strQuery.Substring(0, TamanhoQuery - 1); // retira a ultima (,)
            strQuery = strQuery + " FROM " + pTabela;

            if (!String.IsNullOrEmpty(Ordem)) // verifica se a string ORDEM é vazia ou nula
            {
                // Ñão sendo vazia incrementa na string do SELECT o comando ORDER BY para classificar a QUERY

                strQuery = strQuery + " ORDER BY " + Ordem; 
            }

            SqlCommand cmd = new SqlCommand(strQuery,conn);
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;

            dr = cmd.ExecuteReader();
           


            //MessageBox.Show(strQuery);

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            Finaliza();
        }

        private void listView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                e.Handled = true;
                Finaliza();

            }
        }

        private void Finaliza()
        {
            string xid = listView1.SelectedItems[0].Text;
            txtID.Text = xid.ToString();
            this.Close();

        }

        private void fShow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if(ActiveControl.Name.ToUpper()=="CMBPESQUISA")
                {
                    int xid = 0;
                    txtID.Text = "";
                    this.Close();

                } else
                {
                    cmbPesquisa.Focus();
                }

            }
        }
    }
    
}
