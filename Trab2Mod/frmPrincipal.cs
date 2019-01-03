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
    public partial class frmPrincipal : Form
    {
        ClassVariaveis var = new ClassVariaveis();
        

        public frmPrincipal()
        {
            InitializeComponent();
        }

        protected void timer1_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
        }

        protected void frmPrincipal_Load(object sender, EventArgs e)
        {
            lblData.Text = DateTime.Now.ToLongDateString();
            lblUsuario.Text = ClassVariaveis.funcionarioLog;
            if (ClassVariaveis.funcionarioLog == "Administrador")
            {
               btnLoja.Enabled = true;

                
            }

        }

        protected void lblHora_Click(object sender, EventArgs e)
        {

        }

        protected void button1_Click(object sender, EventArgs e)
        {
            frmCadFunc funcionario = new frmCadFunc();
            funcionario.Show();
        }

        protected void button7_Click(object sender, EventArgs e)
        {
            frmCadLoja loja = new frmCadLoja();
            loja.Show();
        }

        protected void button6_Click(object sender, EventArgs e)
        {
            frmCadSala sala = new frmCadSala();
            sala.Show();
        }

        protected void button5_Click(object sender, EventArgs e)
        {
            frmRelatorio relatorio = new  frmRelatorio();
            relatorio.Show();
        }

        protected void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        protected void button2_Click(object sender, EventArgs e)
        {
            frmAcesso acesso = new frmAcesso();
            acesso.Show();
            
        }

        protected void lblData_Click(object sender, EventArgs e)
        {

        }

        protected void lblUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}
