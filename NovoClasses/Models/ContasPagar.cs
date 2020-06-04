using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;

namespace NovoClasses.Models
{
    class ContasPagar : Conexao
    {

        public int Id { get; set; }
        public DateTime Data { get; set; }
        public String Documento { get; set; }
        public int Fornecedor { get; set; }
        public String Fornecedor_Nome { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public double ValorBruto { get; set; }
        public double Juros { get; set; }
        public double Desconto { get; set; }
        public double ValorDocumento { get; set; }
        public String CentroCusto { get; set; }
        public String CentroCusto_Descricao { get; set; }
        public String Historico { get; set; }
      
        public ArrayList wlFornecedores = new ArrayList();
        public ArrayList wlCentroCustos = new ArrayList();
      

        public SqlDataReader dr;

        //construtor da classe

        public ContasPagar()
        {

        }
        public ContasPagar(string documento, int fornecedor, DateTime dataEmissao, DateTime dataVencimento, double valorBruto, string centroCusto, string historico)
        {
            Documento = documento;
            Fornecedor = fornecedor;
            DataEmissao = dataEmissao;
            DataVencimento = dataVencimento;
            ValorBruto = valorBruto;
            CentroCusto = centroCusto;
            Historico = historico;
        }

        public double TotalPagar(double valorbruto, double juros, double desconto)
        {
            ValorDocumento = (valorbruto + juros) - desconto;
            Juros = juros;
            Desconto = desconto;
            return ValorDocumento;
        }

        public void Conecta()
        {
            conn.Open();
            string sql = "SELECT * FROM Fornecedores";
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.ExecuteNonQuery();
            conn.Close();


        }

       

        public void CarregaCentroCustos()
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            String StrQuery = "SELECT Codigo, Descricao FROM CENTROCUSTOS ORDER BY DESCRICAO";

            SqlCommand CMD = new SqlCommand();

            CMD = new SqlCommand(StrQuery, conn);

            dr = CMD.ExecuteReader();

            string xcodigo = "";
            string xdescricao = "";

            while (dr.Read())
            {
                xcodigo = dr["codigo"].ToString();
                xdescricao = dr["descricao"].ToString();

                wlCentroCustos.Add(xcodigo.ToString() + "-" + xdescricao);

            }

            conn.Close();
        }

        public void ConsultaCentroCustosID(string pCodigo)
        {

            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            
            string StrQuery = "SELECT CODIGO,DESCRICAO FROM CENTROCUSTOS WHERE CODIGO='" + pCodigo + "'";
            SqlCommand CMD = new SqlCommand();
            CMD.CommandText = StrQuery;
            CMD.CommandType = CommandType.Text;
            CMD.Connection = conn;
            dr = CMD.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                if (dr["codigo"].ToString() == pCodigo.ToString())
                {
                    CentroCusto_Descricao = dr["descricao"].ToString();
                }
            }

            conn.Close();

        }

        public void ConsultaPagarID()
        {

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            int xId = int.Parse(Id.ToString());

            string StrQuery = "SELECT * FROM CONTASPAGAR WHERE Id=" + xId.ToString() + ""; 
            SqlCommand CMD = new SqlCommand();
            CMD.CommandText = StrQuery;
            CMD.CommandType = CommandType.Text;
            CMD.Connection = conn;
            dr = CMD.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                if (dr["Id"].ToString() == Id.ToString())
                {
                    Data = DateTime.Parse(dr["data"].ToString());
                    Documento = dr["documento"].ToString();
                    Fornecedor = int.Parse(dr["fornecedor"].ToString());
                    Fornecedor_Nome = dr["fornecedor_nome"].ToString();
                    DataEmissao = DateTime.Parse(dr["emissao"].ToString());
                    DataVencimento = DateTime.Parse(dr["vencimento"].ToString());

                    // ignorar a baixa por enquanto

                    ValorBruto = double.Parse(dr["valorbruto"].ToString());
                    Desconto = double.Parse(dr["desconto"].ToString());
                    Juros = double.Parse(dr["juros"].ToString());
                    ValorDocumento = double.Parse(dr["valordocumento"].ToString());
                    CentroCusto = dr["centrocusto"].ToString();
                    CentroCusto_Descricao = dr["centrocusto_descricao"].ToString();
                    Historico = dr["historico"].ToString();

                }
            }

