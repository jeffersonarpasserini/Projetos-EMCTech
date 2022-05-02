using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCMenu
{
    public static class UsuarioLogado
    {
        private static string idUsuario = "";
        public static string codUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        private static string nome = "";
        public static string nomeUsuario
        {
            get { return nome; }
            set { nome = value; }
        }
        private static string nivel = "";
        public static string nivelAcesso
        {
            get { return nivel; }
            set { nivel = value; }
        }
        private static string acesso = "";
        public static string idAcesso
        {
            get { return acesso; }
            set { acesso = value; }
        }
        private static string modulo = "";
        public static string idModulo
        {
            get { return modulo; }
            set { modulo = value; }
        }
        private static string empresa = "0";
        public static string idEmpresa
        {
            get { return empresa; }
            set { empresa = value; }
        }
        private static string nomeempresa = "";
        public static string nomeEmpresa
        {
            get { return nomeempresa; }
            set { nomeempresa = value; }
        }
        private static string empresamaster = "";
        public static string empresaMaster
        {
            get { return empresamaster; }
            set { empresamaster = value; }
        }
    }
}
