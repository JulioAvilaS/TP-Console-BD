using MySql.Data.MySqlClient;
using System;

namespace TP_DB
{
    class Program
    {
        static void Main(string[] args)
        {
            var localConexao = "server=localhost; database=mydb; uid=root";
            using var conexao = new MySqlConnection(localConexao);
            conexao.Open();

            int opcao;

            do
            {
                Console.WriteLine("\nSelecione uma operação:");
                Console.WriteLine("1 - Adicionar Pessoa");
                Console.WriteLine("2 - Deletar Pessoa");
                Console.WriteLine("3 - Mostrar Pessoas");
                Console.WriteLine("4 - Adicionar Médico");
                Console.WriteLine("5 - Adicionar Consulta");
                Console.WriteLine("6 - Mostrar Consultas por Pessoa");
                Console.WriteLine("7 - Mostrar Consultas por Médico");
                Console.WriteLine("8 - Cancelar Consulta");
                Console.WriteLine("9 - Inserir plano de saúde");
                Console.WriteLine("10 - Consultar dependentes de um titular");
                Console.WriteLine("11 - Cancelar consulta");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine());

                try
                {
                    switch (opcao)
                    {
                        case 1:
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
                            break;

                        case 2:
                            Console.Write("CPF da Pessoa a ser deletada: ");
                            cpf = Console.ReadLine();
                            var comandoDeletarPessoa = new MySqlCommand(
                                "DELETE FROM Pessoa WHERE CPF = @CPF;",
                                conexao);
                            comandoDeletarPessoa.Parameters.AddWithValue("@CPF", cpf);
                            comandoDeletarPessoa.ExecuteNonQuery();
                            Console.WriteLine("Pessoa deletada com sucesso!");
                            break;

                        case 3:
                            var comandoMostrarPessoas = new MySqlCommand("SELECT * FROM Pessoa;", conexao);
                            using (var leitor = comandoMostrarPessoas.ExecuteReader())
                            {
                                while (leitor.Read())
                                {
                                    Console.WriteLine($"CPF: {leitor["CPF"]}, Nome: {leitor["Nome"]}, Gênero: {leitor["Genero"]}, Data de Nascimento: {leitor["Data_Nascimento"]}, Endereço: {leitor["Rua"]}, {leitor["Numero_Endereco"]}, Bairro: {leitor["Bairro"]}, CEP: {leitor["CEP"]}");
                                }
                            }
                            break;

                        case 4:
                            Console.Write("CRM: ");
                            int crm = int.Parse(Console.ReadLine());
                            Console.Write("CPF do Médico: ");
                            cpf = Console.ReadLine();
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
                            break;

                        case 5:
                            Console.Write("CRM do Médico: ");
                            crm = int.Parse(Console.ReadLine());
                            Console.Write("Código do Titular: ");
                            int codTitular = int.Parse(Console.ReadLine());
                            Console.Write("CPF do Paciente: ");
                            cpf = Console.ReadLine();
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
                            status = Console.ReadLine();
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
                            break;

                        case 6:
                            Console.Write("CPF do Paciente: ");
                            cpf = Console.ReadLine();
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
                            break;

                        case 7:
                            Console.Write("CRM do Médico: ");
                            crm = int.Parse(Console.ReadLine());
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
                            break;

                        case 8:
                            Console.Write("ID da Consulta: ");
                            int idConsulta = int.Parse(Console.ReadLine());
                            var comandoCancelarConsulta = new MySqlCommand(
                                "UPDATE Consulta SET Status = 'Cancelada' WHERE ID = @ID;", conexao);
                            comandoCancelarConsulta.Parameters.AddWithValue("@ID", idConsulta);
                            comandoCancelarConsulta.ExecuteNonQuery();
                            Console.WriteLine("Consulta cancelada com sucesso!");
                            break;

                        case 9:
                            
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
                            break;

                        case 10:
                            
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
                            break;

                        case 11:
                            
                            Console.Write("Digite o ID da consulta que deseja cancelar: ");
                            int idConsultaCancelar = Convert.ToInt32(Console.ReadLine());

                            string queryCancelarConsulta = "UPDATE Consulta SET Status = 'Cancelada' WHERE ID = @ID";
                            using (var comando = new MySqlCommand(queryCancelarConsulta, conexao))
                            {
                                comando.Parameters.AddWithValue("@ID", idConsultaCancelar);
                                comando.ExecuteNonQuery();
                                Console.WriteLine("Consulta cancelada com sucesso!");
                            }
                            break;


                        case 0:
                            Console.WriteLine("Saindo...");
                            break;

                        default:
                            Console.WriteLine("Opção inválida! Tente novamente.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro: {ex.Message}");
                }

            } while (opcao != 0);
        }
    }
}