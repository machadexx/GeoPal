using AmigosRESTAPI.Models;
using AmigosRESTAPI.Models.Atividades;
using AmigosRESTAPI.Models.Utilizador;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace AmigosRESTAPI.Persistent
{
    public class DataLayer
    {
        private DbConnection conn = null;

        public DataLayer(string ConnectionString) {
            conn = new NpgsqlConnection(ConnectionString);
        }

        public List<Amigo> GetAllAmimgos(out string erro)
        {
            erro = null;
            List<Amigo> res = new List<Amigo>();

            if(conn != null)
            {
                try
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        using (DbCommand cmd = new NpgsqlCommand(null, (NpgsqlConnection)conn))
                        {
                            cmd.CommandText = "Select * from amigo;";
                            cmd.CommandType = CommandType.Text;
                            DbDataReader dataReader = cmd.ExecuteReader(CommandBehavior.Default);
                            while (dataReader.Read())
                            {
                                res.Add(new Amigo
                                {
                                    Utilizador = dataReader.GetInt32(0),
                                    Utilizador2 = dataReader.GetInt32(1),
                                    Inicio = dataReader.GetString(2),
                                });
                            }
                        }
                    } else erro = "Operation Failed - Closed dataset";
                }catch (Exception ex)
                {
                    erro = ex.Message + "[" + ex.StackTrace + "]";
                } finally { 
                    conn.Close();
                }
            }
            return res;
        }

        public List<Utilizador> GetAllUtilizador(out string erro)
        {
            erro = null;
            List<Utilizador> res = new List<Utilizador>();

            if (conn != null)
            {
                try
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        using (DbCommand cmd = new NpgsqlCommand(null, (NpgsqlConnection)conn))
                        {
                            cmd.CommandText = "SELECT * FROM utilizador;";
                            cmd.CommandType = CommandType.Text;
                            DbDataReader dataReader = cmd.ExecuteReader(CommandBehavior.Default);
                            while (dataReader.Read())
                            {
                                res.Add(new Utilizador
                                {
                                    UtilizadorID = dataReader.GetInt32(0),
                                    Nome = dataReader.GetString(1),
                                    Email = dataReader.GetString(2),
                                    Password = dataReader.GetString(3),
                                    Coordenadas = dataReader.GetString(4),
                                    RaioVizinhanca = dataReader.GetInt32(5)
                                });
                            }
                        }
                    }
                    else erro = "Operation Failed - Closed dataset";
                }
                catch (Exception ex)
                {
                    erro = ex.Message + "[" + ex.StackTrace + "]";
                }
                finally
                {
                    conn.Close();
                }
            }
            return res;
        }


        public List<Locais> GetAllLocais(out string erro)
        {
            erro = null;
            List<Locais> res = new List<Locais>();

            if (conn != null)
            {
                try
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        using (DbCommand cmd = new NpgsqlCommand(null, (NpgsqlConnection)conn))
                        {
                            cmd.CommandText = "Select vizinhancaid, utilizadorid, nome, descriçao from vizinhanca_geo;";
                            cmd.CommandType = CommandType.Text;
                            DbDataReader dataReader = cmd.ExecuteReader(CommandBehavior.Default);
                            while (dataReader.Read())
                            {
                                res.Add(new Locais
                                {
                                    localId = dataReader.GetInt32(0),
                                    Nome = dataReader.GetString(1),
                                    Coords = dataReader.GetString(3),
                                });
                            }
                        }
                    }
                    else erro = "Operation Failed - Closed dataset";
                }
                catch (Exception ex)
                {
                    erro = ex.Message + "[" + ex.StackTrace + "]";
                }
                finally
                {
                    conn.Close();
                }
            }
            return res;
        }

        public List<Atividades> GetAllAtividades(out string erro)
        {
            erro = null;
            List<Atividades> res = new List<Atividades>();

            if (conn != null)
            {
                try
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        using (DbCommand cmd = new NpgsqlCommand(null, (NpgsqlConnection)conn))
                        {
                            cmd.CommandText = "SELECT * FROM atividades;";
                            cmd.CommandType = CommandType.Text;
                            DbDataReader dataReader = cmd.ExecuteReader(CommandBehavior.Default);
                            while (dataReader.Read())
                            {
                                res.Add(new Atividades
                                {
                                    Id = dataReader.GetInt32(0),
                                    Nome = dataReader.GetString(1),
                                    Coordenadas = dataReader.GetString(3),
                                });
                            }
                        }
                    }
                    else erro = "Operation Failed - Closed dataset";
                }
                catch (Exception ex)
                {
                    erro = ex.Message + "[" + ex.StackTrace + "]";
                }
                finally
                {
                    conn.Close();
                }
            }
            return res;
        }


    }
}