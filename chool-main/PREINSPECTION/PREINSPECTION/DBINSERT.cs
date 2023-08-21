using CoreScanner;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Xml;

namespace PREINSPECTION
{
    public partial class DBINSERT : Form
    {
        string barcode;
        PartSearch partsearch = null;
        string[] partList;
        string operatorName;
        CCoreScannerClass cCoreScannerClass;
        XmlDocument xmlDoc = new XmlDocument();
        public DBINSERT(string[] partList, string barcode)
        {
            this.barcode = barcode;
            this.partList = partList;

            InitializeComponent();
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
                Console.WriteLine(outXML);
            }
            catch (Exception ex)
            {
                Log.writeLog(ex.ToString());
            }
        }
        void OnBarcodeEvent(short eventType, ref string pscanData)
        {

            string barcode = pscanData;
            xmlDoc.LoadXml(barcode);
            XmlNode modelnumber = xmlDoc.SelectSingleNode(".//rawdata");
            string modelnumberText = modelnumber.InnerText;
            string[] hexValueArray = modelnumberText.Split(' ');

            string deximalValues = HexToAscii(hexValueArray).Trim();

            this.Invoke((MethodInvoker)delegate
            {
                operatorName = deximalValues;
            });

        }

        static string HexToAscii(string[] hexArray)
        {
            string asciiString = "";
            foreach (string hexValue in hexArray)
            {
                if (hexValue.StartsWith("0x"))
                {
                    int decimalValue = Convert.ToInt32(hexValue, 16);
                    if (decimalValue > 48 && decimalValue < 127)
                    {
                        char asciiChar = (char)decimalValue;
                        asciiString += asciiChar;
                    }
                }
            }
            return asciiString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;
            if (operatorName == null)
            {
                MessageBox.Show("작업자 바코드를 찍어주세요");
            }
            else
            {
                using (SqlConnection connection = ConnectDB.connectDB())
                {
                    using (SqlCommand command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO RESULT (operator, time, igbt,diode,콘덴서,리액터,ct) " +
                                             "Values(@operatorName, @time, @igbt, @diode, @cap, @reac, @ct)";
                        command.Parameters.Add("@operatorName", SqlDbType.VarChar).Value = operatorName;
                        command.Parameters.Add("@time", SqlDbType.DateTime).Value = currentTime;
                        command.Parameters.Add("@igbt", SqlDbType.VarChar).Value = partList[0];
                        command.Parameters.Add("@diode", SqlDbType.VarChar).Value = partList[1];
                        command.Parameters.Add("@cap", SqlDbType.VarChar).Value = partList[2];
                        command.Parameters.Add("@reac", SqlDbType.VarChar).Value = partList[3];
                        command.Parameters.Add("@ct", SqlDbType.VarChar).Value = partList[4];

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("등록하였습니다.");
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
    }
}
