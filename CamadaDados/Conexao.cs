using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data; //permite o uso do DataTale
                   //importa os recursos do MySql
using MySql.Data.MySqlClient; //pacote esta dentro do conector

namespace CamadaDados
{
    public class Conexao
    {
        private MySqlConnection conn;
        public void Conectar()
        {//faz conexão com o banco de dados
            if (conn != null)
                conn.Close();
            string caminho = "server = localhost; database =  dbsiscomercio; uid = root; pwd =; ";


            try
            {
                conn = new MySqlConnection(caminho);
                conn.Open();
                Console.WriteLine("Banco conectado e aberto");
            }

            catch (MySqlException ex) //tratae o erro
            {
                throw new Exception(ex.Message);
            }
        }


        public void ExecutarComandoSql(string comandoSql)
        {//método para executar um insert, 
            //update e delete
            MySqlCommand comando = new MySqlCommand(comandoSql, conn);
            Console.WriteLine(comando.ExecuteNonQuery() == 1 ? "Operação realizada com sucesso!" : "Operação não realizada!");
            conn.Close();


        }


    }
}
