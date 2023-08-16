using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace projectLivro.Models
{
    public class LivrosDAO
    {
        modelDB db = new modelDB();

        public void Insert(modelLivro objLivro)
        {
            string strInsertLivro = string.Format("insert into tbl_Livro(nm_Livro, data_Inicio, data_Termino, nota_Livro) values " +
                "('{0}', STR_TO_DATE('{1}', '%d/%m/%Y %T'), STR_TO_DATE('{2}', '%d/%m/%Y %T'), '{3}');", objLivro.nm_Livro, objLivro.data_Inicio,
                objLivro.data_Termino, objLivro.nota_Livro);
            db.Open();
            db.ExecuteQuery(strInsertLivro);
            db.Close();
        }
        public modelLivro Delete(int Id)
        {
            modelLivro livro = new modelLivro();

            string strDelete = string.Format("delete from tbl_Livro where id_Livro = {0};", Id);
            db.Open();
            db.ExecuteQuery(strDelete);
            db.Close();


            return livro;
        }
        public modelLivro SelectLivro(int Id)
        {
            modelLivro livro = new modelLivro();

            string strSelectLivro = "select * from tbl_Livro where id_Livro = " + Id + ";";

            db.Open();
            MySqlDataReader dr = db.ExecuteReadSql(strSelectLivro);
            dr.Read();

            livro.id_Livro = int.Parse(dr["id_Livro"].ToString());
            livro.nm_Livro = dr["nm_Livro"].ToString();
            livro.data_Inicio = DateTime.Parse(dr["data_Inicio"].ToString());
            livro.data_Termino = DateTime.Parse(dr["data_Inicio"].ToString());
            livro.nota_Livro = dr["nota_Livro"].ToString();

            dr.Close();
            db.Close();

            return livro;
        }
        public void Update(modelLivro objLivro, int Id)
        {
            string strUpdate = string.Format("update tbl_Livro set nm_Livro = '{0}', data_Inicio = STR_TO_DATE('{1}', '%d/%m/%Y %T')," +
                "data_Termino = STR_TO_DATE('{2}', '%d/%m/%Y %T'), nota_Livro = '{3}', where id_Livro = {4};", objLivro.nm_Livro,
                objLivro.data_Inicio, objLivro.data_Termino, objLivro.nota_Livro, Id);
            db.Open();
            db.ExecuteQuery(strUpdate);
            db.Close();
        }
        public List<modelLivro> SelectList()
        {
            string strSelect = "select * from tbl_Livro;";
            db.Open();
            MySqlDataReader dr = db.ExecuteReadSql(strSelect);


            return ListLivro(dr);
        }
        private List<modelLivro> ListLivro(MySqlDataReader leitor)
        {
            var livros = new List<modelLivro>();


            while (leitor.Read())
            {
                var TempLivros = new modelLivro()
                {

                    id_Livro = int.Parse(leitor["id_Livro"].ToString()),
                    nm_Livro = leitor["nm_Livro"].ToString(),
                    data_Inicio = DateTime.Parse(leitor["data_Inicio"].ToString()),
                    data_Termino = DateTime.Parse(leitor["data_Inicio"].ToString()),
                    nota_Livro = leitor["nota_Livro"].ToString(),
                };
                livros.Add(TempLivros);

            }
            db.Close();
            leitor.Close();

            return livros;
        }
    }
}