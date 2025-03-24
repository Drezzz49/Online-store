namespace Online_store
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnFetch = new System.Windows.Forms.Button();
            this.listBoxMain = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnOrderItems = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnProductDiscount = new System.Windows.Forms.Button();
            this.btnDiscounts = new System.Windows.Forms.Button();
            this.btnProducts = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMakeAccount = new System.Windows.Forms.Button();
            this.tbxPhoneNumber = new System.Windows.Forms.TextBox();
            this.tbxCountry = new System.Windows.Forms.TextBox();
            this.tbxCity = new System.Windows.Forms.TextBox();
            this.tbxAddress = new System.Windows.Forms.TextBox();
            this.tbxEmail = new System.Windows.Forms.TextBox();
            this.tbxLastName = new System.Windows.Forms.TextBox();
            this.tbxFirstName = new System.Windows.Forms.TextBox();
            this.tbxPcode = new System.Windows.Forms.TextBox();
            this.tbxPname = new System.Windows.Forms.TextBox();
            this.tbxPbasePrice = new System.Windows.Forms.TextBox();
            this.tbxPquantity = new System.Windows.Forms.TextBox();
            this.tbxPsuppid = new System.Windows.Forms.TextBox();
            this.btnAddProduct = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(16, 465);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(112, 30);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open connection";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(16, 501);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 32);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close connection";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnFetch
            // 
            this.btnFetch.Location = new System.Drawing.Point(196, 6);
            this.btnFetch.Name = "btnFetch";
            this.btnFetch.Size = new System.Drawing.Size(99, 44);
            this.btnFetch.TabIndex = 2;
            this.btnFetch.Text = "fetch all customers";
            this.btnFetch.UseVisualStyleBackColor = true;
            this.btnFetch.Click += new System.EventHandler(this.btnFetch_Click);
            // 
            // listBoxMain
            // 
            this.listBoxMain.FormattingEnabled = true;
            this.listBoxMain.Location = new System.Drawing.Point(466, 34);
            this.listBoxMain.Name = "listBoxMain";
            this.listBoxMain.Size = new System.Drawing.Size(348, 420);
            this.listBoxMain.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(448, 447);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnOrderItems);
            this.tabPage1.Controls.Add(this.btnOrders);
            this.tabPage1.Controls.Add(this.btnProductDiscount);
            this.tabPage1.Controls.Add(this.btnDiscounts);
            this.tabPage1.Controls.Add(this.btnProducts);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btnFetch);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(440, 421);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ADMIN";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnOrderItems
            // 
            this.btnOrderItems.Location = new System.Drawing.Point(196, 57);
            this.btnOrderItems.Name = "btnOrderItems";
            this.btnOrderItems.Size = new System.Drawing.Size(85, 42);
            this.btnOrderItems.TabIndex = 8;
            this.btnOrderItems.Text = "fetch all order items";
            this.btnOrderItems.UseVisualStyleBackColor = true;
            this.btnOrderItems.Click += new System.EventHandler(this.btnOrderItems_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Location = new System.Drawing.Point(301, 8);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(99, 42);
            this.btnOrders.TabIndex = 7;
            this.btnOrders.Text = "fetch all orders";
            this.btnOrders.UseVisualStyleBackColor = true;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnProductDiscount
            // 
            this.btnProductDiscount.Location = new System.Drawing.Point(98, 57);
            this.btnProductDiscount.Name = "btnProductDiscount";
            this.btnProductDiscount.Size = new System.Drawing.Size(92, 42);
            this.btnProductDiscount.TabIndex = 6;
            this.btnProductDiscount.Text = "fetch all product discounts";
            this.btnProductDiscount.UseVisualStyleBackColor = true;
            this.btnProductDiscount.Click += new System.EventHandler(this.btnProductDiscount_Click);
            // 
            // btnDiscounts
            // 
            this.btnDiscounts.Location = new System.Drawing.Point(6, 56);
            this.btnDiscounts.Name = "btnDiscounts";
            this.btnDiscounts.Size = new System.Drawing.Size(86, 43);
            this.btnDiscounts.TabIndex = 5;
            this.btnDiscounts.Text = "fetch all discounts";
            this.btnDiscounts.UseVisualStyleBackColor = true;
            this.btnDiscounts.Click += new System.EventHandler(this.btnDiscounts_Click);
            // 
            // btnProducts
            // 
            this.btnProducts.Location = new System.Drawing.Point(6, 6);
            this.btnProducts.Name = "btnProducts";
            this.btnProducts.Size = new System.Drawing.Size(86, 44);
            this.btnProducts.TabIndex = 4;
            this.btnProducts.Text = "fetch all products";
            this.btnProducts.UseVisualStyleBackColor = true;
            this.btnProducts.Click += new System.EventHandler(this.btnProducts_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(98, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 44);
            this.button1.TabIndex = 3;
            this.button1.Text = "fetch all suppliers";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox2);
            this.tabPage4.Controls.Add(this.groupBox1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(440, 421);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "ADMIN EDITOR";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.btnAddProduct);
            this.groupBox2.Controls.Add(this.tbxPsuppid);
            this.groupBox2.Controls.Add(this.tbxPquantity);
            this.groupBox2.Controls.Add(this.tbxPbasePrice);
            this.groupBox2.Controls.Add(this.tbxPname);
            this.groupBox2.Controls.Add(this.tbxPcode);
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 189);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Add product";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(4, 198);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(294, 190);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add supplier";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(440, 421);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "USER";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.label4);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.btnMakeAccount);
            this.tabPage3.Controls.Add(this.tbxPhoneNumber);
            this.tabPage3.Controls.Add(this.tbxCountry);
            this.tabPage3.Controls.Add(this.tbxCity);
            this.tabPage3.Controls.Add(this.tbxAddress);
            this.tabPage3.Controls.Add(this.tbxEmail);
            this.tabPage3.Controls.Add(this.tbxLastName);
            this.tabPage3.Controls.Add(this.tbxFirstName);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(440, 421);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "NEW COSTUMER";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(199, 181);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "123-123-1234";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(199, 155);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(22, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "UK";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(199, 129);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(43, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "London";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(199, 103);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "12 Cherry st";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(197, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(98, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "aliceW@gmail.com";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(197, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Willams";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(198, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(30, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Alice";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(213, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Examples:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 178);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Phone Number:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Country:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "City:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Email:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Last Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "First Name:";
            // 
            // btnMakeAccount
            // 
            this.btnMakeAccount.Location = new System.Drawing.Point(8, 201);
            this.btnMakeAccount.Name = "btnMakeAccount";
            this.btnMakeAccount.Size = new System.Drawing.Size(126, 34);
            this.btnMakeAccount.TabIndex = 7;
            this.btnMakeAccount.Text = "Make Account";
            this.btnMakeAccount.UseVisualStyleBackColor = true;
            this.btnMakeAccount.Click += new System.EventHandler(this.btnMakeAccount_Click);
            // 
            // tbxPhoneNumber
            // 
            this.tbxPhoneNumber.Location = new System.Drawing.Point(92, 175);
            this.tbxPhoneNumber.Name = "tbxPhoneNumber";
            this.tbxPhoneNumber.Size = new System.Drawing.Size(100, 20);
            this.tbxPhoneNumber.TabIndex = 6;
            // 
            // tbxCountry
            // 
            this.tbxCountry.Location = new System.Drawing.Point(92, 149);
            this.tbxCountry.Name = "tbxCountry";
            this.tbxCountry.Size = new System.Drawing.Size(100, 20);
            this.tbxCountry.TabIndex = 5;
            // 
            // tbxCity
            // 
            this.tbxCity.Location = new System.Drawing.Point(92, 123);
            this.tbxCity.Name = "tbxCity";
            this.tbxCity.Size = new System.Drawing.Size(100, 20);
            this.tbxCity.TabIndex = 4;
            // 
            // tbxAddress
            // 
            this.tbxAddress.Location = new System.Drawing.Point(92, 97);
            this.tbxAddress.Name = "tbxAddress";
            this.tbxAddress.Size = new System.Drawing.Size(100, 20);
            this.tbxAddress.TabIndex = 3;
            // 
            // tbxEmail
            // 
            this.tbxEmail.Location = new System.Drawing.Point(92, 71);
            this.tbxEmail.Name = "tbxEmail";
            this.tbxEmail.Size = new System.Drawing.Size(100, 20);
            this.tbxEmail.TabIndex = 2;
            // 
            // tbxLastName
            // 
            this.tbxLastName.Location = new System.Drawing.Point(92, 45);
            this.tbxLastName.Name = "tbxLastName";
            this.tbxLastName.Size = new System.Drawing.Size(100, 20);
            this.tbxLastName.TabIndex = 1;
            // 
            // tbxFirstName
            // 
            this.tbxFirstName.Location = new System.Drawing.Point(92, 19);
            this.tbxFirstName.Name = "tbxFirstName";
            this.tbxFirstName.Size = new System.Drawing.Size(100, 20);
            this.tbxFirstName.TabIndex = 0;
            // 
            // tbxPcode
            // 
            this.tbxPcode.Location = new System.Drawing.Point(66, 19);
            this.tbxPcode.Name = "tbxPcode";
            this.tbxPcode.Size = new System.Drawing.Size(100, 20);
            this.tbxPcode.TabIndex = 0;
            // 
            // tbxPname
            // 
            this.tbxPname.Location = new System.Drawing.Point(66, 45);
            this.tbxPname.Name = "tbxPname";
            this.tbxPname.Size = new System.Drawing.Size(100, 20);
            this.tbxPname.TabIndex = 1;
            // 
            // tbxPbasePrice
            // 
            this.tbxPbasePrice.Location = new System.Drawing.Point(66, 71);
            this.tbxPbasePrice.Name = "tbxPbasePrice";
            this.tbxPbasePrice.Size = new System.Drawing.Size(100, 20);
            this.tbxPbasePrice.TabIndex = 2;
            // 
            // tbxPquantity
            // 
            this.tbxPquantity.Location = new System.Drawing.Point(66, 97);
            this.tbxPquantity.Name = "tbxPquantity";
            this.tbxPquantity.Size = new System.Drawing.Size(100, 20);
            this.tbxPquantity.TabIndex = 3;
            // 
            // tbxPsuppid
            // 
            this.tbxPsuppid.Location = new System.Drawing.Point(66, 123);
            this.tbxPsuppid.Name = "tbxPsuppid";
            this.tbxPsuppid.Size = new System.Drawing.Size(100, 20);
            this.tbxPsuppid.TabIndex = 4;
            // 
            // btnAddProduct
            // 
            this.btnAddProduct.Location = new System.Drawing.Point(7, 155);
            this.btnAddProduct.Name = "btnAddProduct";
            this.btnAddProduct.Size = new System.Drawing.Size(84, 25);
            this.btnAddProduct.TabIndex = 5;
            this.btnAddProduct.Text = "Add product";
            this.btnAddProduct.UseVisualStyleBackColor = true;
            this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 13);
            this.label16.TabIndex = 6;
            this.label16.Text = "code:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 51);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(36, 13);
            this.label17.TabIndex = 7;
            this.label17.Text = "name:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 78);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 13);
            this.label18.TabIndex = 8;
            this.label18.Text = "base price:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(7, 104);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 13);
            this.label19.TabIndex = 9;
            this.label19.Text = "quantity:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 130);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(57, 13);
            this.label20.TabIndex = 10;
            this.label20.Text = "supplier id:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 562);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.listBoxMain);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Online store aq3187";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnFetch;
        private System.Windows.Forms.ListBox listBoxMain;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMakeAccount;
        private System.Windows.Forms.TextBox tbxPhoneNumber;
        private System.Windows.Forms.TextBox tbxCountry;
        private System.Windows.Forms.TextBox tbxCity;
        private System.Windows.Forms.TextBox tbxAddress;
        private System.Windows.Forms.TextBox tbxEmail;
        private System.Windows.Forms.TextBox tbxLastName;
        private System.Windows.Forms.TextBox tbxFirstName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnProductDiscount;
        private System.Windows.Forms.Button btnDiscounts;
        private System.Windows.Forms.Button btnProducts;
        private System.Windows.Forms.Button btnOrderItems;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbxPbasePrice;
        private System.Windows.Forms.TextBox tbxPname;
        private System.Windows.Forms.TextBox tbxPcode;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.TextBox tbxPsuppid;
        private System.Windows.Forms.TextBox tbxPquantity;
    }
}

