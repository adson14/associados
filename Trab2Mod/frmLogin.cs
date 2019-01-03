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

namespace Trab2Mod
{
    public partial class frmLogin : Form
    {
        public static int funcLogado =0;

        ClassFuncionario funcionario = new ClassFuncionario();
        ClassSala sala = new ClassSala();
        
        ClassVariaveis var = new ClassVariaveis();
        frmPrincipal p = new frmPrincipal();
        int contTentativa = 0;
        int codfunc;
        
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {

            if ((txtUsuario.Text != "")&&(txtSenha.Text != ""))
            {
                funcionario.login = txtUsuario.Text;
                funcionario.senha = txtSenha.Text;

                if (contTentativa >=3)
                {
                    MessageBox.Show("Usuário bloqueado! Contate o Administrador");
                    codfunc = funcionario.RetCodFunc(funcionario.login);
                    funcionario.Bloquear(funcionario,codfunc);
                }

                if ((funcionario.Logar(funcionario)==true)&&(funcionario.RetStatusFunc(txtUsuario.Text)== 0))
                {

                   
                    
                    //PARA SABER QUAL O FUNCIONÁRIO LOGADO
                    funcLogado = funcionario.RetCodFunc(funcionario.login);//ENVIA O USUARIO PARA O METODO E ARMAZENA NA VARIÁVEL
                    ClassVariaveis.funcionarioLog = funcionario.RetTipoFunc(funcionario.login);


                    if ((funcionario.RetTipoFunc(funcionario.login) == "Administrador")|| (funcionario.RetTipoFunc(funcionario.login) == "Gerente"))
                     {
                     frmPrincipal principal = new frmPrincipal();
                     principal.Show();
                     }
                     

                    if (funcionario.RetTipoFunc(funcionario.login) == "Outros")
                     {
                        frmSalasDisp salasDisp = new frmSalasDisp();
                        salasDisp.Show();
                     }

                    this.Hide();
                }
                else if(funcionario.Logar(funcionario) == false)
                {
                    MessageBox.Show("Senha ou usuário incorreto");
                    contTentativa ++ ;

                }
                else
                {
                    MessageBox.Show("Usuário bloqueado! Contate o Administrador");
                }
            }
            else
            {
                MessageBox.Show("Digite todos os campos");
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Carregabox();
        }

        public void Carregabox()
        {
          

        }

        private void cboSala_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnEntrar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((txtUsuario.Text != "") && (txtSenha.Text != ""))
            {
                funcionario.login = txtUsuario.Text;
                funcionario.senha = txtSenha.Text;

                if (contTentativa >= 3)
                {
                    MessageBox.Show("Usuário bloqueado! Contate o Administrador");
                    codfunc = funcionario.RetCodFunc(funcionario.login);
                    funcionario.Bloquear(funcionario, codfunc);
                }

                if ((funcionario.Logar(funcionario) == true) && (funcionario.RetStatusFunc(txtUsuario.Text) == 0))
                {



                    //PARA SABER QUAL O FUNCIONÁRIO LOGADO
                    funcLogado = funcionario.RetCodFunc(funcionario.login);//ENVIA O USUARIO PARA O METODO E ARMAZENA NA VARIÁVEL
                    ClassVariaveis.funcionarioLog = funcionario.RetTipoFunc(funcionario.login);


                    if ((funcionario.RetTipoFunc(funcionario.login) == "Administrador") || (funcionario.RetTipoFunc(funcionario.login) == "Gerente"))
                    {
                        frmPrincipal principal = new frmPrincipal();
                        principal.Show();
                    }


                    if (funcionario.RetTipoFunc(funcionario.login) == "Outros")
                    {
                        frmSalasDisp salasDisp = new frmSalasDisp();
                        salasDisp.Show();
                    }

                    this.Hide();
                }
                else if (funcionario.Logar(funcionario) == false)
                {
                    MessageBox.Show("Senha ou usuário incorreto");
                    contTentativa++;

                }
                else
                {
                    MessageBox.Show("Usuário bloqueado! Contate o Administrador");
                }
            }
            else
            {
                MessageBox.Show("Digite todos os campos");
            }

        }
    }
}
