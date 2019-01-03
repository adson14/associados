using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Trab2Mod
{
    public class ClassAcesso
    {
        public int codAcesso { get; set; }
        public int codSala { get; set; }
        public int codFuncionario { get; set; }
      

        ClassConexao conect = new ClassConexao();

        public bool inserir(ClassAcesso acesso)
        {

            conect.Conectar();

            //inserindo dados
            conect.ExecutarComandosSql(String.Format("Insert into AcessoSala (sala_codSala,funcionario_codFuncionario)" +
                "VALUES ({0},{1})",
                acesso.codSala, acesso.codFuncionario));

            conect.Desconectar();

            return true;
        }

       
        //excluindo
        public bool Excluir(int idAcessoClicado)
        {
            conect.Conectar();
            conect.ExecutarComandosSql(String.Format("DELETE AcessoSala WHERE funcionario_codFuncionario = {0}", idAcessoClicado));
            conect.Desconectar();
            return true;
        }

        //buscando dados
        public DataTable RetTodosAcessos()
        {
            conect.Conectar();
            DataTable dt = conect.RetDataTable(String.Format("SELECT * FROM vwAcessos"));
            conect.Desconectar();


            return dt;
        }


    }
}
