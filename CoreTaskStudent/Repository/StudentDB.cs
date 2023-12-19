using CoreTaskStudent.Models;
using System.Data.SqlClient;
using System.Data;

namespace CoreTaskStudent.Repository
{
    public class StudentDB:IStudentDB
    {
        private readonly string connectionString;

        public StudentDB(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public string InsertStudent(Student studentResult)
        {
            string msg = string.Empty;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("InsertStudentResult", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Student_name", studentResult.Student_name);
                    command.Parameters.AddWithValue("@Age", studentResult.Age);
                    command.Parameters.AddWithValue("@Marks", studentResult.Marks);
                    command.Parameters.AddWithValue("@Result", studentResult.Result);

                    connection.Open();
                    command.ExecuteNonQuery();
                    msg = "SUCCESS";
                }
            }
            catch (SqlException ex)
            {
                msg = ex.Message;
            }
            return msg;
        }

        public string UpdateStudentResult(Student studentResult)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("UpdateStudentResult", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Result", studentResult.Result);

                    connection.Open();
                    command.ExecuteNonQuery();

                    return "SUCCESS";
                }
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }

        public async Task<IEnumerable<Student>> GetStudentDetails()
        {
            try
            {
                List<Student> studentDetails = new List<Student>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("GetStudentDetails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            Student_id = Convert.ToInt32(reader["Student_id"]),
                            Student_name = Convert.ToString(reader["Student_name"]),
                            Age = Convert.ToInt32(reader["Age"]),
                            Marks = Convert.ToInt32(reader["Marks"]),
                            Result = Convert.ToString(reader["Result"])
                        };
                        studentDetails.Add(student);
                    }
                }

                return studentDetails;
            }
            catch (SqlException)
            {
                // Handle exceptions, log, or return an empty list if needed.
                return new List<Student>();
            }
        }

        public string DeleteStudentResult(int studentId)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand("DeleteStudentResult", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Student_id", studentId);

                    connection.Open();
                    command.ExecuteNonQuery();

                    return "SUCCESS";
                }
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }


    }
}
