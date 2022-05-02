using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;
using EMCCadastro;

namespace EMCCadastro
{
    public partial class menu : Form
    {
        ConectaBancoMySql Conexao;

        public menu()
        {
            Conexao = new ConectaBancoMySql();
            Conexao.conectar();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCep ofrm = new frmCep("1","1","1","1",Conexao);
            ofrm.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAplicacao ofrm = new frmAplicacao("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmBanco ofrm = new frmBanco("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmContaCusto ofrm = new frmContaCusto("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmCtaBancaria ofrm = new frmCtaBancaria("1", "1", "1", "1", Conexao);
            //frmCtaBancaria ofrm = new frmCtaBancaria("1", "1", "501", "501", Conexao);
            //frmCtaBancaria ofrm = new frmCtaBancaria("1", "1", "15", "1", Conexao);
            ofrm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmEmpresa ofrm = new frmEmpresa("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmFeriado ofrm = new frmFeriado("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmFormaPagamento ofrm = new frmFormaPagamento("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmIndexador ofrm = new frmIndexador("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmIndice ofrm = new frmIndice("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //frmPessoa ofrm = new frmPessoa("1", "1", "501", "501", Conexao);
            //frmPessoa ofrm = new frmPessoa("1", "1", "15", "1", Conexao);
            //frmPessoa ofrm = new frmPessoa("1", "1", "1", "1", Conexao);
            frmPessoa ofrm = new frmPessoa("1", "1", "120", "1", Conexao);

            ofrm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            frmTipoCobranca ofrm = new frmTipoCobranca("1", "1", "1", "1", Conexao);

            ofrm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            frmTipoDocumento ofrm = new frmTipoDocumento("1", "1", "1", "1", Conexao);
            //frmTipoDocumento ofrm = new frmTipoDocumento("1", "1", "15", "1", Conexao);
            //frmTipoDocumento ofrm = new frmTipoDocumento("1", "1", "501", "501", Conexao);
            ofrm.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Relatorios.relCadastroBanco ofrm = new Relatorios.relCadastroBanco("1", "1", "1", "1", Conexao);
            ofrm.Show();

        }

        private void button15_Click(object sender, EventArgs e)
        {
            Relatorios.relPessoa ofrm = new Relatorios.relPessoa("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

       private void button16_Click(object sender, EventArgs e)

       {
            Relatorios.relIndicePeríodo ofrm = new Relatorios.relIndicePeríodo("1", "1", "1", "1", Conexao);
            ofrm.Show();
       }

       private void button17_Click(object sender, EventArgs e)
       {
            Relatorios.relFormaPagamento ofrm = new Relatorios.relFormaPagamento("1", "1", "1", "1", Conexao);
            ofrm.Show();
       }
       
       private void button18_Click(object sender, EventArgs e)
       {
            Relatorios.relTipoCobranca ofrm = new Relatorios.relTipoCobranca("1", "1", "1", "1", Conexao);
            ofrm.Show();
       }

       private void button19_Click(object sender, EventArgs e)
       {
            Relatorios.relCtaBancaria ofrm = new Relatorios.relCtaBancaria("1", "1", "1", "1", Conexao);
            ofrm.Show();
       }

       private void button20_Click(object sender, EventArgs e)
       {
            Relatorios.relAplicacao ofrm = new Relatorios.relAplicacao("1", "1", "1", "1", Conexao);
            ofrm.Show();
       }

       private void button21_Click(object sender, EventArgs e)
       {
            Relatorios.relCEP ofrm = new Relatorios.relCEP("1", "1", "1", "1", Conexao);
            ofrm.Show();
       }

       private void button22_Click(object sender, EventArgs e)
       {
           frmHolding ofrm = new frmHolding("1", "1", "1", "1", Conexao);
           ofrm.Show();
       }

       private void button23_Click(object sender, EventArgs e)
       {
           frmGrupoEmpresa ofrm = new frmGrupoEmpresa("1", "1", "1", "1", Conexao);
           ofrm.Show();
       }

       private void button24_Click(object sender, EventArgs e)
       {
           frmHistorico ofrm = new frmHistorico("1", "1", "1", "1", Conexao);
           ofrm.Show();
       }

       private void button25_Click(object sender, EventArgs e)
       {
          Relatorios.relFeriado ofrm = new Relatorios.relFeriado("1", "1", "1", "1", Conexao);
          ofrm.Show();
       }
       
       private void button26_Click(object sender, EventArgs e)
       {
          Relatorios.relHistorico ofrm = new Relatorios.relHistorico("1", "1", "1", "1", Conexao);
          ofrm.Show();
       }

       private void button27_Click(object sender, EventArgs e)
       {
          Relatorios.relCustoComponenteGrupo ofrm = new Relatorios.relCustoComponenteGrupo("1", "1", "1", "1", Conexao);
          ofrm.Show();
       }
       
       private void button28_Click(object sender, EventArgs e)
       {
          Relatorios.relCustoComponente ofrm = new Relatorios.relCustoComponente("1", "1", "1", "1", Conexao);
          ofrm.Show();
       }

       private void button29_Click(object sender, EventArgs e)
       {
          Relatorios.relEmpresa ofrm = new Relatorios.relEmpresa("1", "1", "1", "1", Conexao);
          ofrm.Show();
       }

       private void button30_Click(object sender, EventArgs e)
       {
           frmCusto_ComponenteGrupo ofrm = new frmCusto_ComponenteGrupo("1", "1", "1", "1", Conexao);
           ofrm.Show();
       }

       private void button31_Click(object sender, EventArgs e)
       {
           frmCusto_Componente ofrm = new frmCusto_Componente("1", "1", "1", "1", Conexao);
           ofrm.Show();
       }

       private void button32_Click(object sender, EventArgs e)
       {
           frmEstado ofrm = new frmEstado("1", "1", "1", "1", Conexao);
           ofrm.Show();
       }

       private void button33_Click(object sender, EventArgs e)
       {
           frmIbgeCidade ofrm = new frmIbgeCidade("1", "1", "1", "1", Conexao);
           ofrm.Show();
       }

       private void button34_Click(object sender, EventArgs e)
       {
           frmCidade ofrm = new frmCidade("1", "1", "1", "1", Conexao);
           ofrm.Show();
       }
   }
}
