using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Trab2Mod
{
    public class ClassSala
    {
        public int codSala { get; set; }
        public string descricao { get; set; }
        public int codResponsavel { get; set; }
        public int codLoja { get; set; }

        ClassConexao conect = new ClassConexao();
        

        public bool inserir(ClassSala sala)
        {

            conect.Conectar();

            //inserindo dados
            conect.ExecutarComandosSql(String.Format("Insert into sala (descricao,loja_codLoja,funcionario_codFuncResp)" +
                "VALUES ('{0}',{1},'{2}')",
                sala.descricao,sala.codLoja,sala.codResponsavel));

            conect.Desconectar();

            return true;
        }

        //editando
        public bool Editar(int idSalaClicada,int idFumcResp, ClassSala sala)
        {
            conect.Conectar();
            conect.ExecutarComandosSql(String.Format("UPDATE sala SET descricao = '{0}',loja_codLoja = {1},funcionario_codFuncResp = {2} WHERE codSala = {3}",
                sala.descricao,sala.codLoja,sala.codResponsavel,idSalaClicada));
            conect.Desconectar();
            return true;
        }

        //excluindo
        public bool Excluir(int idSalaClicada)
        {
            conect.Conectar();
            conect.ExecutarComandosSql(String.Format("DELETE sala WHERE codSala = '{0}'", idSalaClicada));
            conect.Desconectar();
            return true;
        }

        //buscando dados
        public DataTable RetTodasSalas()
        {
            conect.Conectar();
            DataTable dt = conect.RetDataTable(String.Format("SELECT * FROM sala"));
            conect.Desconectar();


            return dt;
        }

        public DataTable RetSalaPorNome(string nomeBuscado)
        {
            conect.Conectar();
            DataTable dt = conect.RetDataTable(String.Format("SELECT * FROM sala WHERE descricao  LIKE '%{0}%'  ", nomeBuscado));
            conect.Desconectar();

            //Se ele tiver pelo menos uma linha irá retornar os dados
            return dt;
        }

        //excluir sala por cod loja

        public bool ExcluiPorLoj(int idloja)
        {
            conect.Conectar();
            conect.ExecutarComandosSql(String.Format("DELETE sala WHERE loja_codLoja = '{0}'", idloja));
            conect.Desconectar();
            return true;
        }





    }

  


}
