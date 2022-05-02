using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Management;
using System.Configuration;
using System.Text.RegularExpressions;

namespace EMCLibrary
{
    public class EmcResources
    {

#region "Valores estaticos - Enum"
        //definição do tipo de alinhamento
        public enum eAlign
        {
            Direita = 1,
            Esquerda = 2
        }
        /// <summary>
        /// Enum com siglas de estados brasileiros
        /// </summary>
        public enum Estados
        {
            AC,AL,AP,AM,BA,CE,DF,ES,GO,MA,MT,MS,MG,PA,PB,PR,PE,PI,RJ,RN,RS,RO,RR,SC,SP,SE,TO
        }
        /// <summary>
        /// Categoria de Pessoas
        /// </summary>
        public enum CategoriaPessoa
        {
            Cliente = 1,
            Fornecedor = 2,
            Vendedor = 3,
            Fiador = 4
        }
        
    /// <summary>
        /// Enum com tipos de pessoas - Fisica ou Juridica
        /// </summary>
        public enum TipoPessoa
        {
            Física, Juridica
        }
        public enum TipoPessoaTodas
        {
            Física, Juridica, Todas
        }

        /// <summary>
        /// Enum SIM ou NÃO
        /// </summary>
        public enum SimNao
        {
            Sim, Não
        }

        public enum operacaoSeguranca
        {
            execucao,
            inclusao,
            alteracao,
            exclusao,
            impressao,
            ocorrencia
        }

        public enum nivelUsuario
        {
            Administrador=0,
            Gerente=2,
            Supervisor=4,
            Encarregado=6,
            Usuario=8,
        }

       //definindo o tipo de dados
       public enum TipoDados
       {
          Numerico,
          Caracter,
          Boleano
        }

        public enum usuarioJLM
        {
            jlm
        }
        
#endregion

#region [Diretorios]
        /// <summary>
        /// Retorna uma String com o diretorio para GED de acordo com o Sistema
        /// </summary>
        /// <param name="Sistema"></param>
        /// <returns></returns>
        public static String GedDirectory(String Sistema)
        {
           String Diretorio = "";

           if (Sistema == "EMCInd")
           {
               Diretorio = "\\EMCtech\\EmcInd\\GED\\";
           }
           return @Diretorio;
        }
        /// <summary>
        /// Retorna uma String com o diretorio onde está armazenado o logo do sistema
        /// </summary>
        /// <param name="Sistema"></param>
        /// <returns></returns>
        public static String LogoDiretory(String Sistema)
        {
            String Diretorio = "";

            if (Sistema == "EMCInd")
            {
               // Diretorio = "\\EMCtech\\EmcInd\\Logos\\";
                Diretorio = @"\EMCtech\EmcInd\Logos\";
            }
            return @Diretorio;
        }
#endregion

#region [Criptografia]
        /// <summary>
        /// Criptografa uma String com algoritimo MD5
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string getMD5Hash(string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }




#endregion

#region [Validação Documentos]
        //valida nro do pis
        public static bool ValidaPIS(string Valor)
        {
            bool returnValue = default(bool);
            string FTab = default(string);
            string strAux = default(string);
            int Resto = default(int);
            int Tot = default(int);
            int I = default(int);

            //se não informado o PIS, retorna PIS Válido
            if (Valor == "")
            {
                returnValue = true;
                return returnValue;
            }

            strAux = "";
            //retirando a edição do número (pontos e traços)
            for (I = 1; I <= Valor.Length; I++)
            {
                if ("0123456789".IndexOf(Valor.Substring(I - 1, 1)) + 1 > 0)
                {
                    strAux = strAux + Valor.Substring(I - 1, 1);
                }
            }

            //move o valor sem edição
            Valor = strAux;

            //se qtde de dígitos do PIS menor que 11, PIS Inválido
            if (Valor.Length != 11)
            {
                returnValue = false;
                return returnValue;
            }

            //efetuando a verificação do dígito verificador do PIS
            FTab = "3298765432";

            Tot = 0;
            for (I = 1; I <= 10; I++)
            {
                Tot = (int)(Tot + Convert.ToInt32(Valor.Substring(I - 1, 1)) * Convert.ToInt32(FTab.Substring(I - 1, 1)));
            }

            Resto = Convert.ToInt32(Tot % 11);
            if (Resto != 0)
            {
                Resto = 11 - Resto;
                //se o resto for maior que 9, o dígito será 0
                if (Resto > 9)
                {
                    Resto = 0;
                }
            }

            //se digito verificador diferente, PIS Inválido
            if (Resto != Convert.ToInt32(Valor.Substring(10, 1)))
            {
                returnValue = false;
                return returnValue;
            }

            //se dígito verificador igual, PIS Válido
            returnValue = true;
            return returnValue;
        }
        /// <summary>
        /// Verifica a validade de um CNPJ ou CPF
        /// </summary>
        /// <param name="vrCNPJCPF"></param>
        /// <returns></returns>
        public static bool validaCNPJCPF(string vrCNPJCPF)
        {
            bool erro = true;
            if (vrCNPJCPF.Trim().Length < 11)
            {
                return false;
            }
            else if (vrCNPJCPF.Trim().Length > 11)
            {
                erro = validaCNPJ(vrCNPJCPF);
            }
            else
            {
                erro = validaCPF(vrCNPJCPF);
            }
            return erro;
        }
        /// <summary>
        /// Verifica a validade de um CPF
        /// </summary>
        /// <param name="vrCPF"></param>
        /// <returns></returns>
        public static bool validaCPF(string vrCPF)
        {

            string valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");

            if (valor.Length != 11)
                return false;



            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)

                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                    return false;

