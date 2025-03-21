using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
namespace CoffeeShop
{
    public partial class Supplier : Form
    {
        /*
        // Disconnect Model
        // sqlDataAdapter adapter 
        adapter.Fill()
        apdater.Update()
        //Dataset (DataTable)

        */
        private SqlDataAdapter adapter;
        private DataSet dataSet;
        private SqlConnection cn; 
        public Supplier()
        {
            InitializeComponent();
            string cnStr = "Data Source=.;Initial Catalog=CoffeeShop;Integrated Security=True";
            cn = new SqlConnection(cnStr);
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            dataSet = new DataSet();
            string sql = "SELECT * FROM Product";
            adapter = new SqlDataAdapter(sql, cn);
            adapter.Fill(dataSet);
       
            dataGVSql.DataSource = dataSet.Tables[0]; // xu ly de hien thi
        }

        private void btnSave_Click(object sender, EventArgs e) // nút save khi chỉnh sửa trên bảng
        {


            try
            {
                //delete
                string sql = "DELETE FROM Product WHERE id = @ma";
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@ma", SqlDbType.VarChar, 10, "id");
                adapter.DeleteCommand = cmd;

                //adapter.Update(dataSet);

                //INSERT
                String insertSql = "INSERT INTO Product (id, name, purchasePrice, sellingPrice, categoryId, supplierId) VALUES (@id, @name, @purchasePrice, @sellingPrice, @categoryId, @supplierId)";
                SqlCommand insertCmd = new SqlCommand(insertSql, cn);
                insertCmd.CommandType = CommandType.Text;
                insertCmd.Parameters.Add("@id", SqlDbType.VarChar, 10, "id");
                insertCmd.Parameters.Add("@name", SqlDbType.NVarChar, 100, "name");
                insertCmd.Parameters.Add("@purchasePrice", SqlDbType.Float, 0, "purchasePrice");
                insertCmd.Parameters.Add("@sellingPrice", SqlDbType.Float, 0, "sellingPrice");
                insertCmd.Parameters.Add("@categoryId", SqlDbType.Int, 0, "categoryId");
                insertCmd.Parameters.Add("@supplierId", SqlDbType.VarChar, 20, "supplierId");

                adapter.InsertCommand = insertCmd;
                //adapter.Update(dataSet);


                //UPDATE
                String updateSql = "UPDATE Product SET name = @name, purchasePrice = @purchasePrice, sellingPrice = @sellingPrice, categoryId = @categoryId, supplierId = @supplierId WHERE id = @id";
                SqlCommand updateCmd = new SqlCommand(updateSql, cn);
                updateCmd.CommandType = CommandType.Text;
                updateCmd.Parameters.Add("@id", SqlDbType.VarChar, 10, "id");
                updateCmd.Parameters.Add("@name", SqlDbType.NVarChar, 100, "name");
                updateCmd.Parameters.Add("@purchasePrice", SqlDbType.Float, 0, "purchasePrice");
                updateCmd.Parameters.Add("@sellingPrice", SqlDbType.Float, 0, "sellingPrice");
                updateCmd.Parameters.Add("@categoryId", SqlDbType.Int, 0, "categoryId");
                updateCmd.Parameters.Add("@supplierId", SqlDbType.VarChar, 20, "supplierId");

                adapter.UpdateCommand = updateCmd;
                adapter.Update(dataSet);



            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "lỗi rồi nè mẹ");
            }

        }
    }
}
