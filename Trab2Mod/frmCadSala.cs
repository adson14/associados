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
    public partial class frmCadSala : Form
    {
        ClassLoja loja = new ClassLoja();
        ClassSala sala = new ClassSala();
        ClassVariaveis var = new ClassVariaveis();

        int idSalaClicada;


        public frmCadSala()
        {
            InitializeComponent();
        }

        private void frmSala_Load(object sender, EventArgs e)
        {
            Carregabox();
            dvgBuscarSala.DataSource = sala.RetTodasSalas();

            this.tabControl1.TabPages.Remove(this.tabPage1);
           
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


        public void Carregabox()
        {
            DataTable campo = new DataTable();

            loja.RetTodasLojas();
            campo = loja.RetTodasLojas();
            cboLoja.ValueMember = "codLoja";
            cboLoja.DisplayMember = "codLoja";

            cboLoja.DataSource = campo;

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text != "")
            {
                //VARIÁVEIS RECEBEM OS VALORES
                sala.descricao = txtDescricao.Text;
                sala.codResponsavel = frmLogin.funcLogado;
                sala.codLoja = int.Parse(cboLoja.Text);

                if (sala.inserir(sala) == true)// SE O RETORNO FOR POSITIVO
                {

                    //OS CAMPOS SÃO LIMPADOS PARA RECEBER NOVOS DADOS
                    txtDescricao.Text = "";
                    cboLoja.Text = "SELECIONE";

                    dvgBuscarSala.DataSource = sala.RetTodasSalas();
                    MessageBox.Show("Cadastro Realizado com Sucesso!");

                    this.tabControl1.TabPages.Remove(this.tabPage1);
                    this.tabControl1.TabPages.Insert(0, this.tabPage2);
                    this.tabPage2.Show();

                }

                else
                {

                    MessageBox.Show("Erro ao realizar cadastro!");


                }
            }
            else
            {

                MessageBox.Show("Preencha o campo");


            }
        }

        private void dvgBuscarSala_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dvgBuscarSala_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgBuscarSala.Rows[e.RowIndex].Cells["codSala"].Value.ToString() != "")
            {

                //PARA ARMAZENAR O ID DO FUNCIONARIO CLICADO
                idSalaClicada = int.Parse(dvgBuscarSala.Rows[e.RowIndex].Cells["codSala"].Value.ToString());

                //PARA ARMAZENAR O ID DO FUNCIONÁRIO RESPONSÁVEL
                var.idFuncResp = int.Parse(dvgBuscarSala.Rows[e.RowIndex].Cells["funcionario_codFuncResp"].Value.ToString());
            }

            //Toda vez que clicar em um FUNCIONÁRIO, irá preencher automaticamente os 
            //controles/componentes no form

            txtDescricao.Text = dvgBuscarSala.Rows[e.RowIndex].Cells["descricao"].Value.ToString();
            cboLoja.Text = dvgBuscarSala.Rows[e.RowIndex].Cells["loja_codLoja"].Value.ToString();
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnEditar2.Visible = true;
            btnGravar.Visible = false;
            //CHAMA AS ABAS DE CADASTRO PARA EDITAR
            this.tabControl1.TabPages.Insert(0, this.tabPage1);
            this.tabPage1.Show();
           
        }

        private void btnEditar2_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text !="")
            {

                sala.descricao = txtDescricao.Text;
                sala.codResponsavel = 1;
                sala.codLoja = int.Parse(cboLoja.Text);
                




                if (sala.Editar(idSalaClicada, var.idFuncResp, sala) == true)
                {
                    MessageBox.Show("Editado com sucesso!");
                    //OS CAMPOS SÃO LIMPADOS PARA RECEBER NOVOS DADOS
                    txtDescricao.Text = "";
                    cboLoja.Text = "SELECIONE";


                    //ATULAIZA O DATAGRID
                    dvgBuscarSala.DataSource = sala.RetTodasSalas();

                    //REMOVE E ABRE ABAS
                    this.tabControl1.TabPages.Remove(this.tabPage1);
                    this.tabPage2.Show();
                }
                else
                {
                    MessageBox.Show("Erro ao realizar edição!");
                }

            }
            else
            {
                MessageBox.Show("Preencha todos os dados");
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //REMOVE E INSERE AS ABAS
            this.tabControl1.TabPages.Remove(this.tabPage2);
            this.tabControl1.TabPages.Insert(0, this.tabPage1);
            this.tabPage1.Show();
            
            //OS CAMPOS SÃO LIMPADOS PARA RECEBER NOVOS DADOS
            txtDescricao.Text = ""; 
            cboLoja.Text = "SELECIONE"; 
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.tabControl1.TabPages.Remove(this.tabPage1);
            this.tabControl1.TabPages.Insert(0, this.tabPage2);

            this.tabPage2.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (idSalaClicada != 0)//VERIFICA SE POSSUI ALGUM REGISTRO SELECIONADO
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    if (sala.Excluir(idSalaClicada) == true)//ESCLUI E
                    {
                        //ATUALIZA DATAGRID
                        dvgBuscarSala.DataSource = sala.RetTodasSalas();
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

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            dvgBuscarSala.DataSource = sala.RetTodasSalas();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dvgBuscarSala.DataSource = sala.RetSalaPorNome(txtBuscar.Text);
        }

        private void cboLoja_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmSala_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
    
}
