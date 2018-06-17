using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TFM_MVVM.Models
{


    public class SubjectDao : Dao
    {


        private readonly string COURSE_COLUMN = "COURSE";
        private readonly string ID_COLUMN = "ID";
        private readonly string TITLE_COLUMN = "TITLE";

        public SubjectDao() : base() { }

        public void insert(Subject subject)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO SUBJECT (TITLE,COURSE) VALUES(@title,@course)");

                cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = subject.Title;
                cmd.Parameters.Add("@course", SqlDbType.Int).Value = subject.Course;

                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();

                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<Subject> GetAll()
        {
            List<Subject> result = new List<Subject>();
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            SqlDataReader rs;

            cmd.CommandText = "SELECT * FROM SUBJECT;";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();

            rs = cmd.ExecuteReader();

            while (rs.Read())
            {
                result.Add(new Subject()
                {
                    Id = Convert.ToInt32(rs[ID_COLUMN].ToString()),
                    Title = rs[TITLE_COLUMN].ToString(),
                    Course = Convert.ToInt32(rs[COURSE_COLUMN].ToString())
                });
            }
            con.Close();

            return result;
        }

        public List<Subject> getByTeacher(int idTeacher)
        {
            List<Subject> result = new List<Subject>();
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");

            SqlCommand cmd = new SqlCommand(@"
                                SELECT * 
                                FROM SUBJECT S 
                                INNER JOIN TEACHER_SUBJECT TS  
                                ON S.ID = TS.ID_SUBJECT 
                                WHERE TS.ID_TEACHER = @id");

            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = idTeacher;
            con.Open();

            SqlDataReader rs = cmd.ExecuteReader();

            while (rs.Read())
            {
                result.Add(new Subject()
                {
                    Id = Convert.ToInt32(rs[ID_COLUMN].ToString()),
                    Title = rs[TITLE_COLUMN].ToString(),
                    Course = Convert.ToInt32(rs[COURSE_COLUMN].ToString())
                });
            }
            con.Close();

            return result;
        }

        public List<Subject> getByStudent(int idStudent)
        {
            List<Subject> result = new List<Subject>();
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");

            SqlCommand cmd = new SqlCommand(@"
                                SELECT * FROM SUBJECT S 
                                INNER JOIN STUDENT_SUBJECT SS 
                                ON S.ID = SS.ID_SUBJECT 
                                WHERE SS.ID_STUDENT = @id");

            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = idStudent;
            con.Open();

            SqlDataReader rs = cmd.ExecuteReader();

            while (rs.Read())
            {
                result.Add(new Subject()
                {
                    Id = Convert.ToInt32(rs[ID_COLUMN].ToString()),
                    Title = rs[TITLE_COLUMN].ToString(),
                    Course = Convert.ToInt32(rs[COURSE_COLUMN].ToString())
                });
            }
            con.Close();

            return result; 
        }

        public Subject get(int id)
        {
            Subject result = new Subject();
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM SUBJECT WHERE ID = @id");

            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.Open();

            SqlDataReader rs = cmd.ExecuteReader();

            while (rs.Read())
            {
                result= new Subject()
                {
                    Id = Convert.ToInt32(rs[ID_COLUMN].ToString()),
                    Title = rs[TITLE_COLUMN].ToString(),
                    Course = Convert.ToInt32(rs[COURSE_COLUMN].ToString())
                };
            }
            con.Close();

            return result;

        }

        public void remove(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE SUBJECT WHERE ID = @id");
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public void update(Subject subject)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE SUBJECT SET TITLE=@title,COURSE=@course WHERE ID = @id");

                cmd.Parameters.Add("@title", SqlDbType.VarChar).Value = subject.Title;
                cmd.Parameters.Add("@course", SqlDbType.Int).Value = subject.Course;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = subject.Id;

                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

    }
}

