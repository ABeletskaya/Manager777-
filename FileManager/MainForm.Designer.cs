namespace FileManager
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbLeftTree = new System.Windows.Forms.ListBox();
            this.tbRouteLeft = new System.Windows.Forms.TextBox();
            this.btnEnter = new System.Windows.Forms.Button();
            this.lblTest = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCut = new System.Windows.Forms.Button();
            this.cbLogicalDrivers = new System.Windows.Forms.ComboBox();
            this.btnProperties = new System.Windows.Forms.Button();
            this.btnRename = new System.Windows.Forms.Button();
            this.btnCreateFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbRouteRight = new System.Windows.Forms.TextBox();
            this.lbRightTree = new System.Windows.Forms.ListBox();
            this.tbProperties = new System.Windows.Forms.TextBox();
            this.btnInfo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbLeftTree
            // 
            this.lbLeftTree.FormattingEnabled = true;
            this.lbLeftTree.Location = new System.Drawing.Point(15, 67);
            this.lbLeftTree.Name = "lbLeftTree";
            this.lbLeftTree.Size = new System.Drawing.Size(312, 316);
            this.lbLeftTree.TabIndex = 0;
            this.lbLeftTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbLeftTree_MouseClick);
            this.lbLeftTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbLeftTree_MouseDoubleClick);
            // 
            // tbRouteLeft
            // 
            this.tbRouteLeft.Location = new System.Drawing.Point(15, 41);
            this.tbRouteLeft.Name = "tbRouteLeft";
            this.tbRouteLeft.Size = new System.Drawing.Size(312, 20);
            this.tbRouteLeft.TabIndex = 1;
            this.tbRouteLeft.Text = "D:\\";
            this.tbRouteLeft.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbRouteLeft_MouseClick);
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(121, 12);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(100, 25);
            this.btnEnter.TabIndex = 2;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Location = new System.Drawing.Point(12, 18);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(109, 13);
            this.lblTest.TabIndex = 3;
            this.lblTest.Text = "The directory address";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(227, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(100, 25);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(121, 387);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(100, 25);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(227, 387);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(100, 25);
            this.btnPaste.TabIndex = 6;
            this.btnPaste.Text = "Paste";
            this.btnPaste.UseVisualStyleBackColor = true;
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnCut
            // 
            this.btnCut.Location = new System.Drawing.Point(15, 387);
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(100, 25);
            this.btnCut.TabIndex = 7;
            this.btnCut.Text = "Cut";
            this.btnCut.UseVisualStyleBackColor = true;
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // cbLogicalDrivers
            // 
            this.cbLogicalDrivers.FormattingEnabled = true;
            this.cbLogicalDrivers.Location = new System.Drawing.Point(408, 14);
            this.cbLogicalDrivers.Name = "cbLogicalDrivers";
            this.cbLogicalDrivers.Size = new System.Drawing.Size(131, 21);
            this.cbLogicalDrivers.TabIndex = 9;
            this.cbLogicalDrivers.SelectedIndexChanged += new System.EventHandler(this.cbLogicalDrivers_SelectedIndexChanged);
            // 
            // btnProperties
            // 
            this.btnProperties.Location = new System.Drawing.Point(333, 387);
            this.btnProperties.Name = "btnProperties";
            this.btnProperties.Size = new System.Drawing.Size(100, 25);
            this.btnProperties.TabIndex = 10;
            this.btnProperties.Text = "Properties";
            this.btnProperties.UseVisualStyleBackColor = true;
            this.btnProperties.Click += new System.EventHandler(this.btnProperties_Click);
            // 
            // btnRename
            // 
            this.btnRename.Location = new System.Drawing.Point(439, 387);
            this.btnRename.Name = "btnRename";
            this.btnRename.Size = new System.Drawing.Size(100, 25);
            this.btnRename.TabIndex = 11;
            this.btnRename.Text = "Rename";
            this.btnRename.UseVisualStyleBackColor = true;
            this.btnRename.Click += new System.EventHandler(this.btnRename_Click);
            // 
            // btnCreateFolder
            // 
            this.btnCreateFolder.Location = new System.Drawing.Point(545, 387);
            this.btnCreateFolder.Name = "btnCreateFolder";
            this.btnCreateFolder.Size = new System.Drawing.Size(100, 25);
            this.btnCreateFolder.TabIndex = 12;
            this.btnCreateFolder.Text = "CreateFolder";
            this.btnCreateFolder.UseVisualStyleBackColor = true;
            this.btnCreateFolder.Click += new System.EventHandler(this.btnCreateFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(333, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Logical drives:";
            // 
            // tbRouteRight
            // 
            this.tbRouteRight.Location = new System.Drawing.Point(333, 41);
            this.tbRouteRight.Name = "tbRouteRight";
            this.tbRouteRight.Size = new System.Drawing.Size(312, 20);
            this.tbRouteRight.TabIndex = 14;
            this.tbRouteRight.Text = "D:\\";
            this.tbRouteRight.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tbRouteRight_MouseClick);
            // 
            // lbRightTree
            // 
            this.lbRightTree.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbRightTree.FormattingEnabled = true;
            this.lbRightTree.Location = new System.Drawing.Point(333, 67);
            this.lbRightTree.Name = "lbRightTree";
            this.lbRightTree.Size = new System.Drawing.Size(312, 316);
            this.lbRightTree.TabIndex = 15;
            this.lbRightTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbRightTree_MouseClick);
            this.lbRightTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbRightTree_MouseDoubleClick);
            // 
            // tbProperties
            // 
            this.tbProperties.Location = new System.Drawing.Point(15, 418);
            this.tbProperties.Multiline = true;
            this.tbProperties.Name = "tbProperties";
            this.tbProperties.Size = new System.Drawing.Size(630, 119);
            this.tbProperties.TabIndex = 17;
            this.tbProperties.Text = "Properties window";
            // 
            // btnInfo
            // 
            this.btnInfo.Location = new System.Drawing.Point(545, 10);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(100, 25);
            this.btnInfo.TabIndex = 18;
            this.btnInfo.Text = "About Program";
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 546);
            this.Controls.Add(this.btnInfo);
            this.Controls.Add(this.tbProperties);
            this.Controls.Add(this.lbRightTree);
            this.Controls.Add(this.tbRouteRight);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreateFolder);
            this.Controls.Add(this.btnRename);
            this.Controls.Add(this.btnProperties);
            this.Controls.Add(this.cbLogicalDrivers);
            this.Controls.Add(this.btnCut);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblTest);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.tbRouteLeft);
            this.Controls.Add(this.lbLeftTree);
            this.Name = "MainForm";
            this.Text = "File Manager by Beletskaya";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbLeftTree;
        private System.Windows.Forms.TextBox tbRouteLeft;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Label lblTest;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnCut;
        private System.Windows.Forms.ComboBox cbLogicalDrivers;
        private System.Windows.Forms.Button btnProperties;
        private System.Windows.Forms.Button btnRename;
        private System.Windows.Forms.Button btnCreateFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbRouteRight;
        private System.Windows.Forms.ListBox lbRightTree;
        private System.Windows.Forms.TextBox tbProperties;
        private System.Windows.Forms.Button btnInfo;
    }
}

