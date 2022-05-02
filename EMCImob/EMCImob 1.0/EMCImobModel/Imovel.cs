using EMCCadastroModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCImobModel
{
    public class Imovel
    {
        public Imovel()
        {
        }

        public virtual int idImovel { get; set; }
        public virtual TipoImovel tipoImovel { get; set; }
        public virtual string descricao { get; set; }
        public virtual string rua { get; set; }
        public virtual string numero { get; set; }
        public virtual string complemento { get; set; }
        public virtual string bairro { get; set; }
        public virtual string cidade { get; set; }
        public virtual string estado { get; set; }
        public virtual string nroCep { get; set; }
        public virtual string anotacoes { get; set; }
        public virtual string observacoes { get; set; }
        public virtual Decimal valorVenda { get; set; }
        public virtual Decimal valorAluguel { get; set; }
        public virtual Decimal valorCondominio { get; set; }
        public virtual string enderecoChave { get; set; }
        public virtual string matriculaCri { get; set; }
        public virtual double areaConstruida { get; set; }
        /*
         * Situação para Imovel
         * A - Liberado para Locação ou venda
         * L - Imovel com contrato de locação em andamento
         * V - Imovel vendido
         * I - Imovel Inativo
         * C - Cancelado
         */
        public virtual string situacao { get; set; }
       
        public virtual Fornecedor fornecedor { get; set; }
        public virtual CarteiraImoveis carteiraImoveis { get; set; }
        public virtual ContaCusto contaCusto { get; set; }
        public virtual List<ImovelProprietario> lstProprietario { get; set; }
        public virtual List<ImovelComodo> lstComodo { get; set; }
        public virtual Empresa empresa { get; set; }
        public virtual string codigoImovel { get; set; }        
    }
}
