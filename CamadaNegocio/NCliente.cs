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
     public class NCliente
    {
        public static string Inserir(string nome, string endereco, string cidade)
        {
            //associa com a camada de dados
            DCliente Obj = new DCliente();
            Obj.Nome = nome;
            Obj.Endereco = endereco;
            Obj.Cidade = cidade;
            return Obj.Inserir(Obj);
        }

        public static string Editar(int idliente, string nome, string endereco, string cidade)
        {
            DCliente Obj = new DCliente();
            Obj.IdCliente = idliente;
            Obj.Nome = nome;
            Obj.Endereco = endereco;
            Obj.Cidade = cidade;
            return Obj.Editar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new DCliente().Mostrar();
        }

        public static string Excluir(int idcliente)
        {
            DCliente Obj = new DCliente();
            Obj.IdCliente = idcliente;
            return Obj.Excluir(Obj);
        }

    


    }
}
