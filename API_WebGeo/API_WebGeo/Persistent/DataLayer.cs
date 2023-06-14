using API_WebGeo.Models.Registo;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;
using API_WebGeo.Models.Utilizador;
using System.Threading.Tasks;
using System.Web.Helpers;
using API_WebGeo.Models.Atividades;
using API_WebGeo.Models.Notificacoes;
using Microsoft.Win32;

namespace API_WebGeo.Persistent
{
    public class DataLayer
    {
        private DbConnection conn = null;

        public DataLayer(string ConnectionString)
        {
            conn = new NpgsqlConnection(ConnectionString);
        }

        public Registo GetRegistoByEmail(string email, out string erro)
        {
            try
            {
                conn.Open();

                string query = "SELECT * FROM Utilizador WHERE Email = @Email";
                NpgsqlCommand command = new NpgsqlCommand(query, (NpgsqlConnection)conn);
                command.Parameters.AddWithValue("@Email", email);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        
                        Registo registo = new Registo
                        {
                            UtilizadorID = (int)reader["UtilizadorID"],
                            Nome = (string)reader["Nome"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"]
                        };

                        erro = null;
                        return registo;
                    }
                }

                
                erro = null;
                return null;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public void CreateRegisto(Registo registo, out string erro)
        {
            try
            {
                conn.Open();

                string query = "INSERT INTO Utilizador (Nome, Email, Password) VALUES (@Nome, @Email, @Password)";
                NpgsqlCommand command = new NpgsqlCommand(query, (NpgsqlConnection)conn);
                command.Parameters.AddWithValue("@Nome", registo.Nome);
                command.Parameters.AddWithValue("@Email", registo.Email);
                command.Parameters.AddWithValue("@Password", registo.Password);

                command.ExecuteNonQuery();

                erro = null;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }

        public async Task<Utilizador> GetUserByEmail(string email)
        {
            try
            {
                conn.Open();

                string query = "SELECT UtilizadorID, Nome, Email, Password, ST_X(coordenadas) AS Coordenadas_latitude, ST_Y(coordenadas) AS Coordenadas_longitude FROM Utilizador WHERE Email = @Email";


                NpgsqlCommand command = new NpgsqlCommand(query, (NpgsqlConnection)conn);
                command.Parameters.AddWithValue("@Email", email);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Utilizador user = new Utilizador
                        {
                            UtilizadorID = (int)reader["UtilizadorID"],
                            Nome = (string)reader["Nome"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"],
                            Coordenadas_latitude = reader.IsDBNull(reader.GetOrdinal("Coordenadas_latitude")) ? (double?)null : Convert.ToDouble(reader["Coordenadas_latitude"]),
                            Coordenadas_longitude = reader.IsDBNull(reader.GetOrdinal("Coordenadas_longitude")) ? (double?)null : Convert.ToDouble(reader["Coordenadas_longitude"])
                        };


                        return user;

                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public async Task<int> DeleteUtilizador(int utilizadorID)
        {
            try
            {
                conn.Open();

                string query = "DELETE FROM Utilizador WHERE UtilizadorID = @UtilizadorID";
                NpgsqlCommand command = new NpgsqlCommand(query, (NpgsqlConnection)conn);
                command.Parameters.AddWithValue("@UtilizadorID", utilizadorID);

                int rowsAffected = await command.ExecuteNonQueryAsync();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public async Task<Atividades> GetAtividades(int AtividadeID)
        {
            try
            {
                conn.Open();

                string query = "SELECT * FROM Atividades WHERE AtividadeID = @AtividadeID";
                NpgsqlCommand command = new NpgsqlCommand(query, (NpgsqlConnection)conn);
                command.Parameters.AddWithValue("@AtividadeID", AtividadeID);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        Atividades Atividades = new Atividades
                        {
                            AtividadeID = (int)reader["AtividadeID"],
                            Nome = (string)reader["Nome"],
                            Localizaçao = (string)reader["Localizaçao"],
                            Inicio = (string)reader["Inicio"],
                            Fim = (string)reader["Fim"],
                            Coordenadas_latitude = (double)reader["latitude"],
                            Coordenadas_longitude = (double)reader["longitude"],
                            VizinhancaID = (int)reader["vizinhancaID"]
                        };

                        return Atividades;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public async Task<int> DeleteAtividades(int AtividadeID)
        {
            try
            {
                conn.Open();

                string query = "DELETE FROM Atividades WHERE AtividadeID = @AtividadeID";
                NpgsqlCommand command = new NpgsqlCommand(query, (NpgsqlConnection)conn);
                command.Parameters.AddWithValue("@AtividadeID", AtividadeID);

                int rowsAffected = await command.ExecuteNonQueryAsync();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public void CreateAtividade(Atividades atividades, out string erro)
        {
            try
            {
                conn.Open();

                string query = "INSERT INTO Atividades (Nome, Localizacao, Inicio, Fim, Coordenadas) VALUES (@Nome, @Localizacao, @Inicio, @Fim)";
                NpgsqlCommand command = new NpgsqlCommand(query, (NpgsqlConnection)conn);
                command.Parameters.AddWithValue("@Nome", atividades.Nome);
                command.Parameters.AddWithValue("@Localizacao", atividades.Localizaçao);
                command.Parameters.AddWithValue("@Inicio", atividades.Inicio);
                command.Parameters.AddWithValue("@Fim", atividades.Fim);

                command.ExecuteNonQuery();

                erro = null;
            }
            catch (Exception ex)
            {
                erro = ex.Message;
            }
            finally
            {
                conn.Close();
            }
        }



        public async Task<Notificacoes> GetNotificacoes(int NotificacaoID)
        {
            try
            {
                conn.Open();

                string query = "SELECT * FROM Notificacoes WHERE NotificacaoID = @NotificacaoID";
                NpgsqlCommand command = new NpgsqlCommand(query, (NpgsqlConnection)conn);
                command.Parameters.AddWithValue("@NotificacaoID", NotificacaoID);

                using (NpgsqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {

                        Notificacoes Notificacoes = new Notificacoes
                        {
                            NotificacaoID = (int)reader["NotificacaoID"],
                            Mensagem = (string)reader["Mensagem"],
                            DataEnviada = (string)reader["DataEnviada"],
                            UtilizadorID = (int)reader["UtilizadorID"],
                            AtividadeID = (int)reader["AtividadeID"],
                        };

                        return Notificacoes;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }

        public async Task<int> DeleteNotificacoes(int NotificacaoID)
        {
            try
            {
                conn.Open();

                string query = "DELETE FROM Notificacoes WHERE NotificacaoID = @NotificacaoID";
                NpgsqlCommand command = new NpgsqlCommand(query, (NpgsqlConnection)conn);
                command.Parameters.AddWithValue("@NotificacaoID", NotificacaoID);

                int rowsAffected = await command.ExecuteNonQueryAsync();

                return rowsAffected;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        



    }
}