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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Online_store
{
    public partial class Form1 : Form
    {

        private NpgsqlConnection _conn; //för hålla anslutningen till databasen
        private string connString = ""; //min login
        private string loggedUser = "";
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
                            string customerInfo = $"id:{reader["order_item_id"]}, order_id:{reader["order_id"]}, p_id:{reader["product_id"]}, ammount:{reader["quantity"]}" +
                                $", price:{reader["price"]}, discount:{reader["discount_id"]}";
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

        private void btnAddSupplier_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxSname.Text) ||
               string.IsNullOrWhiteSpace(tbxSphone.Text) ||
               string.IsNullOrEmpty(tbxSaddress.Text))

            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {

                    string query = "INSERT INTO Suppliers (name, phone_number, address) " +
                          "VALUES (@name, @phone_number, @address)";
                    using (var cmd = new NpgsqlCommand(query, _conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@name", tbxSname.Text);
                        cmd.Parameters.AddWithValue("@phone_number", tbxSphone.Text);
                        cmd.Parameters.AddWithValue("@address", tbxSaddress.Text);


                        // Execute the command
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Supplier added successfully!");
                    //clears all textboxes
                    tbxSname.Clear();
                    tbxSphone.Clear();
                    tbxSaddress.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error Added Supplier: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No open connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEditStcok_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxEditProductid.Text) ||
                string.IsNullOrWhiteSpace(tbxEditNewQuantity.Text))
            {
                MessageBox.Show("Please fill in both Product ID and New Quantity.");
                return;
            }

            // Check if new quantity is a valid number
            int newQuantity;
            if (!int.TryParse(tbxEditNewQuantity.Text, out newQuantity) || newQuantity < 0)
            {
                MessageBox.Show("Please enter a valid non-negative quantity.");
                return;
            }

            // Check if Product ID is a valid integer
            int productId;
            if (!int.TryParse(tbxEditProductid.Text, out productId))
            {
                MessageBox.Show("Product ID must be a valid integer.");
                return;
            }

            if (IsValueUniqueNumber("Products", "product_id", tbxEditProductid.Text))
            {
                // Om koden redan finns, visa ett meddelande och avbryt
                MessageBox.Show("This product ID does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    // Update the stock quantity
                    string updateQuery = "UPDATE Products SET quantity = @quantity WHERE product_id = @product_id";
                    using (var cmd = new NpgsqlCommand(updateQuery, _conn))
                    {
                        // Add parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@quantity", newQuantity);
                        cmd.Parameters.AddWithValue("@product_id", productId);

                        // Execute the command
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Stock quantity updated successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to update stock quantity. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    // Clear the textboxes after successful update
                    tbxEditProductid.Clear();
                    tbxEditNewQuantity.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating stock: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No open connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxLoginEmail.Text))
            {
                MessageBox.Show("Please enter your email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            loggedUser = tbxLoginEmail.Text;

            if (!IsValueUniqe("Customers", "email", loggedUser))
            {
                
                lblUser.Text = loggedUser;
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                tbxLoginEmail.Clear(); // Clear the email field after successful login
            }
            else
            {
                // Email does not exist
                MessageBox.Show("Email not found. Please check your email or register.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            loggedUser = "";
            lblUser.Text = loggedUser;
        }

        private void btnProductSearch_Click(object sender, EventArgs e)
        {
            //tar bort onödigt spaces, 0 osv
            string searchText = tbxSearchProduct.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Please enter a search term.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    // SQL query to search in multiple columns
                    //bryr sig inte om case sensetivity
                    // ILIKE - Case-insensitive search for text.
                    // TEXT ILIKE - Converts numbers to text so they can be searched like words.
                    string query = @"SELECT product_id, name, base_price, quantity 
                             FROM Products 
                             WHERE code ILIKE @search 
                                OR name ILIKE @search 
                                OR supplier_id::TEXT ILIKE @search 
                                OR base_price::TEXT ILIKE @search";

                    using (var cmd = new NpgsqlCommand(query, _conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                listBoxMain.Items.Clear(); // Clear previous search results

                                while (reader.Read())
                                {
                                    string productInfo = $"ID: {reader["product_id"]}, Name: {reader["name"]}, " +
                                                         $"Price: {reader["base_price"]}, Stock: {reader["quantity"]}";

                                    listBoxMain.Items.Add(productInfo);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No products found matching the search criteria.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error searching for products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No open connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSadmin_Click(object sender, EventArgs e)
        {
            //tar bort onödigt spaces, 0 osv
            string searchText = tbxSadmin.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Please enter a search term.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    // SQL query to search in multiple columns
                    //bryr sig inte om case sensetivity
                    // ILIKE - Case-insensitive search for text.
                    // TEXT ILIKE - Converts numbers to text so they can be searched like words.
                    string query = @"SELECT product_id, name, base_price, quantity 
                             FROM Products 
                             WHERE code ILIKE @search 
                                OR name ILIKE @search 
                                OR supplier_id::TEXT ILIKE @search 
                                OR base_price::TEXT ILIKE @search";

                    using (var cmd = new NpgsqlCommand(query, _conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                listBoxMain.Items.Clear(); // Clear previous search results

                                while (reader.Read())
                                {
                                    string productInfo = $"ID: {reader["product_id"]}, Name: {reader["name"]}, " +
                                                         $"Price: {reader["base_price"]}, Stock: {reader["quantity"]}";

                                    listBoxMain.Items.Add(productInfo);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No products found matching the search criteria.", "Search Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error searching for products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No open connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxAddprodId.Text) || string.IsNullOrWhiteSpace(tbxAddAmount.Text))
            {
                MessageBox.Show("Please enter both Product ID and Amount.");
                return;
            }


            // Konvertera inputs
            if (!int.TryParse(tbxAddprodId.Text, out int productId))
            {
                MessageBox.Show("Product ID must be a valid number.");
                return;
            }

            if (!int.TryParse(tbxAddAmount.Text, out int amount) || amount <= 0)
            {
                MessageBox.Show("Amount must be a valid positive number.");
                return;
            }

            //kollar om product id't finns
            if (IsValueUniqueNumber("Products", "product_id", tbxAddprodId.Text))
            {
                MessageBox.Show("Product ID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    // hitta customer_id från logged user
                    string getCustomerIdQuery = "SELECT customer_id FROM Customers WHERE email = @loggedUser";
                    int customerId = -1;

                    using (var cmd = new NpgsqlCommand(getCustomerIdQuery, _conn))
                    {
                        cmd.Parameters.AddWithValue("@loggedUser", loggedUser);
                        object result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            MessageBox.Show("No customer found with this email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                        customerId = Convert.ToInt32(result);
                    }

                    // Check if there is an open order for the customer
                    string getOrderQuery = "SELECT order_id FROM Orders WHERE customer_id = @customer_id AND confirmed = FALSE";
                    int orderId = -1;

                    using (var cmd = new NpgsqlCommand(getOrderQuery, _conn))
                    {
                        cmd.Parameters.AddWithValue("@customer_id", customerId);
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            orderId = Convert.ToInt32(result);
                        }
                    }

                    // If no open order, create a new order
                    if (orderId == -1)
                    {
                        string createOrderQuery = "INSERT INTO Orders (customer_id, total_price, confirmed) VALUES (@customer_id, 0, FALSE) RETURNING order_id";
                        using (var cmd = new NpgsqlCommand(createOrderQuery, _conn))
                        {
                            cmd.Parameters.AddWithValue("@customer_id", customerId);
                            orderId = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }

                    // Get product information: stock and price
                    string getProductInfoQuery = "SELECT quantity, base_price FROM Products WHERE product_id = @product_id";
                    int stock = 0;
                    decimal productPrice = 0;

                    using (var cmd = new NpgsqlCommand(getProductInfoQuery, _conn))
                    {
                        cmd.Parameters.AddWithValue("@product_id", productId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                stock = reader.GetInt32(0);
                                productPrice = reader.GetDecimal(1);
                            }
                        }
                    }

                    // Ensure there is enough stock
                    if (amount > stock)
                    {
                        MessageBox.Show("Not enough stock available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Add product to the order
                    string insertOrderItemQuery = "INSERT INTO Order_Items (order_id, product_id, quantity, price) VALUES (@order_id, @product_id, @quantity, @price)";
                    using (var cmd = new NpgsqlCommand(insertOrderItemQuery, _conn))
                    {
                        cmd.Parameters.AddWithValue("@order_id", orderId);
                        cmd.Parameters.AddWithValue("@product_id", productId);
                        cmd.Parameters.AddWithValue("@quantity", amount);
                        cmd.Parameters.AddWithValue("@price", productPrice * amount);
                        cmd.ExecuteNonQuery();
                    }

                    // Update the total price of the order
                    string updateTotalPriceQuery = "UPDATE Orders SET total_price = total_price + @added_price WHERE order_id = @order_id";
                    using (var cmd = new NpgsqlCommand(updateTotalPriceQuery, _conn))
                    {
                        cmd.Parameters.AddWithValue("@added_price", productPrice * amount);
                        cmd.Parameters.AddWithValue("@order_id", orderId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Item added to the order successfully!");

                    // Clear the textboxes
                    tbxAddprodId.Clear();
                    tbxAddAmount.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding item to order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No open connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnshowCart_Click(object sender, EventArgs e)
        {
            // Ensure the user is logged in
            if (string.IsNullOrWhiteSpace(loggedUser))
            {
                MessageBox.Show("Please log in first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the customer ID for the logged-in user
            int customerId = -1;
            string getCustomerIdQuery = "SELECT customer_id FROM Customers WHERE email = @loggedUser";

            try
            {
                using (var cmd = new NpgsqlCommand(getCustomerIdQuery, _conn))
                {
                    cmd.Parameters.AddWithValue("@loggedUser", loggedUser);
                    object result = cmd.ExecuteScalar();
                    if (result == null)
                    {
                        MessageBox.Show("No customer found with this email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    customerId = Convert.ToInt32(result);
                }

                // Check if there is an open (unconfirmed) order for the customer
                string getOrderQuery = "SELECT order_id FROM Orders WHERE customer_id = @customer_id AND confirmed = FALSE";
                int orderId = -1;

                using (var cmd = new NpgsqlCommand(getOrderQuery, _conn))
                {
                    cmd.Parameters.AddWithValue("@customer_id", customerId);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        orderId = Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("You do not have any unconfirmed orders.", "Cart is empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                // Fetch the order items for the order
                string getOrderItemsQuery = @"
            SELECT oi.order_item_id, p.name, oi.quantity, oi.price
            FROM Order_Items oi
            JOIN Products p ON oi.product_id = p.product_id
            WHERE oi.order_id = @order_id";

                using (var cmd = new NpgsqlCommand(getOrderItemsQuery, _conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", orderId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        // Assuming you have a ListBox or DataGridView to show the order items
                        string displayText = "";
                        decimal totalPrice = 0;

                        while (reader.Read())
                        {
                            string productName = reader.GetString(1);
                            int quantity = reader.GetInt32(2);
                            decimal price = reader.GetDecimal(3);
                            decimal itemTotal = quantity * price;

                            // Add item details to displayText (you could also add this to a ListBox or DataGridView)
                            displayText += $"Product: {productName}\n" +
                                           $"Quantity: {quantity}\n" +
                                           $"Price: {price:C}\n" +
                                           $"Total: {itemTotal:C}\n\n";

                            totalPrice += itemTotal;  // Add item total to the overall total price
                        }

                        if (string.IsNullOrEmpty(displayText))
                        {
                            MessageBox.Show("Your cart is empty.", "No items", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        // Display the order items and the total price
                        displayText += $"Total Price: {totalPrice:C}";
                        MessageBox.Show(displayText, "Your Cart", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching cart details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
