using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bar
{
    public partial class AddCompo : Form
    {
        public AddCompo()
        {
            this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            using (SqlConnection conn = ConnectDB.connectDB_TEAMDB())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SELECT Component from [dbo].[Component] where [Component_Barcode] = @ComponentBarcode";
                    cmd.Parameters.Add("@ComponentBarcode", SqlDbType.VarChar).Value = ComponentBarcode.Text;
                    cmd.Parameters.Add("@ComboBoxSelected", SqlDbType.Int).Value = comboBox1.SelectedIndex + 1;
                    try
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                ComponentName.Text = dr[0].ToString();
                            }
                            else
                                MessageBox.Show("부품의 이름을 입력해주세요");

                        }

                    }
                    catch (Exception ex)
                    {

                        Log.writeLog(ex.ToString());
                    }
                    finally { conn.Close(); }   

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
         
                using (SqlConnection conn = ConnectDB.connectDB_TEAMDB())
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT Component_barcode FROM [dbo].[Component] WHERE [Component_Barcode] = @ComponentBarcode AND [Category] = @ComboBoxSelected";
                    cmd.Parameters.Add("@ComponentBarcode", SqlDbType.VarChar).Value = ComponentBarcode.Text.Trim();
                    cmd.Parameters.Add("@ComboBoxSelected", SqlDbType.Int).Value = comboBox1.SelectedIndex + 1;
                    try
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                try
                                {
                                    dr.Close();
                                    cmd.CommandText = "UPDATE [dbo].[Component] SET [Component] = @ComponentName WHERE [Component_Barcode] = @ComponentBarcode AND [category] = @ComboBoxSelected";
                                    cmd.Parameters.Clear();
                                    cmd.Parameters.Add("@ComponentName", SqlDbType.VarChar).Value= ComponentName.Text.Trim();
                                    cmd.Parameters.Add("@ComponentBarcode", SqlDbType.VarChar).Value = ComponentBarcode.Text.Trim();
                                    cmd.Parameters.Add("@ComboBoxSelected", SqlDbType.Int).Value = comboBox1.SelectedIndex + 1;
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("업데이트가 완료되었습니다");
                                }
                                catch (Exception ex)
                                {
                                    Log.writeLog(ex.ToString());
                                }                              
                            }
                            else
                            {
                                try
                                {
                                    dr.Close();
                                    cmd.CommandText = "INSERT INTO [dbo].[Component] ([Component], [Component_Barcode], [Category]) VALUES (@ComponentName, @ComponentBarcode, @ComBoboxSelected)";
                                    cmd.Parameters.Clear();
                                    cmd.Parameters.Add("@ComponentName", SqlDbType.VarChar).Value = ComponentName.Text.Trim();
                                    cmd.Parameters.Add("@ComponentBarcode", SqlDbType.VarChar).Value = ComponentBarcode.Text.Trim();
                                    cmd.Parameters.Add("@ComboBoxSelected", SqlDbType.Int).Value = comboBox1.SelectedIndex + 1;
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("저장이 완료되었습니다");
                                }
                                catch(Exception ex) 
                                {
                                    MessageBox.Show("부품 카테고리를 확인해 주세요");
                                    Log.writeLog(ex.ToString());
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        Log.writeLog(ex.ToString()); 
                    }
                    finally
                    {
                        ComponentBarcode.Text = "";
                        ComponentName.Text = "";
                    }

                    }
                }
            }
           
    }

}