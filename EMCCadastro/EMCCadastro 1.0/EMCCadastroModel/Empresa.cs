using System.Collections.Generic; 
using System.Text; 
using System;


namespace EMCCadastroModel
{
    
    public partial class Empresa {
        public Empresa() { }
        
        public Empresa(int vIdEmpresa, Empresa vEmpMaster, String vRazaoSocial, String vNomeFantasia, String vCnpjCpf,
                       String vInscrEstadual, String vInscrMunicipal, String vEndereco,
                       String vNumero, String vBairro, String vComplemento, String vCidade, Cep vCep,
                       String vEstado, String vLogo, String vTelefone, Pessoa vPessoa)
        {
            this.idEmpresa = vIdEmpresa;
            this.empMaster = vEmpMaster;
            this.razaoSocial = vRazaoSocial;
            this.nomeFantasia = vNomeFantasia;
            this.cnpjcpf = vCnpjCpf;
            this.inscrEstadual = vInscrEstadual;
            this.inscrMunicipal = vInscrMunicipal;
            this.endereco = vEndereco;
            this.numero = vNumero;
            this.bairro = vBairro;
            this.complemento = vComplemento;
            this.cidade = vCidade;
            this.cep = vCep;
            this.estado = vEstado;
            this.logo = vLogo;
            this.telefone = vTelefone;
            this.pessoa = vPessoa;
        }
            
        
        public virtual int idEmpresa { get; set; }
        public virtual Empresa empMaster { get; set; }
        public virtual Cep cep { get; set; }
        public virtual string razaoSocial { get; set; }
        public virtual string nomeFantasia { get; set; }
        public virtual string cnpjcpf { get; set; }
        public virtual string inscrEstadual { get; set; }
        public virtual string inscrMunicipal { get; set; }
        public virtual string endereco { get; set; }
        public virtual string numero { get; set; }
        public virtual string bairro { get; set; }
        public virtual string complemento { get; set; }
        public virtual string cidade { get; set; }
        public virtual string estado { get; set; }
        public virtual string logo {get; set; }
        public virtual string telefone{get; set;}
        public virtual Pessoa pessoa { get; set; }
        public virtual string matrizFilial { get; set; }
        public virtual GrupoEmpresa grupoEmpresa { get; set; }
        public virtual Empresa matriz { get; set; }
    }
}