            return true;

        }
        /// <summary>
        /// Verifica a validade de um CNPJ
        /// </summary>
        /// <param name="vrCNPJ"></param>
        /// <returns></returns>
        public static bool validaCNPJ(string vrCNPJ)
        {

            string CNPJ = vrCNPJ.Replace(".", "");
            CNPJ = CNPJ.Replace("/", "");
            CNPJ = CNPJ.Replace("-", "");

            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;

            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;

            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(CNPJ.Substring(nrDig, 1));

                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));

                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));

                }

                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);

                    if ((resultado[nrDig] == 0) || (resultado[nrDig] == 1))
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == 0);
                    else
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
                }

                return (CNPJOk[0] && CNPJOk[1]);

            }

            catch
            {

                return false;

            }

        }
        /// <summary>
        /// Verifica a validade de um PIS
        /// </summary>
        /// <param name="pis"></param>
        /// <returns></returns>
        public static bool validaPis(string pis)
        {
            int[] multiplicador = new int[10] { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            if (pis.Trim().Length != 11)
                return false;
            pis = pis.Trim();
            pis = pis.Replace("-", "").Replace(".", "").PadLeft(11, '0');

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(pis[i].ToString()) * multiplicador[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            return pis.EndsWith(resto.ToString());
        }
        /// <summary>
        /// Verifica se a string é um endereço de email válido
        /// </summary>
        /// <param name="strEmail"></param>
        /// <returns></returns>
        public static bool ValidarEmail(string strEmail)
        {
            if (strEmail.Trim().Length > 0)
            {
                //VALIDAR EMAIL
                string strModelo = "^([0-9a-zA-Z]([-.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
                if (System.Text.RegularExpressions.Regex.IsMatch(strEmail, strModelo))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else return true;
        }
        /// <summary>
        /// Returns MAC Address from first Network Card in Computer
        /// </summary>
        /// <returns>[string] MAC Address</returns>
        public static string GetMACAddress()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
                ManagementObjectCollection moc = mc.GetInstances();
                string MACAddress = String.Empty;
                foreach (ManagementObject mo in moc)
                {
                    if (MACAddress == String.Empty)  // only return MAC Address from first card
                    {
                        if ((bool)mo["IPEnabled"] == true) MACAddress = mo["MacAddress"].ToString();
                    }
                    mo.Dispose();
                }
                MACAddress = MACAddress.Replace(":", " ");
                return MACAddress;
            }
            catch
            {
                return "0";
            }
        }

#endregion

#region [valida datas]
        //formata a data para o padrão universal do banco de dados
        public static string USdata(DateTime pData)
        {
            //salva a cultura atual na memória
            System.Globalization.CultureInfo myCulture = new System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name);

            //mudando a cultura para (Inglês - Americano)
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            //formatando a data (padrão americano)
            string sData = System.Convert.ToString(string.Format("dd-MMM-yyyy", pData.ToString()));

            //restaura a cultura atual (salva anteriormente na memória)
            System.Threading.Thread.CurrentThread.CurrentCulture = myCulture;

            return sData;
        }
        public static string USdata(string pData)
        {
            //salva a cultura atual na memória
            System.Globalization.CultureInfo myCulture = new System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name);

            //setando a cultura para (Portugues)
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pt-BR");

            //convertendo a data da
            DateTime dData = DateTime.Parse(pData);

            //mudando a cultura para (Inglês - Americano)
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            //formatando a data (padrão americano)
            string sData = System.Convert.ToString(string.Format("dd-MM-yyyy", dData.ToString()));

            //restaura a cultura atual (salva anteriormente na memória)
            System.Threading.Thread.CurrentThread.CurrentCulture = myCulture;

            return sData;
        }
        /// <summary>
        /// validacao de comparação entre duas datas
        /// datai - datainicial
        /// dataf - datafinal
        /// </summary>
        /// <param name="datai"></param>
        /// <param name="dataf"></param>
        /// <returns></returns>
        public static bool comparadatas(DateTime datai, DateTime dataf)
        {
            bool res = false;
            if (dataf >= datai)
            {
                res = true;
            }
            else
            {
                res = false;
            }
            return res;
        }
        /// <summary>
        /// Validação geral de um campo data
        /// data - string da data inserida na textbox
        /// dataminima - string da data minima que pode ser inserida
        /// </summary>
        /// <param name="data"></param>
        /// <param name="dataminima"></param>
        /// <returns></returns>
        public static bool VDatas(string data, string dataminima)
        {

            bool resul = false;

            // testa para caixa de data decisão vazia
            if (data == "")
            {
                resul = false;
            }
            // valida campo diferente de vazio
            if (data != "")
            {
                //valida para campo com 10 caracteres e campo com tim e 10 caracteres
                if ((data.Length == 10) || (data.Length == 10))// testa p numero de caracteres
                {
                    // testa se e data valida
                    if (validaData(data))
                    {
                        string datamin = dataminima;
                        string strdatamin = datamin.Substring(6, 4) + "-" + datamin.Substring(3, 2) + "-" + datamin.Substring(0, 2);
                        DateTime datageral2 = Convert.ToDateTime(strdatamin);

                        string str = data.Substring(6, 4) + "-" + data.Substring(3, 2) + "-" + data.Substring(0, 2);
                        DateTime datageral = Convert.ToDateTime(str);

                        //testa se é menor ou igual que  a data actual
                        if (datageral <= datageral2)
                        {
                            resul = false;
                        }
                        //testa se é maior que a data actual
                        if (datageral > datageral2)
                        {
                            resul = true;
                        }

                    }
                    else
                    {

                        resul = false;
                    }
                }
                else
                {
                   resul = false;

                }

            }
            return resul;
        }
        /// <summary>
        /// valida data no ambito da sua formatação
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool validaData(string str)
        {

            Regex Data = new Regex(@"^((((0?[1-9]|[12]\d|3[01])[\-](0?[13578]|1[02])[\-]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|[12]\d|30)[\-](0?[13456789]|1[012])[\-]((1[6-9]|[2-9]\d)?\d{2}))|((0?[1-9]|1\d|2[0-8])[\-]0?2[\-]((1[6-9]|[2-9]\d)?\d{2}))|(29[\-]0?2[\-]((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00)))|(((0[1-9]|[12]\d|3[01])(0[13578]|1[02])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|[12]\d|30)(0[13456789]|1[012])((1[6-9]|[2-9]\d)?\d{2}))|((0[1-9]|1\d|2[0-8])02((1[6-9]|[2-9]\d)?\d{2}))|(2902((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00)|00))))$");
            return Data.IsMatch(str);

        }
        /// <summary>
        /// Converte uma string para o formato Datetime
        /// Se a String for vazia ou nula retorna Null
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DateTime? cDate(string data)
        {
            if (String.IsNullOrEmpty(data))
                return null;
            else
                return Convert.ToDateTime(data);

        }
        public static string sDate(DateTime? data)
        {
            string sDate = "";
            if (data == null || data == Convert.ToDateTime("01/01/0001 00:00"))
            {
                sDate = "";
            }
            else
            {
                sDate = data.ToString();
            }
            return sDate;
        }
        //retorna o dia por extenso
        public static string ExtensoDia(int nDia)
        {
            //verificando o dia
            switch (nDia)
            {
                case 1:
                    return "Um";
                case 2:
                    return "Dois";
                case 3:
                    return "Tres";
                case 4:
                    return "Quatro";
                case 5:
                    return "Cinco";
                case 6:
                    return "Seis";
                case 7:
                    return "Sete";
                case 8:
                    return "Oito";
                case 9:
                    return "Nove";
                case 10:
                    return "Dez";
                case 11:
                    return "Onze";
                case 12:
                    return "Doze";
                case 13:
                    return "Treze";
                case 14:
                    return "Quatorze";
                case 15:
                    return "Quinze";
                case 16:
                    return "Dezesseis";
                case 17:
                    return "Dezessete";
                case 18:
                    return "Dezoito";
                case 19:
                    return "Dezenove";
                case 20:
                    return "Vinte";
                case 21:
                    return "Vinte e um";
                case 22:
                    return "Vinte e dois";
                case 23:
                    return "Vinte e tres";
                case 24:
                    return "Vinte e quatro";
                case 25:
                    return "Vinte e cinco";
                case 26:
                    return "Vinte e seis";
                case 27:
                    return "Vinte e sete";
                case 28:
                    return "Vinte e oito";
                case 29:
                    return "Vinte e nove";
                case 30:
                    return "Trinta";
                case 31:
                    return "Trinta e um";
                default:
                    return "";
            }
        }
        //retorna o mes por extenso
        public static string ExtensoMes(int nMes, bool bAbreviado = false)
        {
            string functionReturnValue = null;
            //verificando o mes
            switch (nMes)
            {
                case 1:
                    functionReturnValue = (bAbreviado ? "JAN" : "Janeiro");
                    break;
                case 2:
                    functionReturnValue = (bAbreviado ? "FEB" : "Fevereiro");
                    break;
                case 3:
                    functionReturnValue = (bAbreviado ? "MAR" : "Março");
                    break;
                case 4:
                    functionReturnValue = (bAbreviado ? "APR" : "Abril");
                    break;
                case 5:
                    functionReturnValue = (bAbreviado ? "MAY" : "Maio");
                    break;
                case 6:
                    functionReturnValue = (bAbreviado ? "JUN" : "Junho");
                    break;
                case 7:
                    functionReturnValue = (bAbreviado ? "JUL" : "Julho");
                    break;
                case 8:
                    functionReturnValue = (bAbreviado ? "AUG" : "Agosto");
                    break;
                case 9:
                    functionReturnValue = (bAbreviado ? "SEP" : "Setembro");
                    break;
                case 10:
                    functionReturnValue = (bAbreviado ? "OCT" : "Outubro");
                    break;
                case 11:
                    functionReturnValue = (bAbreviado ? "NOV" : "Novembro");
                    break;
                case 12:
                    functionReturnValue = (bAbreviado ? "DEC" : "Dezembro");
                    break;
                default:
                    functionReturnValue = "";
                    break;
            }
            return functionReturnValue;
        }


