using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCCadastroModel
{
    public class Pessoa
    {

        public Pessoa()
        {

        }

        public Pessoa(int codEmpresa, int idPessoa, String nome, String nomeFantasia,
                      String cnpjCpf, String tipoPessoa, String inscrMunicipal, String nroRG, 
                      String inscrEstadual, String endereco,
                      String numero, String bairro, String complemento, String cidade,
                      String estado, String idCep, DateTime dataNascimento, String email,
                      String imagem, String site)
        {

            this.codEmpresa = codEmpresa;
            this.idPessoa = idPessoa;
            this.nome = nome;
            this.nomeFantasia = nomeFantasia;
            this.cnpjCpf = cnpjCpf;
            this.tipopessoa = tipopessoa;
            this.inscrMunicipal = inscrMunicipal;
            this.nroRG = nroRG;
            this.InscrEstadual = inscrEstadual;
            this.endereco = endereco;
            this.numero = numero;
            this.bairro = bairro;
            this.complemento = complemento;
            this.cidade = cidade;
            this.estado = estado;
            this.idCep = idCep;
            this.dataNascimento = dataNascimento;
            this.email = email;
            this.imagem = imagem;
            this.site = site;
          
        }
        public virtual int codEmpresa { get; set; }
        public virtual int idPessoa { get; set; }
        public virtual string nome { get; set; }
        public virtual string nomeFantasia { get; set; }
        public virtual string cnpjCpf { get; set; }
        public virtual string tipopessoa { get; set; }
        public virtual string nroRG { get; set; }
        public virtual string InscrEstadual { get; set; }
        public virtual string inscrMunicipal { get; set; }
        public virtual string endereco { get; set; }
        public virtual string numero { get; set; }
        public virtual string bairro { get; set; }
        public virtual string complemento { get; set; }
        public virtual string cidade { get; set; }
        public virtual string estado { get; set; }
        public virtual string idCep { get; set; }
        public virtual DateTime dataNascimento { get; set; }
        public virtual string email { get; set; }
        public virtual string imagem { get; set; }
        public virtual string site { get; set; }
        public virtual Fornecedor fornecedor { get; set; }
        public virtual Cliente cliente { get; set; }

    }
}
