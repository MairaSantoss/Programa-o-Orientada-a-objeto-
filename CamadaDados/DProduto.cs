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
    //deixar classe publica
    public class DProduto
    {

        public int Idproduto { get; set; }
        public string Nomeproduto { get; set; }
        public double Precounitario { get; set; }
        public int QtdeEstoque { get; set; }



        public DProduto()
        {

        }




        public String Inserir(DProduto dProduto)
        {
            string resp = "";
            Console.WriteLine("classe de D Produto............");
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                //conexão objeto instanciado da classe Conexao
                Conexao conexao = new Conexao();
                conexao.Conectar();
                string sqlInserir = "insert into produto (descricao, preco, estoque) values ('" +
                dProduto.Nomeproduto + "', '" + dProduto.Precounitario + "', '" + dProduto.QtdeEstoque + "')";
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




        public string Editar(DProduto dProduto)
        {
            string resp = "";
            Console.WriteLine("classe de D Produto............");
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                //conexão objeto instanciado da classe Conexao
                Conexao conexao = new Conexao();
                conexao.Conectar();
                string sqlEditar = "update produto set "
                 + "idproduto = '" + dProduto.Idproduto + "',"
                 + "descricao = '" + dProduto.Nomeproduto + "',"
                 + "preco = '" + dProduto.Precounitario + "',"
                 + "estoque = '" + dProduto.QtdeEstoque + "' "
                 + "where idproduto = '" + dProduto.Idproduto + "'";
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




        public string Excluir(DProduto dProduto)
        {
            string resp = "";
            Console.WriteLine("classe de D Produto............");
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                //conexão objeto instanciado da classe Conexao
                Conexao conexao = new Conexao();
                conexao.Conectar();
                string sqlDeletar = "delete from produto where idproduto = " + dProduto.Idproduto;
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




        public DataTable Mostrar()
        {
            //DataSet é um banco de dados em memória, retornado de uma fonte de dados 
            //e consiste de uma coleção de objetos, DataTable
            //MySqlDataAdapter usado para preencher um DataSet com linhas de uma 
            //consulta feita em um banco de dados, ou seja, é uma ponte entre o DataSet 
            //e o banco de dados MySQL para retornar e salvar dados
            DataTable DtResultado = new DataTable("Produto");
            Console.WriteLine("classe de D Mostrar..");
            MySqlConnection SqlCon = new MySqlConnection();
            DataSet dataSet;
            try
            {
                MySqlConnection conn = conn = new MySqlConnection("server = localhost; database = dbsiscomercio; uid = root; pwd =; ");
                //string sqlConsultar = "select * produto where nomeproduto like " + dProduto.Nomeproduto;// + "%'";
                string sqlConsultar = "select * from produto";
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






    }  
}
