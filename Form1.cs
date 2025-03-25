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
                    string query = "SELECT * FROM Customers";
                    // hämta allt från customers
                    using (var cmd = new NpgsqlCommand(query, _conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        listBoxMain.Items.Clear();

                        while (reader.Read())
                        {
                            string customerInfo = $"c_id:{reader["customer_id"]}, {reader["first_name"]}, {reader["last_name"]}, " +
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
                    string query = "SELECT * FROM Suppliers";
                    // hämta allt från suppliers
                    using (var cmd = new NpgsqlCommand(query, _conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        listBoxMain.Items.Clear();

                        while (reader.Read())
                        {
                            string customerInfo = $"s_id:{reader["supplier_id"]}, {reader["name"]}, {reader["phone_number"]}, {reader["address"]}";
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
                    string query = "SELECT * FROM Products WHERE is_deleted = FALSE;";
                    // hämta allt från producs som inte är deleted
                    using (var cmd = new NpgsqlCommand(query, _conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        listBoxMain.Items.Clear();

                        while (reader.Read())
                        {
                            string customerInfo = $"id:{reader["product_id"]}, code:{reader["code"]}, {reader["name"]}, {reader["base_price"]}{"$"}, {reader["quantity"]}x" +
                                $",  s_id{reader["supplier_id"]}";
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
                    string query = "SELECT * FROM Discounts";
                    // hämta allt från discounts

                    using (var cmd = new NpgsqlCommand(query, _conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        listBoxMain.Items.Clear();

                        while (reader.Read())
                        {
                            string customerInfo = $"d_id:{reader["discount_id"]}, {reader["discount_code"]}, {reader["percentage"]}, {reader["reason"]}";
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
                    string query = @"
            SELECT pd.product_id, pd.discount_id, pd.start_date, pd.end_date, 
                   p.base_price, d.percentage,
                   (p.base_price * (1 - d.percentage / 100.0)) AS new_price
            FROM Product_Discounts pd
            JOIN Products p ON pd.product_id = p.product_id
            JOIN Discounts d ON pd.discount_id = d.discount_id";
                    // Hämtar information om produktens rabatter från Product_Discounts-tabellen
                    // Kopplar samman Product_Discounts, Products och Discounts-tabellerna via JOIN
                    // Beräknar det nya priset genom att applicera rabatten på produktens baspris
                    // Använder formeln (p.base_price * (1 - d.percentage / 100.0)) för att räkna ut det rabatterade priset


                    using (var cmd = new NpgsqlCommand(query, _conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        listBoxMain.Items.Clear();

                        while (reader.Read())
                        {
                            // Read values from database
                            int productId = reader.GetInt32(reader.GetOrdinal("product_id"));
                            int discountId = reader.GetInt32(reader.GetOrdinal("discount_id"));
                            DateTime startDate = reader.GetDateTime(reader.GetOrdinal("start_date"));
                            DateTime endDate = reader.GetDateTime(reader.GetOrdinal("end_date"));
                            decimal basePrice = reader.GetDecimal(reader.GetOrdinal("base_price"));
                            decimal discountPercentage = reader.GetDecimal(reader.GetOrdinal("percentage"));
                            decimal newPrice = reader.GetDecimal(reader.GetOrdinal("new_price"));

                            // Add to ListBox
                            string productDiscountInfo = $"p_id:{productId}, d_id:{discountId}, " +
                                                         $"{startDate.ToShortDateString()}-{endDate.ToShortDateString()}, " +
                                                         $"Old-P: {basePrice:C}, Discount: {discountPercentage}%, New-P: {newPrice:C}";

                            listBoxMain.Items.Add(productDiscountInfo);
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
                    string query = "SELECT * FROM Orders";  
                    // hämta allt från orders
                    using (var cmd = new NpgsqlCommand(query, _conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        listBoxMain.Items.Clear();

                        while (reader.Read())
                        {
                            string customerInfo = $"ID:{reader["order_id"]}, C_ID:{reader["customer_id"]}, {reader["order_date"]}, {reader["total_price"]}{"$"}" +
                                $", A_confirmed:{reader["confirmed"]}, C_final:{reader["pending_confirmation"]}, cancelled:{reader["cancelled"]}";
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
                    string query = "SELECT * FROM Order_Items";  
                    // hämta allt från order_items

                    using (var cmd = new NpgsqlCommand(query, _conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        listBoxMain.Items.Clear();  // Tömmer listan innan nya data läggs till

                        while (reader.Read())
                        {
                            // Lägg till information från varje rad i ListBox
                            string customerInfo = $"oi_id:{reader["order_item_id"]}, order_id:{reader["order_id"]}, p_id:{reader["product_id"]}, ammount:{reader["quantity"]}" +
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
                    //skickar in en ny kund med användarens valda termer
                    using (var cmd = new NpgsqlCommand(query, _conn))
                    {
                        cmd.Parameters.AddWithValue("@first_name", tbxFirstName.Text);
                        cmd.Parameters.AddWithValue("@last_name", tbxLastName.Text);
                        cmd.Parameters.AddWithValue("@email", tbxEmail.Text);
                        cmd.Parameters.AddWithValue("@address", tbxAddress.Text);
                        cmd.Parameters.AddWithValue("@city", tbxCity.Text);
                        cmd.Parameters.AddWithValue("@country", tbxCountry.Text);
                        cmd.Parameters.AddWithValue("@phone_number", tbxPhoneNumber.Text);

                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Account created successfully!");

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
                    //skickar in en ny product med användarens valda termer

                    using (var cmd = new NpgsqlCommand(query, _conn))
                    {
                        cmd.Parameters.AddWithValue("@code", tbxPcode.Text);
                        cmd.Parameters.AddWithValue("@name", tbxPname.Text);
                        cmd.Parameters.AddWithValue("@base_price", basePrice);
                        cmd.Parameters.AddWithValue("@quantity", quantity);
                        cmd.Parameters.AddWithValue("@supplier_id", productSupplierId);
                        

                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Product added successfully!");

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
                string query = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @value";
                //hämta allt från valt tablename där collumnamet är det valda collumnamnet

                using (var cmd = new NpgsqlCommand(query, _conn))
                {

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
                return false; 
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
                //hämta allt från valt tablename där collumnamet är det valda collumnamnet

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
                    //skickar in datan som avändren skrivit i suppliers tablet

                    using (var cmd = new NpgsqlCommand(query, _conn))
                    {
                        cmd.Parameters.AddWithValue("@name", tbxSname.Text);
                        cmd.Parameters.AddWithValue("@phone_number", tbxSphone.Text);
                        cmd.Parameters.AddWithValue("@address", tbxSaddress.Text);

                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("Supplier added successfully!");

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

        //transaction ligger under denna:
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
                    // Start the transaction
                    using (var transaction = _conn.BeginTransaction())
                    {
                        // Create a command to update the quantity
                        string updateQuery = "UPDATE Products SET quantity = @quantity WHERE product_id = @product_id";

                        using (var cmd = new NpgsqlCommand(updateQuery, _conn, transaction))
                        {
                            // Add parameters to prevent SQL injection
                            cmd.Parameters.AddWithValue("@quantity", newQuantity);
                            cmd.Parameters.AddWithValue("@product_id", productId);

                            // Execute the command
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                // Commit the transaction if successful
                                transaction.Commit();
                                MessageBox.Show("Stock quantity updated successfully!");
                            }
                            else
                            {
                                // Rollback the transaction if the update fails
                                transaction.Rollback();
                                MessageBox.Show("Failed to update stock quantity. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }

                        // Clear the textboxes after successful update
                        tbxEditProductid.Clear();
                        tbxEditNewQuantity.Clear();
                    }
                }
                catch (Exception ex)
                {
                    // If an error occurs, roll back the transaction
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

            loggedUser = tbxLoginEmail.Text;
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
                    string query = @"
                SELECT p.product_id, p.name, p.base_price, p.quantity, 
                       d.discount_code, d.percentage AS discount_percentage
                FROM Products p
                LEFT JOIN Product_Discounts pd ON p.product_id = pd.product_id
                LEFT JOIN Discounts d ON pd.discount_id = d.discount_id 
                    AND CURRENT_DATE BETWEEN pd.start_date AND pd.end_date
                WHERE (p.code ILIKE @search 
                   OR p.name ILIKE @search 
                   OR p.supplier_id::TEXT ILIKE @search 
                   OR p.base_price::TEXT ILIKE @search)
                AND p.is_deleted = FALSE";
                    // Hämtar produktinformation från Products-tabellen
                    // Använder LEFT JOIN för att koppla ihop tabellerna för att kunna nå värden som söks
                    // Rabattens giltighetsperiod filtreras med CURRENT_DATE
                    // WHERE-klausulen gör en sökning baserat på användarens sökterm
                    // Sökningen görs på med ILIKE för case-insensitive matchning
                    // p.is_deleted = FALSE ser till att endast produkter som inte är raderade inkluderas


                    using (var cmd = new NpgsqlCommand(query, _conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                listBoxMain.Items.Clear();

                                while (reader.Read())
                                {
                                    string productInfo = $"ID: {reader["product_id"]}, Name: {reader["name"]}, " +
                                                 $"Price: {reader["base_price"]}, Stock: {reader["quantity"]}";

                                    // Check if a discount is applied
                                    if (reader["discount_code"] != DBNull.Value)
                                    {
                                        productInfo += $", Discount: {reader["discount_code"]} ({reader["discount_percentage"]}% off)";
                                    }

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

                    string query = @"
                SELECT p.product_id, p.name, p.base_price, p.quantity, 
                       d.discount_code, d.percentage AS discount_percentage
                FROM Products p
                LEFT JOIN Product_Discounts pd ON p.product_id = pd.product_id
                LEFT JOIN Discounts d ON pd.discount_id = d.discount_id 
                    AND CURRENT_DATE BETWEEN pd.start_date AND pd.end_date
                WHERE (p.code ILIKE @search 
                   OR p.name ILIKE @search 
                   OR p.supplier_id::TEXT ILIKE @search 
                   OR p.base_price::TEXT ILIKE @search)
                AND p.is_deleted = FALSE;";
                    // Hämtar produktinformation från Products-tabellen
                    // Använder LEFT JOIN för att koppla tabeller för värden som söks
                    // kollar att endast aktiva rabatter (giltiga enligt dagens datum) hämtas
                    // söker i produktens kod, namn, leverantörs-ID eller baspris baserat på användarens sökterm
                    // Sökningen använder ILIKE för att tillåta case-insensitiv matchning
                    // p.is_deleted = FALSE ser till att endast produkter som inte är bortagna kommer med i resultatet


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

                                    // Check if a discount is applied
                                    if (reader["discount_code"] != DBNull.Value)
                                    {
                                        productInfo += $", Discount: {reader["discount_code"]} ({reader["discount_percentage"]}% off)";
                                    }

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
                    // hämtar custimer_id baserat på den inloggade mail-adressen
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

                    
                    string getOrderQuery = "SELECT order_id FROM Orders WHERE customer_id = @customer_id AND confirmed = FALSE";
                    // kollar om dett finns en öppen order för den inloggade användren
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

                    // om det inte finns en öppen order som gör vi en ny
                    if (orderId == -1)
                    {
                        string createOrderQuery = "INSERT INTO Orders (customer_id, total_price, confirmed) VALUES (@customer_id, 0, FALSE) RETURNING order_id";
                        //gör en ny order för den inloggade användarens id
                        using (var cmd = new NpgsqlCommand(createOrderQuery, _conn))
                        {
                            cmd.Parameters.AddWithValue("@customer_id", customerId);
                            orderId = Convert.ToInt32(cmd.ExecuteScalar());
                        }
                    }

                    
                    string getProductInfoQuery = "SELECT quantity, base_price FROM Products WHERE product_id = @product_id";
                    // Hämtar mängd och pris från givet id
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

                    // kollar så det finns tillräckligt i lager
                    if (amount > stock)
                    {
                        MessageBox.Show("Not enough stock available.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }


                    string insertOrderItemQuery = "INSERT INTO Order_Items (order_id, product_id, quantity, price) VALUES (@order_id, @product_id, @quantity, @price)";
                    // lägger till ett föremål beroende på de angivna värdena
                    using (var cmd = new NpgsqlCommand(insertOrderItemQuery, _conn))
                    {
                        cmd.Parameters.AddWithValue("@order_id", orderId);
                        cmd.Parameters.AddWithValue("@product_id", productId);
                        cmd.Parameters.AddWithValue("@quantity", amount);
                        cmd.Parameters.AddWithValue("@price", productPrice * amount);
                        cmd.ExecuteNonQuery();
                    }


                    string updateTotalPriceQuery = "UPDATE Orders SET total_price = total_price + @added_price WHERE order_id = @order_id";
                    // Uppdaterar total_price för en specifik order genom att lägga till ett nytt belopp
                    // med bara på ordern med matchande order_id blir uppdaterad
                    using (var cmd = new NpgsqlCommand(updateTotalPriceQuery, _conn))
                    {
                        cmd.Parameters.AddWithValue("@added_price", productPrice * amount);
                        cmd.Parameters.AddWithValue("@order_id", orderId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Item added to the order successfully!");

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

            
            int customerId = -1;
            string getCustomerIdQuery = "SELECT customer_id FROM Customers WHERE email = @loggedUser";
            //Ta customer id baserat på inloggade mail addressen

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

                
                string getOrderQuery = "SELECT order_id FROM Orders WHERE customer_id = @customer_id AND confirmed = FALSE AND pending_confirmation = FALSE";
                //kollar om order_id som vi stoppat in har confirmed som flask och pending_confirmation som falsk
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


                string getOrderItemsQuery = @"
            SELECT oi.order_item_id, p.name, oi.quantity, oi.price
            FROM Order_Items oi
            JOIN Products p ON oi.product_id = p.product_id
            WHERE oi.order_id = @order_id";
                // Hämtar information om specifika orderrader baserat på order_id
                // Använder JOIN för att koppla ihop Order_Items-tabellen med Products-tabellen
                // filtrerar så att endast rader med order_id som vi skrev in returneras


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

        private void btnAllProducts_Click(object sender, EventArgs e)
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = @"
                SELECT p.product_id, p.name, p.base_price, p.quantity, 
                       d.discount_code, d.percentage AS discount_percentage
                FROM Products p
                LEFT JOIN Product_Discounts pd ON p.product_id = pd.product_id
                LEFT JOIN Discounts d ON pd.discount_id = d.discount_id 
                    AND CURRENT_DATE BETWEEN pd.start_date AND pd.end_date
                WHERE p.is_deleted = FALSE
                GROUP BY p.product_id, p.name, p.base_price, p.quantity, 
                         d.discount_code, d.percentage";
                    // Hämtar information om produkter, inklusive rabattdata från relaterade tabeller
                    // Använder LEFT JOIN för att inkludera alla produkter, även om de inte har någon rabatt
                    // Hämtar produktens ID, namn, baspris och kvantitet från Products-tabellen
                    // Hämtar rabattkod och rabattprocent från Discounts-tabellen via Product_Discounts-tabellen
                    // Kollar om den aktuella dagen (CURRENT_DATE) ligger mellan start- och slutdatum för rabatten
                    // Filtrerar bort borttagna produkter genom att kontrollera p.is_deleted = FALSE
                    // Grupperar resultatet baserat på produktens ID, namn, baspris, kvantitet, rabattkod och rabattprocent
                    // Detta gör att vi får en lista över alla produkter med eventuella aktuella rabatter



                    using (var cmd = new NpgsqlCommand(query, _conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            listBoxMain.Items.Clear(); // Clear previous results

                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string productInfo = $"ID: {reader["product_id"]}, Name: {reader["name"]}, " +
                                                         $"Price: {reader["base_price"]}, Stock: {reader["quantity"]}";

                                    // Check if a discount is applied
                                    if (reader["discount_code"] != DBNull.Value)
                                    {
                                        productInfo += $", Discount: {reader["discount_code"]} ({reader["discount_percentage"]}% off)";
                                    }
                                    else
                                    {
                                        productInfo += ", No discount";
                                    }

                                    // Add the product info to the ListBox
                                    listBoxMain.Items.Add(productInfo);
                                }
                            }
                            else
                            {
                                MessageBox.Show("No products found.", "No Products", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No open connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelProduct_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxDelProduct.Text))
            {
                MessageBox.Show("Please enter a valid product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int productId;
            if (!int.TryParse(tbxDelProduct.Text, out productId))
            {
                MessageBox.Show("Product ID must be a valid integer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult dialogResult = MessageBox.Show("Are you sure you want to mark this product as deleted?" +
                " This action cannot be undone.", "Confirm Deletion",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            
            if (dialogResult == DialogResult.Yes)
            {
                if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
                {
                    try
                    {
                        
                        string updateQuery = "UPDATE Products SET is_deleted = TRUE WHERE product_id = @productId";
                        //uppdaterar produktens's is_deleted column to TRUE (soft delete) på det angivna produkt id't

                        using (var cmd = new NpgsqlCommand(updateQuery, _conn))
                        {
                            cmd.Parameters.AddWithValue("@productId", productId);
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Product successfully marked as deleted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Product not found or already deleted.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error marking product as deleted: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No open connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                // If the user clicks "No"
                MessageBox.Show("Product deletion canceled.", "Cancellation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            tbxDelProduct.Clear();

        }

        private void btnAddDiscount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxAddDiscountName.Text) ||
                string.IsNullOrWhiteSpace(tbxAddDiscountPercentage.Text))
            {
                MessageBox.Show("Please fill in all required fields (Name and Percentage).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validera procent
            if (!decimal.TryParse(tbxAddDiscountPercentage.Text, out decimal discountPercentage) || discountPercentage < 0 || discountPercentage > 100)
            {
                MessageBox.Show("Please enter a valid discount percentage (0-100).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValueUniqe("Discounts", "discount_code", tbxAddDiscountName.Text))
            {
                // Om koden redan finns, visa ett meddelande och avbryt
                MessageBox.Show("The code is already in use.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string discountReason = tbxAddDiscountReason.Text.Trim(); // Can be empty

            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = "INSERT INTO Discounts (discount_code, percentage, reason) " +
                                   "VALUES (@discount_code, @percentage, @reason)";
                    // Sätter in en ny rabatt i Discounts-tabellen
                    // Hämtar discount_code, percentage och reason från de angivna parametrarna
                    


                    using (var cmd = new NpgsqlCommand(query, _conn))
                    {
                        cmd.Parameters.AddWithValue("@discount_code", tbxAddDiscountName.Text);
                        cmd.Parameters.AddWithValue("@percentage", discountPercentage);
                        cmd.Parameters.AddWithValue("@reason", string.IsNullOrEmpty(discountReason) ? (object)DBNull.Value : discountReason);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Discount added successfully!");

                    // Clear input fields
                    tbxAddDiscountName.Clear();
                    tbxAddDiscountPercentage.Clear();
                    tbxAddDiscountReason.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding discount: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No open connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnAddProductDiscount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbxAddProductDisProdid.Text) ||
                string.IsNullOrWhiteSpace(tbxAddProductDisDisId.Text) ||
                string.IsNullOrWhiteSpace(tbxAddProductStart.Text) ||
                string.IsNullOrWhiteSpace(tbxAddProductEnd.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate Product ID, kolla om det är ett nummer
            if (!int.TryParse(tbxAddProductDisProdid.Text, out int productId))
            {
                MessageBox.Show("Invalid Product ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate Discount ID, kolla om det är ett nummer
            if (!int.TryParse(tbxAddProductDisDisId.Text, out int discountId))
            {
                MessageBox.Show("Invalid Discount ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate Dates
            if (!DateTime.TryParse(tbxAddProductStart.Text, out DateTime startDate) ||
                !DateTime.TryParse(tbxAddProductEnd.Text, out DateTime endDate))
            {
                MessageBox.Show("Invalid date format. Please enter a valid start and end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (startDate > endDate)
            {
                MessageBox.Show("Start date must be before end date.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Check if Product ID exists
            if (IsValueUniqueNumber("Products", "product_id", tbxAddProductDisProdid.Text))
            {
                MessageBox.Show("The Product ID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if Discount ID exists
            if (IsValueUniqueNumber("Discounts", "discount_id", tbxAddProductDisDisId.Text))
            {
                MessageBox.Show("The Discount ID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // skicka in värdena som en ny kod på produkten
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = @"INSERT INTO Product_Discounts (product_id, discount_id, start_date, end_date) 
                             VALUES (@product_id, @discount_id, @start_date, @end_date)";
                    // Sätter in en ny rad i Product_Discounts-tabellen
                    // Hämtar product_id, discount_id, start_date och end_date från de angivna parametrarna
                   


                    using (var cmd = new NpgsqlCommand(query, _conn))
                    {
                        cmd.Parameters.AddWithValue("@product_id", productId);
                        cmd.Parameters.AddWithValue("@discount_id", discountId);
                        cmd.Parameters.AddWithValue("@start_date", startDate);
                        cmd.Parameters.AddWithValue("@end_date", endDate);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Product discount added successfully!");

                    tbxAddProductDisProdid.Clear();
                    tbxAddProductDisDisId.Clear();
                    tbxAddProductStart.Clear();
                    tbxAddProductEnd.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding product discount: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No open connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnYourOrders_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(loggedUser))
            {
                MessageBox.Show("No user is logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {

                    string query = @"
                SELECT o.order_id, o.confirmed,
                       p.name AS product_name, oi.quantity, oi.price, 
                       d.percentage AS discount
                FROM Orders o
                JOIN Customers c ON o.customer_id = c.customer_id
                JOIN Order_Items oi ON o.order_id = oi.order_id
                JOIN Products p ON oi.product_id = p.product_id
                LEFT JOIN Discounts d ON oi.discount_id = d.discount_id
                WHERE c.email = @loggedUser
                ORDER BY o.order_id DESC";
                    // Hämtar order_id och confirmed från Orders
                    // Hämtar produktens namn (product_name), quantity och price från Order_Items och Products
                    // Hämtar eventuell rabatt (discount) från Discounts
                    // Gör en JOIN mellan Orders, Customers, Order_Items, Products och Discounts för att kombinera all relevant data
                    // Använder LEFT JOIN för Discounts eftersom en order kan ha en rabatt eller inte
                    // Filtrerar så att endast ordrar från den inloggade kunden (email = @loggedUser) hämtas
                    // Sorterar resultaten efter order_id i fallande ordning, så de senaste ordrarna visas först

                    using (var cmd = new NpgsqlCommand(query, _conn))
                    {
                        cmd.Parameters.AddWithValue("@loggedUser", loggedUser);

                        using (var reader = cmd.ExecuteReader())
                        {
                            listBoxMain.Items.Clear();

                            if (!reader.HasRows)
                            {
                                listBoxMain.Items.Add("No orders found.");
                                return;
                            }

                            while (reader.Read())
                            {
                                int orderId = reader.GetInt32(reader.GetOrdinal("order_id"));
                                bool confirmed = reader.GetBoolean(reader.GetOrdinal("confirmed"));
                                string productName = reader.GetString(reader.GetOrdinal("product_name"));
                                int quantity = reader.GetInt32(reader.GetOrdinal("quantity"));
                                decimal price = reader.GetDecimal(reader.GetOrdinal("price"));
                                decimal? discount = reader.IsDBNull(reader.GetOrdinal("discount")) ? (decimal?)null : reader.GetDecimal(reader.GetOrdinal("discount"));

                                string discountText = discount.HasValue ? $"{discount.Value}%" : "No discount";

                                // Formatera confirmation status
                                string confirmationStatus = confirmed ? "Confirmed" : "Not Confirmed";

                                string orderInfo = $"ID: {orderId}, {confirmationStatus}, " +
                                                   $"{productName}, {quantity}x, " +
                                                   $"Price: {price:C}, Discount: {discountText}";

                                listBoxMain.Items.Add(orderInfo);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No open connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnFinalizeOrder_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(loggedUser))
            {
                MessageBox.Show("No user is logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    // Update the latest order to pending_confirmation = true
                    string query = @"
                UPDATE Orders
                SET pending_confirmation = TRUE
                WHERE customer_id = (SELECT customer_id FROM Customers WHERE email = @loggedUser)
                AND confirmed = FALSE
                RETURNING order_id";

                    using (var cmd = new NpgsqlCommand(query, _conn))
                    {
                        cmd.Parameters.AddWithValue("@loggedUser", loggedUser);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            MessageBox.Show($"Order {result} has been finalized! Waiting for admin confirmation.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No open order found to finalize.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error finalizing order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No open connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnConfirmOrders_Click(object sender, EventArgs e)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(tbxConfirmOrders.Text))
            {
                MessageBox.Show("Please enter an Order ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(tbxConfirmOrders.Text, out int orderId))
            {
                MessageBox.Show("Invalid Order ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if the order exists
            if (IsValueUniqueNumber("Orders", "order_id", tbxConfirmOrders.Text))
            {
                MessageBox.Show("Order ID does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



           
            string checkOrderQuery = "SELECT confirmed FROM Orders WHERE order_id = @order_id";
            //Kollar om ordern redan är "confirmed"
            try
            {
                using (var cmd = new NpgsqlCommand(checkOrderQuery, _conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", orderId);
                    object result = cmd.ExecuteScalar();

                    if (result != null && Convert.ToBoolean(result)) // If confirmed is true
                    {
                        MessageBox.Show("This order is already confirmed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }


                string updateQuery = "UPDATE Orders SET confirmed = TRUE WHERE order_id = @order_id";
                //uppdaterar confirmed värdet på det order id't som vi gav

                using (var cmd = new NpgsqlCommand(updateQuery, _conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", orderId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Order {orderId} has been confirmed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbxConfirmOrders.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Failed to confirm the order. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error confirming order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDelOrderCustomer_Click(object sender, EventArgs e)
        {
            // Ensure the user is logged in
            if (string.IsNullOrWhiteSpace(loggedUser))
            {
                MessageBox.Show("Please log in first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure the customer entered an Order ID
            if (string.IsNullOrWhiteSpace(tbxDelOrderCustomer.Text))
            {
                MessageBox.Show("Please enter an Order ID to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validate Order ID as a number
            if (!int.TryParse(tbxDelOrderCustomer.Text, out int orderId))
            {
                MessageBox.Show("Invalid Order ID format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            int customerId = -1;
            string getCustomerIdQuery = "SELECT customer_id FROM Customers WHERE email = @loggedUser";
            // hämtar customer ID för användaren som är inloggad

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

                
                string checkOrderQuery = @"
            SELECT o.order_id, o.confirmed, o.cancelled 
            FROM Orders o 
            WHERE o.order_id = @order_id AND o.customer_id = @customer_id";
                // hämtar order.order_id, order.confirmed och order.cancelled
                // men bara dom där order.order_id matchar det id't som vi skrev och och om det har användar idet som tillhör använderen

                using (var cmd = new NpgsqlCommand(checkOrderQuery, _conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", orderId);
                    cmd.Parameters.AddWithValue("@customer_id", customerId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("Order does not exist or does not belong to the logged-in customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        reader.Read(); // Read the data for the order
                        bool isConfirmed = reader.GetBoolean(reader.GetOrdinal("confirmed"));
                        bool isCancelled = reader.GetBoolean(reader.GetOrdinal("cancelled"));

                        // Check if the order is confirmed or already cancelled
                        if (isConfirmed)
                        {
                            MessageBox.Show("You cannot cancel a confirmed order.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (isCancelled)
                        {
                            MessageBox.Show("This order has already been canceled.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }

                
                string cancelOrderQuery = "UPDATE Orders SET cancelled = TRUE WHERE order_id = @order_id";
                // Uppdaterar orders kollumn cancelled till true
                // men bara där order_id matchar de vi skrev in

                using (var cmd = new NpgsqlCommand(cancelOrderQuery, _conn))
                {
                    cmd.Parameters.AddWithValue("@order_id", orderId);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"Order {orderId} has been canceled.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbxDelOrderCustomer.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Failed to cancel the order. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error canceling order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnshowAdmin_Click(object sender, EventArgs e)
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                try
                {
                    string query = @"
                SELECT
                    CAST(EXTRACT(YEAR FROM o.order_date) AS INT) AS year,
                    CAST(EXTRACT(MONTH FROM o.order_date) AS INT) AS month,
                    oi.product_id,
                    p.name AS product_name,
                    CAST(SUM(oi.quantity) AS INT) AS total_orders
                FROM
                    Orders o
                JOIN
                    Order_Items oi ON o.order_id = oi.order_id
                JOIN
                    Products p ON oi.product_id = p.product_id
                WHERE
                    o.confirmed = TRUE
                GROUP BY
                    CAST(EXTRACT(YEAR FROM o.order_date) AS INT),
                    CAST(EXTRACT(MONTH FROM o.order_date) AS INT),
                    oi.product_id,
                    p.name
                ORDER BY
                    year DESC, month DESC, total_orders DESC";

                    //tar ut åretr och månaden från varje beställning
                    //hämtar product_id och product_name
                    //räknar ut total_orders
                    //sätter ihopa orders, order_items och products
                    //where (bara ordrar som är confirmed)
                    //Vi grupperar all data efter år, månad, produkt-ID och produktnamn, så vi kan räkna samman hur många av varje produkt som sålts
                    //sortera så år är först och sedan månad

                    using (var cmd = new NpgsqlCommand(query, _conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            listBoxMain.Items.Clear();

                            if (!reader.HasRows)
                            {
                                listBoxMain.Items.Add("No orders found.");
                                return;
                            }

                            while (reader.Read())
                            {
                                int year = reader.GetInt32(reader.GetOrdinal("year"));
                                int month = reader.GetInt32(reader.GetOrdinal("month"));
                                string productName = reader.GetString(reader.GetOrdinal("product_name"));
                                int totalOrders = reader.GetInt32(reader.GetOrdinal("total_orders"));

                                string displayText = $"{year}-{month:D2}: {productName} - {totalOrders} orders";

                                listBoxMain.Items.Add(displayText);
                            }
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
