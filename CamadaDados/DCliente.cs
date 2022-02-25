using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//permite o uso do DataGridView
using System.Data;
//importa os recursos do MySql
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
//permite usar o SqlDataAdapter para preencher DataGridView
//using System.Data.SqlClient;


namespace CamadaDados
{
   public class DCliente
    {

        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }



        public DCliente()
        {

        }

        public String Inserir(DCliente dcliente)
        {
            string resp = "";
            Console.WriteLine("classe de D Produto............");
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                //conexão objeto instanciado da classe Conexao
                Conexao conexao = new Conexao();
                conexao.Conectar();
                string sqlInserir = "insert into cliente (nome, endereco, cidade) values ('" +
                dcliente.Nome + "', '" + dcliente.Endereco + "', '" + dcliente.Cidade + "')";
                Console.WriteLine("SQL..... " + sqlInserir);
                conexao.ExecutarComandoSql(sqlInserir);
            }
            catch (Exception ex)
            {
                resp = "Erro ao salvar!.... " + ex.Message;
            }
            finally //finally sempre é executado
            {//verifica se a conexão esta aberta e fecha
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return resp;
        }


        public string Editar(DCliente cliente)
        {
            string resp = "";
            Console.WriteLine("classe de D Produto............");
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                //conexão objeto instanciado da classe Conexao
                Conexao conexao = new Conexao();
                conexao.Conectar();
                string sqlEditar = "update cliente set "
                 + "idcliente = '" + cliente.IdCliente + "',"
                 + "nome = '" + cliente.Nome + "',"
                 + "endereco = '" + cliente.Endereco + "',"
                 + "cidade = '" + cliente.Cidade + "' "
                 + "where idcliente = '" + cliente.IdCliente + "'";
                Console.WriteLine("SQL.....   " + sqlEditar);
                conexao.ExecutarComandoSql(sqlEditar);
            }
            catch (Exception ex)
            {
                resp = "Erro ao salvar!.... " + ex.Message;
            }
            finally //finally sempre é executado
            {//verifica se a conexão esta aberta e fecha
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return resp;
        }


        public DataTable Mostrar()
        {
            //DataSet é um banco de dados em memória, retornado de uma fonte de dados 
            //e consiste de uma coleção de objetos, DataTable
            //MySqlDataAdapter usado para preencher um DataSet com linhas de uma 
            //consulta feita em um banco de dados, ou seja, é uma ponte entre o DataSet 
            //e o banco de dados MySQL para retornar e salvar dados
            DataTable DtResultado = new DataTable("Cliente");
            Console.WriteLine("classe de D Mostrar..");
            MySqlConnection SqlCon = new MySqlConnection();
            DataSet dataSet;
            try
            {
                MySqlConnection conn = conn = new MySqlConnection("server = localhost; database = dbsiscomercio; uid = root; pwd =; ");
                //string sqlConsultar = "select * produto where nomeproduto like " + dProduto.Nomeproduto;// + "%'";
                string sqlConsultar = "select * from cliente";
                Console.WriteLine("SQL.....   " + sqlConsultar);
                MySqlCommand comando = new MySqlCommand(sqlConsultar, conn);
                MySqlDataAdapter sqlDat = new MySqlDataAdapter(comando);//passa o resultado para a grid
                dataSet = new DataSet();
                //médoto Fill adiciona ou atualiza linhas no DataSet
                sqlDat.Fill(dataSet);//preenche a grid DtResultado
                DtResultado = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                string resp = "Erro ao salvar!.... " + ex.Message;
            }
            finally //finally sempre é executado
            {//verifica se a conexão esta aberta e fecha
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return DtResultado;
        }


        public string Excluir(DCliente cliente)
        {
            string resp = "";
            Console.WriteLine("classe de D Produto............");
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                //conexão objeto instanciado da classe Conexao
                Conexao conexao = new Conexao();
                conexao.Conectar();
                string sqlDeletar = "delete from cliente where idcliente = " + cliente.IdCliente;
                Console.WriteLine("SQL.....   " + sqlDeletar);
                conexao.ExecutarComandoSql(sqlDeletar);
            }
            catch (Exception ex)
            {
                resp = "Erro ao salvar!.... " + ex.Message;

            }
            finally //finally sempre é executado
            {//verifica se a conexão esta aberta e fecha
                if (SqlCon.State == ConnectionState.Open)
                    SqlCon.Close();
            }
            return resp;
        }



    }
}
