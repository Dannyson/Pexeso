namespace HJD.Pexeso.FormGUI
{
	partial class BoardSettingsForm
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.numGroupSize = new System.Windows.Forms.NumericUpDown();
			this.lblGroupSize = new System.Windows.Forms.Label();
			this.numCardsCount = new System.Windows.Forms.NumericUpDown();
			this.lblCards = new System.Windows.Forms.Label();
			this.btnOk = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numGroupSize)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numCardsCount)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.numGroupSize);
			this.groupBox1.Controls.Add(this.lblGroupSize);
			this.groupBox1.Controls.Add(this.numCardsCount);
			this.groupBox1.Controls.Add(this.lblCards);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(260, 82);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Board size";
			// 
			// numGroupSize
			// 
			this.numGroupSize.Location = new System.Drawing.Point(67, 51);
			this.numGroupSize.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numGroupSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.numGroupSize.Name = "numGroupSize";
			this.numGroupSize.Size = new System.Drawing.Size(59, 20);
			this.numGroupSize.TabIndex = 7;
			this.numGroupSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
			// 
			// lblGroupSize
			// 
			this.lblGroupSize.AutoSize = true;
			this.lblGroupSize.Location = new System.Drawing.Point(6, 53);
			this.lblGroupSize.Name = "lblGroupSize";
			this.lblGroupSize.Size = new System.Drawing.Size(57, 13);
			this.lblGroupSize.TabIndex = 6;
			this.lblGroupSize.Text = "Group size";
			// 
			// numCardsCount
			// 
			this.numCardsCount.Location = new System.Drawing.Point(67, 25);
			this.numCardsCount.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.numCardsCount.Name = "numCardsCount";
			this.numCardsCount.Size = new System.Drawing.Size(59, 20);
			this.numCardsCount.TabIndex = 3;
			this.numCardsCount.Value = new decimal(new int[] {
            64,
            0,
            0,
            0});
			// 
			// lblCards
			// 
			this.lblCards.AutoSize = true;
			this.lblCards.Location = new System.Drawing.Point(6, 27);
			this.lblCards.Name = "lblCards";
			this.lblCards.Size = new System.Drawing.Size(34, 13);
			this.lblCards.TabIndex = 2;
			this.lblCards.Text = "Cards";
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(196, 221);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(76, 29);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// BoardSettingsForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.groupBox1);
			this.Name = "BoardSettingsForm";
			this.Text = "Board Settings";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numGroupSize)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numCardsCount)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.NumericUpDown numCardsCount;
		private System.Windows.Forms.Label lblCards;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.NumericUpDown numGroupSize;
		private System.Windows.Forms.Label lblGroupSize;

	}
}