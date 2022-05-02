using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCLibrary
{
    public class popCombo
    {
        string _nome;
        string _valor;

        public popCombo(string nome, string valor)
        {
            Nome = nome;
            Valor = valor;
        }
        
        public string Valor
        {
        get { return _valor; }
        set { _valor = value; }
        }

        public string Nome
        {
        get { return _nome; }
        set { _nome = value; }
        }
    
    }


}
