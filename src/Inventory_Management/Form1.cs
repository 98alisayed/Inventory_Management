using Inventory_Management;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management
{
    public partial class Form1 : Form
    {
        StockItemService stockItemService;

        public Form1()
        {
            InitializeComponent();

            stockItemService = new StockItemService();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            Read();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            LoadItem();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateItem();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {

            Insert();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Delete();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Clear();
            txtName.Clear();
            txtDesc.Clear();
            txtSno.Clear();
            txtQty.Clear();
            txtPrice.Clear();
            txtCategory.Clear();

        }









        private void Read()
        {
            var dataTable = stockItemService.Read();

            dataGridView1.DataSource = dataTable;



        }



        private void LoadItem()
        {

            try
            {

                dataGridView1.DataSource = stockItemService.LoadItem(txtId.Text);
                var dataTable = stockItemService.LoadItem(txtId.Text);

                // txtId.Text = dataTable.Rows[0][0].ToString();
                txtName.Text = dataTable.Rows[0][1].ToString();
                txtDesc.Text = dataTable.Rows[0][2].ToString();
                txtSno.Text = dataTable.Rows[0][3].ToString();
                txtQty.Text = dataTable.Rows[0][4].ToString();
                txtPrice.Text = dataTable.Rows[0][5].ToString();
                txtCategory.Text = dataTable.Rows[0][6].ToString();
            }

            catch
            {
                MessageBox.Show("Please enter the Product Id inorder to load the data");

            }
        }



        private void UpdateItem()
        {

            try
            {

                var stockItem = LoadStockItemFromTextBox();
                var stockItemService = new StockItemService();
                stockItemService.UpdateItem(stockItem);

                Read();
            }

            catch
            {
                MessageBox.Show("Please enter the Product Id inorder to update the table");
            }


        }



        public void Insert()
        {
            StockItem stockItem = null;
            stockItem = LoadStockItemFromTextBox();
            stockItemService.Insert(stockItem);
            Read();
        }



        public void Delete()
        {
            StockItem stockItem = LoadStockItemFromTextBox();
            var stockItemService = new StockItemService();
            stockItemService.Delete(stockItem);
            Read();
        }



        public void Search()
        {
            var stockItem = LoadStockItemFromTextBox();
            var stockItemService = new StockItemService();
            var dataTable = stockItemService.Search(stockItem);
            dataGridView1.DataSource = dataTable;
        }



        private StockItem LoadStockItemFromTextBox()
        {
            var item = new StockItem();

            item.Id = txtId.Text;
            item.Name = txtName.Text;
            item.Desc = txtDesc.Text;
            item.Sno = txtSno.Text;
            item.Qty = txtQty.Text;
            item.Price = txtPrice.Text;
            item.Category = txtCategory.Text;

            return item;
        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void TxtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }
    }
}
