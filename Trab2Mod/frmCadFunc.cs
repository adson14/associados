using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Correios.Net;

namespace Trab2Mod
{
    public partial class frmCadFunc : Form
    {
        ClassConexao conect = new ClassConexao();
        ClassFuncionario funcionario = new ClassFuncionario();
        ClassVariaveis var = new ClassVariaveis();
        frmLogin login = new frmLogin();

        int idFuncClicado;
        int statusVerificacao;

        int contPreencimento ;//PARA CONTAR O NUMERO DE CAMPOS PREENCHIDOS

        //METODO VERIFICA CAMPOS PREENCHIDOS
        public int Verificar()
        {
            contPreencimento = 0;
            if (txtNome.Text !="")
            {
                contPreencimento++;
            }

            if (mskCpf.Text != "   .   .   -")
            {
                contPreencimento++;
            }

            if (mskDataNasc.Text != "  /  /")
            {
                contPreencimento++;
            }

            if (txtEndereco.Text != "")
            {
                contPreencimento++;
            }

            if (txtNumero.Text != "")
            {
                contPreencimento++;
            }

            if (txtComplemento.Text != "")
            {
                contPreencimento++;
            }

            if (txtBairro.Text != "")
            {
                contPreencimento++;
            }

            if (txtCidade.Text != "")
            {
                contPreencimento++;
            }

            if (txtEstado.Text != "")
            {
                contPreencimento++;
            }

            if (cboPais.Text != "SELECIONE")
            {
                contPreencimento++;
            }


            if (mskCelular.Text != "(   )    -")
            {
                contPreencimento++;
            }


            if (cboTipoFunc.Text != "SELECIONE")
            {
                contPreencimento++;
            }

            if (txtUsuario.Text != "")
            {
                contPreencimento++;
            }

            if (txtSenha.Text != "")
            {
                contPreencimento++;
            }

            return contPreencimento;

        }

        