#endregion

#region [Conversao de numeros]
        //converte um objeto em double
        public static double nVal(object pObject)
        {
            //se nulo, retorna 0
            if (pObject == DBNull.Value)
            {
                return 0;
            }

            //retorna o valor convertido
            return Convert.ToInt32(pObject);
        }
        //converte um objeto em double
        public static object cEmpty(object pObject)
        {
            //se nulo, retorna nulo
            if (pObject == DBNull.Value)
            {
                return "";
            }
            //se zero, retorna nulo
            if (Convert.ToInt32(pObject) == 0)
            {
                return "";
            }
            //senão, retorna o valor convertido
            return pObject;
        }
        //converte um objeto em double
        public static object cNull(object pObject)
        {
            //se nulo, retorna nulo
            if (pObject == DBNull.Value)
            {
                return DBNull.Value;
            }
            //se zero, retorna nulo
            if (Convert.ToInt32(pObject) == 0)
            {
                return DBNull.Value;
            }
            //senão, retorna o valor convertido
            return pObject;
        }
        //converte um objeto em decimal
        public static decimal nDec(object pObject)
        {
            //salva a cultura atual na memória
            System.Globalization.CultureInfo myCulture = new System.Globalization.CultureInfo(System.Threading.Thread.CurrentThread.CurrentCulture.Name);
            //mudando a cultura para (Inglês - Americano)
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            //se nulo, retorna 0
            if (pObject == DBNull.Value)
            {
                return 0;
            }
            //se não houver ponto e houver vírgula, substitui por ponto
            if (pObject.ToString().IndexOf(".") + 1 == 0)
            {
                pObject = pObject.ToString().Replace(",", ".");

            }

            //retorna o valor convertido
            decimal Valor = System.Convert.ToDecimal(pObject);

            //volta a cultura padrão
            System.Threading.Thread.CurrentThread.CurrentCulture = myCulture;

            return Valor;
        }
        //retorna um String pronta para ser formatada em decimal
        public static bool TemDecimal(string pValor)
        {
            string sCaracter = "";
            bool bSeparador = false;

            //converte o valor para o padrão americano
            pValor = System.Convert.ToString(USvalor(pValor));

            int Count = 1;
            //verifica caracter por caracter do valor
            for (Count = 1; Count <= pValor.Length; Count++)
            {
                sCaracter = pValor.Substring(Count - 1, 1);
                //se houver um número diferente de 0 após o separador decimal, conta como decimais
                if (bSeparador == true && "123456789".IndexOf(sCaracter) + 1 > 0)
                {
                    return true;
                }
                //se for o separdor decimal, atualiza indicador
                if (char.Parse(sCaracter) == '\u002C' || char.Parse(sCaracter) == '\u002E')
                {
                    bSeparador = true;
                }
            }

            //se tem ou não decimais
            return false;
        }
        //formata o valor para o padrão Americano (utilizado pelos bancos de dados)
        public static double USvalor(string pValor)
        {
            //se o valor possui ponto decimal
            if (pValor.IndexOf(",") + 1 > 0)
            {
                //e o valor possui ponto milhar, retira os pontos (milhar) antes de converter
                pValor = pValor.Replace(".", "");
            }

            //formatando o valor (padrão americano) - "######0.00"
            double dValor = Convert.ToInt32(pValor.Replace(",", "."));

            return dValor;
        }
        /// <summary>
        /// Converte uma string em int
        /// Se a string for nula retorna o valor inteiro 0
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static Int32 cInt(String valor)
        {
            if (String.IsNullOrEmpty(valor.Trim()))
                return 0;
            else
                return Convert.ToInt32(valor);

        }
        /// <summary>
        /// Converte uma string em decimal
        /// Se a string for nula retorna o valor decimal 0.00
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static Decimal cCur(String valor)
        {
            if (String.IsNullOrEmpty(valor))
                return 0;
            else
                return Convert.ToDecimal(valor);
        }
        /// <summary>
        /// Converte uma string em double
        /// Se a string for nula retorna o valor decimal 0.00
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static Double cDouble(String valor)
        {
            if (String.IsNullOrEmpty(valor))
                return 0;
            else
                return Convert.ToDouble(valor);
        }
