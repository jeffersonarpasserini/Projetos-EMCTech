using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCSecurity;
using EMCSecurityRN;
using EMCSecurityModel;
using EmcMenuDAO;
using EmcMenuModel;
using System.Reflection;

namespace EMCMenu
{
   
    public partial class MenuPrincipal : Form
    {
        private ToolStripMenuItem ItemModulo = new ToolStripMenuItem();
        private ToolStripMenuItem ItemMenu = new ToolStripMenuItem();
        private ToolStripMenuItem ItemPrograma = new ToolStripMenuItem();

        //Conexao geral do banco de dados
        public ConectaBancoMySql Conexao;
        public static Assembly[] EMCDll = new Assembly[5];

        public MenuPrincipal()
        {
            try
            {
                frmLogin login = new frmLogin();
                login.ShowDialog();
                if (login.frmParametros != null)
                {
                    UsuarioLogado.idAcesso = login.frmParametros[0];
                    UsuarioLogado.codUsuario = login.frmParametros[1];
                    UsuarioLogado.nomeUsuario = login.frmParametros[2];
                    UsuarioLogado.nivelAcesso = login.frmParametros[3];
                    UsuarioLogado.idEmpresa = login.frmParametros[4];
                    UsuarioLogado.nomeEmpresa = login.frmParametros[5];
                    UsuarioLogado.empresaMaster = login.frmParametros[6];
                }
                else
                {
                    UsuarioLogado.idAcesso = "0";
                    UsuarioLogado.codUsuario = "";
                    UsuarioLogado.nomeUsuario="";
                    UsuarioLogado.nivelAcesso="";
                    UsuarioLogado.idEmpresa = "0";
                    UsuarioLogado.nomeEmpresa = "";
                    UsuarioLogado.empresaMaster = "0";
                }
                login.Close();
                
                InitializeComponent();
            }
            catch (Exception e) 
            {
                MessageBox.Show("Erro : " + e.Message);
            }
            InitializeComponent();
        }

