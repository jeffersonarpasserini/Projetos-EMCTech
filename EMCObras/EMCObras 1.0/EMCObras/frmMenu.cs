using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EMCLibrary;

namespace EMCObras
{
    public partial class frmMenu : Form
    {
        ConectaBancoMySql Conexao;

        public frmMenu()
        {
            Conexao = new ConectaBancoMySql();
            Conexao.conectar();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmObra_Etapa ofrm = new frmObra_Etapa("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmObra_Modulo ofrm = new frmObra_Modulo("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmObra_Tarefa ofrm = new frmObra_Tarefa("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmObra ofrm = new frmObra("1", "1", "1", "1", Conexao);
            //frmObra ofrm = new frmObra("1", "1", "15", "1", Conexao);
            //frmObra ofrm = new frmObra("1", "1", "501", "501", Conexao);
            ofrm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmCronograma ofrm = new frmCronograma("1", "1", "1", "1", Conexao);
            //frmCronograma ofrm = new frmCronograma("1", "1", "15", "1", Conexao);
            //frmCronograma ofrm = new frmCronograma("1", "1", "501", "501", Conexao);
            ofrm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmPrevisaoDespesa ofrm = new frmPrevisaoDespesa("1", "1", "1", "1", Conexao);
            //frmPrevisaoDespesa ofrm = new frmPrevisaoDespesa("1", "1", "15", "1", Conexao);
            //frmPrevisaoDespesa ofrm = new frmPrevisaoDespesa("1", "1", "501", "501", Conexao);
            ofrm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmOrcamentoObra ofrm = new frmOrcamentoObra("1", "1", "1", "1", Conexao);
            //frmOrcamentoObra ofrm = new frmOrcamentoObra("1", "1", "15", "1", Conexao);
            //frmOrcamentoObra ofrm = new frmOrcamentoObra("1", "1", "501", "501", Conexao);
            ofrm.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Relatorios.relOrcamentoObra ofrm = new Relatorios.relOrcamentoObra("1", "1", "1", "1", Conexao);
            Relatorios.relOrcamentoObra ofrm = new Relatorios.relOrcamentoObra("1", "1", "15", "1", Conexao);
            //Relatorios.relOrcamentoObra ofrm = new Relatorios.relOrcamentoObra("1", "1", "501", "501", Conexao);
            ofrm.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //Relatorios.relOrcamentoObra ofrm = new Relatorios.relOrcamentoObra("1", "1", "1", "1", Conexao);
            Relatorios.relObraCronograma ofrm = new Relatorios.relObraCronograma("1", "1", "15", "1", Conexao);
            //Relatorios.relOrcamentoObra ofrm = new Relatorios.relOrcamentoObra("1", "1", "501", "501", Conexao);
            ofrm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //Relatorios.relObraEtapa ofrm = new Relatorios.relObraEtapa("1", "1", "1", "1", Conexao);
            Relatorios.relObraEtapa ofrm = new Relatorios.relObraEtapa("1", "1", "15", "1", Conexao);
            //Relatorios.relObraEtapa ofrm = new Relatorios.relObraEtapa("1", "1", "501", "501", Conexao);
            ofrm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //Relatorios.relObraModulo ofrm = new Relatorios.relObraModulo("1", "1", "1", "1", Conexao);
            Relatorios.relObraModulo ofrm = new Relatorios.relObraModulo("1", "1", "15", "1", Conexao);
            //Relatorios.relObraModulo ofrm = new Relatorios.relObraModulo("1", "1", "501", "501", Conexao);
            ofrm.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //Relatorios.relObraTarefas ofrm = new Relatorios.relObraTarefas("1", "1", "1", "1", Conexao);
            Relatorios.relObraTarefas ofrm = new Relatorios.relObraTarefas("1", "1", "15", "1", Conexao);
            //Relatorios.relObraTarefas ofrm = new Relatorios.relObraTarefas("1", "1", "501", "501", Conexao);
            ofrm.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            frmObra_TipoContrato ofrm = new frmObra_TipoContrato("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            frmGerenciaTarefa ofrm = new frmGerenciaTarefa("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            frmObra_Lancamento ofrm = new frmObra_Lancamento("1", "1", "1", "1", Conexao);
            ofrm.Show();
        }
    }
}
