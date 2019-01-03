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
    public partial class frmSalasDisp : Form
    {
        ClassAcesso aceso = new ClassAcesso();
        ClassFuncionario funcionario = new ClassFuncionario();
        ClassRelatorioAcesso relatorio = new ClassRelatorioAcesso();
        int idSalaClicada = 0;
        public frmSalasDisp()
        {
            InitializeComponent();
        }

        private void frmSalasDisp_Load(object sender, EventArgs e)
        {
            dvgSalasDisp.DataSource = funcionario.RetAcesosFunc(frmLogin.funcLogado);

            if (frmLogin.funcLogado ==0)
            {
                MessageBox.Show("Você não tem acesso a nenhuma sala");
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (idSalaClicada!=0)
            {
                frmSalaAcessada salaAberta = new frmSalaAcessada();
                salaAberta.Show();


                relatorio.codFuncionario = frmLogin.funcLogado;
                relatorio.codSala = idSalaClicada;
                relatorio.dataAcesso =  DateTime.Now.ToLongDateString();



                try
                {
                    relatorio.inserir(relatorio);
                }
                catch (Exception ex)
                {
                    //Retorna mensagem ao usuário
                    throw new Exception(ex.Message); // Retorna mensagem de erro ao usuário
                }



            }
            else
            {
                MessageBox.Show("Você não possui acesso Liberado");
            }
           
        }

        private void dvgSalasDisp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgSalasDisp.Rows[e.RowIndex].Cells["SALAS DISP"].Value.ToString() != "")
            {

                //PARA ARMAZENAR O ID DO FUNCIONARIO CLICADO
                idSalaClicada = int.Parse(dvgSalasDisp.Rows[e.RowIndex].Cells["SALAS DISP"].Value.ToString());


            }
            else
            {
                idSalaClicada = 0;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // relatorio.dataAcesso = DateTime.Now.ToLongTimeString();
        }
    }
}
