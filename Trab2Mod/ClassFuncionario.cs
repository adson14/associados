using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Trab2Mod
{
    public class ClassFuncionario
    {
        //DEFINIÇÃO DAS VARIÁVEIS
        public int codFuncionario { get; set; }
        public string nome { get; set; }
        public string cpf { get; set; }
        public string dataNasc { get; set; }
        public string endereco { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
        public string pais { get; set; }
        public string telFixo { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string tipoFuncionario { get; set; }
        public int status { get; set; }
        public int codFuncResp { get; set; }


        //INSTANCIANDO CLASSES
        ClassConexao conect = new ClassConexao();
        ClassVariaveis var = new ClassVariaveis();


        //MÉTODO DE LOGIN 
        public bool Logar(ClassFuncionario funcionario)
        {
            conect.Conectar();
            DataTable dt = conect.RetDataTable(String.Format("SELECT loginUsuario, senha FROM funcionario WHERE loginUsuario = '{0}' AND senha = '{1}' ", funcionario.login, funcionario.senha));
            if (dt.Rows.Count > 0)
            {
                return true;

            }
            else
            {

                return false;
            }


        }


        //METODO PARA INSERIR DADOS DO USUÁRIO NO BANCO
        public bool inserir(ClassFuncionario funcionario)
        {

            conect.Conectar();

            //inserindo dados
            conect.ExecutarComandosSql(String.Format("Insert into funcionario (nome,cpf,dataNAsc,endereco,numero,complemento,bairro,cidade,estado,pais,telFixo,celular,email,tipoFuncionario,loginUsuario,senha,statusFunc,funcionario_codFuncResp)" +
                "VALUES ('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',{16},{17})",
                funcionario.nome, funcionario.cpf, funcionario.dataNasc, funcionario.endereco, funcionario.numero, funcionario.complemento, funcionario.bairro, funcionario.cidade, funcionario.estado, funcionario.pais, funcionario.telFixo, funcionario.celular, funcionario.email, funcionario.tipoFuncionario, funcionario.login, funcionario.senha, funcionario.status, funcionario.codFuncResp));

            conect.Desconectar();

            return true;
        }

        //editando
        public bool Editar(int idFuncClicado, int codFuncResp, ClassFuncionario funcionario)
        {
            conect.Conectar();
            conect.ExecutarComandosSql(String.Format("UPDATE funcionario SET nome = '{0}',cpf = '{1}',dataNAsc = '{2}',endereco = '{3}',numero = {4},complemento = '{5}',bairro = '{6}',cidade = '{7}',estado = '{8}',pais = '{9}',telFixo = '{10}',celular = '{11}',email = '{12}',tipoFuncionario = '{13}',loginUsuario = '{14}',senha = '{15}',statusFunc = {16},funcionario_codFuncResp = {17} WHERE codFuncionario = {18}",
            funcionario.nome, funcionario.cpf, funcionario.dataNasc, funcionario.endereco, funcionario.numero, funcionario.complemento, funcionario.bairro, funcionario.cidade, funcionario.estado, funcionario.pais, funcionario.telFixo, funcionario.celular, funcionario.email, funcionario.tipoFuncionario, funcionario.login, funcionario.senha, funcionario.status, codFuncResp, idFuncClicado));
            conect.Desconectar();
            return true;
        }
        //excluindo
        public bool Excluir(int idFuncClicado)//RECEBENDO O ID PASSADO QUANDO O METODO É CHAMADO
        {
            conect.Conectar();
            conect.ExecutarComandosSql(String.Format("DELETE funcionario WHERE codFuncionario = '{0}'", idFuncClicado));
            conect.Desconectar();
            return true;
        }

        //buscando dados
        public DataTable RetTodosFuncionarios()
        {
            conect.Conectar();
            DataTable dt = conect.RetDataTable(String.Format("SELECT * FROM funcionario WHERE codFuncionario <> 1"));
            conect.Desconectar();


            return dt;
        }

        //buscando individualmente


        public DataTable RetFuncPorNome(string nomeBuscado)
        {
            conect.Conectar();
            DataTable dt = conect.RetDataTable(String.Format("SELECT * FROM funcionario WHERE nome LIKE '%{0}%'", nomeBuscado));
            conect.Desconectar();

            //Se ele tiver pelo menos uma linha irá retornar os dados
            return dt;
        }



        //METODO PARA PEGAR O CODIGO DO FUNCIONÁRIO LOGADO
        public int RetCodFunc(string nomeLogado)
        {
            conect.Conectar();
            //PESQUISA O CODIGO PELO NOME DIGITADO NO TEXTOBOX DO LOGIN
            DataTable dt = conect.RetDataTable(String.Format("SELECT codFuncionario FROM funcionario WHERE loginUsuario LIKE '%{0}%'", nomeLogado));


            if (dt.Rows.Count > 0)//SE ENCONTRAR ALGUM REGISTRO
            {
                int codFuncionario = int.Parse(dt.Rows[0]["codFuncionario"].ToString());//ARMAZENA NA VARIÁVEL

                conect.Desconectar();

                return codFuncionario;// RETORNA O CÓDIGO DO FUNCIONÁRIO 


            }
            else
            {

                conect.Desconectar();

                return 0;
            }

        }
        //retornar filtrode um determinado funcionario
        public DataTable RetAcesosFunc(int codFunc)
        {
            conect.Conectar();
            DataTable dt = conect.RetDataTable(String.Format("SELECT sala_codSala AS 'SALAS DISP' FROM AcessoSala WHERE funcionario_codFuncionario = {0}", codFunc));
            conect.Desconectar();

            //Se ele tiver pelo menos uma linha irá retornar os dados
            return dt;
        }


        /////////////////////////////////////



        public string RetTipoFunc(string nomeLogado)
        {
            conect.Conectar();
            //PESQUISA O CODIGO PELO NOME DIGITADO NO TEXTOBOX DO LOGIN
            DataTable dt = conect.RetDataTable(String.Format("SELECT tipoFuncionario FROM funcionario WHERE loginUsuario LIKE '%{0}%'", nomeLogado));


            if (dt.Rows.Count > 0)//SE ENCONTRAR ALGUM REGISTRO
            {
                string tipoFunc = dt.Rows[0]["tipoFuncionario"].ToString();//ARMAZENA NA VARIÁVEL

                conect.Desconectar();

                return tipoFunc;// RETORNA O CÓDIGO DO FUNCIONÁRIO 


            }
            else
            {

                conect.Desconectar();

                return "";
            }


        }

        //bloqueio de usuario
        public bool Bloquear(ClassFuncionario funcionario,int cod)
        {
            conect.Conectar();
            conect.ExecutarComandosSql(String.Format("UPDATE funcionario SET statusFunc = '{0}' WHERE codFuncionario = {1}",
           1, cod));
            conect.Desconectar();
            return true;
        }

        //retorna codigo de status do funcionario

        public int RetStatusFunc(string nomeLogado)
        {
            conect.Conectar();
            //PESQUISA O CODIGO PELO NOME DIGITADO NO TEXTOBOX DO LOGIN
            DataTable dt = conect.RetDataTable(String.Format("SELECT statusFunc FROM funcionario WHERE loginUsuario LIKE '%{0}%'", nomeLogado));


            if (dt.Rows.Count > 0)//SE ENCONTRAR ALGUM REGISTRO
            {
                int statusFun = int.Parse(dt.Rows[0]["statusFunc"].ToString());//ARMAZENA NA VARIÁVEL

                conect.Desconectar();

                return statusFun;// RETORNA O CÓDIGO DO FUNCIONÁRIO 


            }
            else
            {

                conect.Desconectar();

                return 2;
            }


        }
    }
}
