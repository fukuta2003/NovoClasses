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
      
            for(x=0; x < Campos.Length; x++)
            {
                listView1.Columns.Add(Campos[x].ToString(), 60, HorizontalAlignment.Left);
            }

            x = Campos.Length;
            int y = 0;

            while (dr.Read())
            {
                item = new ListViewItem(dr[Campos[0]].ToString());

                for(y=1;y < x;y++)
                {
                    item.SubItems.Add(dr[Campos[y]].ToString());
       
                }

                listView1.Items.Add(item);
               
            }


            listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.HeaderSize);

            for (y = 0; y < x; y++)
            {
                listView1.AutoResizeColumn(y, ColumnHeaderAutoResizeStyle.ColumnContent);
            }

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


    }
    
}
