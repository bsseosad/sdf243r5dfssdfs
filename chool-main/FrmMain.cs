using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlClient;

using System.Numerics;
using System.Drawing.Printing;

using System.Data.OleDb;

using Microsoft.Win32.TaskScheduler;
using System.Net.Sockets;
using System.Net;
using System.Security.Cryptography;
using System.Diagnostics.Metrics;
using System.Diagnostics.Eventing.Reader;
using System.Diagnostics;
using System.Data.SqlTypes;

namespace INV_CollectSpec
{
    public partial class FrmMain : Form
    {
        private Thread m_tMonitor;
        private string m_strIP;

        private static Mutex mutex = null;
        private string m_strLine;
        private int m_iEq;

        public FrmMain()
        {
            InitializeComponent();

            AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;
        }

        static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
        {
            // 예외 처리
            Exception ex = (Exception)e.ExceptionObject;

            DirectoryInfo di = new DirectoryInfo(".\\log\\");
            if (di.Exists == false)
                di.Create();

            string logFileName = "";

            logFileName = DateTime.Now.ToString("yyyyMMdd") + ".log";

            string logline = null;

            logline = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "," + ex.Message + "\r\n";

            //FileStream writeData = null;
            StreamWriter sw = null;

            try
            {
                //writeData = new FileStream(".\\log\\" + logFileName, FileMode.Append, FileAccess.Write, FileShare.Read);
                //writeData.Write(Encoding.UTF8.GetBytes(logline), 0, Encoding.UTF8.GetByteCount(logline));

                sw = new StreamWriter(".\\log\\" + logFileName, true);
                sw.AutoFlush = true;

                sw.WriteLine(logline);
            }
            catch (Exception ex2)
            {
                using (SqlConnection conn = new SqlConnection("SERVER = 172.28.140.136, 1433; DATABASE = DB_INV; UID = sa; PWD = 1qaz2wsx3edc"))
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"INSERT INTO DB_INV.dbo.tbl_LOG VALUES (@time,'D36','INSP',@contents)";
                        cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        cmd.Parameters.AddWithValue("@contents", ex2.ToString());

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {
                            cmd.Dispose();
                        }
                    }
                }
            }
            finally
            {
                //writeData.Close();
                sw.Dispose();
            }