        public frmCadFunc()
        {
            InitializeComponent();
        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;// BOTÃO AVANÇA PARA A PROXIMA ABA

        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Verificar();// VERIFICA OS CAMPOS

            if (contPreencimento == 14)
            {

            //VARIÁVEIS RECEBEM OS VALORES
            funcionario.nome = txtNome.Text;
            funcionario.cpf = mskCpf.Text;
            funcionario.dataNasc = mskDataNasc.Text;
            funcionario.endereco = txtEndereco.Text;
            funcionario.numero = int.Parse(txtNumero.Text);
            funcionario.complemento = txtComplemento.Text;
            funcionario.bairro = txtBairro.Text;
            funcionario.cidade = txtCidade.Text;
            funcionario.estado = txtEstado.Text;
            funcionario.pais = cboPais.Text;
            funcionario.telFixo = mskTelFixo.Text;
            funcionario.celular = mskCelular.Text;
            funcionario.email = txtEmail.Text;
            funcionario.tipoFuncionario = cboTipoFunc.Text;
            funcionario.login = txtUsuario.Text;
            funcionario.senha = txtSenha.Text;
            funcionario.status = 0;



                funcionario.codFuncResp = frmLogin.funcLogado;


           
                if (funcionario.inserir(funcionario) == true)// SE O RETORNO FOR POSITIVO
                {

                    //OS CAMPOS SÃO LIMPADOS PARA RECEBER NOVOS DADOS
                    txtNome.Text = ""; ;
                    mskCpf.Text = "";
                    mskDataNasc.Text = "";
                    txtEndereco.Text = "";
                    txtNumero.Text = "";
                    txtComplemento.Text = "";
                    txtBairro.Text = "";
                    txtCidade.Text = "";
                    txtEstado.Text = "";
                    cboPais.Text = "";
                    mskTelFixo.Text = "";
                    mskCelular.Text = "";
                    txtEmail.Text = "";
                    cboTipoFunc.Text = "";
                    txtUsuario.Text = "";
                    txtSenha.Text = "";

                    // O DATAGRID É ATUALIZADO PARA MOSTRAR OS DADOS
                    dvgBuscarFuncionarios.DataSource = funcionario.RetTodosFuncionarios();
                    MessageBox.Show("Cadastro Realizado com Sucesso!");

                    //ABERTURA E FECHAMENTO DE ABAS
                    this.tabControl1.TabPages.Insert(0, this.tabPage3);
                    this.tabControl1.TabPages.Remove(this.tabPage1);
                    this.tabControl1.TabPages.Remove(this.tabPage2);

                }
                else
                {
                    MessageBox.Show("Erro ao realizar cadastro!");
                }

            }
            else
            {
                MessageBox.Show("Preencha todos os dados");
            }

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
       
        private void frmCadFunc_Load(object sender, EventArgs e)
        {
            
           //REMOVE DUAS ABAS NA INICIALIZAÇÃO
            this.tabControl1.TabPages.Remove(this.tabPage1);
            this.tabControl1.TabPages.Remove(this.tabPage2);

            //ATUALIZA O DATAGRID
            dvgBuscarFuncionarios.DataSource = funcionario.RetTodosFuncionarios();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        // EVENTO PARA OBTER O ID DO FUNCIONÁRIO CLICADO NO DATAGRID
        private void dvgBuscarFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                 
            if (dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["codFuncionario"].Value.ToString() != "")
            {

                //PARA ARMAZENAR O ID DO FUNCIONARIO CLICADO
                idFuncClicado = int.Parse(dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["codFuncionario"].Value.ToString());
                
                //PARA ARMAZENAR O ID DO FUNCIONÁRIO RESPONSÁVEL
                var.idFuncResp = int.Parse(dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["funcionario_codFuncResp"].Value.ToString());
            }

            //Toda vez que clicar em um FUNCIONÁRIO, irá preencher automaticamente os 
            //controles/componentes no form
       
            txtNome.Text = dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["nome"].Value.ToString();
            mskCpf.Text = dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["cpf"].Value.ToString();
            mskDataNasc.Text = dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["dataNAsc"].Value.ToString();
            txtEndereco.Text = dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["endereco"].Value.ToString();
            txtNumero.Text = dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["numero"].Value.ToString();
            txtComplemento.Text = dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["complemento"].Value.ToString();
            txtBairro.Text = dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["bairro"].Value.ToString();
            txtCidade.Text = dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["cidade"].Value.ToString();
            txtEstado.Text = dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["estado"].Value.ToString();
            cboPais.Text = dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["pais"].Value.ToString();
            mskTelFixo.Text = dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["telFixo"].Value.ToString();
            mskCelular.Text = dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["celular"].Value.ToString();
            txtEmail.Text = dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["email"].Value.ToString();
            cboTipoFunc.Text = dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["tipoFuncionario"].Value.ToString();
            txtUsuario.Text = dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["loginUsuario"].Value.ToString();
            txtSenha.Text = dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["senha"].Value.ToString();
            txtStatus.Text = dvgBuscarFuncionarios.Rows[e.RowIndex].Cells["statusFunc"].Value.ToString();
            


        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnEditar2.Visible = true;
            btnGravar.Visible = false;
            //CHAMA AS ABAS DE CADASTRO PARA EDITAR
            this.tabControl1.TabPages.Insert(0, this.tabPage2);
            this.tabControl1.TabPages.Insert(0, this.tabPage1);
            //REMOVE A ABA DE VISUALIZAÇÃO
            this.tabControl1.TabPages.Remove(this.tabPage3);

            if ((txtStatus.Text == 1.ToString())&&(ClassVariaveis.funcionarioLog == "Administrador"))
            {
                rbtLiberar.Visible = true;
                
            }
            if (ClassVariaveis.funcionarioLog == "Gerente")
            {
                txtUsuario.Enabled = false;
                txtSenha.Enabled = false;
                


            }



        }
        //BOTÃO PARA CONFIRMAR EDIÇÃO
        private void btnEditar2_Click(object sender, EventArgs e)
        {

            Verificar();//VERIFICA OS CAMPOS

            if (contPreencimento == 14)
            {

                funcionario.nome = txtNome.Text;
                funcionario.cpf = mskCpf.Text;
                funcionario.dataNasc = mskDataNasc.Text;
                funcionario.endereco = txtEndereco.Text;
                funcionario.numero = int.Parse(txtNumero.Text);
                funcionario.complemento = txtComplemento.Text;
                funcionario.bairro = txtBairro.Text;
                funcionario.cidade = txtCidade.Text;
                funcionario.estado = txtEstado.Text;
                funcionario.pais = cboPais.Text;
                funcionario.telFixo = mskTelFixo.Text;
                funcionario.celular = mskCelular.Text;
                funcionario.email = txtEmail.Text;
                funcionario.tipoFuncionario = cboTipoFunc.Text;
                funcionario.login = txtUsuario.Text;
                funcionario.senha = txtSenha.Text;

                if (rbtLiberar.Checked = true)
                {
                    funcionario.status = 0;
                }







                if (funcionario.Editar(idFuncClicado,var.idFuncResp, funcionario) == true)
                {
                    MessageBox.Show("Editado com sucesso!");
                    txtNome.Text = ""; ;
                    mskCpf.Text = "";
                    mskDataNasc.Text = "";
                    txtEndereco.Text = "";
                    txtNumero.Text = "";
                    txtComplemento.Text = "";
                    txtBairro.Text = "";
                    txtCidade.Text = "";
                    txtEstado.Text = "";
                    cboPais.Text = "";
                    mskTelFixo.Text = "";
                    mskCelular.Text = "";
                    txtEmail.Text = "";
                    cboTipoFunc.Text = "";
                    txtUsuario.Text = "";
                    txtSenha.Text = "";
                    
                    rbtLiberar.Checked = false;
                    
                    //ATULAIZA O DATAGRID
                    dvgBuscarFuncionarios.DataSource = funcionario.RetTodosFuncionarios();

                    //REMOVE E ABRE ABAS
                    this.tabControl1.TabPages.Remove(this.tabPage1);
                    this.tabControl1.TabPages.Remove(this.tabPage2);
                    this.tabControl1.TabPages.Insert(0, this.tabPage3);
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (idFuncClicado!=0)//VERIFICA SE POSSUI ALGUM REGISTRO SELECIONADO
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    if (funcionario.Excluir(idFuncClicado) == true)//ESCLUI E
                    {
                        //ATUALIZA DATAGRID
                        dvgBuscarFuncionarios.DataSource = funcionario.RetTodosFuncionarios();
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

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {

            //BUSCA O REGISTRO PELO NOME DIGITADO NO TEXTBOX
            dvgBuscarFuncionarios.DataSource = funcionario.RetFuncPorNome(txtBuscar.Text);
        }

        private void button2_Click_2(object sender, EventArgs e)
        {

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //REMOVE E INSERE AS ABAS
            this.tabControl1.TabPages.Remove(this.tabPage3);
            this.tabControl1.TabPages.Insert(0, this.tabPage1);
            this.tabControl1.TabPages.Insert(0, this.tabPage2);

            //OS CAMPOS SÃO LIMPADOS PARA RECEBER NOVOS DADOS
            txtNome.Text = ""; ;
            mskCpf.Text = "";
            mskDataNasc.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
            cboPais.Text = "";
            mskTelFixo.Text = "";
            mskCelular.Text = "";
            txtEmail.Text = "";
            cboTipoFunc.Text = "";
            txtUsuario.Text = "";
            txtSenha.Text = "";

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //ATUALIZA O DATAGRID QUANDO OCORRE UMA AÇÃO NO TEXTBOX
            dvgBuscarFuncionarios.DataSource = funcionario.RetTodosFuncionarios();
        }

        //LIMPA TODOS OS DADOS CASO DESISTA DO CADASTRO
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtNome.Text = ""; ;
            mskCpf.Text = "";
            mskDataNasc.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
            cboPais.Text = "";
            mskTelFixo.Text = "";
            mskCelular.Text = "";
            txtEmail.Text = "";
            cboTipoFunc.Text = "";
            txtUsuario.Text = "";
            txtSenha.Text = "";

            //REMOVE AS ABAS DE CADASTRO E INSERE A ABA DE VISUALIZAÇÃO
            this.tabControl1.TabPages.Remove(this.tabPage1);
            this.tabControl1.TabPages.Remove(this.tabPage2);
            this.tabControl1.TabPages.Insert(0, this.tabPage3);
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void txtNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtComplemento_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBairro_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEndereco_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCidade_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void mskDataNasc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }
        //BOTÃO FECHAR DO FORM
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void maskedTextBox1_Leave(object sender, EventArgs e)
        {
            
                
            
        }
        

        private void mskCep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtCEP_Leave(object sender, EventArgs e)
        {
           
        }

        private void txtCEP_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void mskCelular_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void mskTelFixo_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txtEstado_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void mskCpf_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cboTipoFunc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmCadFunc_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))

            {

                e.Handled = true;

            }
        }
    }
}
