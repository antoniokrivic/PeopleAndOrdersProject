using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleAndOrders.Repository.Common;
using PeopleAndOrders.Model;
using PeopleAndOrders.Common;

namespace PeopleAndOrders.Repository
{
    public class PeopleRepository : IPeopleRepositoryCommon
    {
        string connString = @"Server=ST-02\SQLEXPRESS;Initial Catalog=master;Trusted_connection=true;";
        
        public async Task<List<People>> FindAllPeopleAsync(Paging paging, Sorting sort, Filtering filtering)
        {
            
            List<People> people = new List<People>();
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM People", con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            people.Add(new People
                            {
                                Id = Convert.ToInt32(sdr["id"]),
                                Address = sdr["address"].ToString(),
                                Email = sdr["email"].ToString(),
                                Password = sdr["password"].ToString(),
                                Name = sdr["name"].ToString(),
                                City = sdr["city"].ToString()

                            });
                        }
                    }
                    con.Close();
                    return people;
                }
            }
        }
        public async Task<People> FindPeopleByIdAsync(int id)
        {
            
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM People WHERE id=@id", con))
                {
                    People people = new People();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            people = new People
                            {
                                Id = Convert.ToInt32(sdr["id"]),
                                Address = sdr["address"].ToString(),
                                Email = sdr["email"].ToString(),
                                Password = sdr["password"].ToString(),
                                Name = sdr["name"].ToString(),
                                City = sdr["city"].ToString()
                            };
                        }
                    }
                    con.Close();
                    return people;
                }
            }
        }

        public async Task<PeopleRest> PostPeopleAsync(PeopleRest people)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO People VALUES (@id,@address,@email,@name,@city)", con))
                {
                    cmd.Parameters.AddWithValue("@id", $"{people.Id}");
                    cmd.Parameters.AddWithValue("@address", $"{people.Address}");
                    cmd.Parameters.AddWithValue("@email", $"{people.Email}");
                    cmd.Parameters.AddWithValue("@name", $"{people.Name}");
                    cmd.Parameters.AddWithValue("@city", $"{people.City}");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return people;
                }
            }
        }

        public async Task<People> PutPeopleAsync(int id, People people)
        {
            id = people.Id;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE People SET address=@address,email=@email,password=@password,name=@name,city=@city WHERE id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", $"{people.Id}");
                    cmd.Parameters.AddWithValue("@address", $"{people.Address}");
                    cmd.Parameters.AddWithValue("@email", $"{people.Email}");
                    cmd.Parameters.AddWithValue("@password", $"{people.Password}");
                    cmd.Parameters.AddWithValue("@name", $"{people.Name}");
                    cmd.Parameters.AddWithValue("@city", $"{people.City}");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return people;
                }
            }
        }

        public async Task DeletePeopleAsync(People people, int id)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM People WHERE id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", $"{people.Id}");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

    }
}
