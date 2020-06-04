using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

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

                string constring = "server=" + host + ";"
                                 + "database=" + DB + ";"
                                 + "user=" + user + ";"
                                 + "password=" + password;

                conn = new SqlConnection(constring);
            }
        }

}
