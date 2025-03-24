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
                    string query = "SELECT * FROM Customers";  // SQL-fråga
                    using (var cmd = new NpgsqlCommand(query, _conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        listBoxMain.Items.Clear();  // Tömmer listan innan nya data läggs till

                        while (reader.Read())
                        {
                            // Lägg till information från varje rad i ListBox
                            string customerInfo = $"{reader["customer_id"]}, {reader["first_name"]}, {reader["last_name"]}, " +
                                $"{reader["email"]}, {reader["address"]}, {reader["city"]}, {reader["country"]}, " +
                                $"{reader["phone_number"]}";
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT * FROM Suppliers";  // SQL-fråga
                    using (var cmd = new NpgsqlCommand(query, _conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        listBoxMain.Items.Clear();  // Tömmer listan innan nya data läggs till

                        while (reader.Read())
                        {
                            // Lägg till information från varje rad i ListBox
                            string customerInfo = $"{reader["supplier_id"]}, {reader["name"]}, {reader["phone_number"]}, {reader["address"]}";
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

        private void btnProducts_Click(object sender, EventArgs e)
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT * FROM Products";  // SQL-fråga
                    using (var cmd = new NpgsqlCommand(query, _conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        listBoxMain.Items.Clear();  // Tömmer listan innan nya data läggs till

                        while (reader.Read())
                        {
                            // Lägg till information från varje rad i ListBox
                            string customerInfo = $"{reader["product_id"]}, {reader["code"]}, {reader["name"]}, {reader["base_price"]}, {reader["quantity"]}" +
                                $",  {reader["supplier_id"]}";
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

        private void btnDiscounts_Click(object sender, EventArgs e)
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT * FROM Discounts";  // SQL-fråga
                    using (var cmd = new NpgsqlCommand(query, _conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        listBoxMain.Items.Clear();  // Tömmer listan innan nya data läggs till

                        while (reader.Read())
                        {
                            // Lägg till information från varje rad i ListBox
                            string customerInfo = $"{reader["discount_id"]}, {reader["discount_code"]}, {reader["percentage"]}, {reader["reason"]}";
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

        private void btnProductDiscount_Click(object sender, EventArgs e)
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT * FROM Product_Discounts";  // SQL-fråga
                    using (var cmd = new NpgsqlCommand(query, _conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        listBoxMain.Items.Clear();  // Tömmer listan innan nya data läggs till

                        while (reader.Read())
                        {
                            // Lägg till information från varje rad i ListBox
                            string customerInfo = $"{reader["product_id"]}, {reader["discount_id"]}, {reader["start_date"]}, {reader["end_date"]}";
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
        
        private void btnOrders_Click(object sender, EventArgs e)
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT * FROM Orders";  // SQL-fråga
                    using (var cmd = new NpgsqlCommand(query, _conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        listBoxMain.Items.Clear();  // Tömmer listan innan nya data läggs till

                        while (reader.Read())
                        {
                            // Lägg till information från varje rad i ListBox
                            string customerInfo = $"{reader["order_id"]}, {reader["customer_id"]}, {reader["order_date"]}, {reader["total_price"]}" +
                                $", {reader["confirmed"]}";
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

        private void btnOrderItems_Click(object sender, EventArgs e)
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "SELECT * FROM Order_Items";  // SQL-fråga
                    using (var cmd = new NpgsqlCommand(query, _conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        listBoxMain.Items.Clear();  // Tömmer listan innan nya data läggs till

                        while (reader.Read())
                        {
                            // Lägg till information från varje rad i ListBox
                            string customerInfo = $"{reader["order_item_id"]}, {reader["order_id"]}, {reader["product_id"]}, {reader["quantity"]}" +
                                $", {reader["price"]}, {reader["discount_id"]}";
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

        private void btnMakeAccount_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(tbxFirstName.Text) ||
                string.IsNullOrWhiteSpace(tbxLastName.Text) ||
                string.IsNullOrWhiteSpace(tbxEmail.Text) ||
                string.IsNullOrEmpty(tbxAddress.Text) ||
                string.IsNullOrWhiteSpace(tbxCity.Text) ||
                string.IsNullOrWhiteSpace(tbxCountry.Text) ||
                string.IsNullOrWhiteSpace(tbxPhoneNumber.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "INSERT INTO Customers (first_name, last_name, email, address, city, country, phone_number) " +
                          "VALUES (@first_name, @last_name, @email, @address, @city, @country, @phone_number)";
                    using (var cmd = new NpgsqlCommand(query, _conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@first_name", tbxFirstName.Text);
                        cmd.Parameters.AddWithValue("@last_name", tbxLastName.Text);
                        cmd.Parameters.AddWithValue("@email", tbxEmail.Text);
                        cmd.Parameters.AddWithValue("@address", tbxAddress.Text);
                        cmd.Parameters.AddWithValue("@city", tbxCity.Text);
                        cmd.Parameters.AddWithValue("@country", tbxCountry.Text);
                        cmd.Parameters.AddWithValue("@phone_number", tbxPhoneNumber.Text);

                        // Execute the command
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Account created successfully!");
                    //clears all textboxes
                    tbxFirstName.Clear();
                    tbxLastName.Clear();
                    tbxEmail.Clear();
                    tbxAddress.Clear();
                    tbxCity.Clear();
                    tbxCountry.Clear();
                    tbxPhoneNumber.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating account: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No open connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(tbxPcode.Text) ||
                string.IsNullOrEmpty(tbxPname.Text) ||
                string.IsNullOrWhiteSpace(tbxPbasePrice.Text) ||
                string.IsNullOrWhiteSpace(tbxPquantity.Text) ||
                string.IsNullOrWhiteSpace(tbxPsuppid.Text))
                
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            decimal basePrice;
            if (!decimal.TryParse(tbxPbasePrice.Text, out basePrice))
            {
                MessageBox.Show("Base price must be a valid number.");
                return;
            }

            int quantity;
            if (!int.TryParse(tbxPquantity.Text, out quantity))
            {
                MessageBox.Show("Quantity must be a valid integer.");
                return;
            }

            int productSupplierId;
            if (!int.TryParse(tbxPsuppid.Text, out productSupplierId))
            {
                MessageBox.Show("Supplier id must be a valid integer.");
                return;
            }


            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    if (!IsValueUniqe("Products", "code", tbxPcode.Text))
                    {
                        // Om koden redan finns, visa ett meddelande och avbryt
                        MessageBox.Show("The product code is already in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return; 
                    }

                    if (!IsValueUniqueNumber("Products", "supplier_id", tbxPsuppid.Text))
                    {
                        // om det inte finns någon supplier med detta id
                        MessageBox.Show("There is no supplier with this id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    string query = "INSERT INTO Products (code, name, base_price, quantity, supplier_id) " +
                          "VALUES (@code, @name, @base_price, @quantity, @supplier_id)";
                    using (var cmd = new NpgsqlCommand(query, _conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@code", tbxPcode.Text);
                        cmd.Parameters.AddWithValue("@name", tbxPname.Text);
                        cmd.Parameters.AddWithValue("@base_price", basePrice);
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@supplier_id", productSupplierId);
                        

                        // Execute the command
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Product added successfully!");
                    //clears all textboxes
                    tbxPcode.Clear();
                    tbxPname.Clear();
                    tbxPbasePrice.Clear();
                    tbxPquantity.Clear();
                    tbxPsuppid.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Added product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No open connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool IsValueUniqe(string tableName, string columnName, string value)
        {
            try
            {
                // uppbyggnad av sql fråga beroende på vilken värde man vill kolla i vilken tabell
                string query = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @value";

                using (var cmd = new NpgsqlCommand(query, _conn))
                {
                    // lägger in värdet att testa på
                    cmd.Parameters.AddWithValue("@value", value);
                    // kollar hur många rader som har det värdet
                    int count = Convert.ToInt32(cmd.ExecuteScalar());


                    if (count > 0)
                    {
                        // värdet finns redan i tabellen
                        return false; 
                    }
                    else
                    {
                        // värdet finns inte i tabellen
                        return true;   // Unique
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking uniqueness: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;  // Return false if an error occurs
            }
        }

        private bool IsValueUniqueNumber(string tableName, string columnName, string value)
        {
            try
            {
                // Try to convert the value to an integer
                if (!int.TryParse(value, out int intValue))
                {
                    MessageBox.Show("Invalid number format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                string query = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @value";

                using (var cmd = new NpgsqlCommand(query, _conn))
                {
                    // Add the integer value as a parameter
                    cmd.Parameters.AddWithValue("@value", intValue);

                    // Execute the query and get the count
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    // If count > 0, it means the value already exists
                    return count == 0;  // Return true if the value is unique
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking uniqueness: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;  // Return false if an error occurs
            }
        }


    }
}