            // 프로그램 종료 방지 등의 추가 로직 처리
        }

        private void checkDuplicate()
        {
            const string appName = "INV_TestSPEC";

            // Create a new Mutex object with a unique name to prevent duplicate execution
            bool createdNew;
            mutex = new Mutex(true, appName, out createdNew);

            if (mutex != null)
            {
                bool isMutexOwned = false;
                try
                {
                    isMutexOwned = mutex.WaitOne(0);
                }
                catch (AbandonedMutexException)
                {
                    // If the previous owner of the mutex terminated without releasing it, the mutex can be acquired
                    isMutexOwned = true;
                }

                if (isMutexOwned)
                {
                    mutex.ReleaseMutex();
                }
            }

            if (!createdNew)
            {
                // If the mutex already exists, another instance of the program is already running
                // Show a message box and exit the application
                //MessageBox.Show("이미 동일한 프로그램이 실행되어 있습니다.", "중복 실행", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                System.Windows.Forms.Application.Exit();
            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            checkDuplicate();

            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;

            m_strIP = getCurrentIP();

            if (m_strIP.IndexOf("10.") != 0)
                setStartupTaskScheduler();

            m_strLine = string.Empty;
            m_iEq = -1;

            using (SqlConnection conn = connectDB_TEAMDB())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT DATAID, DATAVALUE1 FROM [DB_INV].[dbo].[tbl_GCM] WHERE CATEGORY = 'INSP_SPEC' AND DATAID LIKE 'LINE_IP_%'";

                    try
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                if (dr[1].ToString().Equals(m_strIP) == true)
                                {
                                    string strTemp = string.Empty;
                                    strTemp = dr[0].ToString().Split('_')[2];

                                    string[] strTempArr = strTemp.Split('-');
                                    if (strTempArr.Length == 2)
                                    {
                                        m_strLine = strTempArr[0];
                                        m_iEq = int.Parse(strTempArr[1]);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        writeLog(ex.ToString());
                    }
                }
            }

            if ((m_strLine == string.Empty) || (m_iEq == -1))
            {
                MessageBox.Show("현재 검사대에 대한 정의가 되어 있지 않습니다.", "검사대 미정의", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }

            textBox_Path.Text = string.Empty;

            using (SqlConnection conn = connectDB_TEAMDB())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"SELECT DATAVALUE1 FROM [DB_INV].[dbo].[tbl_GCM] WHERE CATEGORY = 'INSP_SPEC' AND DATAID = 'MDB_PATH_{m_strLine}-{m_iEq}'";

                    try
                    {
                        var vv = cmd.ExecuteScalar();

                        if (vv == null)
                        {
                            if (m_strLine == string.Empty)
                            {
                                MessageBox.Show("현재 검사대의 검사Spec파일(MDB) 위치가 선택 되어 있지 않습니다.", "검사Spec파일 미정의", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            textBox_Path.Text = vv.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        writeLog(ex.ToString());
                    }
                }
            }

            m_tMonitor = new Thread(monitor);
            m_tMonitor.Start();

            this.WindowState = FormWindowState.Minimized;
        }

        public SqlConnection connectDB_MES()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection("data source=165.243.100.219;Initial Catalog=LSISDB;uid=app_mesuser;pwd=mes#app1793; Max Pool Size=200;");
                sqlConnection.Open();
                return sqlConnection;
            }
            catch (Exception ex)
            {
                writeLog(ex.ToString());
                return null;
            }
        }

        private void setStartupTaskScheduler()
        {
            TaskService ts = new TaskService();
            ts.RootFolder.DeleteTask("INV_CollectSpec", false);

            TaskDefinition td = ts.NewTask(); //정의 생성.
            td.RegistrationInfo.Description = "INV 검사 Spec 수집 프로그램"; //설명.

            td.Principal.UserId = string.Concat(Environment.UserDomainName, "\\", Environment.UserName); //계정
            td.Principal.LogonType = TaskLogonType.InteractiveToken;
            td.Principal.RunLevel = TaskRunLevel.Highest;

            /*DailyTrigger dt = new DailyTrigger(); //날짜별로 실행.
            dt.StartBoundary = DateTime.Today + TimeSpan.FromSeconds(10);
            dt.DaysInterval = 2;
            td.Triggers.Add(dt);*/

            LogonTrigger lt = new LogonTrigger(); //로그인할때 실행
            td.Triggers.Add(lt);

            //BootTrigger bt = new BootTrigger(); //부팅으로 조건 설정.
            //bt.Delay = new TimeSpan(0, 3, 0); //부팅하고 3분 이후 실행.
            //td.Triggers.Add(bt);

            td.Actions.Add(new ExecAction(System.Windows.Forms.Application.ExecutablePath)); //프로그램, 인자등록.

            try
            {
                ts.RootFolder.RegisterTaskDefinition("INV_CollectSpec", td); //이름으로 등록.  
            }
            catch (Exception ex)
            {
                writeLog(ex.ToString());
            }

        }

        private string getCurrentIP()
        {
            IPAddress[] ipv4Addresses = Array.FindAll(
                Dns.GetHostEntry(string.Empty).AddressList,
                a => a.AddressFamily == AddressFamily.InterNetwork);

            if (ipv4Addresses.Length == 0)
                return "192.168.0.1";
            else
            {
                for (int i = 0; i < ipv4Addresses.Length; i++)
                {
                    if (ipv4Addresses[i].ToString().StartsWith("172.28.") == true)
                        return ipv4Addresses[i].ToString();
                }
            }

            return ipv4Addresses[0].ToString();
        }

        private SqlConnection connectDB_FPR()
        {
            SqlConnection sqlConnection_FPR = new SqlConnection("SERVER = 165.244.151.25, 1433; DATABASE = LSIS_MES_FPR; UID = optience_user; PWD = optience#2017");

            try
            {
                sqlConnection_FPR.Open();
                return sqlConnection_FPR;
            }
            catch (Exception e)
            {
                writeLog(e.ToString());
                return null;
            }

        }

        private SqlConnection connectDB_TEAMDB()
        {
            SqlConnection sqlConnection_TEAMDB = new SqlConnection("SERVER = 172.28.140.136, 1433; DATABASE = DB_INV; UID = sa; PWD = 1qaz2wsx3edc");

            try
            {
                sqlConnection_TEAMDB.Open();
                return sqlConnection_TEAMDB;
            }
            catch (Exception e)
            {
                writeLog(e.ToString());
                return null;
            }

        }

        public void writeLog(string strContent)
        {
            DirectoryInfo di = new DirectoryInfo(".\\log\\");
            if (di.Exists == false)
                di.Create();

            string logFileName = "";

            logFileName = DateTime.Now.ToString("yyyyMMdd") + ".log";

            string logline = null;

            logline = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff") + "," + strContent;

            //FileStream writeData = null;
            StreamWriter sw = null;

            try
            {
                //writeData = new FileStream(".\\log\\" + logFileName, FileMode.Append, FileAccess.Write, FileShare.Read);
                //writeData.Write(Encoding.UTF8.GetBytes(logline), 0, Encoding.UTF8.GetByteCount(logline));

                sw = new StreamWriter(".\\log\\" + logFileName, true);
                sw.AutoFlush = true;

                sw.WriteLine(logline);
            }
            catch (Exception ex)
            {
                using (SqlConnection conn = connectDB_TEAMDB())
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"INSERT INTO DB_INV.dbo.tbl_LOG VALUES (@time,'D36','INSP',@contents)";
                        cmd.Parameters.AddWithValue("@time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                        cmd.Parameters.AddWithValue("@contents", $"{strContent},{ex.ToString()}");

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {
                            cmd.Dispose();
                        }
                    }
                }
                return;
            }
            finally
            {
                //writeData.Close();
                sw.Close();
            }
        }

        private void monitor()
        {
            while (true)
            {
                //if ((DateTime.Now.Hour == 12) && (DateTime.Now.Minute > 30))
                {
                    DataTable dtSpecDef = new DataTable();
                    using (SqlConnection conn = connectDB_TEAMDB())
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = @"SELECT * FROM [DB_INV].[dbo].[tbl_INSP_SPEC_DEF] WITH (NOLOCK) WHERE LINE = @line AND EQ = @eq";
                            cmd.Parameters.AddWithValue("@line", m_strLine);
                            cmd.Parameters.AddWithValue("@eq", m_iEq);

                            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                            {
                                try
                                {
                                    da.Fill(dtSpecDef);
                                }
                                catch (Exception ex)
                                {
                                    writeLog(ex.ToString());
                                    Thread.Sleep(1000 * 60 * 60);
                                    continue;
                                }
                            }
                        }
                    }

                    if (dtSpecDef.Rows.Count < 1)
                    {
                        writeLog("DB에서 검사 Spec을 읽을 수 없음");
                        Thread.Sleep(1000 * 60 * 60);
                        continue;
                    }

                    if (dtSpecDef.Rows.Count == 0)
                    {
                        writeLog($"DB에서 검사 Spec 정의를 찾을 수 없음({m_strLine})");
                        Thread.Sleep(1000 * 60 * 60);
                        continue;
                    }
                    else
                    {
                        FileInfo fi = new FileInfo(textBox_Path.Text);
                        if (fi.Exists == false)
                        {
                            writeLog($"검사Spec파일이 없음 [{textBox_Path.Text}]");
                            Thread.Sleep(1000 * 60 * 60);
                            continue;
                        }

                        //최종 데이터 수집시간 확인
                        DateTime dt_Last = DateTime.MinValue;

                        using (SqlConnection conn = connectDB_TEAMDB())
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = @"SELECT [DATAVALUE1] FROM [DB_INV].[dbo].[tbl_GCM] WITH (NOLOCK)
                                                WHERE CATEGORY = 'INSP_SPEC' AND DATAID = 'LAST_WORK_" + m_strLine + "-" + m_iEq.ToString() + "'";

                                var vv = cmd.ExecuteScalar();
                                if (vv != null)
                                    DateTime.TryParse(vv.ToString(), out dt_Last);
                            }
                        }

                        //if ((fi.LastWriteTime > dt_Last) && ((DateTime.Now - fi.LastWriteTime).TotalHours > 1.0))
                        //{
                        //    Thread.Sleep(1000 * 60 * 10);
                        //    continue;
                        //}

                        //여기에 DB에서 해당 검사대의 table명 모두를 불러와야 함
                        Dictionary<string,DataTable> dicSPEC = new Dictionary<string, DataTable>();

                        using (SqlConnection conn = connectDB_TEAMDB())
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = @"SELECT DISTINCT MDB_TABLE FROM [DB_INV].[dbo].[tbl_INSP_SPEC_DEF] WITH (NOLOCK) WHERE LINE = @line AND EQ = @eq";
                                cmd.Parameters.AddWithValue("@line", m_strLine);
                                cmd.Parameters.AddWithValue("@eq", m_iEq);

                                using (SqlDataReader dr = cmd.ExecuteReader())
                                {
                                    try
                                    {
                                        while (dr.Read())
                                        {
                                            DataTable dtTemp = new DataTable();
                                            dicSPEC.Add(dr[0].ToString(), dtTemp);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        writeLog(ex.ToString());
                                    }
                                }
                            }
                        }

                        //검사대에 있는 검사Spec 불러오기
                        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + textBox_Path.Text + ";";
                        OleDbConnection connection = new OleDbConnection(connectionString);

                        try
                        {
                            connection.Open();

                            List<string> lstKeys = dicSPEC.Keys.ToList();

                            foreach (string vv in lstKeys)
                            {
                                string query = $"SELECT * FROM {vv}";
                                using (OleDbCommand command = new OleDbCommand(query, connection))
                                {
                                    using (OleDbDataAdapter da = new OleDbDataAdapter(command))
                                    {
                                        DataTable dt_Temp = new DataTable();
                                        da.Fill(dt_Temp);

                                        if (dt_Temp.Rows.Count > 0)
                                            dicSPEC[vv] = dt_Temp;
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            writeLog(ex.ToString());
                            Thread.Sleep(1000 * 60 * 10);
                            continue;
                        }
                        finally
                        {
                            connection.Close();
                        }

                        DataTable dtInsert = new DataTable();
                        dtInsert.Columns.Add("LINE", typeof(SqlString));
                        dtInsert.Columns.Add("EQ", typeof(SqlInt32));
                        dtInsert.Columns.Add("MODEL", typeof(SqlString));
                        dtInsert.Columns.Add("CATEGORY", typeof(SqlString));
                        dtInsert.Columns.Add("SPEC_NAME", typeof(SqlString));
                        dtInsert.Columns.Add("SPEC_DATA", typeof(SqlString));
                        dtInsert.Columns.Add("DATA_DATETIME", typeof(SqlString));

                        //DataColumn[] primarykey = new DataColumn[5];
                        //primarykey[0] = dtInsert.Columns["LINE"];
                        //primarykey[0] = dtInsert.Columns["EQ"];
                        //primarykey[0] = dtInsert.Columns["MODEL"];
                        //primarykey[0] = dtInsert.Columns["CATEGORY"];
                        //primarykey[0] = dtInsert.Columns["SPEC_NAME"];

                        //dtInsert.PrimaryKey = primarykey;

                        //통상 Case: Spec Table 1개 - D13
                        if (dicSPEC.Count == 1)
                        {
                            DataTable dtSpec = dicSPEC[dicSPEC.Keys.ToList()[0]];

                            for (int i = 0; i < dtSpec.Rows.Count; i++)
                            {
                                if (dtSpec.Rows[i]["MODEL"].ToString().Length < 5)
                                    continue;

                                for (int j = 0; j < dtSpecDef.Rows.Count; j++)
                                {
                                    if (dicSPEC[dtSpecDef.Rows[j]["MDB_TABLE"].ToString()].Columns.Contains(dtSpecDef.Rows[j]["MDB_COL_NAME"].ToString()) == false)
                                    {
                                        writeLog($"Spec Column 없음,{m_strLine},{m_iEq},{dtSpecDef.Rows[j]["CATEGORY"].ToString()},{dtSpecDef.Rows[j]["SPEC_NAME"].ToString()},{dtSpecDef.Rows[j]["MDB_COL_NAME"].ToString()}");
                                        continue;
                                    }

                                    string strData = "";
                                    if (dicSPEC[dtSpecDef.Rows[j]["MDB_TABLE"].ToString()].Rows[i][dtSpecDef.Rows[j]["MDB_COL_NAME"].ToString()] != null)
                                        strData = dicSPEC[dtSpecDef.Rows[j]["MDB_TABLE"].ToString()].Rows[i][dtSpecDef.Rows[j]["MDB_COL_NAME"].ToString()].ToString();
                                    else
                                    {
                                        int aa = 0;
                                    }

                                    try
                                    {
                                        dtInsert.Rows.Add(m_strLine, m_iEq, dicSPEC["TestSpec"].Rows[i]["MODEL"].ToString(), dtSpecDef.Rows[j]["CATEGORY"].ToString(), dtSpecDef.Rows[j]["SPEC_NAME"].ToString(),
                                            strData, fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
                                    }
                                    catch (Exception ex)
                                    {
                                        ex.ToString();
                                    }
                                }
                            }
                        }
                        else if (dicSPEC.Count == 2) // D31, D35, D36 Case
                        {
                            string strMainTableName = "TEST_SPEC";
                            string strModelName = "INV_MODEL";

                            if ((m_strLine == "D35") || (m_strLine == "D36"))
                            {
                                strMainTableName = "TEST_SPEC";
                                strModelName = "INV_MODEL";
                            }
                            else if ((m_strLine == "D31"))
                            {
                                strMainTableName = "TESTSPEC";
                                strModelName = "MODEL";
                            }
                            else
                            {
                                writeLog($"아직 미정의된 설비입니다. {m_strLine}");
                                Thread.Sleep(1000 * 60 * 60);
                                continue;
                            }

                            if (dicSPEC.ContainsKey(strMainTableName) == false)
                            {
                                writeLog($"{strMainTableName} 테이블이 없는 비정상 Case입니다.");
                                Thread.Sleep(1000 * 60 * 60);
                                continue;
                            }

                            //foreach (KeyValuePair<string, DataTable> kvp in dicSPEC)
                            for (int i=0;i< dicSPEC[strMainTableName].Rows.Count;i++)
                            {
                                if (dicSPEC[strMainTableName].Rows[i][strModelName].ToString().Length < 5)
                                    continue;

                                for (int j = 0; j < dtSpecDef.Rows.Count; j++)
                                {
                                    if (dicSPEC[dtSpecDef.Rows[j]["MDB_TABLE"].ToString()].Columns.Contains(dtSpecDef.Rows[j]["MDB_COL_NAME"].ToString()) == false)
                                    {
                                        writeLog($"Spec Column 없음,{m_strLine},{m_iEq},{dtSpecDef.Rows[j]["CATEGORY"].ToString()},{dtSpecDef.Rows[j]["SPEC_NAME"].ToString()},{dtSpecDef.Rows[j]["MDB_COL_NAME"].ToString()}");
                                        continue;
                                    }

                                    string strData = "";
                                    int iIdx = -1;

                                    if (dtSpecDef.Rows[j]["MDB_TABLE"].ToString() != strMainTableName)
                                    {
                                        for (int k = 0; k < dicSPEC[dtSpecDef.Rows[j]["MDB_TABLE"].ToString()].Rows.Count; k++)
                                        {
                                            if (dicSPEC[dtSpecDef.Rows[j]["MDB_TABLE"].ToString()].Columns.Contains(strModelName) == false)
                                                break;

                                            if (dicSPEC[strMainTableName].Rows[i][strModelName].ToString() == dicSPEC[dtSpecDef.Rows[j]["MDB_TABLE"].ToString()].Rows[k][strModelName].ToString())
                                            {
                                                iIdx = k;
                                                break;
                                            }
                                        }
                                    }
                                    else
                                        iIdx = i;

                                    if (iIdx == -1)
                                    {
                                        strData = "";
                                    }
                                    else
                                    {
                                        if (dicSPEC[dtSpecDef.Rows[j]["MDB_TABLE"].ToString()].Rows[iIdx][dtSpecDef.Rows[j]["MDB_COL_NAME"].ToString()] != null)
                                            strData = dicSPEC[dtSpecDef.Rows[j]["MDB_TABLE"].ToString()].Rows[iIdx][dtSpecDef.Rows[j]["MDB_COL_NAME"].ToString()].ToString();
                                        else
                                        {
                                            strData = "";
                                        }
                                    }

                                    try
                                    {
                                        dtInsert.Rows.Add(m_strLine, m_iEq, dicSPEC[strMainTableName].Rows[i][strModelName].ToString(), dtSpecDef.Rows[j]["CATEGORY"].ToString(), dtSpecDef.Rows[j]["SPEC_NAME"].ToString(),
                                            strData, fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
                                    }
                                    catch (Exception ex)
                                    {
                                        ex.ToString();
                                    }
                                }
                            }
                        }
                        else //아직 정의되지 않은 Case
                        {
                            writeLog($"정의되지 않은 Case입니다. Spec Table 갯수가 {dicSPEC.Count}개 입니다.");
                            Thread.Sleep(1000 * 60 * 60);
                            continue;
                        }

                        //기존에 모두 올리는 것에서 변경된 것만 올리는 것으로 수정...
                        int iModifyRowCount = 0;

                        List<string> lstInputContents = new List<string>();
                        string strModifyContents = string.Empty;

                        DataTable dtLastData = new DataTable();

                        using (SqlConnection conn = connectDB_TEAMDB())
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = $"SELECT LINE, EQ, MODEL, CATEGORY, SPEC_NAME, SPEC_DATA FROM" +
                                    $" (SELECT *, ROW_NUMBER() OVER (PARTITION BY LINE, EQ, MODEL, CATEGORY, SPEC_NAME ORDER BY DATA_DATETIME DESC) AS rn" +
                                    $"  FROM [DB_INV].[dbo].[tbl_INSP_SPEC_DAT-{m_strLine}]) AS sub WHERE rn = 1";

                                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                                {
                                    try
                                    {
                                        da.Fill(dtLastData);
                                    }
                                    catch (Exception ex)
                                    {
                                        writeLog(ex.ToString());
                                        Thread.Sleep(1000 * 60 * 60);
                                        continue;
                                    }
                                }
                            }
                        }

                        foreach (DataRow row in dtInsert.Rows)
                        {
                            string filterExpression = $"LINE = '{row["LINE"]}' AND EQ = '{row["EQ"]}' AND MODEL = '{row["MODEL"]}'" +
                                                    $" AND CATEGORY = '{row["CATEGORY"]}' AND SPEC_NAME = '{row["SPEC_NAME"]}'";
                            DataRow[] filteredRows = dtLastData.Select(filterExpression);


                            //없는 경우 무조건 넣음
                            if (filteredRows.Length < 1)
                            {
                                using (SqlConnection conn = connectDB_TEAMDB())
                                {
                                    using (SqlCommand cmd = conn.CreateCommand())
                                    {
                                        cmd.CommandText = $"INSERT INTO [DB_INV].[dbo].[tbl_INSP_SPEC_DAT-{m_strLine}]" +
                                            $" VALUES ('{row["LINE"]}','{row["EQ"]}','{row["MODEL"]}','{row["CATEGORY"]}','{row["SPEC_NAME"]}'," +
                                            $"'{row["SPEC_DATA"]}','{row["DATA_DATETIME"]}')";

                                        try
                                        {
                                            cmd.ExecuteNonQuery();
                                        }
                                        catch (Exception ex)
                                        {
                                            writeLog(ex.ToString());
                                            continue;
                                        }

                                        if (lstInputContents.Contains(row["MODEL"].ToString()) == false)
                                            lstInputContents.Add(row["MODEL"].ToString());
                                    }
                                }
                            }
                            else
                            {
                                if (row["SPEC_DATA"].ToString() != filteredRows[0]["SPEC_DATA"].ToString())
                                {
                                    using (SqlConnection conn = connectDB_TEAMDB())
                                    {
                                        using (SqlCommand cmd = conn.CreateCommand())
                                        {
                                            cmd.CommandText = $"INSERT INTO [DB_INV].[dbo].[tbl_INSP_SPEC_DAT-{m_strLine}]" +
                                            $" VALUES ('{row["LINE"]}','{row["EQ"]}','{row["MODEL"]}','{row["CATEGORY"]}','{row["SPEC_NAME"]}'," +
                                            $"'{row["SPEC_DATA"]}','{row["DATA_DATETIME"]}')";

                                            try
                                            {
                                                cmd.ExecuteNonQuery();
                                            }
                                            catch (Exception ex)
                                            {
                                                writeLog(ex.ToString());
                                                continue;
                                            }

                                            iModifyRowCount++;

                                            if (strModifyContents != string.Empty)
                                                strModifyContents += ",";

                                            strModifyContents += $"수정,{row["LINE"]},{row["EQ"]},{row["MODEL"]},{row["CATEGORY"]},{row["SPEC_NAME"]},{row["SPEC_DATA"]},{row["DATA_DATETIME"]}";
                                        }
                                    }
                                }
                            }
                        }

                        using (SqlConnection conn = connectDB_TEAMDB())
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = @"UPDATE [DB_INV].[dbo].[tbl_GCM] SET [DATAVALUE1] = @datetime WHERE CATEGORY = 'INSP_SPEC' AND DATAID = @id";
                                cmd.Parameters.AddWithValue("@datetime", fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
                                cmd.Parameters.AddWithValue("@id", $"LAST_WORK_{m_strLine}-{m_iEq}");

                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    writeLog(ex.ToString());
                                }
                            }
                        }

                        if ((lstInputContents.Count == 0) && (strModifyContents == string.Empty))
                        {
                            writeLog($"{m_strLine},{m_iEq},신규:0,수정:0,{fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss")}");
                            Thread.Sleep(1000 * 60 * 10);
                            continue;
                        }

                        string strResult = "신규 - ";
                        if (lstInputContents.Count > 0)
                        {
                            strResult = lstInputContents[0];
                            for (int i = 1; i < lstInputContents.Count; i++)
                                strResult += $",{lstInputContents[i]}";
                        }
                        
                        strResult += "," + strModifyContents;

                        using (SqlConnection conn = connectDB_TEAMDB())
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandText = @"INSERT INTO [DB_INV].[dbo].[tbl_INSP_SPEC_CHANGE_LOG] VALUES (@datetime,@line,@eq,@rows)";
                                cmd.Parameters.AddWithValue("@datetime", fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss"));
                                cmd.Parameters.AddWithValue("@line", m_strLine);
                                cmd.Parameters.AddWithValue("@eq", m_iEq);

                                if (strResult.Length > 4500)
                                    strResult = strResult.Substring(0, 4500) + "....";

                                cmd.Parameters.AddWithValue("@rows", strResult);

                                try
                                {
                                    cmd.ExecuteNonQuery();
                                }
                                catch (Exception ex)
                                {
                                    writeLog(ex.ToString());
                                    Thread.Sleep(1000 * 60 * 10);
                                    continue;
                                }
                            }
                        }

                        writeLog($"{m_strLine},{m_iEq},신규:{lstInputContents.Count},수정:{iModifyRowCount},{fi.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss")}");
                    }
                }

                //10분 마다 loop
                Thread.Sleep(1000 * 60 * 10);
            }
        }

        public void SaveDataTableToCsv(DataTable dataTable, string csvFilePath)
        {
            // CSV 파일 작성
            using (StreamWriter streamWriter = new StreamWriter(csvFilePath))
            {
                // 헤더 작성
                foreach (DataColumn column in dataTable.Columns)
                {
                    streamWriter.Write(column.ColumnName);
                    streamWriter.Write(",");
                }
                streamWriter.WriteLine();

                // 데이터 작성
                foreach (DataRow row in dataTable.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        streamWriter.Write(item.ToString());
                        streamWriter.Write(",");
                    }
                    streamWriter.WriteLine();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                //openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "MDB files (*.MDB)|*.MDB";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file
                    filePath = openFileDialog.FileName;

                    using (SqlConnection conn = connectDB_TEAMDB())
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            // WHERE CATEGORY = 'REPORT' AND DATAID = 'D36_MDB_PATH'
                            cmd.CommandText = @"MERGE INTO [DB_INV].[dbo].[tbl_GCM] AS target
                                                USING (VALUES ('INSP_SPEC', @name, @path)) AS source (CATEGORY, DATAID, DATAVALUE1)
                                                ON (target.CATEGORY = source.CATEGORY AND target.DATAID = source.DATAID)
                                                WHEN MATCHED THEN
                                                    UPDATE SET target.DATAVALUE1 = source.DATAVALUE1
                                                WHEN NOT MATCHED THEN
                                                    INSERT (CATEGORY, DATAID, DATAVALUE1) VALUES ('INSP_SPEC', @name, @path);";
                            cmd.Parameters.AddWithValue("@path", filePath);
                            cmd.Parameters.AddWithValue("@name", $"MDB_PATH_{ m_strLine}-{ m_iEq}");

                            try
                            {
                                cmd.ExecuteNonQuery();
                            }
                            catch (Exception ex)
                            {
                                writeLog(ex.ToString());
                            }
                        }
                    }

                    textBox_Path.Text = filePath;
                }
            }
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
                return;
            }

            if (m_tMonitor != null)
            {
                m_tMonitor.Abort();
                while (m_tMonitor.ThreadState != System.Threading.ThreadState.Aborted)
                    Thread.Sleep(100);
            }

            System.Windows.Forms.Application.ExitThread();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
    }
}
