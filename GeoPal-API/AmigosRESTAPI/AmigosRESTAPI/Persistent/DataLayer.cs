using AmigosRESTAPI.Models;
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
                            cmd.CommandText = "Select idamigo, nome, urlfoto from amigo;";
                            cmd.CommandType = CommandType.Text;
                            DbDataReader dataReader = cmd.ExecuteReader(CommandBehavior.Default);
                            while (dataReader.Read())
                            {
                                res.Add(new Amigo
                                {
                                    IdAmigo = dataReader.GetInt32(0),
                                    Nome = dataReader.GetString(1),
                                    Urlfoto = dataReader.IsDBNull(2) ? "" : dataReader.GetString(2),
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
                            cmd.CommandText = "Select idamigo, nome, urlfoto from amigo;";
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


    }
}