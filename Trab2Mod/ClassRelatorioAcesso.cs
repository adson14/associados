using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Trab2Mod
{
    public class ClassRelatorioAcesso
    {
        public int codFuncionario { get; set; }
        public int codSala { get; set; }
        public string dataAcesso { get; set; }
        public int codRelatorioAcess { get; set; }

        ClassConexao conect = new ClassConexao();

        public bool inserir(ClassRelatorioAcesso relatorio)
        {

            conect.Conectar();

            //inserindo dados
            conect.ExecutarComandosSql(String.Format("Insert into relatorioAcesso (funcionario_codFuncionario,sala_codSala,dataAcesso)" +
                "VALUES ('{0}',{1},'{2}')",
                relatorio.codFuncionario,relatorio.codSala,relatorio.dataAcesso));

            conect.Desconectar();

            return true;
        }

        //editando
        public bool Editar(int idRelatorioClicado, ClassRelatorioAcesso relatorio)
        {
            conect.Conectar();
            conect.ExecutarComandosSql(String.Format("UPDATE relatorio SET funcionario_codFuncionario = {0},sala_codSala = {1},dataAcesso= '{2}' WHERE codRelatorio = {3}",
                relatorio.codFuncionario,relatorio.codSala,relatorio.dataAcesso, idRelatorioClicado));
            conect.Desconectar();
            return true;
        }

        //excluindo
        public bool Excluir(int idRelatorioClicado)
        {
            conect.Conectar();
            conect.ExecutarComandosSql(String.Format("DELETE relatorio WHERE codRelatorio = {0}", idRelatorioClicado));
            conect.Desconectar();
            return true;
        }

        //buscando dados
        public DataTable RetTodosRelatorios()
        {
            conect.Conectar();
            DataTable dt = conect.RetDataTable(String.Format("SELECT * FROM vwRelatorio"));
            conect.Desconectar();


            return dt;
        }

        public DataTable RetRelaFuncPorNome(string codigoBuscado)
        {
            conect.Conectar();
            DataTable dt = conect.RetDataTable(String.Format("select * FROM relatorioAcesso"+
                " WHERE funcionario_CodFuncionario LIKE '%{0}%'", codigoBuscado));
            conect.Desconectar();

            //Se ele tiver pelo menos uma linha irá retornar os dados
            return dt;
        }
    }
}
