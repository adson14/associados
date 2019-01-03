using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Trab2Mod
{
    public class ClassLoja 
    {
        public int codLoja { get; set; }
        public string razaoSocial { get; set; }
        public string nomeFantasia { get; set; }
        public string cnpj { get; set; }
        public string site { get; set; }
        public string inauguracao { get; set; }
        public int tipoLoja { get; set; }
        public int codResponsavel { get; set; }
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

        ClassConexao conect = new ClassConexao();

        public bool inserir(ClassLoja loja)
        {

            conect.Conectar();

            //inserindo dados
            conect.ExecutarComandosSql(String.Format("Insert into loja (razaoSocial,nomeFantasia,cnpj,endereco,numero,complemento,bairro,cidade,estado,pais,telFixo,celular,email, siteEmpresa,dataInauguracao,tipoLoja,funcionario_codFuncResp)" +
                "VALUES ('{0}','{1}','{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}',{15},{16})",
                loja.razaoSocial, loja.nomeFantasia, loja.cnpj, loja.endereco, loja.numero, loja.complemento, loja.bairro, loja.cidade, loja.estado, loja.pais, loja.telFixo, loja.celular, loja.email, loja.site, loja.inauguracao, loja.tipoLoja, codResponsavel));

            conect.Desconectar();

            return true;
        }

        //editando
        public bool Editar(int idLojaClicada,int idFuncResp ,ClassLoja loja)
        {
            conect.Conectar();
            conect.ExecutarComandosSql(String.Format("UPDATE loja SET razaoSocial = '{0}',nomeFantasia = '{1}',cnpj = '{2}',endereco = '{3}',numero = {4},complemento = '{5}',bairro = '{6}',cidade = '{7}',estado = '{8}',pais = '{9}',telFixo = '{10}',celular = '{11}',email = '{12}', siteEmpresa = '{13}',dataInauguracao = '{14}',tipoLoja = {15},funcionario_codFuncResp = {16} WHERE codLoja = {17}",
                loja.razaoSocial, loja.nomeFantasia, loja.cnpj, loja.endereco, loja.numero, loja.complemento, loja.bairro, loja.cidade, loja.estado, loja.pais, loja.telFixo, loja.celular, loja.email, loja.site, loja.inauguracao, loja.tipoLoja, codResponsavel,idLojaClicada));
            conect.Desconectar();
            return true;
        }

        //excluindo = '{0}'
        public bool Excluir(int idLojaClicada)
        {
            conect.Conectar();
            conect.ExecutarComandosSql(String.Format("DELETE loja WHERE codLoja = '{0}'", idLojaClicada));
            conect.Desconectar();
            return true;
        }

        //buscando dados
        public DataTable RetTodasLojas()
        {
            conect.Conectar();
            DataTable dt = conect.RetDataTable(String.Format("SELECT * FROM loja"));
            conect.Desconectar();


            return dt;
        }

        //buscando individualmente


        public DataTable RetLojaPorNome(string nomeBuscado)
        {
            conect.Conectar();
            DataTable dt = conect.RetDataTable(String.Format("SELECT * FROM loja WHERE nomeFantasia  LIKE '%{0}%'  ", nomeBuscado));
            conect.Desconectar();

            //Se ele tiver pelo menos uma linha irá retornar os dados
            return dt;
        }


       


    }
}