            conn.Close();

        }

        public bool InserirDados(bool pIncluir)
        {
            if(conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }
            String strquery;

            if(pIncluir) { 
                // inclusao
                strquery = "INSERT INTO CONTASPAGAR (" +
                        "data," +
                        "documento," +
                        "fornecedor," +
                        "fornecedor_nome," +
                        "emissao," +
                        "vencimento," +
                        "valorbruto," +
                        "juros," +
                        "desconto," +
                        "valordocumento," +
                        "centrocusto," +
                        "centrocusto_descricao," +
                        "historico) VALUES (@data, @documento, @fornecedor, @fornecedor_nome," +
                        "@dataemissao,@datavencimento,@valorbruto,@juros,@desconto," +
                        "@valordocumento,@centrocusto,@centrocusto_descricao,@historico)";
            } else
            {
                // ALTERACAO
                strquery = "UPDATE CONTASPAGAR SET " +
                    "data=@data," +
                    "documento=@documento," +
                    "fornecedor=@fornecedor," +
                    "fornecedor_nome=@fornecedor_nome," +
                    "emissao=@dataemissao," +
                    "vencimento=@datavencimento," +
                    "valorbruto=@valorbruto," +
                    "juros=@juros," +
                    "desconto=@desconto," +
                    "valordocumento=@valordocumento," +
                    "centrocusto=@centrocusto," +
                    "centrocusto_descricao=@centrocusto_descricao," +
                    "historico=@historico WHERE id=" + Id;

            }
            SqlCommand cmd = new SqlCommand(strquery,conn);
            //  adiciona os dados da classe nos objetos do CMD
            cmd.Parameters.AddWithValue("@data", Data);
            cmd.Parameters.AddWithValue("@documento", Documento);
            cmd.Parameters.AddWithValue("@fornecedor", Fornecedor);
            cmd.Parameters.AddWithValue("@fornecedor_nome", Fornecedor_Nome);
            cmd.Parameters.AddWithValue("@dataemissao", DataEmissao);
            cmd.Parameters.AddWithValue("@datavencimento", DataVencimento);
            cmd.Parameters.AddWithValue("@valorbruto", ValorBruto);
            cmd.Parameters.AddWithValue("@juros", Juros);
            cmd.Parameters.AddWithValue("@desconto", Desconto);
            cmd.Parameters.AddWithValue("@valordocumento", ValorDocumento);
            cmd.Parameters.AddWithValue("@centrocusto", CentroCusto);
            cmd.Parameters.AddWithValue("@centrocusto_descricao", CentroCusto_Descricao);
            cmd.Parameters.AddWithValue("@historico", Historico);

            // cmd.Parameters.AddWithValue("@baixa", DataPagamento);

            cmd.CommandType = CommandType.Text;

            // TENTA REALIZAR A INCLUSAO, CASO TENHA SUCESSO ELA SALVA OS DADOS E RETORNA (OK)
            // SE ALGUM ERRO ACONTECER, É CRIADA UMA EXCEPTION QUE MOSTRA NA TELA O ERRO OCORRIDO
            // E FINALMENTE (FINNALY) CONCLUI A OPERACAO.

            try
            {
                int i = cmd.ExecuteNonQuery();  // ESTA LINHA SALVA DOS DADOS NO BANCO DE DADOS E RETORNA QUANTAS LINHAS FORAM AFETADAS.
                if (i > 0)
                    MessageBox.Show("Registro atualizado com sucesso!");
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

        public void ConsultaFornecedorID(int pID)
        {
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();

            }
            string StrQuery = "SELECT Id,Nome FROM Fornecedores WHERE Id = " + pID.ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = StrQuery;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = conn;
            dr = cmd.ExecuteReader();
            dr.Read();
            if (dr.HasRows)
            {
                if (dr["Id"].ToString() == pID.ToString())
                {
                    Fornecedor_Nome = dr["Nome"].ToString();
                }
            }

            conn.Close();


        }
        public void CarregaFornecedores()
        {
            int x = 0;

            conn.Open();
            String StrQuery = "SELECT Id,Nome FROM Fornecedores ORDER BY Nome";
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand(StrQuery, conn);
            dr = cmd.ExecuteReader();

            // gera o datareader atraves da string de abertura da tabela (SQLCOMMAND)
            string xNomes = "";
            string xId = "";
            int z = dr.RecordsAffected;
           // wlFornecedores = new string[50];
            

            while (dr.Read())
            {
                xId = dr["Id"].ToString();
                xNomes = dr["Nome"].ToString();

               //  wlFornecedores[x] = xId.ToString().PadLeft(5,'0') + "-" + xNomes;
                wlFornecedores.Add(xId.ToString().PadLeft(5, '0') + "-" + xNomes);
                x++;

            }

            conn.Close();
            dr.Close();

        }

       

    }

    
}
