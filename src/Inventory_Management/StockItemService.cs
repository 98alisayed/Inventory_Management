using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management
{
    class StockItemService
    {

        private SqlConnection conn;

        public StockItemService()
        {
            conn = Connect();
        }
        public void Insert(StockItem stockItem)
        {
            try
            {




                string q = "INSERT INTO STOCKITEM VALUES (@id, @name, @desc, @sNo, @qty, @price, @category);";

                var cmd = new SqlCommand(q, conn);

                cmd.Parameters.AddWithValue("@id", stockItem.Id);
                cmd.Parameters.AddWithValue("@name", stockItem.Name);
                cmd.Parameters.AddWithValue("@desc", stockItem.Desc);
                cmd.Parameters.AddWithValue("@sNo", stockItem.Sno);
                cmd.Parameters.AddWithValue("@qty", stockItem.Qty);
                cmd.Parameters.AddWithValue("@price", stockItem.Price);
                cmd.Parameters.AddWithValue("@category", stockItem.Category);

                cmd.ExecuteNonQuery();
            }

            catch
            {
                MessageBox.Show("Duplicate Primary Key. Please enter a different Id Number");
            }
        }

        public DataTable Read()
        {

            string Q = "SELECT * FROM STOCKITEM";

            SqlCommand cmd = new SqlCommand(Q, conn);


            var da = new SqlDataAdapter(cmd);
            var dataTable = new DataTable();

            da.Fill(dataTable);

            return dataTable;
        }

        public void UpdateItem(StockItem stockItem)
        {
            string Q = "UPDATE STOCKITEM SET Name = @name, Description = @desc, SerialNo = @sNo, Quantity = @qty, Price = @price, Category = @category" +
                         " where Id = @id";

            SqlCommand cmd = new SqlCommand(Q, conn);

            cmd.Parameters.AddWithValue("@id", stockItem.Id);
            cmd.Parameters.AddWithValue("@name", stockItem.Name);
            cmd.Parameters.AddWithValue("@desc", stockItem.Desc);
            cmd.Parameters.AddWithValue("@sNo", stockItem.Sno);
            cmd.Parameters.AddWithValue("@qty", stockItem.Qty);
            cmd.Parameters.AddWithValue("@price", stockItem.Price);
            cmd.Parameters.AddWithValue("@category", stockItem.Category);

            cmd.ExecuteNonQuery();
        }

        public void Delete(StockItem stockItem)
        {
            string Q = "DELETE FROM STOCKITEM WHERE ID = @id";

            SqlCommand cmd = new SqlCommand(Q, conn);
            cmd.Parameters.AddWithValue("@id", stockItem.Id);

            cmd.ExecuteNonQuery();
        }

        public DataTable Search(StockItem stockItem)
        {
            string Q = "SELECT * FROM STOCKITEM WHERE (Id = @id OR @id = '') AND (Name = @name OR @name = '') " +
                          "AND (Description = @desc OR @desc = '') AND (SerialNo = @sNo OR @sNo = '') " +
                            "AND (Quantity = @qty OR @qty = '') AND (Price = @price OR @price = '') " +
                              "AND (Category = @category OR @category = '')";


            SqlCommand cmd = new SqlCommand(Q, conn);
            cmd.Parameters.AddWithValue("@id", stockItem.Id);
            cmd.Parameters.AddWithValue("@name", stockItem.Name);
            cmd.Parameters.AddWithValue("@desc", stockItem.Desc);
            cmd.Parameters.AddWithValue("@sNo", stockItem.Sno);
            cmd.Parameters.AddWithValue("@qty", stockItem.Qty);
            cmd.Parameters.AddWithValue("@price", stockItem.Price);
            cmd.Parameters.AddWithValue("@category", stockItem.Category);


            var da = new SqlDataAdapter(cmd);

            var dataTable = new DataTable();
            da.Fill(dataTable);

            return dataTable;
        }

        public DataTable LoadItem(string Id)
        {

            SqlConnection conn = Connect();
            string Q = "SELECT * FROM STOCKITEM where Id = @id";

            SqlCommand cmd = new SqlCommand(Q, conn);

            cmd.Parameters.AddWithValue("@id", Id);

            var item = new StockItem();


            cmd.ExecuteNonQuery();

            var da = new SqlDataAdapter(cmd);
            var dataTable = new DataTable();




            da.Fill(dataTable);
            item.Id = dataTable.Rows[0][0].ToString();
            item.Name = dataTable.Rows[0][1].ToString();
            item.Desc = dataTable.Rows[0][2].ToString();
            item.Sno = dataTable.Rows[0][3].ToString();
            item.Qty = dataTable.Rows[0][4].ToString();
            item.Price = dataTable.Rows[0][5].ToString();
            item.Category = dataTable.Rows[0][6].ToString();


            return dataTable;





        }
        private SqlConnection Connect()
        {
            string connString;
            connString = @"Server = STEALTH-PC; Database = SuperMarket; User Id =mainUser; Password = Ali-123";

            SqlConnection conn = new SqlConnection(connString);

            conn.Open();
            return conn;
        }

    }
}

