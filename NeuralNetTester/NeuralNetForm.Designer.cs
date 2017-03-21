namespace NeuralNetTester
{
    partial class NeuralNetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NeuralNetForm));
            this.btnTrain = new System.Windows.Forms.Button();
            this.lstOutput = new System.Windows.Forms.ListBox();
            this.cmbType = new System.Windows.Forms.ComboBox();
            this.chkLimit = new System.Windows.Forms.CheckBox();
            this.updIterations = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvInputs = new System.Windows.Forms.DataGridView();
            this.dgvOutputs = new System.Windows.Forms.DataGridView();
            this.txtSubmit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.updIterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutputs)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTrain
            // 
            this.btnTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTrain.Location = new System.Drawing.Point(668, 39);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(56, 21);
            this.btnTrain.TabIndex = 0;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // lstOutput
            // 
            this.lstOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstOutput.FormattingEnabled = true;
            this.lstOutput.HorizontalScrollbar = true;
            this.lstOutput.Location = new System.Drawing.Point(11, 151);
            this.lstOutput.Name = "lstOutput";
            this.lstOutput.Size = new System.Drawing.Size(712, 173);
            this.lstOutput.TabIndex = 1;
            // 
            // cmbType
            // 
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Location = new System.Drawing.Point(12, 12);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(188, 21);
            this.cmbType.TabIndex = 2;
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
            // 
            // chkLimit
            // 
            this.chkLimit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkLimit.AutoSize = true;
            this.chkLimit.Checked = true;
            this.chkLimit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLimit.Location = new System.Drawing.Point(425, 14);
            this.chkLimit.Name = "chkLimit";
            this.chkLimit.Size = new System.Drawing.Size(92, 17);
            this.chkLimit.TabIndex = 3;
            this.chkLimit.Text = "Limit iterations";
            this.chkLimit.UseVisualStyleBackColor = true;
            this.chkLimit.CheckedChanged += new System.EventHandler(this.chkLimit_CheckedChanged);
            // 
            // updIterations
            // 
            this.updIterations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.updIterations.Location = new System.Drawing.Point(625, 13);
            this.updIterations.Name = "updIterations";
            this.updIterations.Size = new System.Drawing.Size(99, 20);
            this.updIterations.TabIndex = 4;
            this.updIterations.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(523, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "1000s of iterations:";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(11, 66);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(712, 79);
            this.txtDescription.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(11, 350);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvInputs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvOutputs);
            this.splitContainer1.Size = new System.Drawing.Size(711, 88);
            this.splitContainer1.SplitterDistance = 355;
            this.splitContainer1.TabIndex = 9;
            // 
            // dgvInputs
            // 
            this.dgvInputs.AllowUserToAddRows = false;
            this.dgvInputs.AllowUserToDeleteRows = false;
            this.dgvInputs.AllowUserToResizeRows = false;
            this.dgvInputs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvInputs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInputs.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvInputs.Location = new System.Drawing.Point(3, 3);
            this.dgvInputs.MultiSelect = false;
            this.dgvInputs.Name = "dgvInputs";
            this.dgvInputs.RowHeadersVisible = false;
            this.dgvInputs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvInputs.Size = new System.Drawing.Size(349, 82);
            this.dgvInputs.TabIndex = 8;
            // 
            // dgvOutputs
            // 
            this.dgvOutputs.AllowUserToAddRows = false;
            this.dgvOutputs.AllowUserToDeleteRows = false;
            this.dgvOutputs.AllowUserToResizeRows = false;
            this.dgvOutputs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOutputs.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOutputs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutputs.Enabled = false;
            this.dgvOutputs.Location = new System.Drawing.Point(1, 3);
            this.dgvOutputs.MultiSelect = false;
            this.dgvOutputs.Name = "dgvOutputs";
            this.dgvOutputs.ReadOnly = true;
            this.dgvOutputs.RowHeadersVisible = false;
            this.dgvOutputs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvOutputs.Size = new System.Drawing.Size(350, 82);
            this.dgvOutputs.TabIndex = 9;
            this.dgvOutputs.SelectionChanged += new System.EventHandler(this.dgvOutputs_SelectionChanged);
            // 
            // txtSubmit
            // 
            this.txtSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubmit.Enabled = false;
            this.txtSubmit.Location = new System.Drawing.Point(665, 441);
            this.txtSubmit.Name = "txtSubmit";
            this.txtSubmit.Size = new System.Drawing.Size(56, 21);
            this.txtSubmit.TabIndex = 10;
            this.txtSubmit.Text = "Submit";
            this.txtSubmit.UseVisualStyleBackColor = true;
            this.txtSubmit.Click += new System.EventHandler(this.txtSubmit_Click);
            // 
            // NeuralNetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(737, 466);
            this.Controls.Add(this.txtSubmit);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updIterations);
            this.Controls.Add(this.chkLimit);
            this.Controls.Add(this.cmbType);
            this.Controls.Add(this.lstOutput);
            this.Controls.Add(this.btnTrain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(530, 372);
            this.Name = "NeuralNetForm";
            this.Text = "Neural Net Tester";
            ((System.ComponentModel.ISupportInitialize)(this.updIterations)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInputs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutputs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.ListBox lstOutput;
        private System.Windows.Forms.ComboBox cmbType;
        private System.Windows.Forms.CheckBox chkLimit;
        private System.Windows.Forms.NumericUpDown updIterations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvInputs;
        private System.Windows.Forms.DataGridView dgvOutputs;
        private System.Windows.Forms.Button txtSubmit;
    }
}

