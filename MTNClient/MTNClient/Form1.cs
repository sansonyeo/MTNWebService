using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MTNClient
{
    public partial class Form1 : Form
    {
        List<WebServiceRef.Certificate> certificateList;
        int count;

        public Form1()
        {
            InitializeComponent();
            certificateList = new List<WebServiceRef.Certificate>();
        }

        void OnRefreshList(object sender, EventArgs e)
        {
            this.ctlCerts.Enabled = this.ctlRefresh.Enabled = false;

            this.ctlCerts.Items.Clear();

            foreach (var drive in DriveInfo.GetDrives())
            {
                foreach (var cert in Cert.GetCerts(drive.Name))
                {
                    var item = new ListViewItem
                    {
                        Tag = cert,
                        Text = cert.Name
                    };

                    item.SubItems.Add(cert.Type);
                    item.SubItems.Add(cert.NotAfter.ToString("yy-MM-dd"));
                    item.SubItems.Add(cert.Drive);
                    item.SubItems.Add(cert.Ca);
                    item.SubItems.Add(cert.DerFullFileName + ";" + cert.KeyFullFileName); // [2020.09.04 JYYun] 추가

                    if (cert.NotAfter < DateTime.Now)
                        item.ForeColor = Color.Red;

                    this.ctlCerts.Items.Add(item);
                }
            }

            this.ctlCertsListDesc.Text = "설치된 Guest 인증서 : " + this.ctlCerts.Items.Count.ToString();

            this.ctlCerts.Enabled = this.ctlRefresh.Enabled = true;
        }

        private void btnWebServiceSend_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btnSend = (System.Windows.Forms.Button)sender;

            SetMenuDrive("send");

            Point screenPoint = btnSend.PointToScreen(new Point(btnSend.Left, btnSend.Bottom));
            if (screenPoint.Y + mnuDrive.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                mnuDrive.Show(btnSend, new Point(0, -mnuDrive.Size.Height));
            }
            else
            {
                mnuDrive.Show(btnSend, new Point(0, btnSend.Height));
            }
        }

        private void btnWebServiceRecv_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btnRecv = (System.Windows.Forms.Button)sender;

            SetMenuDrive("recv");

            Point screenPoint = btnRecv.PointToScreen(new Point(btnRecv.Left, btnRecv.Bottom));
            if (screenPoint.Y + mnuDrive.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                mnuDrive.Show(btnRecv, new Point(0, -mnuDrive.Size.Height));
            }
            else
            {
                mnuDrive.Show(btnRecv, new Point(0, btnRecv.Height));
            }
        }

        #region 클라이언트 드라이브 찾기 및 버튼 이벤트 [2020.09.11 JYYun]
        private List<string> _lstFileName = new List<string>();
        private List<string> _lstNodeDir = new List<string>();

        /// <summary>
        /// 로컬 드라이브 메뉴에 추가
        /// </summary>
        private void SetMenuDrive(string sendRecvType)
        {
            mnuDrive.Items.Clear();

            DriveInfo[] allDrives = DriveInfo.GetDrives();
            Dictionary<string, string> dicDrive = new Dictionary<string, string>();

            foreach (DriveInfo d in allDrives)
            {
                if (d.IsReady == true)
                {
                    string strName = d.Name;
                    strName = strName.Replace(@"\", "");
                    string strDiveType = string.Empty;
                    if (d.DriveType.ToString() == "Fixed")
                    {
                        if (strName == "C:") strDiveType = "하드 디스크";
                        else strDiveType = "로컬 디스크";
                    }
                    else if (d.DriveType.ToString() == "Removable")
                        strDiveType = "이동 디스크";
                    else
                        strDiveType = d.VolumeLabel;

                    dicDrive.Add(strName, strDiveType);
                }
            }

            ToolStripMenuItem[] items = new ToolStripMenuItem[dicDrive.Count];
            int index = 0;
            foreach (KeyValuePair<string, string> driveinfo in dicDrive)
            {
                items[index] = new ToolStripMenuItem();
                items[index].Name = driveinfo.Value;
                items[index].Tag = driveinfo.Key.Replace(":", "");
                items[index].Text = driveinfo.Value + " (" + driveinfo.Key + ")";

                if (sendRecvType == "send") // 보내기
                    items[index].Click += new EventHandler(sendMenuItemClickHandler);
                else if (sendRecvType == "recv") // 가져오기
                    items[index].Click += new EventHandler(recvMenuItemClickHandler);

                index++;
            }
            mnuDrive.Items.AddRange(items);
        }

        private void dirSearch(string dir)
        {
            if (Directory.Exists(dir))
            {
                string[] Directories = Directory.GetDirectories(dir);   // Defalut Folder
                {
                    string[] Files = Directory.GetFiles(dir);   // File list Search
                    foreach (string fileName in Files)   // File check
                    {
                        _lstFileName.Add(fileName); // File add
                    }
                    foreach (string nodeDir in Directories)   // Folder list Search
                    {
                        _lstNodeDir.Add(nodeDir); // Folder add
                        dirSearch(nodeDir);   // reSearch
                    }
                }
            }
            else
            {
                MessageBox.Show("선택한 드라이브에 인증서 폴더가 존재하지 않습니다!");
            }
        }

        private void sendMenuItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            // 1. 클라이언트에 의한 웹서비스 객체 생성
            ListView ctlCertsSend = new ListView();
            string driveName = clickedItem.Tag.ToString() + @":\";
            foreach (var cert in Cert.GetCerts(driveName))
            {
                var item = new ListViewItem
                {
                    Tag = cert,
                    Text = cert.Name
                };
                item.SubItems.Add(cert.Type);
                item.SubItems.Add(cert.NotAfter.ToString("yy-MM-dd"));
                item.SubItems.Add(cert.Drive);
                item.SubItems.Add(cert.Ca);
                item.SubItems.Add(cert.DerFullFileName + ";" + cert.KeyFullFileName); // [2020.09.04 JYYun] 추가
                ctlCertsSend.Items.Add(item);
            }

            for (int i = 0; i < ctlCertsSend.Items.Count; i++)
            {
                var cert = (Cert)ctlCertsSend.Items[i].Tag;
                WebServiceRef.Certificate wsCert = new WebServiceRef.Certificate();

                wsCert.certs_name = cert.Name;
                wsCert.certs_type = cert.Type;
                wsCert.certs_not_after = cert.NotAfter;
                wsCert.certs_drive = cert.Drive;
                wsCert.certs_ca = cert.Ca;
                wsCert.certs_full_filename = cert.DerFullFileName + ";" + cert.KeyFullFileName;

                // 1-1. 파일 바이트로 만들기
                int[] nFileLen = new int[2];
                try
                {
                    FileStream fsDer = new FileStream(cert.DerFullFileName, FileMode.Open);
                    FileStream fsKey = new FileStream(cert.KeyFullFileName, FileMode.Open);
                    FileInfo fiDer = new FileInfo(cert.DerFullFileName);
                    FileInfo fiKey = new FileInfo(cert.KeyFullFileName);
                    nFileLen[0] = Convert.ToInt32(fiDer.Length);
                    nFileLen[1] = Convert.ToInt32(fiKey.Length);
                    byte[] byteDer = new byte[nFileLen[0]];
                    byte[] byteKey = new byte[nFileLen[1]];
                    fsDer.Read(byteDer, 0, nFileLen[0]);
                    fsKey.Read(byteKey, 0, nFileLen[1]);

                    wsCert.certs_byte_der = byteDer;
                    wsCert.certs_byte_key = byteKey;

                    fsDer.Close();
                    fsKey.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                certificateList.Add(wsCert);
            }

            // 2. 전송 웹서비스 객체 생성
            DAL dalObj = new DAL();
            bool[] result = dalObj.InsertCertificate(certificateList);
            if (result != null)
            {
                string temp = ""; bool error = false;
                for (int i = 0; i < (count - 1); i++)
                {
                    if (result[i] == false)
                    {
                        temp = temp + i + 1 + " ";
                        error = true;

                    }//close if
                }//close for

                //Display Error/Success
                if (error)
                    MessageBox.Show("Record(s) " + temp + "Couldn't Be Inserted.", "Result");
                else
                    MessageBox.Show("All Records Inserted", "Success");
            }
            else
                MessageBox.Show("No Records Inserted", "Error");

            certificateList.Clear();

        }

        private void recvMenuItemClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            //Create a New DAL obj:
            DAL dalObj = new DAL();

            //Get the GradeSheet Table via WebService
            string driveName = clickedItem.Tag.ToString() + @":\";
            DataTable dt = dalObj.SelectCertificate(driveName);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string certs_full_filename_der = dt.Rows[i]["CERTS_FULL_FILENAME"].ToString().Split(';')[0];
                string certs_full_filename_key = dt.Rows[i]["CERTS_FULL_FILENAME"].ToString().Split(';')[1];
                byte[] certs_byte_der = (byte[])dt.Rows[i]["CERTS_BYTE_DER"];
                byte[] certs_byte_key = (byte[])dt.Rows[i]["CERTS_BYTE_KEY"];

                if (!Directory.Exists(Path.GetDirectoryName(certs_full_filename_der)))
                    Directory.CreateDirectory(Path.GetDirectoryName(certs_full_filename_der));

                File.WriteAllBytes(certs_full_filename_der, certs_byte_der);
                File.WriteAllBytes(certs_full_filename_key, certs_byte_key);

            }

            //Assign it to GridView
            try
            {
                // DataGridView에서 바이러리는 바인딩이 안되어서 컬럼을 삭제함.
                dt.Columns.RemoveAt(dt.Columns.Count - 1);
                dt.Columns.RemoveAt(dt.Columns.Count - 1);
                dgviewCerts.DataSource = dt;
            }
            catch
            {
            }

            //Auto Resize the GridView
            AutoSizeGridView(dgviewCerts);

        }

        private void AutoSizeGridView(DataGridView dgv)
        {
            if (dgv != null)
                for (int i = 0; i < dgv.ColumnCount; i++)
                    dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void dgviewCerts_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            string path = Path.GetDirectoryName(dgviewCerts.Rows[rowIndex].Cells[0].Value.ToString().Split(';')[0]);
            System.Diagnostics.Process.Start(path);
        }

        #endregion

    }
}
