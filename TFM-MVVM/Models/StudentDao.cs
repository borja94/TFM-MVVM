
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TFM_MVVM.Models
{

    public class StudentDao : Dao
    {
        private readonly string ID_COLUMN = "ID";
        private readonly string SURNAME_COLUMN = "SURNAME";
        private readonly string NAME_COLUMN = "NAME";

        public void insert(Student student)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO STUDENT (NAME,SURNAME) VALUES(@name,@surname)");

                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = student.Name;
                cmd.Parameters.Add("@surname", SqlDbType.VarChar).Value = student.Surname;

                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;

                con.Open();

                cmd.ExecuteNonQuery();
                removeAllStudentSubjects(student.Id);
                foreach (Subject subject in student.Subjects)
                {
                    insertSubjectStudent(student.Id, subject.Id);
                }
            }
            finally
            {
                con.Close();
            }
        }

        public void update(Student student)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE STUDENT SET NAME=@name,SURNAME=@surname WHERE ID = @id");

                cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = student.Name;
                cmd.Parameters.Add("@surname", SqlDbType.VarChar).Value = student.Surname;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = student.Id;

                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();

                removeAllStudentSubjects(student.Id);
                foreach (Subject subject in student.Subjects)
                {
                    insertSubjectStudent(student.Id, subject.Id);
                }
            }
            finally
            {
                con.Close();
            }
        }

        public List<Student> getAll()
        {

            List<Student> result = new List<Student>();
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");

            SqlCommand cmd = new SqlCommand();
            SqlDataReader rs;

            cmd.CommandText = "SELECT * FROM STUDENT;";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;

            con.Open();

            rs = cmd.ExecuteReader();

            while (rs.Read())
            {
                result.Add(new Student()
                {
                    Id = Convert.ToInt32(rs[ID_COLUMN].ToString()),
                    Name = rs[NAME_COLUMN].ToString(),
                    Surname = rs[SURNAME_COLUMN].ToString()
                });
            }
            con.Close();

            return result;
        }

        public Student get(int id)
        {
            Student result = new Student();
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");

            SqlCommand cmd = new SqlCommand(@"SELECT * FROM STUDENT WHERE ID = @id");

            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            con.Open();

            SqlDataReader rs = cmd.ExecuteReader();

            while (rs.Read())
            {
                result = new Student()
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
                SqlCommand cmd = new SqlCommand("DELETE STUDENT WHERE ID = @id");
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

        public void removeAllStudentSubjects(int idStudent)
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");
            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM  STUDENT_SUBJECT WHERE ID_STUDENT = @id");
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idStudent;
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

        public void insertSubjectStudent(int idStudent, int idSubject)
        {

            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Proyectos\\TFM\\TFM-MVVM\\TFM-MVVM\\TFMEntities.mdf;Integrated Security=True");
            try
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO STUDENT_SUBJECT (ID_SUBJECT,ID_STUDENT) VALUES(@idSubject,@idStudent)");

                cmd.Parameters.Add("@idSubject", SqlDbType.Int).Value = idSubject;
                cmd.Parameters.Add("@idStudent", SqlDbType.Int).Value = idStudent;

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