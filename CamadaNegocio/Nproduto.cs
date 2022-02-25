using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//negocio interage com dados
using System.Data;
using CamadaDados;


namespace CamadaNegocio
{
    public class Nproduto
    {
        public static string Inserir(string nome, double preco, int qtdEstoque)
        {
            //associa com a camada de dados
            DProduto Obj = new DProduto();
            Obj.Nomeproduto = nome;
            Obj.Precounitario = preco;
            Obj.QtdeEstoque = qtdEstoque;
            return Obj.Inserir(Obj);
        }



        public static string Excluir(int idproduto)
        {
            DProduto Obj = new DProduto();
            Obj.Idproduto = idproduto;
            return Obj.Excluir(Obj);
        }



        public static string Editar(int idProduto, string nome, double preco, int qtdeEstoque)
        {
            DProduto Obj = new DProduto();
            Obj.Idproduto = idProduto;
            Obj.Nomeproduto = nome;
            Obj.Precounitario = preco;
            Obj.QtdeEstoque = qtdeEstoque;
            return Obj.Editar(Obj);
        }


        public static DataTable Mostrar()
        {
            return new DProduto().Mostrar();
        }



    }
}
