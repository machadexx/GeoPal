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

                string query = "SELECT * FROM Utilizador WHERE Email = @Email";
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
                            Password = (string)reader["Password"]
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

    }
}