using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trab2Mod
{
    public partial class frmRelatorio : Form
    {

        ClassRelatorioAcesso relatorio = new ClassRelatorioAcesso();
        public frmRelatorio()
        {
            InitializeComponent();
        }

        private void frmRelatorio_Load(object sender, EventArgs e)
        {
            dvgBuscaRelatorio.DataSource = relatorio.RetTodosRelatorios();
        }

        private void dvgBuscaRelatorio_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //dvgBuscaRelatorio.DataSource = relatorio.RetTodosRelatorios();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dvgBuscaRelatorio.DataSource = relatorio.RetRelaFuncPorNome(txtBuscar.Text);
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void frmRelatorio_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}
