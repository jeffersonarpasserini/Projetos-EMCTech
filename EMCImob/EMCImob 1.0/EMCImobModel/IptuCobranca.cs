using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCImobModel
{
    public class IptuCobranca
    {
        public IptuCobranca() { }

        public int idIptuCobranca { get; set; }
        public int idIptu { get; set; }
        public LocacaoCCPagar locacaoCCPagar { get; set; }
        public LocacaoCCReceber locacaoCCReceber { get; set; }
        public decimal valorIptu { get; set; }
        public double rateio { get; set; }
        public string statusOperacao { get; set; }

    }
}