#endregion

#region [Conversao de strings]
        //remove caracteres especiais (acentos) de uma string
        public static string RemoveChars(string pText, bool pRemoveBarras = false, bool pRemovePontuacao = false, bool pRemoveTracos = false)
        {
            //se não houver texto, não há nada a remover
            if (pText.Length == 0)
            {
                return pText;
            }

            //ATENÇÃO. ESTA ROTINA TAMBÉM EXISTE NA FUNÇÃO DTV_RemoveChars - SEGURANCA

            //substitui o ç pelo c e o Ç pelo C e o ¿ pelo C
            pText = pText.Replace("ç", "c");
            pText = pText.Replace("Ç", "C");
            pText = pText.Replace("¿", "C");

            //substitui o ã pelo a e o Ã pelo A
            pText = pText.Replace("ã", "a");
            pText = pText.Replace("Ã", "A");
            //substitui o â pelo a e o Â pelo A
            pText = pText.Replace("â", "a");
            pText = pText.Replace("Â", "A");
            //substitui o á pelo a e o Á pelo A
            pText = pText.Replace("á", "a");
            pText = pText.Replace("Á", "A");
            //substitui o à pelo a e o À pelo A
            pText = pText.Replace("à", "a");
            pText = pText.Replace("À", "A");
            //substitui o ä pelo a e o Ä pelo A
            pText = pText.Replace("ä", "a");
            pText = pText.Replace("Ä", "A");

            //substitui o ê pelo e e o Ê pelo E
            pText = pText.Replace("ê", "e");
            pText = pText.Replace("Ê", "E");
            //substitui o é pelo e e o É pelo E
            pText = pText.Replace("é", "e");
            pText = pText.Replace("É", "E");
            //substitui o è pelo e e o È pelo E
            pText = pText.Replace("è", "e");
            pText = pText.Replace("È", "E");
            //substitui o ë pelo e e o Ë pelo E
            pText = pText.Replace("ë", "e");
            pText = pText.Replace("Ë", "E");

            //substitui o î pelo i e o Î pelo I
            pText = pText.Replace("î", "i");
            pText = pText.Replace("Î", "I");
            //substitui o í pelo i e o Í pelo I
            pText = pText.Replace("í", "i");
            pText = pText.Replace("Í", "I");
            //substitui o ì pelo i e o Ì pelo I
            pText = pText.Replace("ì", "i");
            pText = pText.Replace("Ì", "I");
            //substitui o ï pelo i e o Ï pelo I
            pText = pText.Replace("ï", "i");
            pText = pText.Replace("Ï", "I");

            //substitui o õ pelo o e o Õ pelo O
            pText = pText.Replace("õ", "o");
            pText = pText.Replace("Õ", "O");
            //substitui o ô pelo o e o Ô pelo O
            pText = pText.Replace("ô", "o");
            pText = pText.Replace("Ô", "O");
            //substitui o ó pelo o e o Ó pelo O
            pText = pText.Replace("ó", "o");
            pText = pText.Replace("Ó", "O");
            //substitui o ò pelo o e o Ò pelo O
            pText = pText.Replace("ò", "o");
            pText = pText.Replace("Ò", "O");
            //substitui o ö pelo o e o Ö pelo O
            pText = pText.Replace("ö", "o");
            pText = pText.Replace("Ö", "O");

            //substitui o û pelo u e o Û pelo U
            pText = pText.Replace("û", "u");
            pText = pText.Replace("Û", "U");
            //substitui o ú pelo u e o Ú pelo U
            pText = pText.Replace("ú", "u");
            pText = pText.Replace("Ú", "U");
            //substitui où pelo u e o Ù pelo U
            pText = pText.Replace("ù", "u");
            pText = pText.Replace("Ù", "U");
            //substitui o ü pelo u e o Ü pelo U
            pText = pText.Replace("ü", "u");
            pText = pText.Replace("Ü", "U");

            //substitui o ª pelo a e o º pelo o
            pText = pText.Replace("ª", "a");
            pText = pText.Replace("º", "o");
            pText = pText.Replace("°", "o");

            //remove o ¨
            pText = pText.Replace("¨", "");

            //remove aspas simples '
            pText = pText.Replace("\'", "");
            //remove apóstrofo
            pText = pText.Replace("´", "");

            //verifica se substitui barras
            if (pRemoveBarras == true)
            {
                //remove /
                pText = pText.Replace("/", "");
                //remove \
                pText = pText.Replace("\\", "");
            }

            if (pRemoveTracos == true)
            {
                //remove /
                pText = pText.Replace("-", "");
            }

            //verifica se remove pontuação
            if (pRemovePontuacao == true)
            {
                //substitui pontuação
                pText = pText.Replace(".", "");
                pText = pText.Replace(":", "");
                pText = pText.Replace(";", "");
                pText = pText.Replace(",", "");
            }

            //substitui o Ñ por N
            pText = pText.Replace("Ñ", "N");

            //substitui o Ý por Y
            pText = pText.Replace("Ý", "Y");

            //Remove Outros Caracteres
            pText = pText.Replace("§", "");

            return pText;
        }
        //remove os caracteres de parenteses de uma string
        public static string RemoveParenteses(string pText)
        {
            //se não houver texto, não há nada a remover
            if (pText.Length == 0)
            {
                return pText;
            }

            //substitui o ) e ( por espaço
            pText = pText.Replace("(", " ");
            pText = pText.Replace(")", " ");

            //substitui o " por espaço
            pText = pText.Replace(@"\u0022", " ");

            return pText;
        }
        //retorna caracteres numericos de uma string
        public static string SomenteNumero(string pTexto)
        {
            string sAux = "";
            string nNumeros = "0123456789";

            //removendo os espaços da string
            pTexto = pTexto.Trim();

            //lendo os caracteres
            for (int x = 1; x <= pTexto.Length; x++)
            {
                if (nNumeros.IndexOf(pTexto.Substring(x - 1, 1)) > 0)
                {
                    sAux = sAux + pTexto.Substring(x - 1, 1);
                }
            }
            sAux = sAux.Trim();

            //verifica se a função retornou algum número
            if (sAux.Length == 0)
            {
                return " 0";
            }
            else
            {
                return sAux;
            }
        }
        //converte um objeto em string
        public static string sStr(object pObject)
        {
            //se nulo, retorna ''
            if (pObject == DBNull.Value)
            {
                return "";
            }

            //retorna o valor convertido
            return System.Convert.ToString(pObject);
        }
        /// <summary>
        /// Converte um valor string em string
        /// Se a string de entrada for igual a NULL retornará ""
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        public static string cStr(String valor)
        {
            if (String.IsNullOrEmpty(valor))
                return "";
            else
                return Convert.ToString(valor);

        }
