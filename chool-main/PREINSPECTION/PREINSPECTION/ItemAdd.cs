using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CoreScanner;
using System.Xml;

namespace PREINSPECTION
{
    public partial class ItemAdd : Form
    {
        string itemSelectComboText;
        CCoreScannerClass cCoreScannerClass;
        XmlDocument xmlDoc = new XmlDocument();
        public ItemAdd()
        {
            InitializeComponent();

        
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = ConnectDB.connectDB())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Select * from item " +
                                          "where barcode = @barcode";
                    command.Parameters.Add("@barcode", SqlDbType.VarChar).Value = barcodeText.Text;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            if (reader.Read())
                            {
                                MessageBox.Show("중복된 바코드가 있습니다");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.writeLog(ex.ToString());
                        }

                    }
                }
            }
            if (itemSelectCombo.SelectedItem == null || itemTextBox.Text=="" || barcodeText.Text=="")
            {
                MessageBox.Show("제품 그룹을 선택하거나 바코드를 입력하세요");
                return;
            }
            else
            {
                itemSelectComboText = itemSelectCombo.SelectedItem.ToString();
                    using (SqlConnection connection = ConnectDB.connectDB())
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandText = "Select name from part where name = @item_group";
                            command.Parameters.Add("@item_group", SqlDbType.VarChar).Value = itemSelectComboText;
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                try
                                {
                                    if (reader.Read())
                                    {
                                        MessageBox.Show("중복된 제품이 있습니다");

                                    }
                                }
                                catch (Exception ex)
                                {
                                    Log.writeLog(ex.ToString());
                                }

                            }
                        }
                    }
               

                using (SqlConnection connection = ConnectDB.connectDB())
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO item (name, group_id, barcode) " +
                                              "SELECT @name,id,@barcode " +
                                              "FROM item_group " +
                                              "WHERE name = @item_groupName;";
                        command.Parameters.Add("@name", SqlDbType.VarChar).Value = itemTextBox.Text;
                        command.Parameters.Add("@item_groupName", SqlDbType.VarChar).Value = itemSelectComboText;
                        command.Parameters.Add("@barcode", SqlDbType.VarChar).Value = barcodeText.Text;
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("입력에 성공하였습니다.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("제품 추가에 실패했습니다.");
                            Log.writeLog(ex.ToString());
                        }
                    }
                }
            }
            
           
        }
        void OnBarcodeEvent(short eventType, ref string pscanData)
        {

            string barcode = pscanData;
            xmlDoc.LoadXml(barcode);
            XmlNode modelnumber = xmlDoc.SelectSingleNode(".//rawdata");
            string modelnumberText = modelnumber.InnerText;
            string[] hexValueArray = modelnumberText.Split(' ');

            string deximalValues = HexToAscii(hexValueArray);
            this.Invoke((MethodInvoker)delegate
            {
                barcodeText.Text = deximalValues.Trim();

            });
            barcodeText.Enabled = false;
        }

        static string HexToAscii(string[] hexArray)
        {
            string asciiString = "";
            foreach (string hexValue in hexArray)
            {
                if (hexValue.StartsWith("0x"))
                {
                    int decimalValue = Convert.ToInt32(hexValue, 16);
                    if (decimalValue > 47 && decimalValue < 127)
                    {
                        char asciiChar = (char)decimalValue;
                        asciiString += asciiChar;
                    }
                }
            }
            return asciiString;
        }
        private void ItemAdd_Load(object sender, EventArgs e)
        {
            barcodeText.Enabled = false;
            this.WindowState = FormWindowState.Maximized;
            using (SqlConnection connection = ConnectDB.connectDB())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Select name from item_group";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                itemSelectCombo.Items.Add(reader[0].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.writeLog(ex.ToString());
                        }
                    }
                }
            }
            try
            {
                cCoreScannerClass = new CCoreScannerClass();

                short[] scannerTypes = new short[1];
                scannerTypes[0] = 2;
                short numberOfScannerTypes = 1;
                int status;

                cCoreScannerClass.Open(0, scannerTypes, numberOfScannerTypes, out status);
                cCoreScannerClass.BarcodeEvent += OnBarcodeEvent;

                int opcode = 1001;
                string outXML;
                string inXML = "<inArgs>" +
                                "<cmdArgs>" +
                                    "<arg-int>1</arg-int>" +
                                    "<arg-int>1</arg-int>" +
                                "</cmdArgs>" +
                                "</inArgs>";
                cCoreScannerClass.ExecCommand(opcode, ref inXML, out outXML, out status);
                Console.WriteLine(outXML);
            }
            catch (Exception ex)
            {
                Log.writeLog(ex.ToString());
            }
        }
    }
}
