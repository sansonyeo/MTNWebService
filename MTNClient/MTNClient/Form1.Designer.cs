namespace MTNClient
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mnuDrive = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tblClientCerts = new System.Windows.Forms.TableLayoutPanel();
            this.ctlCerts = new System.Windows.Forms.ListView();
            this.ctlCertsName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlCertsType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlCertsNotAfter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlCertsDrive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlCertsCA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlCertsFullFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctlRefresh = new System.Windows.Forms.Button();
            this.ctlCertsListDesc = new System.Windows.Forms.Label();
            this.dgviewCerts = new System.Windows.Forms.DataGridView();
            this.btnWebServiceRecv = new System.Windows.Forms.Button();
            this.btnWebServiceSend = new System.Windows.Forms.Button();
            this.tblClientCerts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgviewCerts)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuDrive
            // 
            this.mnuDrive.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mnuDrive.Name = "mnuDrive";
            this.mnuDrive.Size = new System.Drawing.Size(61, 4);
            // 
            // tblClientCerts
            // 
            this.tblClientCerts.ColumnCount = 1;
            this.tblClientCerts.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblClientCerts.Controls.Add(this.ctlCerts, 0, 1);
            this.tblClientCerts.Controls.Add(this.ctlRefresh, 0, 1);
            this.tblClientCerts.Controls.Add(this.ctlCertsListDesc, 0, 0);
            this.tblClientCerts.Location = new System.Drawing.Point(7, 7);
            this.tblClientCerts.Name = "tblClientCerts";
            this.tblClientCerts.RowCount = 2;
            this.tblClientCerts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tblClientCerts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tblClientCerts.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 185F));
            this.tblClientCerts.Size = new System.Drawing.Size(662, 160);
            this.tblClientCerts.TabIndex = 7;
            // 
            // ctlCerts
            // 
            this.ctlCerts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ctlCertsName,
            this.ctlCertsType,
            this.ctlCertsNotAfter,
            this.ctlCertsDrive,
            this.ctlCertsCA,
            this.ctlCertsFullFileName});
            this.ctlCerts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ctlCerts.FullRowSelect = true;
            this.ctlCerts.GridLines = true;
            this.ctlCerts.HideSelection = false;
            this.ctlCerts.Location = new System.Drawing.Point(0, 29);
            this.ctlCerts.Margin = new System.Windows.Forms.Padding(0);
            this.ctlCerts.MultiSelect = false;
            this.ctlCerts.Name = "ctlCerts";
            this.ctlCerts.ShowGroups = false;
            this.ctlCerts.Size = new System.Drawing.Size(662, 100);
            this.ctlCerts.TabIndex = 7;
            this.ctlCerts.UseCompatibleStateImageBehavior = false;
            this.ctlCerts.View = System.Windows.Forms.View.Details;
            // 
            // ctlCertsName
            // 
            this.ctlCertsName.Text = "이름";
            this.ctlCertsName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctlCertsName.Width = 51;
            // 
            // ctlCertsType
            // 
            this.ctlCertsType.Text = "종류";
            this.ctlCertsType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ctlCertsNotAfter
            // 
            this.ctlCertsNotAfter.Text = "유효기간";
            this.ctlCertsNotAfter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctlCertsNotAfter.Width = 77;
            // 
            // ctlCertsDrive
            // 
            this.ctlCertsDrive.Text = "위치";
            this.ctlCertsDrive.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctlCertsDrive.Width = 110;
            // 
            // ctlCertsCA
            // 
            this.ctlCertsCA.Text = "발급자";
            this.ctlCertsCA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ctlCertsCA.Width = 110;
            // 
            // ctlCertsFullFileName
            // 
            this.ctlCertsFullFileName.Text = "파일명";
            this.ctlCertsFullFileName.Width = 722;
            // 
            // ctlRefresh
            // 
            this.ctlRefresh.AutoSize = true;
            this.ctlRefresh.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctlRefresh.Location = new System.Drawing.Point(0, 132);
            this.ctlRefresh.Margin = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.ctlRefresh.Name = "ctlRefresh";
            this.ctlRefresh.Padding = new System.Windows.Forms.Padding(20, 1, 20, 1);
            this.ctlRefresh.Size = new System.Drawing.Size(662, 28);
            this.ctlRefresh.TabIndex = 6;
            this.ctlRefresh.Text = "갱신";
            this.ctlRefresh.UseVisualStyleBackColor = true;
            this.ctlRefresh.Click += new System.EventHandler(this.OnRefreshList);
            // 
            // ctlCertsListDesc
            // 
            this.ctlCertsListDesc.AutoSize = true;
            this.ctlCertsListDesc.Location = new System.Drawing.Point(3, 3);
            this.ctlCertsListDesc.Margin = new System.Windows.Forms.Padding(3);
            this.ctlCertsListDesc.Name = "ctlCertsListDesc";
            this.ctlCertsListDesc.Size = new System.Drawing.Size(136, 12);
            this.ctlCertsListDesc.TabIndex = 4;
            this.ctlCertsListDesc.Text = "설치된 Guest 인증서 : 0";
            // 
            // dgviewCerts
            // 
            this.dgviewCerts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgviewCerts.Location = new System.Drawing.Point(7, 207);
            this.dgviewCerts.Name = "dgviewCerts";
            this.dgviewCerts.ReadOnly = true;
            this.dgviewCerts.Size = new System.Drawing.Size(662, 102);
            this.dgviewCerts.TabIndex = 30;
            this.dgviewCerts.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgviewCerts_CellMouseDoubleClick);
            // 
            // btnWebServiceRecv
            // 
            this.btnWebServiceRecv.Location = new System.Drawing.Point(288, 173);
            this.btnWebServiceRecv.Name = "btnWebServiceRecv";
            this.btnWebServiceRecv.Size = new System.Drawing.Size(275, 28);
            this.btnWebServiceRecv.TabIndex = 29;
            this.btnWebServiceRecv.Text = "웹서비스로 공인인증서 가져오기";
            this.btnWebServiceRecv.UseVisualStyleBackColor = true;
            this.btnWebServiceRecv.Click += new System.EventHandler(this.btnWebServiceRecv_Click);
            // 
            // btnWebServiceSend
            // 
            this.btnWebServiceSend.Location = new System.Drawing.Point(7, 173);
            this.btnWebServiceSend.Name = "btnWebServiceSend";
            this.btnWebServiceSend.Size = new System.Drawing.Size(275, 28);
            this.btnWebServiceSend.TabIndex = 28;
            this.btnWebServiceSend.Text = "웹서비스로 공인인증서 보내기";
            this.btnWebServiceSend.UseVisualStyleBackColor = true;
            this.btnWebServiceSend.Click += new System.EventHandler(this.btnWebServiceSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 316);
            this.Controls.Add(this.dgviewCerts);
            this.Controls.Add(this.btnWebServiceRecv);
            this.Controls.Add(this.btnWebServiceSend);
            this.Controls.Add(this.tblClientCerts);
            this.Name = "Form1";
            this.Text = "MTN 웹서비스용 공인인증서 보내기/가져오기";
            this.tblClientCerts.ResumeLayout(false);
            this.tblClientCerts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgviewCerts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnuDrive;
        private System.Windows.Forms.TableLayoutPanel tblClientCerts;
        private System.Windows.Forms.ListView ctlCerts;
        private System.Windows.Forms.ColumnHeader ctlCertsName;
        private System.Windows.Forms.ColumnHeader ctlCertsType;
        private System.Windows.Forms.ColumnHeader ctlCertsNotAfter;
        private System.Windows.Forms.ColumnHeader ctlCertsDrive;
        private System.Windows.Forms.ColumnHeader ctlCertsCA;
        private System.Windows.Forms.ColumnHeader ctlCertsFullFileName;
        private System.Windows.Forms.Button ctlRefresh;
        private System.Windows.Forms.Label ctlCertsListDesc;
        private System.Windows.Forms.DataGridView dgviewCerts;
        private System.Windows.Forms.Button btnWebServiceRecv;
        private System.Windows.Forms.Button btnWebServiceSend;
    }
}

