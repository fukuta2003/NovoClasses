using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovoClasses.Models
{
    public class Validacao
    {
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }

        public static void RetornarMascara(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.Text = double.Parse(txt.Text).ToString("C2");
        }

        public string Formata_Cep(string txt)
        {
            if (!string.IsNullOrEmpty(txt))
            {

                if (txt.Length == 8 && txt.Substring(5, 1) != "-")
                {
                    txt = Convert.ToUInt64(txt).ToString(@"00000\-000");

                }
            }
            
            return txt;

        }

        public string Formata_TelefoneFixo(string txt)
        {
            if (!string.IsNullOrEmpty(txt))
            {
                if (txt.Length == 10 && txt.Substring(7, 1) != "-")
                {
                    txt = Convert.ToUInt64(txt).ToString(@"\(00\)0000\-0000");

                }
            }
            return txt;

        }
        public string Formata_Celular(string txt)
        {
            if (!string.IsNullOrEmpty(txt))
            {
                if (txt.Length == 11 && txt.Substring(8, 1) != "-")
                {
                    txt = Convert.ToUInt64(txt).ToString(@"\(00\)00000\-0000");

                }
            }
            return txt;

        }

        public string Formata_CNPJ(string txt)
        {
            if (!string.IsNullOrEmpty(txt))
            {
                if (txt.Length == 14 && txt.Substring(2, 1) != ".")
                {
                    txt = Convert.ToUInt64(txt).ToString(@"00\.000\.000\/0000\-00");
                }

               
            }
            return txt;
        }


        public string Formata_CPF(string txt)
        {
            if (!string.IsNullOrEmpty(txt))
            {
                if (txt.Length == 11 && txt.Substring(3, 1) != ".")
                {
                    txt = Convert.ToUInt64(txt).ToString(@"000\.000\.000\-00");
                }
            }
            return txt;
        }

        public string Formata_Moeda(string txt)
        {
           
            if (!string.IsNullOrEmpty(txt))
            {
               // txt = txt.Replace("." , ",");
                
                txt = Convert.ToDouble(txt).ToString("n");

            } else
            {
                txt = "0,00";
            }

            return txt;
        }

        public string ApenasNumeros(string str)
        {
            var apenasDigitos = new Regex(@"[^\d]");
            
            return apenasDigitos.Replace(str, "");
        }

        public void MesInicioFim()
        {
            DateTime Hoje;
            string xAno,xProxAno;
            string xMes,xProxMes;
            DateTime xDataInicial, xDataFinal;

            Hoje = DateTime.Today;
            xAno = Hoje.Year.ToString();
            xMes = Hoje.Month.ToString();
            if(xMes=="12")
            {
                xProxMes = "01";
                xProxAno = ((Hoje.Year) + 1).ToString();
                xDataFinal = DateTime.Parse("01/" + xProxMes + "/" + xProxAno);
            } else
            {
                xProxMes = ((Hoje.Month) + 1).ToString();
                xDataFinal = DateTime.Parse("01/" + xProxMes + "/" + xAno);

            }

            xMes = xMes.ToString().PadLeft(2, '0');

            xDataInicial = DateTime.Parse("01/" + xMes.ToString() + "/" + xAno.ToString());
            xDataInicial = DateTime.Parse("01/" + xMes.ToString() + "/" + xAno.ToString());
            DataInicial = xDataInicial.ToString();
            xDataFinal = xDataFinal.AddDays(-1);
            DataFinal = xDataFinal.ToString();

        }


    }
    }
