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
    public partial class frmCadLoja : Form
    {

        ClassConexao conect = new ClassConexao();
        ClassLoja loja = new ClassLoja();
        ClassSala sala = new ClassSala();
        ClassVariaveis var = new ClassVariaveis();
        frmLogin login = new frmLogin();

        int idLojaClicada;


        int contPreencimento;//PARA CONTAR O NUMERO DE CAMPOS PREENCHIDOS

        //METODO VERIFICA CAMPOS PREENCHIDOS
        public int Verificar()
        {
            contPreencimento = 0;
            if (txtRazao.Text != "")
            {
                contPreencimento++;
            }

            if (txtFantasia.Text != "")
            {
                contPreencimento++;
            }


            if (mskCNPJ.Text != "  .   .   /    -")
            {
               contPreencimento++;
            }

            if (mskDataIn.Text != "  /  /")
            {
                contPreencimento++;
            }
            
            if (cboTipo.Text != "SELECIONE")
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


            if (mskTelFixo.Text != "(   )    -")
            {
                contPreencimento++;
            }

            
            return contPreencimento;

        }


        public frmCadLoja()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            Verificar();// VERIFICA OS CAMPOS

            if (contPreencimento == 13)
            {

                //VARIÁVEIS RECEBEM OS VALORES
                loja.razaoSocial = txtRazao.Text;
                loja.nomeFantasia = txtFantasia.Text;
                loja.cnpj = mskCNPJ.Text;
                loja.site = txtSite.Text;
                loja.inauguracao = mskDataIn.Text;
                loja.tipoLoja = int.Parse(cboTipo.Text);

                loja.endereco = txtEndereco.Text;
                loja.numero = int.Parse(txtNumero.Text);
                loja.complemento = txtComplemento.Text;
                loja.bairro = txtBairro.Text;
                loja.cidade = txtCidade.Text;
                loja.estado = txtEstado.Text;
                loja.pais = cboPais.Text;
                loja.telFixo = mskTelFixo.Text;
                loja.celular = mskCelular.Text;
                loja.email = txtEmail.Text;
                loja.codResponsavel = frmLogin.funcLogado;



                if (loja.inserir(loja) == true)// SE O RETORNO FOR POSITIVO
                {

                    //OS CAMPOS SÃO LIMPADOS PARA RECEBER NOVOS DADOS
                    txtRazao.Text = ""; ;
                    txtFantasia.Text = ""; ;
                    mskCNPJ.Text = "";
                    mskDataIn.Text = "";
                    cboTipo.Text = "";
                    txtSite.Text = "";
                    txtEndereco.Text = "";
                    txtNumero.Text = "";
                    txtComplemento.Text = "";
                    txtBairro.Text = "";
                    txtCidade.Text = "";
                    txtEstado.Text = "";
                    cboPais.Text = "";
                    mskCelular.Text = "";
                    txtEmail.Text = "";


                    // O DATAGRID É ATUALIZADO PARA MOSTRAR OS DADOS
                    dvgBuscarLoja.DataSource = loja.RetTodasLojas();
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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;// BOTÃO AVANÇA PARA A PROXIMA ABA

        }

        private void dvgBuscarLoja_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dvgBuscarLoja_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dvgBuscarLoja.Rows[e.RowIndex].Cells["codLoja"].Value.ToString() != "")
            {

                //PARA ARMAZENAR O ID DO FUNCIONARIO CLICADO
                idLojaClicada = int.Parse(dvgBuscarLoja.Rows[e.RowIndex].Cells["codLoja"].Value.ToString());

                //PARA ARMAZENAR O ID DO FUNCIONÁRIO RESPONSÁVEL
                var.idFuncResp = int.Parse(dvgBuscarLoja.Rows[e.RowIndex].Cells["funcionario_codFuncResp"].Value.ToString());
            }

            //Toda vez que clicar em um FUNCIONÁRIO, irá preencher automaticamente os 
            //controles/componentes no form

            txtRazao.Text = dvgBuscarLoja.Rows[e.RowIndex].Cells["razaoSocial"].Value.ToString();
            txtFantasia.Text = dvgBuscarLoja.Rows[e.RowIndex].Cells["nomeFantasia"].Value.ToString();
            mskCNPJ.Text = dvgBuscarLoja.Rows[e.RowIndex].Cells["cnpj"].Value.ToString();
            
            txtEndereco.Text = dvgBuscarLoja.Rows[e.RowIndex].Cells["endereco"].Value.ToString();
            txtNumero.Text = dvgBuscarLoja.Rows[e.RowIndex].Cells["numero"].Value.ToString();
            txtComplemento.Text = dvgBuscarLoja.Rows[e.RowIndex].Cells["complemento"].Value.ToString();
            txtBairro.Text = dvgBuscarLoja.Rows[e.RowIndex].Cells["bairro"].Value.ToString();
            txtCidade.Text = dvgBuscarLoja.Rows[e.RowIndex].Cells["cidade"].Value.ToString();
            txtEstado.Text = dvgBuscarLoja.Rows[e.RowIndex].Cells["estado"].Value.ToString();
            cboPais.Text = dvgBuscarLoja.Rows[e.RowIndex].Cells["pais"].Value.ToString();
            mskTelFixo.Text = dvgBuscarLoja.Rows[e.RowIndex].Cells["telFixo"].Value.ToString();
            mskCelular.Text = dvgBuscarLoja.Rows[e.RowIndex].Cells["celular"].Value.ToString();
            txtEmail.Text = dvgBuscarLoja.Rows[e.RowIndex].Cells["email"].Value.ToString();
            txtSite.Text = dvgBuscarLoja.Rows[e.RowIndex].Cells["siteEmpresa"].Value.ToString();
            mskDataIn.Text = dvgBuscarLoja.Rows[e.RowIndex].Cells["dataInauguracao"].Value.ToString();
            cboTipo.Text = dvgBuscarLoja.Rows[e.RowIndex].Cells["tipoLoja"].Value.ToString();
           
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
        }

        private void btnEditar2_Click(object sender, EventArgs e)
        {

            Verificar();//VERIFICA OS CAMPOS

            if (contPreencimento == 13)
            {

                loja.razaoSocial = txtRazao.Text;
                loja.nomeFantasia = txtFantasia.Text;
                loja.cnpj = mskCNPJ.Text;
                loja.site = txtSite.Text;
                loja.inauguracao = mskDataIn.Text;
                loja.tipoLoja = int.Parse(cboTipo.Text);

                loja.endereco = txtEndereco.Text;
                loja.numero = int.Parse(txtNumero.Text);
                loja.complemento = txtComplemento.Text;
                loja.bairro = txtBairro.Text;
                loja.cidade = txtCidade.Text;
                loja.estado = txtEstado.Text;
                loja.pais = cboPais.Text;
                loja.telFixo = mskTelFixo.Text;
                loja.celular = mskCelular.Text;
                loja.email = txtEmail.Text;
                loja.codResponsavel = 1;




                if (loja.Editar(idLojaClicada, var.idFuncResp, loja) == true)
                {
                    MessageBox.Show("Editado com sucesso!");
                    //OS CAMPOS SÃO LIMPADOS PARA RECEBER NOVOS DADOS
                    txtRazao.Text = ""; ;
                    txtFantasia.Text = ""; ;
                    mskCNPJ.Text = "";
                    mskDataIn.Text = "";
                    cboTipo.Text = "";
                    txtSite.Text = "";
                    txtEndereco.Text = "";
                    txtNumero.Text = "";
                    txtComplemento.Text = "";
                    txtBairro.Text = "";
                    txtCidade.Text = "";
                    txtEstado.Text = "";
                    cboPais.Text = "";
                    mskCelular.Text = "";
                    txtEmail.Text = "";

                    //ATULAIZA O DATAGRID
                    dvgBuscarLoja.DataSource = loja.RetTodasLojas();

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

        private void frmCadLoja_Load(object sender, EventArgs e)
        {

            //REMOVE DUAS ABAS NA INICIALIZAÇÃO
            this.tabControl1.TabPages.Remove(this.tabPage1);
            this.tabControl1.TabPages.Remove(this.tabPage2);

            //ATUALIZA O DATAGRID
            dvgBuscarLoja.DataSource = loja.RetTodasLojas();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //REMOVE E INSERE AS ABAS
            this.tabControl1.TabPages.Remove(this.tabPage3);
            this.tabControl1.TabPages.Insert(0, this.tabPage1);
            this.tabControl1.TabPages.Insert(0, this.tabPage2);

            //OS CAMPOS SÃO LIMPADOS PARA RECEBER NOVOS DADOS
            txtRazao.Text = ""; 
            txtFantasia.Text = ""; 
            mskCNPJ.Text = "";
            mskDataIn.Text = "";
            cboTipo.Text = "";
            txtSite.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
            cboPais.Text = "";
            mskCelular.Text = "";
            txtEmail.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (idLojaClicada != 0)//VERIFICA SE POSSUI ALGUM REGISTRO SELECIONADO
            {
                if (DialogResult.Yes == MessageBox.Show("Tem certeza que deseja apagar o registro?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2))
                {
                    sala.ExcluiPorLoj(idLojaClicada);

                    if (loja.Excluir(idLojaClicada) == true)//ESCLUI E
                    {
                        //ATUALIZA DATAGRID
                        dvgBuscarLoja.DataSource = loja.RetTodasLojas();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            //OS CAMPOS SÃO LIMPADOS PARA RECEBER NOVOS DADOS
            txtRazao.Text = ""; ;
            txtFantasia.Text = ""; ;
            mskCNPJ.Text = "";
            mskDataIn.Text = "";
            cboTipo.Text = "";
            txtSite.Text = "";
            txtEndereco.Text = "";
            txtNumero.Text = "";
            txtComplemento.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtEstado.Text = "";
            cboPais.Text = "";
            mskCelular.Text = "";
            txtEmail.Text = "";

            //REMOVE AS ABAS DE CADASTRO E INSERE A ABA DE VISUALIZAÇÃO
            this.tabControl1.TabPages.Remove(this.tabPage1);
            this.tabControl1.TabPages.Remove(this.tabPage2);
            this.tabControl1.TabPages.Insert(0, this.tabPage3);

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            //ATUALIZA O DATAGRID QUANDO OCORRE UMA AÇÃO NO TEXTBOX
            dvgBuscarLoja.DataSource = loja.RetTodasLojas();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dvgBuscarLoja.DataSource = loja.RetLojaPorNome(txtBuscar.Text);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmCadLoja_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
    
    }
