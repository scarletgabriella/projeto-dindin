using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Dindin.DAO
{
    public class ConexaoMysql
    {
        // info do banco
        static string connectionString = "datasource=;port=3306;username=;password=;database=;SslMode=none";
        static MySqlConnection conn = new MySqlConnection(connectionString);

        static public int? executaComando(string comandoSQL, bool queroID)
        {
            MySqlTransaction transaction = null;

            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
                transaction = conn.BeginTransaction();
            }

            try
            {
                MySqlCommand cmd = new MySqlCommand(comandoSQL, conn);
                cmd.Transaction = transaction;
                cmd.ExecuteNonQuery();

                if (queroID)
                {
                    cmd.Parameters.Add(new MySqlParameter("ultimoId", cmd.LastInsertedId));
                    int ID = Convert.ToInt32(cmd.Parameters["@ultimoId"].Value);
                    transaction.Commit();
                    return ID;
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
            return null;
        }

        static public DataTable retornaDados(string comandoSQL)
        {
            if (conn.State != ConnectionState.Open) conn.Open();

            try
            {
                MySqlCommand cmd = new MySqlCommand(comandoSQL, conn);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                return dt;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                if (conn.State == ConnectionState.Open) conn.Close();
            }
        }
    }
}
