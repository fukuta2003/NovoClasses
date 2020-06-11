using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace NovoClasses.Models
{
        public class Conexao
        {
            public SqlConnection conn;

            public Conexao()  // FUNÇÃO DE CONEXÃO DO BANCO DE DADOS
            {
                string host = "192.168.1.250";

               // string host = "sqlserverflex.ddns.net"; // para acesso externo
                

                string DB = "OFICINA2";   // nome do banco de dados

                // string port = "1433";

                string user = "dev078";    // usuario do banco de dados
                string password = "etec078";  // senha do banco de dados

                string constring = "server=" + host + "; Connection Timeout=10 ;"
                                 + "database=" + DB + ";"
                                 + "user=" + user + ";"
                                 + "password=" + password;

                conn = new SqlConnection(constring);
                

            }


        public bool Conecta()
        {
            bool conecta = true;

            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.Open();
                    conecta = true;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Erro de Conexão com Banco de Dados !", ex.ToString());
                    conecta = false;
                }
                finally
                {
                    if (conecta == false)
                    {
                        Application.Exit();
                    }
                }

            }

            return conecta;

        }




    }

}
