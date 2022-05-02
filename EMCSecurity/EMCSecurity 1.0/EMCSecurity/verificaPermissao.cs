using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EMCLibrary;
using EMCSecurityModel;
using EMCSecurityRN;

namespace EMCSecurity
{
    public class verificaPermissao
    {

        public static bool getPermissao(ConectaBancoMySql pConexao, int idUsuario, string Aplicativo, string Formulario, EmcResources.operacaoSeguranca Operacao)
        {
            Ocorrencia oOcorrencia = new Ocorrencia();
            MenuUsuarioRN oMenuRN = new MenuUsuarioRN(pConexao,oOcorrencia,0);
            MenuUsuario oMenu = new MenuUsuario();
            oMenu = oMenuRN.ObterPor(Formulario,idUsuario,Aplicativo);

            return getPermissao(pConexao,idUsuario,oMenu.idMenuSistema,Aplicativo,Operacao);

        }
        public static bool getPermissao(ConectaBancoMySql pConexao, int idUsuario, int idMenu, string Aplicativo, EmcResources.operacaoSeguranca Operacao) 
        {
            
            bool retPermissao=false;

            if (pConexao == null)
            {
                ConectaBancoMySql myConexao = new ConectaBancoMySql();
                pConexao = myConexao;
            }

            Ocorrencia oOcorrencia = new Ocorrencia();

            MenuUsuarioRN oMenuRN = new MenuUsuarioRN(pConexao,oOcorrencia,0);
            MenuUsuario oMenu = new MenuUsuario();
            oMenu = oMenuRN.ObterPor(idMenu,idUsuario,Aplicativo);

             Usuario oUsuario = new Usuario();
             oUsuario.idUsuario=idUsuario;
             UsuarioBLL oUserRN = new UsuarioBLL(pConexao);
             oUsuario=oUserRN.ObterPor(oUsuario);

             if (Operacao==EmcResources.operacaoSeguranca.execucao)
             {
                 //verifica se usuario tem permissão de execucao
                 if (oMenu.executa == "S")
                 {
                     //verifica se item de menu é exclusivo da JLM
                     if (oMenu.exclusivoJLM == "N")
                     {
                         //verifica se o nivel de usuario permite que ele acesse
                         if (oMenu.nivelUsuario >= oUsuario.nivelUsuario)
                         {
                             return true;
                         }  
                     }
                     else 
                     {
                         if (oUsuario.nome.ToUpper() == "JLM")
                         {
                             //verifica se o nivel de usuario permite que ele acesse
                             if (oMenu.nivelUsuario >= oUsuario.nivelUsuario)
                             {
                                 return true;
                             }  
                         }
                     }
                 }
                 else return false;
 
             }
             else if (Operacao==EmcResources.operacaoSeguranca.inclusao)
             {
                 if (oMenu.inclusao=="S")
                     return true;
                 else
                    return false;

             }
             else if (Operacao==EmcResources.operacaoSeguranca.alteracao)
             {
                 if (oMenu.alteracao=="S")
                     return true;
                 else
                    return false;

             }
             else if (Operacao == EmcResources.operacaoSeguranca.exclusao)
             {
                 if (oMenu.exclusao=="S")
                     return true;
                 else
                    return false;
             }
             else if (Operacao == EmcResources.operacaoSeguranca.impressao)
             {
                 if (oMenu.impressao=="S")
                     return true;
                 else
                    return false;
             }
             else if (Operacao == EmcResources.operacaoSeguranca.ocorrencia)
             {
                 if (oMenu.ocorrencia=="S")
                     return true;
                 else
                    return false;
             }
            return retPermissao;
           
        }

    }

    
}
