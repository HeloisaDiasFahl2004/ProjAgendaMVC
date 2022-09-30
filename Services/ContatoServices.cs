using Models;
using System;
using System.Data.SqlClient;
using System.Text;
using System.Collections.Generic;

namespace Services
{
    public class ContatoServices
    {
        #region Banco de Dados
        // C:\Users\Heloísa\source\repos\ProjAgendaMVC -  pode ser substituido pelo ponto ( . ) com o ponyo, executa em qualquer máquina
        static string Caminho = @"Data Source=(LocalDB)\MSSQLLocalDB;
                       AttachDbFilename=C:\Users\Heloísa\source\repos\ProjAgendaMVC\Services\Banco\Agenda.mdf;
                       Integrated Security=True;Connect Timeout=5";

        // SqlConnection conn = new SqlConnection(Caminho); // uso quando não uso o método  BuscarConexao
        SqlConnection conn; //uso quando uso o método BuscarConexao 
        public SqlConnection BuscarConexao() //design pattern singleton
        {
            if (conn == null)
            {
                conn = new SqlConnection(Caminho);
                conn.Open();
                return conn;
            }
            if (conn.State == System.Data.ConnectionState.Open)
            {
                return conn;
            }
            conn.Open();
            return conn;
        }
        #endregion


        //INSERIR
        #region Insert
        public Contato InserirContato(Contato contato)
        {
            // conn.Open();  // uso quando não uso o método BuscarConexao

           var conn=  BuscarConexao(); // uso quando uso o método BuscarConexao

            SqlCommand dataInsert = new SqlCommand();  // tenho o objeto para criar o comando
                                                       //  dataInsert.CommandText = "INSERT INTO CONTATOS (Nome,Telefone) VALUES(@Nome,@Telefone)"; // pode inserir assim ou do jeito abaixo
            dataInsert.CommandText = $"INSERT INTO CONTATOS (Nome,Telefone) VALUES('{contato.Nome}', '{contato.Telefone}')";

            //Como inseriri no banco de dados
            //   StringBuilder sb = new StringBuilder();
            //  sb.Append($"INSERT INTO CONTATOS (Nome,Telefone) ");
            //  sb.Append($"VALUES('{contato.Nome}', '{contato.Telefone}')");

            dataInsert.Parameters.Add(new SqlParameter("@Nome", contato.Nome));
            dataInsert.Parameters.Add(new SqlParameter("@Telefone", contato.Telefone));

            dataInsert.Connection = conn;
            dataInsert.ExecuteNonQuery();

            //conn.Close() // uso quando não uso o método BuscarConexao
            return contato;
        }
        #endregion

        //SELECT
        #region Select
        public List<Contato> ConsultaTodos()
        {
           var conn= BuscarConexao();
            SqlCommand dataSelect = new SqlCommand();

            dataSelect.CommandText = "SELECT * FROM Contatos";
            dataSelect.Connection = conn;
            List<Contato> agenda = new List<Contato>();

            using (SqlDataReader dataReader = dataSelect.ExecuteReader())
            {
                while (dataReader.Read())
                {
                    Contato c = new();
                    c.Id = dataReader.GetInt32(0);
                    c.Nome = dataReader.GetString(1);
                    c.Telefone = dataReader.GetString(2);
                    agenda.Add(c);
                }
                return agenda;
            }
        }
        #endregion
    }
}