        #region [Formulario]
        private void MenuPrincipal_Activated(object sender, EventArgs e)
        {
           

        }
        private void MenuPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        private void MenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!EMCSecurity.Logout.getLogout(Convert.ToInt32(UsuarioLogado.idAcesso), Conexao))
            {
                MessageBox.Show("Erro na baixa do login!");
            }
        }
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            if (UsuarioLogado.idAcesso.Equals("0") || UsuarioLogado.idAcesso == null)
            {
                this.Close();
            }


            //Cria a conexão com o banco de dados
            //ParametroBanco strConexao = new ParametroBanco();
            //Conexao = new ConectaBancoMySql(@strConexao.StrConnection());
            Conexao = new ConectaBancoMySql();
            Conexao.conectar();

            DestroiMenu();

            //UsuarioLogado.idModulo = "EMCCadastro";
            //MontaMenu("EMCCadastro", 1);
           // lblUsuario.Text = "Usuario : " + UsuarioLogado.nomeUsuario.Trim();
           // lblEmpresa.Text = "Empresa : " + UsuarioLogado.idEmpresa.Trim() + " - " + UsuarioLogado.nomeEmpresa.Trim();

            lblIdentificaLogin.Text = "";
            lblIdentificaLogin.Text = "Empresa : " + UsuarioLogado.idEmpresa.Trim() + " - " + UsuarioLogado.nomeEmpresa.Trim() + "  -  Usuário : " + UsuarioLogado.nomeUsuario.Trim();

           

        }
        #endregion

        #region [Gerenciamento do Menu Principal]
        private void DestroiMenu()
        {
            mnuPrincipal.Items.Clear();
        }
        private void MontaMenu(String Sistema, int idUsuario)
        {
            string strModulo = "";
            string strMenu = "";
            string strPrograma = "";
            int nivel0 = 0;
            int nivel1 = 1;
            int nivel2 = 2;

            //Busca as informações no banco de dados e cria os menus  
            DataTable dt = new DataTable();
            MenuDAO menu = new MenuDAO(Conexao);

            dt = menu.BuscaMenu(Sistema, idUsuario, nivel0, 0);

            foreach (DataRow drow in dt.Rows)
            {

                //1o. Nivel de menu
                if (drow["indicadorabertura"].ToString() == "N")
                {
                    // Carrega Informações do Módulo  
                    ItemModulo = new ToolStripMenuItem(drow["descricao"].ToString());
                    strModulo = drow["descricao"].ToString();


                    //adiciona item ao menustrip
                    mnuPrincipal.Items.Add(ItemModulo);

                    //busca por subniveis 2o nivel
                    DataTable dt01 = new DataTable();
                    MenuDAO menu01 = new MenuDAO(Conexao);
                    dt01 = menu01.BuscaMenu(Sistema, idUsuario, nivel1, int.Parse(drow["idmenusistema"].ToString()));

                    //2o nivel de menu
                    foreach (DataRow drow01 in dt01.Rows)
                    {
                        if (drow01["indicadorabertura"].ToString() == "N")
                        {
                            //Carrega Informações do Menu  
                            ItemMenu = new ToolStripMenuItem(drow01["descricao"].ToString());
                            strMenu = drow01["descricao"].ToString();

                            //adiciona 2o nivel ao itemmodulo
                            ItemModulo.DropDownItems.Add(ItemMenu);


                            //busca por subniveis 3o nivel
                            DataTable dt02 = new DataTable();
                            MenuDAO menu02 = new MenuDAO(Conexao);
                            dt02 = menu02.BuscaMenu(Sistema, idUsuario, nivel2, int.Parse(drow01["idmenusistema"].ToString()));

                            //3o nivel menu
                            foreach (DataRow drow02 in dt02.Rows)
                            {

                                if (drow02["indicadorabertura"].ToString() == "S")
                                {

                                    if (verificaPermissao.getPermissao(Conexao,
                                                         Convert.ToInt32(UsuarioLogado.codUsuario),
                                                         Convert.ToInt32(drow02["idmenusistema"].ToString()),
                                                         drow02["modulo"].ToString(),
                                                         EmcResources.operacaoSeguranca.execucao))
                                    {
                                        //Carrega Informações do Programa  
                                        ItemPrograma = new ToolStripMenuItem(drow02["descricao"].ToString());

                                        //Atribui o codigo do programa no banco de dados ao item  
                                        ItemPrograma.Tag = drow02["idmenusistema"];

                                        //Associa o evento do clic no StripMenu ao evento criado no código.  
                                        ItemPrograma.Click += new EventHandler(this.toolStripMenuItem_Click);
                                        strPrograma = drow02["descricao"].ToString();

                                        //adiciona 3o nivel ao subitem anterior
                                        ItemMenu.DropDownItems.Add(ItemPrograma);
                                    }
                                }
                                else
                                {
                                    //erro não pode ter nivel 3 sem indicacao de abertura
                                }
                            }

                        }
                        else
                        {
                            //abre programa no 2o nivel


                            if (verificaPermissao.getPermissao(Conexao,
                                                 Convert.ToInt32(UsuarioLogado.codUsuario),
                                                 Convert.ToInt32(drow01["idmenusistema"].ToString()),
                                                 drow01["modulo"].ToString(),
                                                 EmcResources.operacaoSeguranca.execucao))
                            {
                                //Carrega Informações do Menu  
                                ItemMenu = new ToolStripMenuItem(drow01["descricao"].ToString());
                                strMenu = drow01["descricao"].ToString();

                                //Atribui o codigo do programa no banco de dados ao item  
                                ItemMenu.Tag = drow01["idmenusistema"];

                                if (drow01["exibeimagem"].ToString() == "S")
                                {
                                    //carregar imagem
                                    //ItemMenu.Image = drow["urlimagem"].ToString();
                                }

                                //Associa o evento do clic no StripMenu ao evento criado no código.  
                                ItemMenu.Click += new EventHandler(this.toolStripMenuItem_Click);

                                //adiciona 2o nivel ao itemmodulo
                                ItemModulo.DropDownItems.Add(ItemMenu);
                            }
                        }    
                    
                    }

                }
                else
                {
                    //abre programa no 1o nivel

                    if (verificaPermissao.getPermissao(Conexao,
                                         Convert.ToInt32(UsuarioLogado.codUsuario),
                                         Convert.ToInt32(drow["idmenusistema"].ToString()),
                                         drow["modulo"].ToString(),
                                         EmcResources.operacaoSeguranca.execucao))
                    {
                        // Carrega Informações do Módulo  
                        ItemModulo = new ToolStripMenuItem(drow["descricao"].ToString());
                        strModulo = drow["descricao"].ToString();

                        //Atribui o codigo do programa no banco de dados ao item  
                        ItemModulo.Tag = drow["idmenusistema"];

                        if (drow["exibeimagem"].ToString() == "S")
                        {
                            //carregar imagem
                            //ItemModulo.Image = drow["urlimagem"].ToString();
                        }

                        //Associa o evento do clic no StripMenu ao evento criado no código.  
                        ItemModulo.Click += new EventHandler(this.toolStripMenuItem_Click);

                        //adiciona item ao menustrip
                        mnuPrincipal.Items.Add(ItemModulo);
                    }
                }     
            }

            /* Inserir controle de formulários abertos no MDI */
            // Carrega Informações do Módulo  
            ToolStripMenuItem ItemMdi = new ToolStripMenuItem("Formulários");
            
            //adiciona item ao menustrip
            mnuPrincipal.Items.Add(ItemMdi);

            mnuPrincipal.MdiWindowListItem  = ItemMdi;
        }
        #endregion

        #region [Barra de mensagem]
        private void toolStripMenuItem_Click(object sender, EventArgs e)
        {
            //abri o formulário conforme o codigo clicado no StripMenu  
            int CodigoPrograma = 0;
            ToolStripMenuItem ItemClicado;

            //Captura o item Clicado  
            ItemClicado = (ToolStripMenuItem)sender;
            //Identifica o codigo do item que foi clicado  
            CodigoPrograma = Convert.ToInt32(ItemClicado.Tag);

            MenuDAO dao = new MenuDAO(Conexao);
            MenuModel objMenu = new MenuModel();

            objMenu = dao.ObterForm(Convert.ToInt32(UsuarioLogado.codUsuario),
                                    UsuarioLogado.idModulo,CodigoPrograma);

            //String AssemblyDLL = objMenu.nNamespace.ToUpper()+".DLL";
            String Formulario = objMenu.endereco;

            //Abrindo o formulario de um outro Assembly de forma dinamica
            String Assembly_culture = "neutral";
            String Assembly_PublicKeyToken = "null";
           
            String Assembly_Version = "";
            

            /*0 - EMCLibrary
             *1 - EMCSecurity
             *2 - EMCCadastro
             *3 - EMCFinanceiro
             *4 - EMCImob
             */
            if (objMenu.nNamespace == "EMCSecurity")
            {
                Assembly_Version = EMCSecurity.Version.GetVersion();
            } 
            else if (objMenu.nNamespace == "EMCImob") 
            {
                Assembly_Version = EMCImob.Version.GetVersion();
            }
            else if (objMenu.nNamespace == "EMCCadastro")
            {
                Assembly_Version = EMCCadastro.Version.GetVersion();
            }
            else if (objMenu.nNamespace == "EMCFinanceiro")
            {
                Assembly_Version = EMCFinanceiro.Version.GetVersion();
            }
            else if (objMenu.nNamespace == "EMCEstoque")
            {
                Assembly_Version = EMCEstoque.Version.GetVersion();
            }
            else if (objMenu.nNamespace == "EMCObras")
            {
                Assembly_Version = EMCObras.Version.GetVersion();
            }
            else if (objMenu.nNamespace == "EMCFaturamento")
            {
                Assembly_Version = EMCFaturamento.Version.GetVersion();
            }

            String tela = objMenu.nNamespace.Trim() + "." + objMenu.endereco.Trim()+
                         ","+objMenu.nNamespace.Trim()+
                         ", Version="+Assembly_Version+
                         ", Culture="+Assembly_culture+
                         ", PublicKeyToken="+Assembly_PublicKeyToken;


            Type t = Type.GetType(tela);
            if (t != null)
            {
                //Form f = (Form)Activator.CreateInstance(t,UsuarioLogado.codUsuario,UsuarioLogado.idAcesso,UsuarioLogado.idEmpresa);
                Form f = (Form)Activator.CreateInstance(t, UsuarioLogado.codUsuario, UsuarioLogado.idAcesso,UsuarioLogado.idEmpresa,UsuarioLogado.empresaMaster,Conexao);
                if (false)
                {
                    f.ShowDialog(); 
                }
                f.MdiParent = this;
                f.Show();

            }

            //string nomeForm = @Formulario;
            //Form f = (Form)Activator.CreateInstance(null, nomeForm).Unwrap();
            //Form f = (Form)Activator.CreateInstance("EMCSecurity", nomeForm).Unwrap();
            //f.MdiParent = this;
            //f.Show();
        }
        #endregion

        #region [Botão - Modulos]
        private void btnCadastro_Click(object sender, EventArgs e)
        {
            DestroiMenu();
            UsuarioLogado.idModulo = "EMCCadastro";
            MontaMenu("EMCCadastro", EmcResources.cInt(UsuarioLogado.codUsuario));
        }

        private void btnFinanceiro_Click(object sender, EventArgs e)
        {
            DestroiMenu();
            UsuarioLogado.idModulo = "EMCFinanceiro";
            MontaMenu("EMCFinanceiro", EmcResources.cInt(UsuarioLogado.codUsuario));
        }

        private void btnImob_Click(object sender, EventArgs e)
        {
            DestroiMenu();
            UsuarioLogado.idModulo = "EMCImob";
            MontaMenu("EMCImob", EmcResources.cInt(UsuarioLogado.codUsuario));
        }

        private void btnFaturamento_Click(object sender, EventArgs e)
        {
            DestroiMenu();
            UsuarioLogado.idModulo = "EMCFaturamento";
            MontaMenu(UsuarioLogado.idModulo, EmcResources.cInt(UsuarioLogado.codUsuario));
        }
        private void btnEstoque_Click(object sender, EventArgs e)
        {
            DestroiMenu();
            UsuarioLogado.idModulo = "EMCEstoque";
            MontaMenu("EMCEstoque", EmcResources.cInt(UsuarioLogado.codUsuario));
        }

        private void btnObras_Click(object sender, EventArgs e)
        {
            DestroiMenu();
            UsuarioLogado.idModulo = "EMCObras";
            MontaMenu("EMCObras", EmcResources.cInt(UsuarioLogado.codUsuario));
        }

        private void btnSeguranca_Click(object sender, EventArgs e)
        {
            DestroiMenu();
            UsuarioLogado.idModulo = "EMCSecurity";
            MontaMenu("EMCSecurity", EmcResources.cInt(UsuarioLogado.codUsuario));
        }
#endregion

        private void btnTrocaEmpresa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Todos formulários abertos nesta empresa serão fechados. Confirma?", "Troca Empresa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    /* fechando os formulários abertos */
                    foreach (Form mdiChildForm in MdiChildren)
                    {
                        mdiChildForm.Close();
                    }

                    frmTrocaEmpresa oform = new frmTrocaEmpresa(Conexao);
                    oform.ShowDialog();

                    lblIdentificaLogin.Text = "";
                    lblIdentificaLogin.Text = "Empresa : " + UsuarioLogado.idEmpresa.Trim() + " - " + UsuarioLogado.nomeEmpresa.Trim() + "  -  Usuário : " + UsuarioLogado.nomeUsuario.Trim();

                }
                else
                {

                }
            }
            catch(Exception oErro)
            {
                MessageBox.Show("Erro :" + oErro.Message);
            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       

        


   

    }
}