#endregion

#region [Calculos Bancários]
        public static double taxaMensal2Diaria(double taxa)
        {
            double taxaDiaria = 0;
            taxa = taxa / 100;

            try
            {
                double passo1 = (1 + taxa);
                double passo2 = 0.03333333333;

                taxaDiaria = Math.Round(Math.Pow(passo1, passo2), 10);

                taxaDiaria = (taxaDiaria - 1) * 100;
            }
            catch (Exception oErro)
            {
                throw oErro;
            }

            return taxaDiaria;
        }

        public static double taxaMensal2Anual(double taxa)
        {
            double taxaAnual = 0;
            taxa = taxa/100;
            try
            {
                taxaAnual = Math.Pow((1 + taxa), 12) - 1;
            }
            catch(Exception oErro)
            {
                throw oErro;
            }

            return (taxaAnual*100);
        }

        public static double taxaAnual2Mensal(double taxa)
        {
            double taxaMensal = 0;
            taxa = taxa / 100;
            try
            {
                taxaMensal = Math.Pow((1 + taxa), 0.083333333333) - 1;
            }
            catch (Exception oErro)
            {
                throw oErro;
            }

            return (taxaMensal*100);
        }

        public static decimal calculaJurosParcela(DateTime dtaVencimento, DateTime dtaCorrecao, decimal valorParcela, double taxaJuros, string tipoJuros = "S")
        {
                        
            Decimal jurosCalculado = 0;

            try
            {
                Double vlrParcDouble = Convert.ToDouble(valorParcela);
                double txa = (taxaJuros / 100);
                int ndias = (int)dtaCorrecao.Subtract(dtaVencimento).TotalDays;

                /* juros simples */
                if (tipoJuros == "S")
                {
                    jurosCalculado = EmcResources.cCur(Math.Round((vlrParcDouble * txa * ndias)).ToString());

                }
                else
                {
                    /* juros compostos */
                    double montante = 0;

                    montante = vlrParcDouble * Math.Pow((1 + txa), ndias);
                    jurosCalculado = EmcResources.cCur(Math.Round((montante - vlrParcDouble), 2).ToString());
                }
            }
            catch (Exception oErro)
            {
                throw oErro;
            }
            
            return jurosCalculado;
        }

