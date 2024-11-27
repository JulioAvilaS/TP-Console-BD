using MySql.Data.MySqlClient;
using System;
using TP_DB_Console;

namespace TP_DB
{
    class CentralHospitalar
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
                Console.WriteLine("11 - Criar nova especialidade médica");
                Console.WriteLine("12 - Definir a especialidade do médico");
                Console.WriteLine("13 - Inserir unidade médica");
                Console.WriteLine("14 - Inserir Titular de um plano");
                Console.WriteLine("15 - Definir os procedimentos realizados pelo hospital");
                Console.WriteLine("0 - Sair");
                Console.Write("Opção: ");
                opcao = int.Parse(Console.ReadLine());

                try
                {
                    switch (opcao)
                    {
                        case 1:
                            MetodosPessoa.AdicionarPessoa(conexao);
                            break;

                        case 2:
                            MetodosPessoa.DeletarPessoa(conexao);
                            break;

                        case 3:
                            MetodosPessoa.MostrarPessoas(conexao);
                            break;

                        case 4:
                            MetodosMedico.AdicionarMedico(conexao);
                            break;

                        case 5:
                           MetodosConsulta.MarcarConsulta(conexao);
                            break;

                        case 6:
                           MetodosPessoa.MostrarConsultas(conexao);
                            break;

                        case 7:
                            MetodosMedico.MostrarConsultas(conexao);
                            break;

                        case 8:
                            MetodosConsulta.CancelarConsulta(conexao);
                            break;

                        case 9:
                            MetodosPlano.AdicionarNovoPlano(conexao);
                            break;

                        case 10:
                            MetodosPlano.ConsultarDependentes(conexao);
                            break;

                        case 11:
                            MetodosUnidadeMedica.CriarNovaEspecialidade(conexao);
                            break;

                        case 12:
                            MetodosMedico.DefinirEspecialidade(conexao);
                            break;

                        case 13:
                            MetodosUnidadeMedica.InserirUnidadeMedica(conexao);
                            break;

                        case 14:
                            MetodosPlano.InserirTitular(conexao);
                            break;

                        case 15:
                            MetodosUnidadeMedica.AdicionarProcedimento(conexao);
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