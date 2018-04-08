using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WithAccessDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(Configuration.ConfigurationMethod());
            OleDbCommand cmd = new OleDbCommand(@"insert into EMPTBL(NAME,FNAME) values('" + nametextBox1.Text.Trim() + "','" + fatherNametextBox2.Text.Trim() + "')", conn);


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Insert Data Successfully Test");
            dataGridView1.DataSource = GetDataFromAccessDatabase();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection(Configuration.ConfigurationMethod());
            OleDbCommand cmd = new OleDbCommand(@"Update EMPTBL SET FNAME=' " + fatherNametextBox2.Text.Trim() + "' where NAME = '" + nametextBox1.Text.Trim() + "'", conn);


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Update Data Successfully Test");
            dataGridView1.DataSource = GetDataFromAccessDatabase();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = GetDataFromAccessDatabase();
            dataGridView1.Columns[0].Visible = false;
        }

        private DataTable GetDataFromAccessDatabase()
        {
            DataTable dt = new DataTable();
            OleDbConnection conn = new OleDbConnection(Configuration.ConfigurationMethod());
            OleDbCommand cmd = new OleDbCommand(@"select * from EMPTBL", conn);
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            
            int rowindex = dataGridView1.Rows.GetFirstRow(DataGridViewElementStates.Selected);

            string  row =Convert.ToString(dataGridView1.Rows[rowindex].Cells["NAME"].Value);
            string  row1 = Convert.ToString(dataGridView1.Rows[rowindex].Cells["FNAME"].Value);

            nametextBox1.Text = row.ToString();
            fatherNametextBox2.Text = row1.ToString();
        }
    }
}