#endregion

#region "Funções Auxiliares"
        public static string Space(int vTamanho)
        {
            return (new string(' ', vTamanho));
        }
        public static char Chr(int codigo)
        {
            return Convert.ToChar(codigo);
        }
        public static int Asc(string letra)
        {
            return (int)(Convert.ToChar(letra));
        }

         /// <summary>
         /// Faz a leitura do objeto e retona o seu valor e texto selecionado em duas variáveis separados por virgula
         /// </summary>
         /// <param name="pObjeto"></param>
         /// <param name="pValue"></param>
        /// <param name="pText"></param>
        /// <param name="pTipo"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static String ReadObject(System.Windows.Forms.CheckedListBox pObjeto, TipoDados pTipo, Boolean ObjetoVinculado)
   {  
      string strAux = "";

      //se o objeto é vinculado ao banco de dados
      if (ObjetoVinculado == true)
         {
         foreach (DataRowView itemChecked in pObjeto.CheckedItems)
            {
            //verifica se deve acrescentar a vírgula
            if (strAux.Length > 0)
               strAux = strAux + ',';

            //acrescenta aspas ou não conforme o tipo de dados
            if (pTipo == EmcResources.TipoDados.Caracter)
               strAux = strAux + "'" + itemChecked.Row.ItemArray.GetValue(0) + "'";
            else
               strAux = strAux + itemChecked.Row.ItemArray.GetValue(0);
            }
         }
      // se o objeto é desvinculado de banco de dados
      else
         {
         // Next show the object title and check state for each item selected. 
         foreach (object itemChecked in pObjeto.CheckedItems)
            {
            //verifica se deve acrescentar a vírgula
            if (strAux.Length > 0)
               strAux = strAux + ',';
            //acrescenta aspas ou não conforme o tipo de dados
            if (pTipo == TipoDados.Caracter)
               strAux = strAux + "'" + itemChecked.ToString() + "'";
            else
               strAux = strAux + itemChecked.ToString();
            }
         }
       
      //retorna string com dados concatenados       
      return strAux;
   }
        #endregion

