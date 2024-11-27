using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_DB_Console
{
    public static class MetodosConsulta
    {
        public static void MarcarConsulta(MySqlConnection conexao)
        {
            Console.Write("CRM do Médico: ");
            int crm = int.Parse(Console.ReadLine());
            Console.Write("Código do Titular: ");
            int codTitular = int.Parse(Console.ReadLine());
            Console.Write("CPF do Paciente: ");
            string cpf = Console.ReadLine();
            Console.Write("CNPJ da Unidade Médica: ");
            string cnpj = Console.ReadLine();
            Console.Write("Sala: ");
            string sala = Console.ReadLine();
            Console.Write("Andar: ");
            string andar = Console.ReadLine();
            Console.Write("Bloco: ");
            string bloco = Console.ReadLine();
            Console.Write("Prédio: ");
            string predio = Console.ReadLine();
            Console.Write("Data e Hora do Agendamento (YYYY-MM-DD HH:MM:SS): ");
            string agendamento = Console.ReadLine();
            Console.Write("Tempo Estimado (em minutos): ");
            int tempoEstimado = int.Parse(Console.ReadLine());
            Console.Write("Status: ");
            string status = Console.ReadLine();
            Console.Write("Valor: ");
            float valor = float.Parse(Console.ReadLine());
            Console.Write("Descrição: ");
            string descricao = Console.ReadLine();

            var comandoAdicionarConsulta = new MySqlCommand(
                "INSERT INTO Consulta (Medico_CRM, Titular_Cod_Identificacao, CPF_Paciente, Unidade_Medica_CNPJ, Sala, Andar, Bloco, Predio, Agendamento, Tempo_Estimado, Status, Valor, Descricao) VALUES (@Medico_CRM, @Titular_Cod_Identificacao, @CPF_Paciente, @Unidade_Medica_CNPJ, @Sala, @Andar, @Bloco, @Predio, @Agendamento, @Tempo_Estimado, @Status, @Valor, @Descricao);",
                conexao);
            comandoAdicionarConsulta.Parameters.AddWithValue("@Medico_CRM", crm);
            comandoAdicionarConsulta.Parameters.AddWithValue("@Titular_Cod_Identificacao", codTitular);
            comandoAdicionarConsulta.Parameters.AddWithValue("@CPF_Paciente", cpf);
            comandoAdicionarConsulta.Parameters.AddWithValue("@Unidade_Medica_CNPJ", cnpj);
            comandoAdicionarConsulta.Parameters.AddWithValue("@Sala", sala);
            comandoAdicionarConsulta.Parameters.AddWithValue("@Andar", andar);
            comandoAdicionarConsulta.Parameters.AddWithValue("@Bloco", bloco);
            comandoAdicionarConsulta.Parameters.AddWithValue("@Predio", predio);
            comandoAdicionarConsulta.Parameters.AddWithValue("@Agendamento", agendamento);
            comandoAdicionarConsulta.Parameters.AddWithValue("@Tempo_Estimado", tempoEstimado);
            comandoAdicionarConsulta.Parameters.AddWithValue("@Status", status);
            comandoAdicionarConsulta.Parameters.AddWithValue("@Valor", valor);
            comandoAdicionarConsulta.Parameters.AddWithValue("@Descricao", descricao);
            comandoAdicionarConsulta.ExecuteNonQuery();
            Console.WriteLine("Consulta adicionada com sucesso!");
        }
        public static void CancelarConsulta(MySqlConnection conexao)
        {
            Console.Write("ID da Consulta: ");
            int idConsulta = int.Parse(Console.ReadLine());
            var comandoCancelarConsulta = new MySqlCommand(
                "UPDATE Consulta SET Status = 'Cancelada' WHERE ID = @ID;", conexao);
            comandoCancelarConsulta.Parameters.AddWithValue("@ID", idConsulta);
            comandoCancelarConsulta.ExecuteNonQuery();
            Console.WriteLine("Consulta cancelada com sucesso!");
        }
    }
}
