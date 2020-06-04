using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace NovoClasses.Models
{
    class Clientes
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public double Limite { get; set; }
        public string Telefone { get; set; }
        public string Estado { get; set; }

        public Clientes(string nome, string endereco, string cidade)
        {
            Nome = nome;
            Endereco = endereco;
            Cidade = cidade;
        }

        public double SemLimite()
        {
            Limite = 0;
            return Limite;
        }

        public double DefinirLimite(double limite)
        {
            Limite = limite;
            return Limite;
        }

        public void AumentarLimite()
        {
            Limite += 500;
        }


        



    }

    
}
