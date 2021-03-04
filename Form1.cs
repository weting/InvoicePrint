using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Management;
using System.Drawing.Printing;
using System.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Windows.Forms.VisualStyles;
using ZXing;
using QRCoder;
using System.IO;
using System.IO.Ports;
using System.Threading;

namespace InvoicePrint
{
    public partial class Form1 : Form
    {
        bool test_flag = false;
        //bool test_flag = true;
        
        bool printd_flag = false;
        
        //the string for datebase
        string str_database = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source =";
        string str_database_1 = ";User Id=admin;Password=";
        string str_conn = "";

        string csv_invoiceallno;

        //read content read from csv file
        string str_oriinvoicedate;
        string str_oriinvoicenoen;
        string str_oriinvoicenomin;
        string str_oriinvoicenomax;

        //the range of random number
        const int minvalue = 999;
        const int maxvalue = 10000;

        private OleDbConnection conn;

        //test for print example
        private Font printFont;
        private StreamReader streamToPrint;
        static string filePath;

        public Form1()
        {
            InitializeComponent();
          /**  if (test_flag == true)
            {
                txtbx_test.Visible = true;
            }
            else
            {
                txtbx_test.Visible = false;
            }*/
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.Blue,
              new Rectangle(100, 150, 250, 250));
        }
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            /*float linesPerPage = 0;
            float yPos = 0;
            int count = 0;
            float leftMargin = ev.MarginBounds.Left;
            float topMargin = ev.MarginBounds.Top;
            String line = null;

            // Calculate the number of lines per page.
            linesPerPage = ev.MarginBounds.Height /
               printFont.GetHeight(ev.Graphics);

            // Iterate over the file, printing each line.
            while (count < linesPerPage &&
               ((line = streamToPrint.ReadLine()) != null))
            {
                yPos = topMargin + (count * printFont.GetHeight(ev.Graphics));
                ev.Graphics.DrawString(line, printFont, Brushes.Black,
                   leftMargin, yPos, new StringFormat());
                count++;
            }

            // If more lines exist, print another page.
            if (line != null)
                ev.HasMorePages = true;
            else
                ev.HasMorePages = false;
            */
            Point location = new Point(0, 0);
            Image img = Image.FromFile(@".\result\Test.jpg");
            ev.Graphics.DrawImage(img, location);

        }


        private void btn_check_Click(object sender, EventArgs e)
        {
            const string save_file = @".\result\";

            string str_date = txtbx_date.Text;
            string str_invoiceno = txtbx_invoiceno.Text;

            //set the path of reading the database
            str_conn = str_database + txtbx_database.Text + str_database_1;
            conn = new OleDbConnection(@str_conn);         

            string str_carrierid = "";

            //parameters wil be used
            string str_outno;
            string str_invoicenumber;
            int int_salesamount;
            int int_taxamount;
            int int_totalamount;
            string str_buyerid;
            int int_goodsclass;
            int int_totalgoodsno;
            string[] str_productdes;
            int[] int_productno;
            int[] int_productunitprice;
            string str_randomno;
            string str_donate;

            string[] str_goodsid;
            string str_encryptdate;
            string str_invoicetime;

            //for creating the qrcode
            com.tradevan.qrutil.QREncrypter aes_encrpypter = new com.tradevan.qrutil.QREncrypter();

            //電子發票印出格式
            string invoice_number = ""; // 發票號碼 英文兩碼 數字八碼
            string invoice_date = "";   // 發票日期 
            string random_no = "";      // 隨機碼
            string salesamount = "";    // 16進制表示
            string totalamount = "";    // 16進制表示
            string buyer_id = "";       // 統編 若無 為00000000
            string seller_id;           // 賣方統編
            string encrypt_date = "";   // 24碼  採Base64加密 加密內容為 發票號碼+隨機碼
            string reserved;            // 保留欄位
            string goodsclass = "";     // 10 進制
            string totalgoodsno = "";   // 10 進制
            string reference = "";      // 0 = Big5 , 1 = UTF-8, 2 = Base64
            
            string[] product_des;
            string[] product_no;
            string[] product_unitprice;
            string ps = "";             // 補充說明

            string invoice_time;

            string carrierid;

            Int64 max_invoiceno = Convert.ToInt64(str_oriinvoicenomax);
            Int64 min_invoiceno = Convert.ToInt64(str_oriinvoicenomin);
            Int64 now_invoiceno = Convert.ToInt64(txtbx_invoiceno.Text);
            /*
                        //read the csv file to confirm the invoice number
                        string str_csvcontent = "";
                        string[] str_divcon;
                        string str_oriinvoicedate;
                        string str_oriinvoicenoen;
                        string str_oriinvoicenomin;
                        string str_oriinvoicenomax;
                        str_divcon = new string[14];
                        try
                        {
                            var stream_csvreader = new StreamReader(csv_invoiceallno);
                            str_csvcontent = stream_csvreader.ReadToEnd();

                            str_divcon = str_csvcontent.Split(',');

                            for (int i = 0; i < 14; i++) {
                                txtbox_csvcontent.Text += str_divcon[i] + "\n";
                            }
                            str_csvcontent.Split();

                            stream_csvreader.Close();

                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Error:" + ex.ToString());

                        }

                       */
            try
            {
                //check the invoice number is between the min and max
                //print the content on the textbox
                //txtbox_csvcontent.Text += "min:"+Convert.ToInt64(str_oriinvoicenomin).ToString()+Environment.NewLine;
                //txtbox_csvcontent.Text += "max:" + Convert.ToInt64(str_oriinvoicenomax).ToString() + Environment.NewLine;
                //txtbox_csvcontent.Text += "now_invoiceno:" + Convert.ToInt64(txtbx_invoiceno.Text);
                
                //檢測字軌範圍
                if (test_flag == true)
                {
                    MessageBox.Show("測試中 檢測字軌範圍");
                }
                else
                {                    
                    if (min_invoiceno <= now_invoiceno && max_invoiceno >= now_invoiceno)
                    {
                        MessageBox.Show("開立成功");
                    }
                    else
                    {
                        MessageBox.Show("字軌錯誤 不在範圍內");
                        return;
                    }
                }
                
                //create random number to write into the datebase
                Random random = new Random();
                random_no = random.Next(minvalue, maxvalue).ToString();

                conn.Open();
                
                //pick the date that its invoice number and date is right
                OleDbCommand command = new OleDbCommand();
                command.Connection = conn;
                string query = "select * from Out_order_main where InvoiceNo='" + txtbx_invoiceno.Text + "' and OutDate=#" + txtbx_date.Text + "#";
                command.CommandText = query;

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dataTable = new DataTable();
                da.Fill(dataTable);

                str_outno = dataTable.Rows[0]["OutNo"].ToString();
                str_invoicetime = dataTable.Rows[0]["STIME"].ToString();
            
                str_buyerid = dataTable.Rows[0]["theNo"].ToString();
                str_randomno = dataTable.Rows[0]["Random"].ToString();

                str_carrierid = txtbx_carrier.Text;

                // 有統編時 銷售額跟稅要分開算
                // 沒有統編 稅為零 銷售額為總額
                if (str_buyerid == "")
                {
                    str_buyerid = "00000000";
                    int_salesamount = Convert.ToInt32(float.Parse(dataTable.Rows[0]["Asum"].ToString()));
                    int_taxamount = Convert.ToInt32(float.Parse(dataTable.Rows[0]["TaxKind"].ToString()));
                    //int_totalamount = Convert.ToInt32(dataTable.Rows[0]["TaxKind"]) + Convert.ToInt32(dataTable.Rows[0]["Asum"]);                  
                    int_totalamount = int_salesamount + int_taxamount;
                    int_salesamount = int_totalamount;
                    int_taxamount = 0;
                }
                else
                {
                    //set the flag print the details of the invoice
                    printd_flag = true;                 
                    int_salesamount = Convert.ToInt32(float.Parse(dataTable.Rows[0]["Asum"].ToString()));
                    int_taxamount = Convert.ToInt32(float.Parse(dataTable.Rows[0]["TaxKind"].ToString()));                 
                    int_totalamount = int_salesamount + int_taxamount;
                }

                //設定發票號碼(包含2碼英文和8碼號碼)
                str_invoicenumber = str_oriinvoicenoen + txtbx_invoiceno.Text;

                int_totalgoodsno = Convert.ToInt32(dataTable.Rows[0]["AllGoodsNum"]);
                totalgoodsno = int_totalgoodsno.ToString();

                OleDbCommand command_detail = new OleDbCommand();
                command_detail.Connection = conn;
                string query_detail = "select * from Out_order_detail where OutNo='" + str_outno + "'";
                command_detail.CommandText = query_detail;

                OleDbDataAdapter da_detail = new OleDbDataAdapter(command_detail);
                DataTable dataTable_detail = new DataTable();
                da_detail.Fill(dataTable_detail);
               
                //商品種類
                int_goodsclass = dataTable_detail.Rows.Count;

                str_productdes = new string[int_goodsclass];
                int_productno = new int[int_goodsclass];
                int_productunitprice = new int[int_goodsclass];
                str_goodsid = new string[int_goodsclass];

                product_des = new string[int_goodsclass];
                product_no = new string[int_goodsclass];
                product_unitprice = new string[int_goodsclass];

                for (int i = 0; i < int_goodsclass; i++)
                {
                    int_productno[i] = Convert.ToInt32(dataTable_detail.Rows[i]["Number"]);
                    int_productunitprice[i] = Convert.ToInt32(dataTable_detail.Rows[i]["SalePrice"]);
                    str_goodsid[i] = dataTable_detail.Rows[i]["GoodsID"].ToString();
                }
                //Get data from original database
                OleDbCommand command_goods = new OleDbCommand();
                command_goods.Connection = conn;

                for (int j = 0; j < int_goodsclass; j++)
                {
                    string query_goods = "select * from AllGoods where GoodsID='" + str_goodsid[j] + "'";
                    command_goods.CommandText = query_goods;
                    OleDbDataAdapter da_goods = new OleDbDataAdapter(command_goods);
                    DataTable dataTable_goods = new DataTable();
                    da_goods.Fill(dataTable_goods);
                    str_productdes[j] = dataTable_goods.Rows[0]["GoodsName"].ToString();
                }

                //conn.Close();
                
                /*
                                //隨機碼 寫入資料庫
                                try
                                {
                                    OleDbCommand command_random = new OleDbCommand();
                                    command_random.Connection = conn;
                                    string query_random = "ALTER TABLE Out_order_main ADD Random char(4)";
                                    command_random.CommandText = query_random;

                                    OleDbDataAdapter da_random = new OleDbDataAdapter(command_random);
                                    DataTable dataTable_random = new DataTable();
                                    da_random.Fill(dataTable_random);
                                }
                                catch(Exception ex)
                                {
                                    MessageBox.Show(ex.ToString());
                                }

                  */
                
                //建立載具欄位 寫入資料庫
                try
                {
                    OleDbCommand command_carrier = new OleDbCommand();
                    command_carrier.Connection = conn;
                    string query_carrier = "ALTER TABLE Out_order_main ADD CarrierId char(16)";
                    command_carrier.CommandText = query_carrier;

                    OleDbDataAdapter da_carrier = new OleDbDataAdapter(command_carrier);
                    DataTable dataTable_carrier = new DataTable();
                    da_carrier.Fill(dataTable_carrier);
                }                              
                catch(Exception ex)
                {
                    if (ex.Data.ToString().Equals("System.Collections.ListDictionaryInternal"))
                    {
                        //成功建立 CarrierId 欄位 不做任何動作
                        //    MessageBox.Show("成功");                
                    }
                    else
                    {
                        MessageBox.Show(ex.Data.ToString());
                    }         
                }

                //建立捐贈碼欄位 寫入資料庫
                try
                {
                    OleDbCommand command_donate = new OleDbCommand();
                    command_donate.Connection = conn;
                    string query_donate = "ALTER TABLE Out_order_main ADD DonateMark char(10)";
                    command_donate.CommandText = query_donate;

                    OleDbDataAdapter da_donate = new OleDbDataAdapter(command_donate);
                    DataTable dataTable_donate = new DataTable();
                    da_donate.Fill(dataTable_donate);
                }
                catch (Exception ex)
                {
                    if (ex.Data.ToString().Equals("System.Collections.ListDictionaryInternal"))
                    {
                        //成功建立 CarrierId 欄位 不做任何動作
                        //MessageBox.Show("捐贈碼成功建立");                
                    }
                    else
                    {
                        MessageBox.Show(ex.Data.ToString());
                    }
                }

                invoice_number = txtbx_invoiceno.Text;

                //寫入隨機碼
                if (str_randomno == "")
                {
                    OleDbCommand command_addrand = new OleDbCommand();
                    command_addrand.Connection = conn;
                    //string query_addrand = "insert into Out_order_main (OutNo, Random,) values('" + str_outno + "','"+ random_no + "')";
                    string query_addrand = "update Out_order_main set Random='" + random_no + "' where InvoiceNo='" + txtbx_invoiceno.Text + "'";
                    // MessageBox.Show(query_addrand);
                    command_addrand.CommandText = query_addrand;

                    OleDbDataAdapter da_addrand = new OleDbDataAdapter(command_addrand);
                    DataTable dataTable_addrand = new DataTable();
                    da_addrand.Fill(dataTable_addrand);
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("已存在隨機碼 不能複寫 可以按補印按鍵列印發票");
                }

                //寫入載具(包含一般載具8碼和自然人憑證16碼)
                if(txtbx_carrier.Text == "")
                {
                    MessageBox.Show("沒有載具內容");
                }
                else
                {
                    //check the carrier id format
                    carrierid = txtbx_carrier.Text;
                    if(carrierid.Length == 8)
                    {
                        if (carrierid[0].Equals('/'))
                        {
                            //寫入資料庫
                            OleDbCommand command_addcarrier = new OleDbCommand();
                            command_addcarrier.Connection = conn;
                            string query_addcarrier = "update Out_order_main set CarrierId='" + carrierid + "' where InvoiceNo='" + txtbx_invoiceno.Text + "'";
                            command_addcarrier.CommandText = query_addcarrier;

                            OleDbDataAdapter da_addcarrier = new OleDbDataAdapter(command_addcarrier);
                            DataTable dataTable_addcarrier = new DataTable();
                            da_addcarrier.Fill(dataTable_addcarrier);
                            conn.Close();
                            //MessageBox.Show("8碼 載具寫入成功");
                        }
                        else
                        {
                            MessageBox.Show("8碼 載具格式錯誤");
                        }
                    }
                    else if(carrierid.Length == 16)
                    {
                        char first_char = carrierid[0];
                        char second_char = carrierid[1];
                        bool check_carrier = false;
                        if ((first_char>=65) && (first_char<=90))
                        {
                            if ((second_char >= 65) && (second_char <= 90))
                            {
                                for (int i = 0; i < 14; i++)
                                {
                                    if ((carrierid[i + 2] >= 48) && (carrierid[i + 2] <= 57))
                                    {
                                        check_carrier = true;
                                    }
                                    else
                                    {
                                        check_carrier = false;
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("16碼 載具格式錯誤");
                            }
                        }
                        else
                        {
                            MessageBox.Show("16碼 載具格式錯誤");
                        }
                    
                        if(check_carrier == true)
                        {
                            //寫入資料庫
                            OleDbCommand command_addcarrier = new OleDbCommand();
                            command_addcarrier.Connection = conn;
                            string query_addcarrier = "update Out_order_main set CarrierId='" + carrierid + "' where InvoiceNo='" + txtbx_invoiceno.Text + "'";
                            command_addcarrier.CommandText = query_addcarrier;

                            OleDbDataAdapter da_addcarrier = new OleDbDataAdapter(command_addcarrier);
                            DataTable dataTable_addcarrier = new DataTable();
                            da_addcarrier.Fill(dataTable_addcarrier);
                            conn.Close();
                            //MessageBox.Show("16碼 載具寫入成功");
                        }                   
                    }
                    else
                    {
                        MessageBox.Show("載具格式錯誤");
                    }                              
                }

                //寫入捐贈碼
                if (txtbx_donate.Text != "")
                {
                    str_donate = txtbx_donate.Text;
                    OleDbCommand command_adddonate = new OleDbCommand();
                    command_adddonate.Connection = conn;
                    string query_adddonate = "update Out_order_main set DonateMark='" + str_donate + "' where InvoiceNo='" + txtbx_invoiceno.Text + "'";                   
                    command_adddonate.CommandText = query_adddonate;
                    OleDbDataAdapter da_adddonate = new OleDbDataAdapter(command_adddonate);
                    DataTable dataTable_adddonate = new DataTable();
                    da_adddonate.Fill(dataTable_adddonate);
                    conn.Close();
                }
                else
                {
                    //MessageBox.Show("沒有捐贈碼");
                }


                //Before print the invoice check the random and invoice number check the invoice number whether exist already
                //利用額外的 txt 檔確認(我覺得沒有必要 上面已經有確認過了)
                var reader = new StreamReader(@".\document\RandomNo.txt");
                string str_randomtxt = reader.ReadToEnd();
                int index_txtrandom = reader.Peek();
                reader.Close();

                if (str_randomtxt.Contains(invoice_number))
                {
                    MessageBox.Show(str_randomtxt + "已開過的發票字軌");
                    if (test_flag == false)
                    {
                        return;
                    }
                }
                else
                {
                    // MessageBox.Show(str_randomtxt+"\n"+ "invoice_number" + invoice_number + "\n已開過的發票字軌"+"\nindex_txtrandom:"+index_txtrandom.ToString());
                    //var streamwriter = new StreamWriter(@".\document\RandomNo.txt");
                    //streamwriter.WriteLine(invoice_number + ","+random_no+"\r\n");
                    // Environment.NewLine(invoice_number + "," + random_no));
                    File.AppendAllText(@".\document\RandomNo.txt", invoice_number + "," + random_no + Environment.NewLine);
                    //streamwriter.Flush();
                    //streamwriter.Close();
                }
                  
                
                /*
                 下方所有內容為製作列印電自子發票的所有內容及流程
                 */
                // 設定列印電子發票紙本所有需要的內容
                com.tradevan.qrutil.QREncrypter qrEncrypter = new com.tradevan.qrutil.QREncrypter();
                str_encryptdate = str_invoicenumber + random_no;
                
                // 左方二維碼
                invoice_number = txtbx_invoiceno.Text;
                invoice_date = txtbx_date.Text.Replace("/", "-");
                salesamount = int.Parse(int_salesamount.ToString(), System.Globalization.NumberStyles.HexNumber).ToString();
                totalamount = int.Parse(int_totalamount.ToString(), System.Globalization.NumberStyles.HexNumber).ToString();
                buyer_id = str_buyerid;
                seller_id = "99965650";
                encrypt_date = aes_encrpypter.AESEncrypt(str_encryptdate, "C1EF9E812DA461C39394144669AECCF2");//AES key 
                reserved = "**********";//保留用 前面要加:
                goodsclass = int_goodsclass.ToString(); //前面要加:
                totalgoodsno = int_totalgoodsno.ToString();//前面要加:
                reference = "2"; //不確定  前面要加:

                invoice_time = str_invoicetime;
                string str_left_qrcode = "";
                //string str_left_qrcode = invoice_number + invoice_date + salesamount + totalamount + buyer_id + seller_id + encrypt_date
                //               + ":" + reserved + ":" + goodsclass + ":" + totalgoodsno + ":" + reference;
                if (test_flag == true)
                {
                    string invoice_date_test = "1040115";
                    string invoice_time_test = invoice_time.Replace(":", "");
                    str_left_qrcode = qrEncrypter.QRCodeINV(str_invoicenumber, invoice_date_test, invoice_time_test, random_no, int_salesamount, int_taxamount, int_totalamount,
                                                                buyer_id, buyer_id, seller_id, seller_id, "C1EF9E812DA461C39394144669AECCF2");

                }
                else
                {
                    //invoice_date 
                    str_left_qrcode = qrEncrypter.QRCodeINV(str_invoicenumber, invoice_date, invoice_time, random_no, int_salesamount, int_taxamount, int_totalamount,
                                                                buyer_id, buyer_id, seller_id, seller_id, "C1EF9E812DA461C39394144669AECCF2");
                }

                //txtbx_test.Text = str_left_qrcode;
               
                //右方二維碼
                string str_right_qrcode = "**";
                for (int z = 0; z < int_goodsclass; z++)
                {
                    str_right_qrcode += ":" + str_productdes[z] + ":" + int_productno[z].ToString() + ":" + int_productunitprice[z].ToString();
                }

                string print_month = "1234", print_barcode_month = "56";
               
                //發票月份 以及一維碼的月份
                if (DateTime.Now.Month.Equals(1) || DateTime.Now.Month.Equals(2))
                {
                    print_month = "01-02";
                    print_barcode_month = "02";
                }
                else if (DateTime.Now.Month.Equals(3) || DateTime.Now.Month.Equals(4))
                {
                    print_month = "03-04";
                    print_barcode_month = "04";
                }
                else if (DateTime.Now.Month.Equals(5) || DateTime.Now.Month.Equals(6))
                {
                    print_month = "05-06";
                    print_barcode_month = "06";
                }
                else if (DateTime.Now.Month.Equals(7) || DateTime.Now.Month.Equals(8))
                {
                    print_month = "07-08";
                    print_barcode_month = "08";
                }
                else if (DateTime.Now.Month.Equals(9) || DateTime.Now.Month.Equals(10))
                {
                    print_month = "09-10";
                    print_barcode_month = "10";
                }
                else if (DateTime.Now.Month.Equals(11) || DateTime.Now.Month.Equals(12))
                {
                    print_month = "11-12";
                    print_barcode_month = "12";
                }

                //一維碼 內容
                string str_barcode = "*"+(int.Parse(DateTime.Now.Year.ToString()) - 1911).ToString() + print_barcode_month + str_invoicenumber + random_no+"*";

                //產生條碼
                //一維
                BarcodeWriter writer = new BarcodeWriter();
                writer.Format = BarcodeFormat.CODE_39;
                //label_test.Text = str_barcode;
                Bitmap img = writer.Write(str_barcode);
                img.Save(save_file+"barcode.jpg");
                //左QRCode
                QRCodeGenerator left_gen = new QRCodeGenerator();
                QRCodeData left_qrcodedata;
                QRCode left_code;

                left_qrcodedata = left_gen.CreateQrCode(str_left_qrcode, QRCodeGenerator.ECCLevel.H);
                left_code = new QRCode(left_qrcodedata);
                left_code.GetGraphic(41).Save(save_file+"left_code.jpg");

                //右QRCode
                QRCodeGenerator right_gen = new QRCodeGenerator();
                QRCodeData right_qrcodedata;
                QRCode right_code;

                right_qrcodedata = right_gen.CreateQrCode(str_right_qrcode, QRCodeGenerator.ECCLevel.H);
                right_code = new QRCode(right_qrcodedata);
                right_code.GetGraphic(41).Save(save_file+"right_code.jpg");
                //const string folder = @"D:\Code_visual\InvoicePrint\bin\Debug";
                //發票 5.7 * 9 cm 
                // Image img_mix = Image.FromFile("img_ini.jpg");
                // Image img_barcode = Image.FromFile(Path.Combine(save_file, "barcode.jpg"));
                //  Image img_lqrcode = Image.FromFile(Path.Combine(save_file, "left_code.jpg"));
                // Image img_rqrcode = Image.FromFile(Path.Combine(save_file, "right_code.jpg"));


                /*
                                Font f = new Font("宋體", 8);
                                Brush b = new SolidBrush(Color.Black);

                                Font f2 = new Font("宋體", 35);
                                Font f3 = new Font("宋體", 25);
                                Font f4 = new Font("宋體", 20);

                                graphics.DrawString("阿立圓山玩具模型店", f4, b, 35, 120);
                                //graphics.DrawString("微縮世界", f3, b, 100, 120);
                                graphics.DrawString("電子發票證明聯", f3, b, 30, 150);
                                graphics.DrawString(DateTime.Now.ToLongDateString(), f2, b, 25, 180);
                                graphics.DrawString("AB-" + invoice_number,f2, b, 25, 220);

                                graphics.DrawString(invoice_date+"  "+invoice_time, f, b, 35, 270);
                                graphics.DrawString("隨機碼 "+random_no.ToString()+"\t  總計 "+int_totalamount.ToString(), f, b, 35, 285);
                                graphics.DrawString("賣方" + seller_id+"\t"+"買方"+buyer_id, f, b, 35, 300);

                                graphics.DrawImage(img_barcode, 30, 300, 270, 50);
                                graphics.DrawImage(img_lqrcode, 30, 350, 120, 120);
                                graphics.DrawImage(img_rqrcode, 170, 350, 120, 120);


                                picbx_invoice.Image = img_mix;
                */
                //發票 5.7 * 9 cm 
                //img_ini.jpg 空白圖片
                Image img_mix = Image.FromFile(@".\picture\img_ini.jpg");
            
                Image img_barcode = img;
                Image img_lqrcode = left_code.GetGraphic(41);
                Image img_rqrcode = right_code.GetGraphic(41);
                Graphics graphics = Graphics.FromImage(img_mix);

                Font f = new Font("宋體", 250);
                Brush b = new SolidBrush(Color.Black);

                Font f2 = new Font("宋體", 680);
                Font f3 = new Font("宋體", 620);
                Font f4 = new Font("宋體", 570);
                Font f5 = new Font("宋體", 470);
                Font f6 = new Font("宋體", 650);

                // graphics.DrawString("阿立圓山玩具模型店", f5, b, 100, 800);
                if (combx_shop.Text == "微縮世界")
                {
                    graphics.DrawString("微縮世界", f6, b, 1375, 700);
                }
                else
                {
                    graphics.DrawString("阿立圓山玩具模型店", f5, b, 100, 800);
                }
                graphics.DrawString("電子發票證明聯", f4, b, 300, 1600);
                graphics.DrawString((int.Parse(DateTime.Now.Year.ToString())-1911).ToString()+"年"+ print_month + "月", f3, b, 700, 2500);
           
                graphics.DrawString("AB-" + invoice_number, f2, b,500, 3350);
                graphics.DrawString(invoice_date + "  " + invoice_time, f, b, 700, 4325);
                graphics.DrawString("隨機碼 " + random_no.ToString() + "\t\t  總計 " + int_totalamount.ToString(), f, b, 700, 4725);

                if (buyer_id == "00000000")
                {
                    graphics.DrawString("賣方" + seller_id, f, b, 700, 5100);
                }
                else
                {
                    graphics.DrawString("賣方" + seller_id + "\t" + "買方" + buyer_id, f, b, 700, 5100);
                }
                graphics.DrawImage(img_barcode, 900, 5600, 5000, 1000);
                graphics.DrawImage(img_lqrcode, 900, 6600, 2500, 2500);
                graphics.DrawImage(img_rqrcode, 3600, 6600, 2500, 2500);

                GC.Collect();
                //產生出來的檔案後存入系統裡 檔名為發票號碼
                img_mix.Save(save_file+"mix_code.jpg");
                img_mix.Save(save_file+invoice_number+".jpg");

                txtbx_invoiceno.Text = (int.Parse(txtbx_invoiceno.Text) + 1).ToString();
                MessageBox.Show("發票開立成功");
                label_number.Text = "剩" + (Convert.ToInt32(str_oriinvoicenomax) - Convert.ToInt32(txtbx_invoiceno)).ToString() + "張發票";
                if (((Convert.ToInt64(str_oriinvoicenomax) - Convert.ToInt64(txtbx_invoiceno.Text)) + 1).ToString() == "0")
                {
                    MessageBox.Show("字軌已用畢，請去電子發票整合服務平台申請字軌");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show( ex.ToString());
            }
      
        }

        private void Form1_Load(object sender, EventArgs e)
        {                       
           //讀取發票配號檔
           if(test_flag == true)
           {
                csv_invoiceallno = @".\document\invnoapplyTest.csv";
           }
           else
           {
                csv_invoiceallno = @".\document\invnoapply.csv";
            }
            
            //read the csv file to confirm the invoice number
            string str_csvcontent = "";
            string[] str_divcon;

            str_divcon = new string[14];
            try
            {
                var stream_csvreader = new StreamReader(csv_invoiceallno, System.Text.Encoding.Default);
                str_csvcontent = stream_csvreader.ReadToEnd();

                str_divcon = str_csvcontent.Split(',', '\n');
                int j;
                for (int i = 0; i < 14; i++)
                {
                    txtbox_csvcontent.Text += str_divcon[i];// + str_divcon[i].Length.ToString();
                    j = 0;
                    do
                    {
                        if (i < 6)
                        {
                            txtbox_csvcontent.Text += " ";
                        }
                        else if (i == 9)
                        {
                            txtbox_csvcontent.Text += " ";
                        }
                        else {
                            txtbox_csvcontent.Text += "  ";
                        }
                        j++;
                    
                    } while ((j + str_divcon[i].Length) != 17);


                    if ( i == 6)
                    {
                        txtbox_csvcontent.Text += Environment.NewLine;
                    }
                }
                str_oriinvoicedate = str_divcon[10];
                str_oriinvoicenoen = str_divcon[11];
                str_oriinvoicenomin = str_divcon[12];
                str_oriinvoicenomax = str_divcon[13];
     
                str_csvcontent.Split();

                stream_csvreader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());

            }

            //read the invoice number last time save
            string read_invoiceno = "";
            
            try 
            {
                if (test_flag == true)
                {
                    var stream_reader = new StreamReader(@".\document\InvoiceNoTest.txt");
                    if (stream_reader == null)
                    {
                        Directory.CreateDirectory(@".\document\");

                    }
                    read_invoiceno = stream_reader.ReadLine();
                    stream_reader.Close();
                }
                else
                {
                    var stream_reader = new StreamReader(@".\document\InvoiceNo.txt");
                    if (stream_reader == null)
                    {
                        Directory.CreateDirectory(@".\document\");
                    }
                    read_invoiceno = stream_reader.ReadLine();
                    stream_reader.Close();                                  
                }     
                
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error:"+ex.ToString());
            }
            
            if (test_flag == true)
            {
                //txtbx_test.Text = read_invoiceno;
                txtbx_invoiceno.Text = read_invoiceno;
                txtbx_date.Text = "2020/2/14";
                txtbx_database.Text = @"D:\posdb.mdb";
                combx_shop.Text = "阿立圓山玩具模型店";
                //txtbx_carrier.Text = "/GHTU47Q";
                txtbx_carrier.Text = "AB12345678901234";
                txtbx_donate.Text = "98765";
                txtbx_setinno.Text = "32420900";
            }
            else
            {
                txtbx_invoiceno.Text = read_invoiceno;
                txtbx_date.Text = DateTime.Now.ToShortDateString();
                combx_shop.Text = "阿立圓山玩具模型店";
                txtbx_database.Text = @"C:\inetpub\wwwroot\Webpos\database\posdb.mdb";
                txtbx_carrier.Text = "";
                txtbx_donate.Text = "";
                label_number.Text = "剩" + (Convert.ToInt32(str_oriinvoicenomax) - Convert.ToInt32(read_invoiceno) + 1).ToString() + "張發票";
                txtbx_setinno.Text = "32420900";
            }
            combx_shop.Items.Add("阿立圓山玩具模型店");
            combx_shop.Items.Add("微縮模型");
            if (txtbx_invoiceno.Text == "")
            {
                MessageBox.Show("請設定新字軌");
            }
            else
            {
                if (((Convert.ToInt64(str_oriinvoicenomax) - Convert.ToInt64(txtbx_invoiceno.Text)) + 1).ToString() == "0")
                {
                    MessageBox.Show("字軌已用畢，請去電子發票整合服務平台申請字軌");
                }
            }
        }

        private void btn_view_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();

            openFileDialog.InitialDirectory = @"D:\Code_visual\Access_Process";

            openFileDialog.DefaultExt = ".txt";
            openFileDialog.Filter = "Text Document (.txt)|*.txt";

            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "All flie(*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtbx_database.Text = openFileDialog.FileName;
            }
        }

        private void Form1_Closed(object sender, FormClosedEventArgs e)
        {
            if (test_flag == true)
            {
                var stream_write = new StreamWriter(@".\document\InvoiceNoTest.txt");
                string ori_invoiceno = txtbx_invoiceno.Text;
                string next_invoiceno = txtbx_invoiceno.Text;
                stream_write.WriteLine(next_invoiceno);
                stream_write.Close();

            }
            else
            {
                var stream_write = new StreamWriter(@".\document\InvoiceNo.txt");
                string ori_invoiceno = txtbx_invoiceno.Text;
                //string next_invoiceno = (int.Parse(ori_invoiceno)+1).ToString();
                string next_invoiceno = txtbx_invoiceno.Text;
                stream_write.WriteLine(next_invoiceno);
                stream_write.Close();

            }
        }

        private void btn_setinno_Click(object sender, EventArgs e)
        {
            if (test_flag == true)
            {
                var stream_write = new StreamWriter(@".\document\InvoiceNoTest.txt");
                string set_invoiceno = txtbx_setinno.Text;
                if ((Convert.ToInt32(set_invoiceno) >= Convert.ToInt32(str_oriinvoicenomin)) && (Convert.ToInt32(set_invoiceno) <= Convert.ToInt32(str_oriinvoicenomax)))
                {
                    stream_write.WriteLine(set_invoiceno);
                    txtbx_invoiceno.Text = set_invoiceno;
                    label_number.Text = "剩" + (Convert.ToInt32(str_oriinvoicenomax) - Convert.ToInt32(txtbx_setinno.Text)+1).ToString() + "張發票";
                }
                else
                {
                    txtbx_invoiceno.Text = set_invoiceno;
                    label_number.Text = "剩" + (Convert.ToInt32(str_oriinvoicenomax) - Convert.ToInt32(txtbx_setinno.Text)+1).ToString() + "張發票";
                    MessageBox.Show("字軌超出範圍");
                }
                stream_write.Close();
            }
            else
            {
                var stream_write = new StreamWriter(@".\document\InvoiceNo.txt");
                string set_invoiceno = txtbx_setinno.Text;
                if ((Convert.ToInt32(set_invoiceno) >= Convert.ToInt32(str_oriinvoicenomin)) && (Convert.ToInt32(set_invoiceno) <= Convert.ToInt32(str_oriinvoicenomax)))
                {
                    stream_write.WriteLine(set_invoiceno);
                    txtbx_invoiceno.Text = set_invoiceno;
                    label_number.Text = "剩" + (Convert.ToInt32(str_oriinvoicenomax) - Convert.ToInt32(txtbx_setinno.Text)+1).ToString() + "張發票";
                }
                else
                {
                    txtbx_invoiceno.Text = set_invoiceno;
                    label_number.Text = "剩" + (Convert.ToInt32(str_oriinvoicenomax) - Convert.ToInt32(txtbx_setinno.Text)+1).ToString() + "張發票";
                    MessageBox.Show("字軌超出範圍，起重新設定號碼");
                }
                stream_write.Close();

            }
        }

        private void btn_agprint_Click(object sender, EventArgs e)
        {
            string str_agpinvoiceno = "";
            string str_agpdate = "";
            string str_agprandomno = "";
            Int32 int_randomno;

            //parameters wil be used
            string str_outno;
            string str_invoicenumber;
            int int_salesamount;
            int int_taxamount;
            int int_totalamount;
            string str_buyerid;
            int int_goodsclass;
            int int_totalgoodsno;
            string[] str_productdes;
            int[] int_productno;
            int[] int_productunitprice;
            string str_randomno;
            string str_donate;

            string[] str_goodsid;
            string str_encryptdate;
            string str_invoicetime;

            string invoice_time;
            const string save_file = @".\result\";

            //電子發票印出格式
            string invoice_number = ""; // 發票號碼 英文兩碼 數字八碼
            string invoice_date = "";   // 發票日期 
            string random_no = "";      // 隨機碼
            string salesamount = "";    // 16進制表示
            string totalamount = "";    // 16進制表示
            string buyer_id = "";       // 統編 若無 為00000000
            string seller_id;           // 賣方統編
            string encrypt_date = "";   // 24碼  採Base64加密 加密內容為 發票號碼+隨機碼
            string reserved;            // 保留欄位
            string goodsclass = "";     // 10 進制
            string totalgoodsno = "";   // 10 進制
            string reference = "";      // 0 = Big5 , 1 = UTF-8, 2 = Base64

            string[] product_des;
            string[] product_no;
            string[] product_unitprice;
            string ps = "";
            //for creating the qrcode
            com.tradevan.qrutil.QREncrypter aes_encrpypter = new com.tradevan.qrutil.QREncrypter();


            str_conn = str_database + txtbx_database.Text + str_database_1;
            conn = new OleDbConnection(@str_conn);

            if ((txtbx_agpinvoiceno.Text != "") && (txtbx_agpdate.Text != ""))
            {
                if (txtbx_agprandomno.Text != "")
                {
                    str_agpinvoiceno = txtbx_agpinvoiceno.Text;
                    str_agpdate = txtbx_agpdate.Text;
                    str_agprandomno = txtbx_agprandomno.Text;
                    int_randomno = Convert.ToInt32(str_agprandomno);
                    //確認格式
                    if(str_agpinvoiceno.Length == 8)
                    {
                        if (int_randomno >= 999 && int_randomno <= 10000)
                        {
                            try
                            {
                                conn.Open();                                
                                OleDbCommand command = new OleDbCommand();
                                command.Connection = conn;
                                string query = "select * from Out_order_main where InvoiceNo='" + str_agpdate + "' and OutDate=#" + str_agpdate + "# and Random="+str_agprandomno;
                                command.CommandText = query;

                                OleDbDataAdapter da = new OleDbDataAdapter(command);
                                DataTable dataTable = new DataTable();
                                da.Fill(dataTable);

                                str_outno = dataTable.Rows[0]["OutNo"].ToString();
                                str_invoicetime = dataTable.Rows[0]["STIME"].ToString();

                                str_buyerid = dataTable.Rows[0]["theNo"].ToString();
                                str_randomno = dataTable.Rows[0]["Random"].ToString();

                                if (str_buyerid == "")
                                {
                                    str_buyerid = "00000000";
                                    int_salesamount = Convert.ToInt32(float.Parse(dataTable.Rows[0]["Asum"].ToString()));
                                    int_taxamount = Convert.ToInt32(float.Parse(dataTable.Rows[0]["TaxKind"].ToString()));
                                    //int_totalamount = Convert.ToInt32(dataTable.Rows[0]["TaxKind"]) + Convert.ToInt32(dataTable.Rows[0]["Asum"]);                  
                                    int_totalamount = int_salesamount + int_taxamount;
                                    int_salesamount = int_totalamount;
                                    int_taxamount = 0;
                                }
                                else
                                {
                                    //set the flag print the details of the invoice
                                    printd_flag = true;
                                    int_salesamount = Convert.ToInt32(float.Parse(dataTable.Rows[0]["Asum"].ToString()));
                                    int_taxamount = Convert.ToInt32(float.Parse(dataTable.Rows[0]["TaxKind"].ToString()));
                                    int_totalamount = int_salesamount + int_taxamount;
                                }

                                //設定發票號碼(包含2碼英文和8碼號碼)
                                str_invoicenumber = str_oriinvoicenoen + txtbx_invoiceno.Text;

                                int_totalgoodsno = Convert.ToInt32(dataTable.Rows[0]["AllGoodsNum"]);
                                totalgoodsno = int_totalgoodsno.ToString();

                                OleDbCommand command_detail = new OleDbCommand();
                                command_detail.Connection = conn;
                                string query_detail = "select * from Out_order_detail where OutNo='" + str_outno + "'";
                                command_detail.CommandText = query_detail;

                                OleDbDataAdapter da_detail = new OleDbDataAdapter(command_detail);
                                DataTable dataTable_detail = new DataTable();
                                da_detail.Fill(dataTable_detail);

                                //商品種類
                                int_goodsclass = dataTable_detail.Rows.Count;

                                str_productdes = new string[int_goodsclass];
                                int_productno = new int[int_goodsclass];
                                int_productunitprice = new int[int_goodsclass];
                                str_goodsid = new string[int_goodsclass];

                                product_des = new string[int_goodsclass];
                                product_no = new string[int_goodsclass];
                                product_unitprice = new string[int_goodsclass];

                                for (int i = 0; i < int_goodsclass; i++)
                                {
                                    int_productno[i] = Convert.ToInt32(dataTable_detail.Rows[i]["Number"]);
                                    int_productunitprice[i] = Convert.ToInt32(dataTable_detail.Rows[i]["SalePrice"]);
                                    str_goodsid[i] = dataTable_detail.Rows[i]["GoodsID"].ToString();
                                }
                                // 設定列印電子發票紙本所有需要的內容
                                com.tradevan.qrutil.QREncrypter qrEncrypter = new com.tradevan.qrutil.QREncrypter();
                                str_encryptdate = str_invoicenumber + random_no;

                                // 左方二維碼
                                invoice_number = txtbx_invoiceno.Text;
                                invoice_date = txtbx_date.Text.Replace("/", "-");
                                salesamount = int.Parse(int_salesamount.ToString(), System.Globalization.NumberStyles.HexNumber).ToString();
                                totalamount = int.Parse(int_totalamount.ToString(), System.Globalization.NumberStyles.HexNumber).ToString();
                                buyer_id = str_buyerid;
                                seller_id = "99965650";
                                encrypt_date = aes_encrpypter.AESEncrypt(str_encryptdate, "C1EF9E812DA461C39394144669AECCF2");//AES key 
                                reserved = "**********";//保留用 前面要加:
                                goodsclass = int_goodsclass.ToString(); //前面要加:
                                totalgoodsno = int_totalgoodsno.ToString();//前面要加:
                                reference = "2"; //不確定  前面要加:

                                invoice_time = str_invoicetime;
                                string str_left_qrcode = "";
                                //string str_left_qrcode = invoice_number + invoice_date + salesamount + totalamount + buyer_id + seller_id + encrypt_date
                                //               + ":" + reserved + ":" + goodsclass + ":" + totalgoodsno + ":" + reference;
                                if (test_flag == true)
                                {
                                    string invoice_date_test = "1040115";
                                    string invoice_time_test = invoice_time.Replace(":", "");
                                    str_left_qrcode = qrEncrypter.QRCodeINV(str_invoicenumber, invoice_date_test, invoice_time_test, random_no, int_salesamount, int_taxamount, int_totalamount,
                                                                                buyer_id, buyer_id, seller_id, seller_id, "C1EF9E812DA461C39394144669AECCF2");

                                }
                                else
                                {
                                    //invoice_date 
                                    str_left_qrcode = qrEncrypter.QRCodeINV(str_invoicenumber, invoice_date, invoice_time, random_no, int_salesamount, int_taxamount, int_totalamount,
                                                                                buyer_id, buyer_id, seller_id, seller_id, "C1EF9E812DA461C39394144669AECCF2");
                                }

                                //txtbx_test.Text = str_left_qrcode;

                                //右方二維碼
                                string str_right_qrcode = "**";
                                for (int z = 0; z < int_goodsclass; z++)
                                {
                                    str_right_qrcode += ":" + str_productdes[z] + ":" + int_productno[z].ToString() + ":" + int_productunitprice[z].ToString();
                                }

                                string print_month = "1234", print_barcode_month = "56";

                                //發票月份 以及一維碼的月份
                                if (DateTime.Now.Month.Equals(1) || DateTime.Now.Month.Equals(2))
                                {
                                    print_month = "01-02";
                                    print_barcode_month = "02";
                                }
                                else if (DateTime.Now.Month.Equals(3) || DateTime.Now.Month.Equals(4))
                                {
                                    print_month = "03-04";
                                    print_barcode_month = "04";
                                }
                                else if (DateTime.Now.Month.Equals(5) || DateTime.Now.Month.Equals(6))
                                {
                                    print_month = "05-06";
                                    print_barcode_month = "06";
                                }
                                else if (DateTime.Now.Month.Equals(7) || DateTime.Now.Month.Equals(8))
                                {
                                    print_month = "07-08";
                                    print_barcode_month = "08";
                                }
                                else if (DateTime.Now.Month.Equals(9) || DateTime.Now.Month.Equals(10))
                                {
                                    print_month = "09-10";
                                    print_barcode_month = "10";
                                }
                                else if (DateTime.Now.Month.Equals(11) || DateTime.Now.Month.Equals(12))
                                {
                                    print_month = "11-12";
                                    print_barcode_month = "12";
                                }

                                //一維碼 內容
                                string str_barcode = "*" + (int.Parse(DateTime.Now.Year.ToString()) - 1911).ToString() + print_barcode_month + str_invoicenumber + random_no + "*";

                                //產生條碼
                                //一維
                                BarcodeWriter writer = new BarcodeWriter();
                                writer.Format = BarcodeFormat.CODE_39;
                                //label_test.Text = str_barcode;
                                Bitmap img = writer.Write(str_barcode);
                                img.Save(save_file + "barcode.jpg");
                                //左QRCode
                                QRCodeGenerator left_gen = new QRCodeGenerator();
                                QRCodeData left_qrcodedata;
                                QRCode left_code;

                                left_qrcodedata = left_gen.CreateQrCode(str_left_qrcode, QRCodeGenerator.ECCLevel.H);
                                left_code = new QRCode(left_qrcodedata);
                                left_code.GetGraphic(41).Save(save_file + "left_code.jpg");

                                //右QRCode
                                QRCodeGenerator right_gen = new QRCodeGenerator();
                                QRCodeData right_qrcodedata;
                                QRCode right_code;

                                right_qrcodedata = right_gen.CreateQrCode(str_right_qrcode, QRCodeGenerator.ECCLevel.H);
                                right_code = new QRCode(right_qrcodedata);
                                right_code.GetGraphic(41).Save(save_file + "right_code.jpg");
                                //const string folder = @"D:\Code_visual\InvoicePrint\bin\Debug";
                                //發票 5.7 * 9 cm 
                                // Image img_mix = Image.FromFile("img_ini.jpg");
                                // Image img_barcode = Image.FromFile(Path.Combine(save_file, "barcode.jpg"));
                                //  Image img_lqrcode = Image.FromFile(Path.Combine(save_file, "left_code.jpg"));
                                // Image img_rqrcode = Image.FromFile(Path.Combine(save_file, "right_code.jpg"));


                                /*
                                                Font f = new Font("宋體", 8);
                                                Brush b = new SolidBrush(Color.Black);

                                                Font f2 = new Font("宋體", 35);
                                                Font f3 = new Font("宋體", 25);
                                                Font f4 = new Font("宋體", 20);

                                                graphics.DrawString("阿立圓山玩具模型店", f4, b, 35, 120);
                                                //graphics.DrawString("微縮世界", f3, b, 100, 120);
                                                graphics.DrawString("電子發票證明聯", f3, b, 30, 150);
                                                graphics.DrawString(DateTime.Now.ToLongDateString(), f2, b, 25, 180);
                                                graphics.DrawString("AB-" + invoice_number,f2, b, 25, 220);

                                                graphics.DrawString(invoice_date+"  "+invoice_time, f, b, 35, 270);
                                                graphics.DrawString("隨機碼 "+random_no.ToString()+"\t  總計 "+int_totalamount.ToString(), f, b, 35, 285);
                                                graphics.DrawString("賣方" + seller_id+"\t"+"買方"+buyer_id, f, b, 35, 300);

                                                graphics.DrawImage(img_barcode, 30, 300, 270, 50);
                                                graphics.DrawImage(img_lqrcode, 30, 350, 120, 120);
                                                graphics.DrawImage(img_rqrcode, 170, 350, 120, 120);


                                                picbx_invoice.Image = img_mix;
                                */
                                //發票 5.7 * 9 cm 
                                //img_ini.jpg 空白圖片
                                Image img_mix = Image.FromFile(@".\picture\img_ini.jpg");

                                Image img_barcode = img;
                                Image img_lqrcode = left_code.GetGraphic(41);
                                Image img_rqrcode = right_code.GetGraphic(41);
                                Graphics graphics = Graphics.FromImage(img_mix);

                                Font f = new Font("宋體", 250);
                                Brush b = new SolidBrush(Color.Black);

                                Font f2 = new Font("宋體", 680);
                                Font f3 = new Font("宋體", 620);
                                Font f4 = new Font("宋體", 570);
                                Font f5 = new Font("宋體", 470);
                                Font f6 = new Font("宋體", 650);

                                // graphics.DrawString("阿立圓山玩具模型店", f5, b, 100, 800);
                                if (combx_shop.Text == "微縮世界")
                                {
                                    graphics.DrawString("微縮世界", f6, b, 1375, 700);
                                }
                                else
                                {
                                    graphics.DrawString("阿立圓山玩具模型店", f5, b, 100, 800);
                                }
                                graphics.DrawString("電子發票證明聯", f4, b, 300, 1600);
                                graphics.DrawString((int.Parse(DateTime.Now.Year.ToString()) - 1911).ToString() + "年" + print_month + "月", f3, b, 700, 2500);

                                graphics.DrawString("AB-" + invoice_number, f2, b, 500, 3350);
                                graphics.DrawString(invoice_date + "  " + invoice_time, f, b, 700, 4325);
                                graphics.DrawString("隨機碼 " + random_no.ToString() + "\t\t  總計 " + int_totalamount.ToString(), f, b, 700, 4725);

                                if (buyer_id == "00000000")
                                {
                                    graphics.DrawString("賣方" + seller_id, f, b, 700, 5100);
                                }
                                else
                                {
                                    graphics.DrawString("賣方" + seller_id + "\t" + "買方" + buyer_id, f, b, 700, 5100);
                                }
                                graphics.DrawImage(img_barcode, 900, 5600, 5000, 1000);
                                graphics.DrawImage(img_lqrcode, 900, 6600, 2500, 2500);
                                graphics.DrawImage(img_rqrcode, 3600, 6600, 2500, 2500);

                                GC.Collect();
                                //產生出來的檔案後存入系統裡 檔名為發票號碼
                                img_mix.Save(save_file + "mix_code.jpg");
                                img_mix.Save(save_file + invoice_number+"again"+ ".jpg");
                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            MessageBox.Show("隨機碼錯誤");
                        }
                    }
                    else
                    {
                        MessageBox.Show("發票號碼長度錯誤");
                    }
                }
                else
                {
                    MessageBox.Show("請輸入資料");
                }
            }
            else
            {
                MessageBox.Show("請輸入資料");
            }
        }

        private void btn_print_Click(object sender, EventArgs e)
        {
            int number_comport = 0;
            //check the com port of the printer on the computer

            //First step : get the available com port on the computer
         /*   //easier way
            string[] list_comport = SerialPort.GetPortNames();

            foreach (string port in list_comport)
            {
                txtbx_test.Text += port.ToString() + Environment.NewLine;
            }
         */
            //detail information of the com port
            int i = 0;
            string[] name_comport = new string[10];
            string[] des_comport = new string[10]; ;
            var searcher = new ManagementObjectSearcher("SELECT DeviceID,Caption FROM WIN32_SerialPort");
            
            foreach(ManagementObject comport in searcher.Get())
            {
                name_comport[i] = comport.GetPropertyValue("DeviceID").ToString();
                des_comport[i] = comport.GetPropertyValue("Caption").ToString();
                txtbx_test.Text += name_comport[i] + des_comport[i] + Environment.NewLine;
                i++;                
            }

            //get the com port printer is using 
   /*         try
            {
                if (des_comport[i].Equals("影印機名稱"))
                {
                }
            }
            catch { 
                MessageBox.Show("找不到影印機，請確認影印機COM PORT");
            }
*/
            // the method on the Internet            
            StreamReader streamToPrint;
            string filePath = "";
            try
            {
                streamToPrint = new StreamReader(filePath);
                try
                {                                   
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
                    // Print the document.
                    pd.Print();
                }
                finally
                {
                    streamToPrint.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}
