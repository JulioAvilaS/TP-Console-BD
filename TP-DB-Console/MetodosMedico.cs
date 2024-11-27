using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DB_Console
{
    public static class MetodosMedico
    {
        public static void AdicionarMedico(MySqlConnection conexao)
        {
            Console.Write("CRM: ");
            int crm = int.Parse(Console.ReadLine());
            Console.Write("CPF do Médico: ");
            string cpf = Console.ReadLine();
            Console.Write("Data de Admissão (YYYY-MM-DD): ");
            string dataAdmissao = Console.ReadLine();
            Console.Write("Status: ");
            string status = Console.ReadLine();

            var comandoAdicionarMedico = new MySqlCommand(
                "INSERT INTO Medico (CRM, Pessoa_CPF, Data_Admissao, Status) VALUES (@CRM, @Pessoa_CPF, @Data_Admissao, @Status);",
                conexao);
            comandoAdicionarMedico.Parameters.AddWithValue("@CRM", crm);
            comandoAdicionarMedico.Parameters.AddWithValue("@Pessoa_CPF", cpf);
            comandoAdicionarMedico.Parameters.AddWithValue("@Data_Admissao", dataAdmissao);
            comandoAdicionarMedico.Parameters.AddWithValue("@Status", status);
            comandoAdicionarMedico.ExecuteNonQuery();
            Console.WriteLine("Médico adicionado com sucesso!");
        }
        public static void MostrarConsultas(MySqlConnection conexao)
        {
            Console.Write("CRM do Médico: ");
            int crm = int.Parse(Console.ReadLine());
            var comandoMostrarConsultasPorMedico = new MySqlCommand(
                "SELECT * FROM Consulta WHERE Medico_CRM = @CRM;", conexao);
            comandoMostrarConsultasPorMedico.Parameters.AddWithValue("@CRM", crm);
            using (var leitor = comandoMostrarConsultasPorMedico.ExecuteReader())
            {
                while (leitor.Read())
                {
                    Console.WriteLine($"ID: {leitor["ID"]}, Sala: {leitor["Sala"]}, Status: {leitor["Status"]}, Data: {leitor["Agendamento"]}");
                }
            }
        }

        internal static void DefinirEspecialidade(MySqlConnection conexao)
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
    }
}
