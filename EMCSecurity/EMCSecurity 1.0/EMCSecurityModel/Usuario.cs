using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EMCSecurityModel
{
    public class Usuario
    {
         public Usuario(int idUsuario, String vNome, String vNomeCompleto, String vSenha, String vNivelacesso, bool vValidado) 
         {

            this.idUsuario = idUsuario;
            this.nome = vNome;
            this.nomeCompleto = vNomeCompleto;
            this.senha = vSenha;
            this.nivelacesso = vNivelacesso;
            this.validado = vValidado;
            //empresas = lstEmpresa;
        }

        public Usuario() { }

        public virtual int idUsuario { get; set; }
        public virtual string nome { get; set; }
        public virtual string nomeCompleto { get; set; }
        public virtual string senha { get; set; }
        public virtual string nivelacesso { get; set; }
        public virtual int nivelUsuario { get; set; }
        public virtual bool validado { get; set; }
        public virtual List<UsuarioEmpresa> usuarioEmpresa { get; set; }
    }
}
