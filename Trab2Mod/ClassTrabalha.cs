using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Trab2Mod
{
    public class ClassTrabalha
    {
        public string dataCad { get; set; }
        public int codFuncionario { get; set; }
        public int codLoja { get; set; }

        ClassConexao conect = new ClassConexao();

        public bool inserir(ClassTrabalha trabalha)
        {

            conect.Conectar();

            //inserindo dados
            conect.ExecutarComandosSql(String.Format("Insert into trabalha (dataCadastro,funcionario_codFuncionario,loja_codLoja)" +
                "VALUES ('{0}',{1},'{2}')",
                trabalha.dataCad,trabalha.codFuncionario,trabalha.codLoja));

            conect.Desconectar();

            return true;
        }

       



    }
}
