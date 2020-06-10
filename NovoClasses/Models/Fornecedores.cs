using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

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
        public string Pessoa { get; set; }


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
            Pessoa = "";
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
            SqlCommand cmd = new SqlCommand(StrQuery, conn);
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
                    Pessoa = dr["pessoa"].ToString();

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

        public bool Salvar_Dados(bool pIncluir)
        {

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            String strquery;

            if (pIncluir)
            {
                // inclusao
                strquery = "INSERT INTO FORNECEDORES (" +
                        "nome," +
                        "endereco," +
                        "bairro," +
                        "cidade," +
                        "estado," +
                        "cep," +
                        "telefone," +
                        "celular," +
                        "email," +
                        "cnpj," +
                        "ie," +
                        "obs, pessoa) VALUES (@nome, @endereco, @bairro, @cidade," +
                        "@estado,@cep,@telefone,@celular,@email," +
                        "@cnpj,@ie,@obs,@pessoa)";
            }
            else
            {
                // ALTERACAO
                strquery = "UPDATE FORNECEDORES SET " +
                    "nome=@nome," +
                    "endereco=@endereco," +
                    "bairro=@bairro," +
                    "cidade=@cidade," +
                    "estado=@estado," +
                    "cep=@cep," +
                    "telefone=@telefone," +
                    "celular=@celular," +
                    "email=@email," +
                    "cnpj=@cnpj," +
                    "ie=@ie," +
                    "obs=@obs, pessoa=@pessoa WHERE id=" + Id;

            }
            SqlCommand cmd = new SqlCommand(strquery, conn);
            //  adiciona os dados da classe nos objetos do CMD
            cmd.Parameters.AddWithValue("@nome", Nome);
            cmd.Parameters.AddWithValue("@endereco", Endereco);
            cmd.Parameters.AddWithValue("@bairro", Bairro);
            cmd.Parameters.AddWithValue("@cidade", Cidade);
            cmd.Parameters.AddWithValue("@estado", Estado);
            cmd.Parameters.AddWithValue("@cep", Cep);
            cmd.Parameters.AddWithValue("@telefone", Telefone);
            cmd.Parameters.AddWithValue("@celular", Celular);
            cmd.Parameters.AddWithValue("@email", Email);
            cmd.Parameters.AddWithValue("@cnpj", Cnpj);
            cmd.Parameters.AddWithValue("@ie", Ie);
            cmd.Parameters.AddWithValue("@obs", Obs);
            cmd.Parameters.AddWithValue("@pessoa", Pessoa);

            // cmd.Parameters.AddWithValue("@baixa", DataPagamento);

            cmd.CommandType = CommandType.Text;

            // TENTA REALIZAR A INCLUSAO, CASO TENHA SUCESSO ELA SALVA OS DADOS E RETORNA (OK)
            // SE ALGUM ERRO ACONTECER, É CRIADA UMA EXCEPTION QUE MOSTRA NA TELA O ERRO OCORRIDO
            // E FINALMENTE (FINNALY) CONCLUI A OPERACAO.

            try
            {
                int i = cmd.ExecuteNonQuery();  // ESTA LINHA SALVA DOS DADOS NO BANCO DE DADOS E RETORNA QUANTAS LINHAS FORAM AFETADAS.
                if (i > 0)

                    return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro sistema: " + ex.ToString());
            }
            finally
            {
             
                conn.Close();
            }
            return false;

        }

        public bool Apaga(int pId)
        {
            bool ret = false;

            Inicializa();

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();

            }
            string StrQuery = "DELETE FROM Fornecedores WHERE Id = " + pId.ToString();
            SqlCommand cmd = new SqlCommand(StrQuery, conn);
            //cmd.CommandText = StrQuery;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            
            int i = cmd.ExecuteNonQuery();  // ESTA LINHA EXECUTA A QUERY DE DADOS E RETORNA QUANTAS LINHAS FORAM AFETADAS.
            if (i > 0) { 
               ret=true;  // deletou
            } else
            {
                ret=false;   // não deletou.
            }

            conn.Close();
            return ret;

        }

    }
}
