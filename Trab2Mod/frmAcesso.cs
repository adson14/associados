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
    public partial class frmAcesso : Form
    {

        ClassFuncionario funcionario = new ClassFuncionario();
        ClassAcesso acesso = new ClassAcesso();
        ClassSala sala = new ClassSala();
        int idFuncClicado;
        public frmAcesso()
        {
            InitializeComponent();
        }

        private void dvgBuscarFuncionarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            
        }

        public void Carregabox()
        {
            DataTable campo = new DataTable();

            sala.RetTodasSalas();
            campo = sala.RetTodasSalas();
            cboSala.ValueMember = "codSala";
            cboSala.DisplayMember = "codSala";

            cboSala.DataSource = campo;

        }


        private void frmAcesso_Load(object sender, EventArgs e)
        {
            DataTable campo = new DataTable();
            Carregabox();
            dvgBuscarFuncionarios.DataSource = funcionario.RetTodosFuncionarios();
            dvgAcessoLiberado.DataSource = acesso.RetTodosAcessos();

            this.tabControl1.TabPages.Remove(this.tabPage1);
            
            this.tabPage2.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {

            if (txtCodFunc.Text != "")
            {
                //VARIÁVEIS RECEBEM OS VALORES
                acesso.codFuncionario = int.Parse(txtCodFunc.Text);
                acesso.codSala = int.Parse(cboSala.Text);
                

                if (acesso.inserir(acesso) == true)// SE O RETORNO FOR POSITIVO
                {

                    //OS CAMPOS SÃO LIMPADOS PARA RECEBER NOVOS DADOS
                    txtCodFunc.Text = "";
                    cboSala.Text = "SELECIONE";

                    
                    MessageBox.Show("Funcionário liberado com Sucesso!");

                    

                }

                else
                {

                    MessageBox.Show("Erro ao Liberar Acesso!");


                }
                this.tabControl1.TabPages.Remove(this.tabPage1);
            }
            else
            {

                MessageBox.Show("Preencha o campo");


            }



            dvgBuscarFuncionarios.DataSource = funcionario.RetTodosFuncionarios();
            dvgAcessoLiberado.DataSource = acesso.RetTodosAcessos();


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idFuncClicado != 0)//VERIFICA SE POSSUI ALGUM REGISTRO SELECIONADO
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja remover o acesso?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    if (acesso.Excluir(idFuncClicado) == true)//ESCLUI E
                    {
                        //ATUALIZA DATAGRID
                        dvgAcessoLiberado.DataSource = acesso.RetTodosAcessos();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao excluir cadastro!");
                    }
                    MessageBox.Show("Registro apagado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

            }
            else
            {
                MessageBox.Show("Clique em um dos registros.");
            }
        }

        private void cboSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void dvgBuscarFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["codFuncionario"].Value.ToString() != "")
            {

                //PARA ARMAZENAR O ID DO FUNCIONARIO CLICADO
                idFuncClicado = int.Parse(dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["codFuncionario"].Value.ToString());


            }

            //Toda vez que clicar em um FUNCIONÁRIO, irá preencher automaticamente os 
            //controles/componentes no form

            txtCodFunc.Text = dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["codFuncionario"].Value.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

            txtCodFunc.Text = "";
            cboSala.Text = "";

            dvgBuscarFuncionarios.DataSource = funcionario.RetTodosFuncionarios();
            dvgAcessoLiberado.DataSource = acesso.RetTodosAcessos();

            this.tabControl1.TabPages.Remove(this.tabPage1);

            this.tabPage2.Show();
        }

        private void btnDesb_Click(object sender, EventArgs e)
        {
            this.tabControl1.TabPages.Insert(0, this.tabPage1);

            this.tabPage1.Show();
        }
    }
}
