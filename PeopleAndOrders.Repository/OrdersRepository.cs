using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using PeopleAndOrders.Model;
using PeopleAndOrders.Repository.Common;
using PeopleAndOrders.Common;


namespace PeopleAndOrders.Repository
{
    
    public class OrdersRepository : IOrdersRepositoryCommon
    {
        string connString = @"Server=ST-02\SQLEXPRESS;Initial Catalog=master;Trusted_connection=true;";
        public async Task<List<Orders>> FindAllOrdersAsync(Paging paging, Sorting sort, Filtering filtering)                          /*Paging Sorting Filtering*/
        {
            StringBuilder queryBuilder = new StringBuilder();
            Orders order = new Orders();
            using (SqlConnection con = new SqlConnection(connString))
            {
                queryBuilder.Append("SELECT * FROM Orders ");
                SqlCommand cmd = new SqlCommand(queryBuilder.ToString(), con);

                if (filtering.PreMade != null || filtering.PostMade != null || filtering.GoodOrderReview == true)
                {
                    queryBuilder.AppendLine("WHERE orderDate < " + filtering.PreMade + " ");
                }
                if (sort.SortBy == "id_order")
                {
                    queryBuilder.AppendLine(" ORDER BY id_order;");
                }
                if (sort.SortOrder == "ascending")
                {
                    queryBuilder.AppendLine("asc;");
                }
                if (sort.SortOrder == "descending")
                {
                    queryBuilder.AppendLine("desc;");
                }

                int offset = (paging.PageNumber - 1) * paging.PageSize;

                queryBuilder.Append("ORDER BY id DESC ");                                                                           /*descending test*/
                queryBuilder.Append("OFFSET " + offset + " ROWS ");
                cmd.Parameters.AddWithValue("@PageNumber", (paging.PageNumber - 1) * paging.PageSize);
                queryBuilder.AppendLine("FETCH NEXT " + paging.PageSize + " ROWS ONLY;");
                cmd.Parameters.AddWithValue("@PageSize", paging.PageSize);

                using (cmd)
                {
                    List<Orders> orders = new List<Orders>();
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            orders.Add(new Orders
                            {
                                Id_Order = Convert.ToInt32(sdr["id_order"]),
                                Id_User = Convert.ToInt32(sdr["id_user"]),
                                Product = sdr["product"].ToString(),
                                Total_Price = Convert.ToInt32(sdr["total_price"]),
                            });
                        }
                    }
                    con.Close();
                    return orders;
                }
            }
        }    
        public async Task<Orders> FindOrderByIdAsync(int id)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Orders WHERE Id_Order=@id_order", con))
                {
                    Orders order = new Orders();
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@id_order", id);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            order = new Orders
                            {
                                Id_Order = Convert.ToInt32(sdr["id_order"]),
                                Id_User = Convert.ToInt32(sdr["id_user"]),
                                Product = sdr["product"].ToString(),
                                Total_Price = Convert.ToInt32(sdr["total_price"]),
                            };
                        }
                    }
                    con.Close();
                    return order;
                }
            }          
        }
        public async Task<Orders> PostOrderAsync(OrdersRest orderRest)
        {
            Orders order = new Orders(orderRest.Id_Order, orderRest.Product, orderRest.Total_Price, null, orderRest.OrderDate);
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Orders VALUES (@id_order,@product,@total_price,@orderDate)", con))
                {
                    cmd.Parameters.AddWithValue("@id_order", $"{order.Id_Order}"); 
                    cmd.Parameters.AddWithValue("@product", $"{order.Product}");
                    cmd.Parameters.AddWithValue("@total_price", $"{order.Total_Price}");
                    cmd.Parameters.AddWithValue("@orderDate", $"{order.OrderDate}");

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return order;
                }
            }
        }
        public async Task<Orders> PutOrderAsync(int id, Orders orders)
        {
            id = orders.Id_Order;
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Orders SET id_order=@id_order,id_user=@id_user,product=@product,total_price=@total_price WHERE id_order=@id_order", con))
                {
                    cmd.Parameters.AddWithValue("@id_user", $"{orders.Id_User}");
                    cmd.Parameters.AddWithValue("@id_order", $"{id}");
                    cmd.Parameters.AddWithValue("@product", $"{orders.Product}");
                    cmd.Parameters.AddWithValue("@total_price", $"{orders.Total_Price}");             
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return orders;
                }
            }
        }
        public async Task DeleteOrderAsync(Orders orders)
        {
            using (SqlConnection con = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Orders WHERE id_order=@id_order", con))
                {
                    cmd.Parameters.AddWithValue("@id", $"{orders.Id_Order}");
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
