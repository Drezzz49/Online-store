using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Online_store
{
    public partial class Form1 : Form
    {

        private NpgsqlConnection _conn; //för hålla anslutningen till databasen
        private string connString = ""; //min login
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)//om den finns och är öppen
            {
                _conn.Close();  // Stänger
                MessageBox.Show("Connection closed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No open connection to close.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

            _conn = new NpgsqlConnection(connString);  // Skapar anslutning

            try
            {
                _conn.Open();  // Öppnar anslutningen
                MessageBox.Show("Connection to PostgreSQL successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Connection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT * FROM customer";  // SQL-fråga för att hämta alla kunder
                    using (var cmd = new NpgsqlCommand(query, _conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        listBoxMain.Items.Clear();  // Tömmer listan innan nya data läggs till

                        while (reader.Read())
                        {
                            // Lägg till information från varje rad i ListBox
                            string customerInfo = $"ID: {reader["id"]}, Name: {reader["firstname"]}, lastname: {reader["lastname"]}";
                            listBoxMain.Items.Add(customerInfo);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No open connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
