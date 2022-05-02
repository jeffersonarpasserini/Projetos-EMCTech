using EMCImobModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCImob
{


    public static class retPesquisa
    {

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
