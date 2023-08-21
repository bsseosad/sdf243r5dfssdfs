using CoreScanner;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml;

namespace PREINSPECTION
{
    public partial class UpdatePart : Form
    {
        XmlDocument xmlDoc = new XmlDocument();
        CCoreScannerClass cCoreScannerClass;
        string barcodetext = "";
        public UpdatePart()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();

            barcodeText.Enabled = false;
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
            using (SqlConnection connection = ConnectDB.connectDB())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Select name from part_group";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                partGroupSelect.Items.Add(reader[0].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.writeLog(ex.ToString());
                        }
                    }
                }
            }
        }
        private void updateButton_Click(object sender, EventArgs e)
        {


            barcodetext = barcodeText.Text.Trim();
            using (SqlConnection connection = ConnectDB.connectDB())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "Select * from part " +
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
            if (partCombo.SelectedItem == null)
            {
                MessageBox.Show("부품을 선택하세요");
            }
            else
            {
                string partName = partCombo.SelectedItem.ToString();    
                using (SqlConnection connection = ConnectDB.connectDB())
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {

                        command.CommandText = "update part " +
                                              "set barcode = @barcodetext " +
                                              "where name = @parttext";
                        command.Parameters.Add("@barcodetext", SqlDbType.VarChar).Value = barcodetext;
                        command.Parameters.Add("@parttext", SqlDbType.VarChar).Value = partName;
                        try
                        {
                            int affected = command.ExecuteNonQuery();
                            if (affected != 0)
                            {
                                MessageBox.Show("저장됐습니다.");
                            }
                            else
                            {
                                MessageBox.Show("저장에 실패했습니다.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.writeLog(ex.ToString());
                        }
                    }
                }
            }
        }
        void OnBarcodeEvent(short eventType, ref string pscanData)
        {
            barcodeText.Enabled = true;
            string barcode = pscanData;
            xmlDoc.LoadXml(barcode);
            XmlNode modelnumber = xmlDoc.SelectSingleNode(".//rawdata");
            string modelnumberText = modelnumber.InnerText;
            string[] hexValueArray = modelnumberText.Split(' ');

            string deximalValues = HexToAscii(hexValueArray);
           
            this.Invoke((MethodInvoker)delegate
            {
                barcodeText.Text = deximalValues.Trim(); ;

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

        private void partGroupSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            partCombo.Items.Clear();
            string selectedItem = partGroupSelect.SelectedItem.ToString();

            using (SqlConnection connection = ConnectDB.connectDB())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT part.name FROM part_group INNER JOIN " +
                                           "part ON part_group.id = part.group_id " +
                                           "WHERE part_group.name = @SelectedItem";
                    command.Parameters.Add("@SelectedItem", SqlDbType.VarChar).Value = selectedItem;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                partCombo.Items.Add(reader[0].ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.writeLog(ex.ToString());
                        }
                    }
                }
            }
        }
    }
}

