using MySql.Data.MySqlClient;
using System;
using System.Configuration;

namespace projectLivro.Models
{
    public class modelDB
    {
        private readonly MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        private readonly MySqlCommand cmd = new MySqlCommand();
        public void Open()
        {
            if (conexao.State == System.Data.ConnectionState.Closed)
                conexao.Open();
        }
        public MySqlDataReader ExecuteReadSql(string strQuery)
        {
            cmd.CommandText = strQuery;
            cmd.Connection = conexao;
            MySqlDataReader leitor = cmd.ExecuteReader();
            return leitor;
        }
        public void ExecuteQuery(string strQuery)
        {
            cmd.CommandText = strQuery;
            cmd.Connection = conexao;
            cmd.ExecuteNonQuery();
        }
        public string ExecuteScalarSql(string strQuery)
        {
            cmd.CommandText = strQuery;
            cmd.Connection = conexao;
            string strRetorno = Convert.ToString(cmd.ExecuteScalar());
            if (strRetorno.Length < 1)
            {
                return strRetorno = "";
            }
            return strRetorno;
        }
        public void Close()
        {
            if (conexao.State == System.Data.ConnectionState.Open)
                conexao.Close();
        }
    }
}