using CoreScanner;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml;

namespace PREINSPECTION
{
    public partial class itemSelect : Form
    {
        CCoreScannerClass cCoreScannerClass;
        XmlDocument xmlDoc = new XmlDocument();
        UpdatePart updatepart = null;//부품 수정하는 폼
        addPart addpart = null;//부품을 추가하는 폼
        PartSearch partsearch = null;
        ItemAdd itemadd = null;
        Mapping mapping = null;
        public itemSelect()
        {
            InitializeComponent();
            
        }
        void OnBarcodeEvent(short eventType, ref string pscanData)
        {
        
            string barcode = pscanData;
            xmlDoc.LoadXml(barcode);
            XmlNode modelnumber = xmlDoc.SelectSingleNode(".//rawdata");
            string modelnumberText = modelnumber.InnerText;
            string[] hexValueArray = modelnumberText.Split(' ');

            string deximalValues = HexToAscii(hexValueArray);
          //  string inverterBarcode = deximalValues.Substring(22).Trim();

            using (SqlConnection connection = ConnectDB.connectDB())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT name FROM item " +
                                           "WHERE barcode = @inverterBarcode";
                    command.Parameters.Add("@inverterBarcode", SqlDbType.VarChar).Value = deximalValues;  //바꿀것
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            if (reader.Read())
                            {
                                this.Invoke((MethodInvoker)delegate
                                {
                                    
                                    try
                                    {                                     
                                        partsearch = new PartSearch(deximalValues);
                                        partsearch.ShowDialog();
                                        return;

                                    }
                                    catch (Exception ex)
                                    {
                                        Log.writeLog(ex.ToString());
                                    }

                                });
                            }
                            else
                            {
                                MessageBox.Show("없는바코드입니다하하");
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
        private void itemSelect_Load(object sender, EventArgs e)
        {
            
            this.WindowState = FormWindowState.Maximized;
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
            }
            catch (Exception ex)
            {
                Log.writeLog(ex.ToString());
            }

            using (SqlConnection connection = ConnectDB.connectDB())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT name FROM item_group";
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                itemGroupBox.Items.Add(reader[0].ToString());
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
        private void itemGroupBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            itemBox.Items.Clear();
            string selectedItem = itemGroupBox.SelectedItem.ToString();

            using (SqlConnection connection = ConnectDB.connectDB())
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = @"SELECT item.name FROM item_group INNER JOIN " +
                        "item ON item_group.id = item.group_id " +
                        "WHERE item_group.name = @SelectedItem";
                    command.Parameters.Add("@SelectedItem", SqlDbType.VarChar).Value = selectedItem;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                itemBox.Items.Add(reader[0].ToString());
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
        private void partAdd_Click(object sender, EventArgs e)
        {
            try
            {
                addpart = new addPart();
                addpart.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.writeLog(ex.ToString());
            }
        }
        private void updatePart_Click(object sender, EventArgs e)
        {
            try
            {           
                updatepart = new UpdatePart();
                updatepart.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.writeLog(ex.ToString());
            }
        }
        private void itemAdd_Click(object sender, EventArgs e)
        {
            try
            {         
                itemadd = new ItemAdd();
                itemadd.ShowDialog();
            }
            catch (Exception ex)
            {
                Log.writeLog(ex.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (itemBox.SelectedItem != null)
                {
                    string name;
                    name = itemBox.SelectedItem.ToString();
                    mapping = new Mapping(name);
                    mapping.ShowDialog();
                }
                else
                {
                    MessageBox.Show("제품을 선택하세요");
                }
            }
            catch (Exception ex)
            {
                Log.writeLog(ex.ToString());
            }
        }

        private void itemSelect_Deactivate(object sender, EventArgs e)
        {
            cCoreScannerClass.BarcodeEvent -= OnBarcodeEvent;
        }
    }
}
