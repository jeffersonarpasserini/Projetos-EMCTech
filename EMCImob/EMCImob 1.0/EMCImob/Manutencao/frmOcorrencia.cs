using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EMCImobModel;
using EMCImobRN;
using EMCLibrary;

namespace EMCImob
{
    public partial class frmOcorrencia : Form
    {
        private String usuario = "";
        private String login = "";
        private int codempresa = 0;
        private int empMaster = 0;
        private ConectaBancoMySql Conexao;
        private Ocorrencia objOcorrencia;

        public frmOcorrencia(String idUsuario, String seqLogin, String idEmpresa, String empmaster, ConectaBancoMySql parConexao, Ocorrencia Oco)
        {
            usuario = idUsuario;
            login = seqLogin;
            codempresa = Convert.ToInt32(idEmpresa);
            empMaster = Convert.ToInt32(empmaster);
            Conexao = parConexao;
            objOcorrencia = Oco;
            InitializeComponent();
        }

        private void frmOcorrencia_Load(object sender, EventArgs e)
        {
            montaGrid();
        }

        private void montaGrid()
        {
            if (!string.IsNullOrEmpty(objOcorrencia.chaveidentificacao))
            {
                OcorrenciaRN oRN = new OcorrenciaRN(Conexao, codempresa);
                //adquiri lista de parcelas do objeto documento
                List<Ocorrencia> lstOcorrencia = oRN.ListaOcorrencia(objOcorrencia);

                grdOcorrencia.Rows.Clear();

                foreach (Ocorrencia oOcorrencia in lstOcorrencia)
                {
                    grdOcorrencia.Rows.Add(oOcorrencia.idOcorrencia, oOcorrencia.data_hora, oOcorrencia.descricao);
                }
                grdOcorrencia.ScrollBars = ScrollBars.Both;
            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
