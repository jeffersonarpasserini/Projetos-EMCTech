using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace EMCLibrary
{
    public class CrtlAssembly
    {
        public enum eLoad
        {
            Tab = 1,
            Show = 2,
            ShowDialog = 3
        }

        
        public static Assembly[] AsmEMC = new Assembly[5];

        /// <summary>
        /// Funcao que retorna os bytes de um assemby
        /// </summary>
        /// <param name="pLibrary"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        private static string GetPathAssembly(string pLibrary)
        {
            return pLibrary;
        }

        /// <summary>
        /// Retorna o Assembly do Modulo solicitado
        /// </summary>
        /// <param name="pLibrary"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static Assembly LoadAssembly(string pLibrary)
        {
            
            //case do modulo passado
            switch (pLibrary.ToUpper())
            {
                 
                //0 Library
                case "EMCLIBRARY.DLL":
                    if (AsmEMC[0] == null)
                    {
                        AsmEMC[0] = Assembly.LoadFrom(GetPathAssembly(pLibrary));
                    }
                    return AsmEMC[0];

                //1 Seguranca
                case "EMCSECURITY.DLL":
                    if (AsmEMC[1] == null)
                    {
                        AsmEMC[1] = Assembly.LoadFrom(GetPathAssembly(pLibrary));
                    }
                    return AsmEMC[1];

                //2 Cadastro
                case "EMCCADASTRO.DLL":
                    if (AsmEMC[2] == null)
                    {
                        AsmEMC[2] = Assembly.LoadFrom(GetPathAssembly(pLibrary));
                    }
                    return AsmEMC[2];

                //3 Financeiro
                case "EMCFINANCEIRO.DLL":
                    if (AsmEMC[3] == null)
                    {
                        AsmEMC[3] = Assembly.LoadFrom(GetPathAssembly(pLibrary));
                    }
                    return AsmEMC[3];

                //4 Locacao
                case "EMCLOCACAO.DLL":
                    if (AsmEMC[4] == null)
                    {
                        AsmEMC[4] = Assembly.LoadFrom(GetPathAssembly(pLibrary));
                    }
                    return AsmEMC[4];

                default:
                    return Assembly.LoadFrom(GetPathAssembly(pLibrary));

            }
        }


        /// <summary>
        /// Carrega o Objeto informado
        /// </summary>
        /// <param name="pLibrary"></param>
        /// <param name="pObject"></param>
        /// <param name="pParametro"></param>
        /// <param name="pTipoLoad"></param>
        /// <param name="pStart"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        //public static object LoadObject(string pLibrary, string pObject, object pParametro, eLoad pTipoLoad, bool pStart)
        //{
        //    //variáveis para carregar o object
        //    Type Tpe = default(Type);
        //    object Form = default(object);

        //    try
        //    {

        //        //Criando um Tipo através do objeto informado
        //        Tpe = LoadAssembly(pLibrary).GetType(pObject, false, true);

        //        //instanciando o objeto, se tiver parametros com o parametro, senão, sem
        //        if (pParametro.Count > 0)
        //        {
        //            object[] oParametro = pParametro.ToArray;
        //            Form = Activator.CreateInstance(Tpe, oParametro);
        //        }
        //        else
        //        {
        //            Form = Activator.CreateInstance(Tpe);
        //        }

        //        //carregando o objeto conforme o tipo
        //        if (pTipoLoad == eLoad.Tab)
        //        {

        //            if (Form is System.Windows.Controls.UserControl)
        //            {

        //                Form.Start(tplBasico.eShowForm.Show);

        //            }
        //            else
        //            {

        //                if (pStart == true)
        //                {
        //                    if (Form.TopMost == true)
        //                    {
        //                        Form.TopMost = false;
        //                        Form.StartPosition = FormStartPosition.CenterScreen;
        //                        Form.Start(tplCadastro.eShowForm.ShowDialog);
        //                    }
        //                    else
        //                    {
        //                        Form.Start(tplCadastro.eShowForm.Show);
        //                    }
        //                }
        //                else
        //                {
        //                    if (Form.TopMost == true)
        //                    {
        //                        Form.TopMost = false;
        //                        Form.StartPosition = FormStartPosition.CenterScreen;
        //                        Form.ShowDialog();
        //                    }
        //                    else
        //                    {
        //                        Form.Show();
        //                    }
        //                }

        //            }


        //        }
        //        else if (pTipoLoad == eLoad.Show)
        //        {

        //            if (Form is System.Windows.Controls.UserControl)
        //            {

        //                Form.Start(tplBasico.eShowForm.Show);

        //            }
        //            else
        //            {

        //                if (pStart == true)
        //                {
        //                    Form.StartPosition = FormStartPosition.CenterScreen;
        //                    Form.Start(tplCadastro.eShowForm.Show);
        //                }
        //                else
        //                {
        //                    Form.StartPosition = FormStartPosition.CenterScreen;
        //                    Form.Show();
        //                }

        //            }


        //        }
        //        else if (pTipoLoad == eLoad.ShowDialog)
        //        {

        //            if (Form is System.Windows.Controls.UserControl)
        //            {

        //                Form.Start(tplCadastro.eShowForm.ShowDialog);

        //            }
        //            else
        //            {

        //                if (pStart == true)
        //                {
        //                    Form.StartPosition = FormStartPosition.CenterScreen;
        //                    Form.Start(tplCadastro.eShowForm.ShowDialog);
        //                    Form.Close();
        //                    Form.Dispose();
        //                }
        //                else
        //                {
        //                    Form.ShowDialog();
        //                }

        //            }

        //        }
        //        return Form;
        //    }
        //    catch (Exception ex)
        //    {
        //        CapturaErro("Leitura de " + pObject + " - Menus Dinâmicos", "", ex);
        //        return Form;
        //    }
        //}
    }
}
