using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;

namespace EMCImob
{
    public partial class frmPrincipal : Form
    {
        ConectaBancoMySql Conexao;

        public frmPrincipal()
        {
            Conexao = new ConectaBancoMySql();
            Conexao.conectar();
            InitializeComponent();
        }


        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            grdAplicacao.Rows.Add("Tabela de Comodos");
            grdAplicacao.Rows.Add("Tabela de Tipos de Imóveis");
            grdAplicacao.Rows.Add("Tabela de Grupos Ativos");
            grdAplicacao.Rows.Add("Tabela de Carteira de Imoveis");
            grdAplicacao.Rows.Add("Tabela de Tipo Lançamento de Captação");
            grdAplicacao.Rows.Add("Tabela de Proventos");
            grdAplicacao.Rows.Add("Tabela de Imóveis");
            grdAplicacao.Rows.Add("Contas Captação do Vendedor");
            grdAplicacao.Rows.Add("Contrato Locação de Imóveis");
            grdAplicacao.Rows.Add("Despesa do Imóvel");
            grdAplicacao.Rows.Add("Iptu");
            grdAplicacao.Rows.Add("Integração Financeiro");
        }

        private void grdAplicacao_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Form oForm = new Form();
                switch (grdAplicacao.Rows[grdAplicacao.CurrentRow.Index].Cells["aplicacao"].Value.ToString())
                {
                    case ("Tabela de Comodos"):
                        oForm = new frmComodo("1", "1", "1", "1", Conexao);
                        break;
                    case ("Tabela de Tipos de Imóveis"):
                        oForm = new frmTipoImovel("1", "1", "1", "1", Conexao);
                        break;
                    //case ("Tabela de Grupos Ativos"):
                        //oForm = new frmAtivoGrupo("1", "1", "1", "1", Conexao);
                        //break;
                    case ("Tabela de Carteira de Imoveis"):
                        oForm = new frmCarteiraImoveis("1", "1", "1", "1", Conexao);
                        break;
                    case ("Tabela de Tipo Lançamento de Captação"):
                        oForm = new frmTipoLanctoCaptacao("1", "1", "1", "1",Conexao);
                        break;
                    case ("Tabela de Proventos"):
                        oForm = new frmLocacaoProventos("1", "1", "1", "1", Conexao);
                        break;
                    case ("Tabela de Imóveis"):
                        oForm = new frmImovel("1", "1", "1", "1", Conexao);
                        break;
                    case ("Contas Captação do Vendedor"):
                        oForm = new frmContasCaptacao("1", "1", "1", "1",Conexao);
                        break;
                    case ("Contrato Locação de Imóveis"):
                        oForm = new frmContratoLocacao("1", "1", "1", "1", Conexao);
                        break;
                    case ("Despesa do Imóvel"):
                        oForm = new frmDespesaImovel("1", "1", "1", "1", Conexao);
                        break;
                    case ("Iptu"):
                        oForm = new frmIptu("1", "1", "1", "1", Conexao);
                        break;
                    case ("Integração Financeiro"):
                        oForm = new frmIntegFinanceiro("1", "1", "1", "1", Conexao);
                        break;
                }
                oForm.Show();
             }
            catch (Exception err)
            {
                MessageBox.Show(err.StackTrace);
            }
        }
    }
}
