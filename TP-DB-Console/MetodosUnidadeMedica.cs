using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DB_Console
{
    internal class MetodosUnidadeMedica
    {
        internal static void AdicionarProcedimento(MySqlConnection conexao)
        {
            Console.Write("Nome do Procedimento: ");
            string nome = Console.ReadLine();
            Console.Write("Valor: ");
            float valor = float.Parse(Console.ReadLine());
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            var comando = new MySqlCommand(
                "INSERT INTO Procedimento (Nome, Valor, Descricao) VALUES (@Nome, @Valor, @Descricao);", conexao);
            comando.Parameters.AddWithValue("@Nome", nome);
            comando.Parameters.AddWithValue("@Valor", valor);
            comando.Parameters.AddWithValue("@Descricao", descricao);
            comando.ExecuteNonQuery();
            Console.WriteLine("Procedimento criado com sucesso!");
        }

        internal static void CriarNovaEspecialidade(MySqlConnection conexao)
        {
            Console.Write("Nome da Especialidade: ");
            string nome = Console.ReadLine();
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            var comando = new MySqlCommand(
                "INSERT INTO Especialidade (Nome, Descricao) VALUES (@Nome, @Descricao);", conexao);
            comando.Parameters.AddWithValue("@Nome", nome);
            comando.Parameters.AddWithValue("@Descricao", descricao);
            comando.ExecuteNonQuery();
            Console.WriteLine("Especialidade inserida com sucesso!");
        }

        internal static void InserirUnidadeMedica(MySqlConnection conexao)
        {
            Console.Write("Nome do Procedimento: ");
            string nome = Console.ReadLine();
            Console.Write("Valor: ");
            float valor = float.Parse(Console.ReadLine());
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            var comando = new MySqlCommand(
                "INSERT INTO Procedimento (Nome, Valor, Descricao) VALUES (@Nome, @Valor, @Descricao);", conexao);
            comando.Parameters.AddWithValue("@Nome", nome);
            comando.Parameters.AddWithValue("@Valor", valor);
            comando.Parameters.AddWithValue("@Descricao", descricao);
            comando.ExecuteNonQuery();
            Console.WriteLine("Procedimento criado com sucesso!");
        }
    }
}
