using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DB_Console
{
    public static class MetodosPessoa
    {
        public static void AdicionarPessoa(MySqlConnection conexao)
        {
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Gênero: ");
            string genero = Console.ReadLine();
            Console.Write("Data de Nascimento (YYYY-MM-DD): ");
            string dataNascimento = Console.ReadLine();
            Console.Write("CEP: ");
            string cep = Console.ReadLine();
            Console.Write("Número do Endereço: ");
            int numeroEndereco = int.Parse(Console.ReadLine());
            Console.Write("Rua: ");
            string rua = Console.ReadLine();
            Console.Write("Bairro: ");
            string bairro = Console.ReadLine();

            var comandoAdicionarPessoa = new MySqlCommand(
                "INSERT INTO Pessoa (CPF, Nome, Genero, Data_Nascimento, CEP, Numero_Endereco, Rua, Bairro) VALUES (@CPF, @Nome, @Genero, @Data_Nascimento, @CEP, @Numero_Endereco, @Rua, @Bairro);",
                conexao);
            comandoAdicionarPessoa.Parameters.AddWithValue("@CPF", cpf);
            comandoAdicionarPessoa.Parameters.AddWithValue("@Nome", nome);
            comandoAdicionarPessoa.Parameters.AddWithValue("@Genero", genero);
            comandoAdicionarPessoa.Parameters.AddWithValue("@Data_Nascimento", dataNascimento);
            comandoAdicionarPessoa.Parameters.AddWithValue("@CEP", cep);
            comandoAdicionarPessoa.Parameters.AddWithValue("@Numero_Endereco", numeroEndereco);
            comandoAdicionarPessoa.Parameters.AddWithValue("@Rua", rua);
            comandoAdicionarPessoa.Parameters.AddWithValue("@Bairro", bairro);
            comandoAdicionarPessoa.ExecuteNonQuery();
            Console.WriteLine("Pessoa adicionada com sucesso!");
        }
        public static void DeletarPessoa(MySqlConnection conexao)
        {
            Console.Write("CPF da Pessoa a ser deletada: ");
            string cpf = Console.ReadLine();
            var comandoDeletarPessoa = new MySqlCommand(
                "DELETE FROM Pessoa WHERE CPF = @CPF;",
                conexao);
            comandoDeletarPessoa.Parameters.AddWithValue("@CPF", cpf);
            comandoDeletarPessoa.ExecuteNonQuery();
            Console.WriteLine("Pessoa deletada com sucesso!");
        }
        public static void MostrarPessoas(MySqlConnection conexao)
        {
            var comandoMostrarPessoas = new MySqlCommand("SELECT * FROM Pessoa;", conexao);
            using (var leitor = comandoMostrarPessoas.ExecuteReader())
            {
                while (leitor.Read())
                {
                    Console.WriteLine($"CPF: {leitor["CPF"]}, Nome: {leitor["Nome"]}, Gênero: {leitor["Genero"]}, Data de Nascimento: {leitor["Data_Nascimento"]}, Endereço: {leitor["Rua"]}, {leitor["Numero_Endereco"]}, Bairro: {leitor["Bairro"]}, CEP: {leitor["CEP"]}");
                }
            }
        }
        public static void MostrarConsultas(MySqlConnection conexao)
        {
            Console.Write("CPF do Paciente: ");
            string cpf = Console.ReadLine();
            var comandoMostrarConsultasPorPessoa = new MySqlCommand(
                "SELECT * FROM Consulta WHERE CPF_Paciente = @CPF;", conexao);
            comandoMostrarConsultasPorPessoa.Parameters.AddWithValue("@CPF", cpf);
            using (var leitor = comandoMostrarConsultasPorPessoa.ExecuteReader())
            {
                while (leitor.Read())
                {
                    Console.WriteLine($"ID: {leitor["ID"]}, Sala: {leitor["Sala"]}, Status: {leitor["Status"]}, Data: {leitor["Agendamento"]}");
                }
            }
        }
    }
}
