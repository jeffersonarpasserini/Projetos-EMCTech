using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCObras
{
    public class Version
    {
        public static string GetVersion()
        {

            string Versao = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            return Versao;

        }

    }
}
