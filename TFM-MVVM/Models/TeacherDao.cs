using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TFM_MVVM.Models
{

    public class TeacherDao : Dao
    {

        private readonly string ID_COLUMN = "ID";
        private readonly string SURNAME_COLUMN = "SURNAME";
        private readonly string NAME_COLUMN = "NAME";

        public TeacherDao() : base()
        {
        }

        public void insert(Teacher teacher)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO TEACHER (NAME,SURNAME) VALUES(@name,@surname)");

                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = teacher.Name;
                cmd.Parameters.Add("@surname", SqlDbType.VarChar).Value = teacher.Surname;

                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();

                cmd.ExecuteNonQuery();

                removeAllTeacherSubjects(teacher.Id);
                foreach (Subject subject in teacher.Subjects)
                {
                    insertSubjectTeacher(teacher.Id, subject.Id);
                }
            }
            finally
            {
                con.Close();
            }
        }

        public void update(Teacher teacher)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE TEACHER SET NAME=@name,SURNAME=@surname WHERE ID = @id");

                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = teacher.Name;
                cmd.Parameters.Add("@surname", SqlDbType.VarChar).Value = teacher.Surname;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = teacher.Id;

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

        public List<Teacher> getAll()
        {

            List<Teacher> result = new List<Teacher>();
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            SqlDataReader rs;

            cmd.CommandText = "SELECT * FROM TEACHER;";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();

            rs = cmd.ExecuteReader();

            while (rs.Read())
            {
                result.Add(new Teacher()
                {
                    Id = Convert.ToInt32(rs[ID_COLUMN].ToString()),
                    Name = rs[NAME_COLUMN].ToString(),
                    Surname = rs[SURNAME_COLUMN].ToString()
                });
            }
            con.Close();

            return result;
        }

        public Teacher get(int id)
        {
            Teacher result = new Teacher();
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM TEACHER WHERE ID = @id");

            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.Open();

            SqlDataReader rs = cmd.ExecuteReader();

            while (rs.Read())
            {
                result = new Teacher()
                {
                    Id = Convert.ToInt32(rs[ID_COLUMN].ToString()),
                    Name = rs[NAME_COLUMN].ToString(),
                    Surname = rs[SURNAME_COLUMN].ToString()
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
                SqlCommand cmd = new SqlCommand("DELETE TEACHER WHERE ID = @id");
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

        public void removeAllTeacherSubjects(int idTeacher)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM  TEACHER_SUBJECT WHERE ID_TEACHER = @id");
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idTeacher;
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

        public void insertSubjectTeacher(int idTeacher, int idSubject)
        {

            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO TEACHER_SUBJECT (ID_TEACHER,ID_TEACHER) VALUES(@idSubject,@idTeacher)");

                cmd.Parameters.Add("@idSubject", SqlDbType.Int).Value = idSubject;
                cmd.Parameters.Add("@idTeacher", SqlDbType.Int).Value = idTeacher;

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
