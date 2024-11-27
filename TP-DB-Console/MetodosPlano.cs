using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DB_Console
{
    public static class MetodosPlano
    {
        public static void AdicionarNovoPlano(MySqlConnection conexao)
        {
            Console.Write("Digite o nome do plano: ");
            string nomePlano = Console.ReadLine();
            Console.Write("Digite o valor da mensalidade: ");
            float valorMensalidade = Convert.ToSingle(Console.ReadLine());
            Console.Write("Digite a descrição do plano: ");
            string descricaoPlano = Console.ReadLine();
            Console.Write("Digite o limite de dependentes: ");
            int limiteDependentes = Convert.ToInt32(Console.ReadLine());

            string queryPlano = "INSERT INTO Plano (Nome, Valor_Mensalidade, Descricao, Limite_Dependentes) VALUES (@Nome, @Valor_Mensalidade, @Descricao, @Limite_Dependentes)";
            using (var comando = new MySqlCommand(queryPlano, conexao))
            {
                comando.Parameters.AddWithValue("@Nome", nomePlano);
                comando.Parameters.AddWithValue("@Valor_Mensalidade", valorMensalidade);
                comando.Parameters.AddWithValue("@Descricao", descricaoPlano);
                comando.Parameters.AddWithValue("@Limite_Dependentes", limiteDependentes);
                comando.ExecuteNonQuery();
                Console.WriteLine("Plano cadastrado com sucesso!");
            }
        }
        public static void ConsultarDependentes(MySqlConnection conexao)
        {
            Console.Write("Digite o código de identificação do titular: ");
            int codIdentificacaoTitular = Convert.ToInt32(Console.ReadLine());

            string queryDependentes = @"
                                SELECT p.CPF, p.Nome 
                                FROM Dependente d
                                JOIN Pessoa p ON d.CPF = p.CPF
                                WHERE d.Titular_Cod_Identificacao = @Cod_Identificacao";
            using (var comando = new MySqlCommand(queryDependentes, conexao))
            {
                comando.Parameters.AddWithValue("@Cod_Identificacao", codIdentificacaoTitular);
                using (var reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"CPF: {reader["CPF"]}, Nome: {reader["Nome"]}");
                    }
                }
            }
        }

        internal static void InserirTitular(MySqlConnection conexao)
        {
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
            Console.Write("ID do Plano: ");
            int planoId = int.Parse(Console.ReadLine());

            var comando = new MySqlCommand(
                "INSERT INTO Titular (CPF, Plano_ID) VALUES (@CPF, @PlanoID);", conexao);
            comando.Parameters.AddWithValue("@CPF", cpf);
            comando.Parameters.AddWithValue("@PlanoID", planoId);
            comando.ExecuteNonQuery();
            Console.WriteLine("Titular inserido com sucesso!");
        }
    }
}
