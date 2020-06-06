using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace NovoClasses.Models
{
    public class Fornecedores : Conexao
    {
        // objetos da classe (iguais ao banco de dados)
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Cnpj { get; set; }
        public string Ie { get; set; }
        public string Obs { get; set; }


        // objetos para uso com banco de dados

        public SqlDataReader dr;
         

        // Construtor Padrão sem argumentos
        public Fornecedores()
        {

        }

        // operaçoes com objetos

        public void Inicializa()
        {
            Id = 0;
            Nome = "";
            Endereco = "";
            Bairro = "";
            Cidade = "";
            Estado = "";
            Cep = "";
            Telefone = "";
            Celular = "";
            Email = "";
            Cnpj = "";
            Ie = "";
            Obs = "";
        }

        // operações com banco de dados 



        // Consulta --> CONSULTA POR ID os dados do fornecedor
        public bool Consulta(int pID)
        {
            bool ret = false;

            Inicializa();

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();

            }
            string StrQuery = "SELECT * FROM Fornecedores WHERE Id = " + pID.ToString();
            SqlCommand cmd = new SqlCommand(StrQuery,conn);
            //cmd.CommandText = StrQuery;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                if (dr["Id"].ToString() == pID.ToString())
                {
                    Nome = dr["nome"].ToString();
                    Endereco = dr["endereco"].ToString();
                    Bairro = dr["bairro"].ToString();
                    Cidade = dr["cidade"].ToString();
                    Estado = dr["estado"].ToString();
                    Cep = dr["cep"].ToString();
                    Telefone = dr["telefone"].ToString();
                    Celular = dr["celular"].ToString();
                    Email = dr["email"].ToString();
                    Cnpj = dr["cnpj"].ToString();
                    Ie = dr["ie"].ToString();
                    Obs = dr["obs"].ToString();

                    ret = true;
                }
                else
                {
                    Nome = "";
                    ret = false;
                }
            }

            conn.Close();
            return ret;

        }



    }
}
