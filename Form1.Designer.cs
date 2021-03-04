namespace InvoicePrint
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label_invoiceno = new System.Windows.Forms.Label();
            this.label_date = new System.Windows.Forms.Label();
            this.txtbx_invoiceno = new System.Windows.Forms.TextBox();
            this.txtbx_date = new System.Windows.Forms.TextBox();
            this.btn_check = new System.Windows.Forms.Button();
            this.label_database = new System.Windows.Forms.Label();
            this.txtbx_database = new System.Windows.Forms.TextBox();
            this.btn_view = new System.Windows.Forms.Button();
            this.label_test = new System.Windows.Forms.Label();
            this.combx_shop = new System.Windows.Forms.ComboBox();
            this.label_shopname = new System.Windows.Forms.Label();
            this.txtbx_test = new System.Windows.Forms.TextBox();
            this.txtbox_csvcontent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbx_carrier = new System.Windows.Forms.TextBox();
            this.btn_print = new System.Windows.Forms.Button();
            this.btn_agprint = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbx_donate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtbx_agpinvoiceno = new System.Windows.Forms.TextBox();
            this.label_number = new System.Windows.Forms.Label();
            this.btn_setinno = new System.Windows.Forms.Button();
            this.txtbx_setinno = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtbx_agpdate = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtbx_agprandomno = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_invoiceno
            // 
            this.label_invoiceno.AutoSize = true;
            this.label_invoiceno.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_invoiceno.Location = new System.Drawing.Point(20, 63);
            this.label_invoiceno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_invoiceno.Name = "label_invoiceno";
            this.label_invoiceno.Size = new System.Drawing.Size(89, 19);
            this.label_invoiceno.TabIndex = 0;
            this.label_invoiceno.Text = "發票號碼";
            // 
            // label_date
            // 
            this.label_date.AutoSize = true;
            this.label_date.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_date.Location = new System.Drawing.Point(35, 100);
            this.label_date.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(49, 19);
            this.label_date.TabIndex = 1;
            this.label_date.Text = "日期";
            // 
            // txtbx_invoiceno
            // 
            this.txtbx_invoiceno.Location = new System.Drawing.Point(108, 63);
            this.txtbx_invoiceno.Margin = new System.Windows.Forms.Padding(2);
            this.txtbx_invoiceno.Name = "txtbx_invoiceno";
            this.txtbx_invoiceno.ReadOnly = true;
            this.txtbx_invoiceno.Size = new System.Drawing.Size(205, 22);
            this.txtbx_invoiceno.TabIndex = 2;
            // 
            // txtbx_date
            // 
            this.txtbx_date.Location = new System.Drawing.Point(108, 100);
            this.txtbx_date.Margin = new System.Windows.Forms.Padding(2);
            this.txtbx_date.Name = "txtbx_date";
            this.txtbx_date.ReadOnly = true;
            this.txtbx_date.Size = new System.Drawing.Size(205, 22);
            this.txtbx_date.TabIndex = 3;
            // 
            // btn_check
            // 
            this.btn_check.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_check.Location = new System.Drawing.Point(18, 389);
            this.btn_check.Margin = new System.Windows.Forms.Padding(2);
            this.btn_check.Name = "btn_check";
            this.btn_check.Size = new System.Drawing.Size(88, 33);
            this.btn_check.TabIndex = 4;
            this.btn_check.Text = "開立";
            this.btn_check.UseVisualStyleBackColor = true;
            this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
            // 
            // label_database
            // 
            this.label_database.AutoSize = true;
            this.label_database.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_database.Location = new System.Drawing.Point(24, 134);
            this.label_database.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_database.Name = "label_database";
            this.label_database.Size = new System.Drawing.Size(69, 19);
            this.label_database.TabIndex = 5;
            this.label_database.Text = "資料庫";
            // 
            // txtbx_database
            // 
            this.txtbx_database.Location = new System.Drawing.Point(108, 134);
            this.txtbx_database.Margin = new System.Windows.Forms.Padding(2);
            this.txtbx_database.Name = "txtbx_database";
            this.txtbx_database.ReadOnly = true;
            this.txtbx_database.Size = new System.Drawing.Size(205, 22);
            this.txtbx_database.TabIndex = 6;
            // 
            // btn_view
            // 
            this.btn_view.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_view.Location = new System.Drawing.Point(328, 128);
            this.btn_view.Margin = new System.Windows.Forms.Padding(2);
            this.btn_view.Name = "btn_view";
            this.btn_view.Size = new System.Drawing.Size(75, 31);
            this.btn_view.TabIndex = 7;
            this.btn_view.Text = "瀏覽";
            this.btn_view.UseVisualStyleBackColor = true;
            this.btn_view.Click += new System.EventHandler(this.btn_view_Click);
            // 
            // label_test
            // 
            this.label_test.AutoSize = true;
            this.label_test.Location = new System.Drawing.Point(743, 299);
            this.label_test.Name = "label_test";
            this.label_test.Size = new System.Drawing.Size(0, 12);
            this.label_test.TabIndex = 8;
            // 
            // combx_shop
            // 
            this.combx_shop.FormattingEnabled = true;
            this.combx_shop.Location = new System.Drawing.Point(112, 27);
            this.combx_shop.Name = "combx_shop";
            this.combx_shop.Size = new System.Drawing.Size(200, 20);
            this.combx_shop.TabIndex = 9;
            // 
            // label_shopname
            // 
            this.label_shopname.AutoSize = true;
            this.label_shopname.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label_shopname.Location = new System.Drawing.Point(20, 27);
            this.label_shopname.Name = "label_shopname";
            this.label_shopname.Size = new System.Drawing.Size(89, 19);
            this.label_shopname.TabIndex = 10;
            this.label_shopname.Text = "發票店名";
            // 
            // txtbx_test
            // 
            this.txtbx_test.Enabled = false;
            this.txtbx_test.Location = new System.Drawing.Point(328, 369);
            this.txtbx_test.Margin = new System.Windows.Forms.Padding(2);
            this.txtbx_test.Multiline = true;
            this.txtbx_test.Name = "txtbx_test";
            this.txtbx_test.Size = new System.Drawing.Size(404, 102);
            this.txtbx_test.TabIndex = 11;
            // 
            // txtbox_csvcontent
            // 
            this.txtbox_csvcontent.Location = new System.Drawing.Point(18, 273);
            this.txtbox_csvcontent.Multiline = true;
            this.txtbox_csvcontent.Name = "txtbox_csvcontent";
            this.txtbox_csvcontent.Size = new System.Drawing.Size(714, 91);
            this.txtbox_csvcontent.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(35, 164);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 19);
            this.label1.TabIndex = 13;
            this.label1.Text = "載具";
            // 
            // txtbx_carrier
            // 
            this.txtbx_carrier.Location = new System.Drawing.Point(108, 164);
            this.txtbx_carrier.Name = "txtbx_carrier";
            this.txtbx_carrier.Size = new System.Drawing.Size(205, 22);
            this.txtbx_carrier.TabIndex = 14;
            // 
            // btn_print
            // 
            this.btn_print.Location = new System.Drawing.Point(123, 389);
            this.btn_print.Name = "btn_print";
            this.btn_print.Size = new System.Drawing.Size(75, 23);
            this.btn_print.TabIndex = 15;
            this.btn_print.Text = "列印";
            this.btn_print.UseVisualStyleBackColor = true;
            this.btn_print.Click += new System.EventHandler(this.btn_print_Click);
            // 
            // btn_agprint
            // 
            this.btn_agprint.Location = new System.Drawing.Point(335, 73);
            this.btn_agprint.Name = "btn_agprint";
            this.btn_agprint.Size = new System.Drawing.Size(75, 23);
            this.btn_agprint.TabIndex = 16;
            this.btn_agprint.Text = "補印";
            this.btn_agprint.UseVisualStyleBackColor = true;
            this.btn_agprint.Click += new System.EventHandler(this.btn_agprint_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(227, 389);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 17;
            this.btn_cancel.Text = "作廢";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(24, 198);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "捐贈碼";
            // 
            // txtbx_donate
            // 
            this.txtbx_donate.Location = new System.Drawing.Point(108, 199);
            this.txtbx_donate.Name = "txtbx_donate";
            this.txtbx_donate.Size = new System.Drawing.Size(205, 22);
            this.txtbx_donate.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(5, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 19);
            this.label3.TabIndex = 20;
            this.label3.Text = "發票號碼";
            // 
            // txtbx_agpinvoiceno
            // 
            this.txtbx_agpinvoiceno.Location = new System.Drawing.Point(122, 15);
            this.txtbx_agpinvoiceno.Name = "txtbx_agpinvoiceno";
            this.txtbx_agpinvoiceno.Size = new System.Drawing.Size(205, 22);
            this.txtbx_agpinvoiceno.TabIndex = 21;
            // 
            // label_number
            // 
            this.label_number.AutoSize = true;
            this.label_number.Location = new System.Drawing.Point(26, 9);
            this.label_number.Name = "label_number";
            this.label_number.Size = new System.Drawing.Size(0, 12);
            this.label_number.TabIndex = 22;
            // 
            // btn_setinno
            // 
            this.btn_setinno.Location = new System.Drawing.Point(314, 226);
            this.btn_setinno.Name = "btn_setinno";
            this.btn_setinno.Size = new System.Drawing.Size(75, 23);
            this.btn_setinno.TabIndex = 23;
            this.btn_setinno.Text = "設定發票號碼";
            this.btn_setinno.UseVisualStyleBackColor = true;
            this.btn_setinno.Click += new System.EventHandler(this.btn_setinno_Click);
            // 
            // txtbx_setinno
            // 
            this.txtbx_setinno.Location = new System.Drawing.Point(108, 227);
            this.txtbx_setinno.Name = "txtbx_setinno";
            this.txtbx_setinno.Size = new System.Drawing.Size(200, 22);
            this.txtbx_setinno.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(5, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 19);
            this.label4.TabIndex = 25;
            this.label4.Text = "發票日期";
            // 
            // txtbx_agpdate
            // 
            this.txtbx_agpdate.Location = new System.Drawing.Point(122, 43);
            this.txtbx_agpdate.Name = "txtbx_agpdate";
            this.txtbx_agpdate.Size = new System.Drawing.Size(205, 22);
            this.txtbx_agpdate.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(5, 74);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 19);
            this.label5.TabIndex = 27;
            this.label5.Text = "發票隨機碼";
            // 
            // txtbx_agprandomno
            // 
            this.txtbx_agprandomno.Location = new System.Drawing.Point(119, 71);
            this.txtbx_agprandomno.Name = "txtbx_agprandomno";
            this.txtbx_agprandomno.Size = new System.Drawing.Size(210, 22);
            this.txtbx_agprandomno.TabIndex = 28;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtbx_agprandomno);
            this.groupBox1.Controls.Add(this.txtbx_agpinvoiceno);
            this.groupBox1.Controls.Add(this.btn_agprint);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtbx_agpdate);
            this.groupBox1.Location = new System.Drawing.Point(418, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 103);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "補印功能(尚未測試)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 482);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtbx_setinno);
            this.Controls.Add(this.btn_setinno);
            this.Controls.Add(this.label_number);
            this.Controls.Add(this.txtbx_donate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_print);
            this.Controls.Add(this.txtbx_carrier);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtbox_csvcontent);
            this.Controls.Add(this.txtbx_test);
            this.Controls.Add(this.label_shopname);
            this.Controls.Add(this.combx_shop);
            this.Controls.Add(this.label_test);
            this.Controls.Add(this.btn_view);
            this.Controls.Add(this.txtbx_database);
            this.Controls.Add(this.label_database);
            this.Controls.Add(this.btn_check);
            this.Controls.Add(this.txtbx_date);
            this.Controls.Add(this.txtbx_invoiceno);
            this.Controls.Add(this.label_date);
            this.Controls.Add(this.label_invoiceno);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_Closed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_invoiceno;
        private System.Windows.Forms.Label label_date;
        private System.Windows.Forms.TextBox txtbx_invoiceno;
        private System.Windows.Forms.TextBox txtbx_date;
        private System.Windows.Forms.Button btn_check;
        private System.Windows.Forms.Label label_database;
        private System.Windows.Forms.TextBox txtbx_database;
        private System.Windows.Forms.Button btn_view;
        private System.Windows.Forms.Label label_test;
        private System.Windows.Forms.ComboBox combx_shop;
        private System.Windows.Forms.Label label_shopname;
        private System.Windows.Forms.TextBox txtbx_test;
        private System.Windows.Forms.TextBox txtbox_csvcontent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbx_carrier;
        private System.Windows.Forms.Button btn_print;
        private System.Windows.Forms.Button btn_agprint;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbx_donate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtbx_agpinvoiceno;
        private System.Windows.Forms.Label label_number;
        private System.Windows.Forms.Button btn_setinno;
        private System.Windows.Forms.TextBox txtbx_setinno;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbx_agpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtbx_agprandomno;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

