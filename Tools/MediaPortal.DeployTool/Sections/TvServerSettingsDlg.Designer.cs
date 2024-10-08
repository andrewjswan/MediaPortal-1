#region Copyright (C) 2005-2023 Team MediaPortal

// Copyright (C) 2005-2023 Team MediaPortal
// http://www.team-mediaportal.com
// 
// MediaPortal is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// MediaPortal is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with MediaPortal. If not, see <http://www.gnu.org/licenses/>.

#endregion

namespace MediaPortal.DeployTool.Sections
{
  partial class TvServerSettingsDlg
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.buttonBrowse = new System.Windows.Forms.Button();
      this.textBoxDir = new System.Windows.Forms.TextBox();
      this.labelInstDir = new System.Windows.Forms.Label();
      this.labelHeading = new System.Windows.Forms.Label();
      this.checkBoxFirewall = new System.Windows.Forms.CheckBox();
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.SuspendLayout();
      // 
      // buttonBrowse
      // 
      this.buttonBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonBrowse.Cursor = System.Windows.Forms.Cursors.Hand;
      this.buttonBrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
      this.buttonBrowse.Location = new System.Drawing.Point(831, 127);
      this.buttonBrowse.Name = "buttonBrowse";
      this.buttonBrowse.Size = new System.Drawing.Size(70, 23);
      this.buttonBrowse.TabIndex = 21;
      this.buttonBrowse.Text = "Browse";
      this.buttonBrowse.UseVisualStyleBackColor = true;
      this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
      // 
      // textBoxDir
      // 
      this.textBoxDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.textBoxDir.Location = new System.Drawing.Point(333, 129);
      this.textBoxDir.Name = "textBoxDir";
      this.textBoxDir.Size = new System.Drawing.Size(492, 20);
      this.textBoxDir.TabIndex = 20;
      this.textBoxDir.TextChanged += new System.EventHandler(this.textBoxDir_TextChanged);
      // 
      // labelInstDir
      // 
      this.labelInstDir.AutoSize = true;
      this.labelInstDir.ForeColor = System.Drawing.Color.White;
      this.labelInstDir.Location = new System.Drawing.Point(330, 113);
      this.labelInstDir.Name = "labelInstDir";
      this.labelInstDir.Size = new System.Drawing.Size(101, 13);
      this.labelInstDir.TabIndex = 19;
      this.labelInstDir.Text = "TV-Server install dir:";
      // 
      // labelHeading
      // 
      this.labelHeading.AutoSize = true;
      this.labelHeading.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.labelHeading.ForeColor = System.Drawing.Color.White;
      this.labelHeading.Location = new System.Drawing.Point(330, 56);
      this.labelHeading.Name = "labelHeading";
      this.labelHeading.Size = new System.Drawing.Size(402, 13);
      this.labelHeading.TabIndex = 18;
      this.labelHeading.Text = "Please set the needed options for the TV-Server installation:";
      // 
      // checkBoxFirewall
      // 
      this.checkBoxFirewall.AutoSize = true;
      this.checkBoxFirewall.Checked = true;
      this.checkBoxFirewall.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkBoxFirewall.Cursor = System.Windows.Forms.Cursors.Hand;
      this.checkBoxFirewall.ForeColor = System.Drawing.Color.White;
      this.checkBoxFirewall.Location = new System.Drawing.Point(333, 177);
      this.checkBoxFirewall.Name = "checkBoxFirewall";
      this.checkBoxFirewall.Size = new System.Drawing.Size(331, 17);
      this.checkBoxFirewall.TabIndex = 22;
      this.checkBoxFirewall.Text = "Configure Windows Firewall to allow external access to TvServer";
      this.checkBoxFirewall.UseVisualStyleBackColor = true;
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = global::MediaPortal.DeployTool.Images.Mediaportal_Box;
      this.pictureBox1.Location = new System.Drawing.Point(40, 70);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(176, 357);
      this.pictureBox1.TabIndex = 25;
      this.pictureBox1.TabStop = false;
      // 
      // TvServerSettingsDlg
      // 
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
      this.BackgroundImage = global::MediaPortal.DeployTool.Images.Background_middle_empty;
      this.Controls.Add(this.pictureBox1);
      this.Controls.Add(this.checkBoxFirewall);
      this.Controls.Add(this.buttonBrowse);
      this.Controls.Add(this.textBoxDir);
      this.Controls.Add(this.labelInstDir);
      this.Controls.Add(this.labelHeading);
      this.Name = "TvServerSettingsDlg";
      this.Controls.SetChildIndex(this.labelSectionHeader, 0);
      this.Controls.SetChildIndex(this.labelHeading, 0);
      this.Controls.SetChildIndex(this.labelInstDir, 0);
      this.Controls.SetChildIndex(this.textBoxDir, 0);
      this.Controls.SetChildIndex(this.buttonBrowse, 0);
      this.Controls.SetChildIndex(this.checkBoxFirewall, 0);
      this.Controls.SetChildIndex(this.pictureBox1, 0);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button buttonBrowse;
    private System.Windows.Forms.TextBox textBoxDir;
    private System.Windows.Forms.Label labelInstDir;
    private System.Windows.Forms.Label labelHeading;
    private System.Windows.Forms.CheckBox checkBoxFirewall;
    private System.Windows.Forms.PictureBox pictureBox1;
  }
}