#region "[Funções auxiliares a Impressão]"
        //formatação de texto - padrão AcActive
        public static string MyFormat(string pTexto, string pMascara)
        {
            int iStr = 0;
            int iMsc = 0;
            int nLen = 0;
            string strAux = "";

            int qDecStr = 0;
            int qDecMsc = 0;

            //substitui o ponto decimal por vírgula
            pTexto = pTexto.Replace(".", ",");

            //calculando a qtde de casas decimais
            qDecStr = (pTexto.IndexOf(",") + 1 > 0) ? (pTexto.Length - (pTexto.IndexOf(",") + 1)) : 0;
            qDecMsc = (pTexto.IndexOf(",") + 1 > 0) ? (pTexto.Length - (pTexto.IndexOf(",") + 1)) : 0;

            iStr = 1;
            //retirando a edição (máscara) do campo
            while (iStr <= pTexto.Length)
            {
                if ("0123456789,-".IndexOf(pTexto.Substring(iStr - 1, 1)) + 1 > 0)
                {
                    strAux += pTexto.Substring(iStr - 1, 1);
                }
                iStr++;
            }

            //atualiza a string (sem a máscara)
            pTexto = strAux;
            strAux = "";

            //definindo o tamanho do campo
            if (pTexto.Length > pMascara.Length)
            {
                nLen = pTexto.Length;
            }
            else
            {
                nLen = pMascara.Length;
            }

            //se campo com decimais, sincroniza as casas decimais
            if (qDecStr > 0 | qDecMsc > 0)
            {
                if (qDecStr < qDecMsc)
                {
                    //se não digitou separador decimal
                    if (pTexto.IndexOf(",") + 1 == 0)
                    {
                        pTexto += ",";
                        //acrescenta zeros a direita até completar a máscara
                        pTexto = pTexto.PadRight(pTexto.Length + qDecMsc, '0');
                    }
                    else
                    {
                        //acrescenta zeros a direita até completar a máscara
                        pTexto = pTexto.PadRight(pTexto.Length + (qDecMsc - qDecStr), '0');
                    }
                }
            }

            //se digitou mais casas decimais que o permitido, corta-as
            if (qDecStr > qDecMsc)
            {
                pTexto = pTexto.Substring(0, pTexto.Length - (qDecStr - qDecMsc));
                //se a mascara não tiver casa decimal, retira a virgula
                if (qDecMsc == 0)
                {
                    pTexto = pTexto.Substring(0, pTexto.Length - 1);
                }
            }

            iMsc = pMascara.Length;
            iStr = pTexto.Length;
            //montando os dígitos até o fim da máscara
            while (iMsc > 0)
            {
                //se houver dados na string
                if (iStr > 0)
                {
                    //se caracteres especiais, troca-os pelos dígitos da string
                    if (pMascara.Substring(iMsc - 1, 1) == "0" || pMascara.Substring(iMsc - 1, 1) == "#" || pMascara.Substring(iMsc - 1, 1) == ",")
                    {
                        strAux = pTexto.Substring(iStr - 1, 1) + strAux;
                        iStr--;
                        iMsc--;
                        //se
                    }
                    else
                    {
                        //verifica se o o campo a ser inserido ´eo sinal de NEGATIVO
                        if (pTexto.Substring(iStr - 1, 1) == "-")
                        {
                            strAux = pTexto.Substring(iStr - 1, 1) + strAux;
                            iStr--;
                            iMsc--;
                        }
                        else
                        {
                            strAux = pMascara.Substring(iMsc - 1, 1) + strAux;
                            iMsc--;
                        }
                    }
                    //se não houver dados na string, continua lendo a máscara
                }
                else
                {
                    switch (pMascara.Substring(iMsc - 1, 1))
                    {
                        case "0":
                            strAux = "0" + strAux;
                            break;
                        case "#":
                            strAux = strAux;
                            break;
                        case ",":
                            strAux = strAux;
                            break;
                        case ".":
                            if (iMsc > 1)
                            {
                                if (pMascara.Substring(iMsc - 1 - 1, 1) == "0")
                                {
                                    strAux = pMascara.Substring(iMsc - 1, 1) + strAux;
                                }
                                else
                                {
                                    strAux = strAux;
                                }
                            }
                            else
                            {
                                strAux = strAux;
                            }
                            break;
                        default:
                            strAux = pMascara.Substring(iMsc - 1, 1) + strAux;
                            break;
                    }
                    iMsc--;
                }
            }

            return strAux;
        }
        //converte a sigla do estado para o nome do estado por extenso
        public static string NomeEstado(string UF)
        {
            switch (UF)
            {
                case "AC":
                    return "ACRE";
                case "AL":
                    return "ALAGOAS";
                case "AM":
                    return "AMAZONAS";
                case "AP":
                    return "AMAPA";
                case "BA":
                    return "BAHIA";
                case "CE":
                    return "CEARA";
                case "DF":
                    return "DISTRITO FEDERAL";
                case "ES":
                    return "ESPIRITO SANTO";
                case "EX":
                    return "EXTERIOR";
                case "GO":
                    return "GOIAS";
                case "MA":
                    return "MARANHAO";
                case "MG":
                    return "MINAS GERAIS";
                case "MS":
                    return "MATO GROSSO DO SUL";
                case "MT":
                    return "MATO GROSSO";
                case "PA":
                    return "PARA";
                case "PB":
                    return "PARAIBA";
                case "PE":
                    return "PERNAMBUCO";
                case "PI":
                    return "PIAUI";
                case "PR":
                    return "PARANA";
                case "RJ":
                    return "RIO DE JANEIRO";
                case "RN":
                    return "RIO GRANDO DO NORTE";
                case "RO":
                    return "RONDONIA";
                case "RR":
                    return "RORAIMA";
                case "RS":
                    return "RIO GRANDE DO SUL";
                case "SC":
                    return "SANTA CATARINA";
                case "SE":
                    return "SERGIPE";
                case "SP":
                    return "SAO PAULO";
                case "TO":
                    return "TOCANTINS";
                default:
                    return "";
            }
        }
        //retornando um string somente com letras e numeros
        public static string PlacaSomenteLetrasNumero(string pTexto)
        {
            string sAux = "";

            //removendo os espaços da string
            pTexto = pTexto.Trim();

            for (int x = 1; x <= pTexto.Length; x++)
            {
                if ("0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz".IndexOf(pTexto.Substring(x - 1, 1))>0)
                {
                    sAux = sAux + pTexto.Substring(x - 1, 1);
                }
            }
            sAux = sAux.Trim();

            //verifica se a função retornou algum número
            if (sAux.Length == 0)
            {
                return "";
            }
            else
            {
                return sAux;
            }
        }
        //função que formata o campo para impressão em modo texto
        public static string FormatText(string pTexto, string pFormat, int pTamanho, eAlign pAlinhamento)
        {
            //se não informado se trunca as casas decimais, move com update não
            return FormatText(pTexto, pFormat, pTamanho, false, 0, pAlinhamento);
        }
        public static string FormatText(string pTexto, string pFormat,int pTamanho, Boolean pTruncaDecimal, eAlign pAlinhamento)
        {
            //se não informado se trunca as casas decimais, move com update não
            return FormatText(pTexto, pFormat, pTamanho, pTruncaDecimal, 0, pAlinhamento);
        }
        public static string FormatText(string pTexto, string pFormat, int pTamanho, Boolean pTruncaDecimal, int pQtdeDecimalMinimo, eAlign pAlinhamento)
        {
            //formatando o campo
            if (pFormat.Length > 0)
            {
                string nTexto = pTexto;
                pTexto = String.Format(nTexto, pFormat);
            }

            //eliminando os espaços do texto
            pTexto = pTexto.Trim();

            //se o conteudo do texto for maior que o tamanho permitido, trunca
            if (pTexto.Length > pTamanho)
                pTexto = pTexto.Substring(0, pTamanho);
                

            //se não possuir casa decimal
            if (pTruncaDecimal == true)
            {
                //verifica se possue casa decimal
                if (pTexto.IndexOf(",") > 0)
                {
                    while ((pQtdeDecimalMinimo > 0 & (pTexto.Length - pTexto.IndexOf(",") > pQtdeDecimalMinimo) | pQtdeDecimalMinimo == 0))
                    {
                        //se a ultima casa decimal é zero, subtrai a casa decimal
                        if (pTexto.PadRight(1) == "0")
                        //if (String.Right(pTexto, 1) == "0")
                        {
                            pTexto = pTexto.Substring(0, pTexto.Length-1);
                            //pTexto = Strings.Mid(pTexto, 1, pTexto.Length - 1);
                        }
                        //se a ultima casa decimal for virgula, remove a virgula
                        else if (pTexto.PadRight(1) == ",")
                        //else if (Strings.Right(pTexto, 1) == ",")
                        {
                            pTexto = pTexto.Substring(0, pTexto.Length - 1);
                            //pTexto = Strings.Mid(pTexto, 1, pTexto.Length - 1);
                            
                            
                        }
                        //se for outra caracter, encerra
                        else
                        {
                            
                        }
                    }
                }
            }

            //alinhando a direita
            if (pAlinhamento == eAlign.Direita)
            {
                return EmcResources.Space((pTamanho - pTexto.Length)) + pTexto;
            }
            else
            {
                //alinhando a esquerda
                return pTexto + EmcResources.Space((pTamanho - pTexto.Length));
            }
        }

#endregion





    }
}
