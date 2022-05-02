using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastro
{
    public static class retPesquisa
    {
        //area de tranferancia global do sistema

        private static int xcodempresa;
        public static int codempresa
        {
            get { return xcodempresa; }
            set { xcodempresa = value; }
        }

        private static string xchavebusca;
        public static string chavebusca
        {
            get { return xchavebusca; }
            set { xchavebusca = value; }
        }

        private static int xchaveinterna;
        public static int chaveinterna
        {
            get { return xchaveinterna; }
            set { xchaveinterna = value; }
        }

    }

}
