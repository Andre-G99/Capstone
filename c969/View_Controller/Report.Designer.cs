
namespace c969.View_Controller
{
    partial class Report
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
            this.monthBox = new System.Windows.Forms.ComboBox();
            this.monthLabel = new System.Windows.Forms.Label();
            this.typeLabel = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.generateFirstReport = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.scheduleLabel = new System.Windows.Forms.Label();
            this.scheduleGrid = new System.Windows.Forms.DataGridView();
            this.dataSet = new c969.dataSet();
            this.userBox = new System.Windows.Forms.ComboBox();
            this.genSchedule = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.end = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lastUpdateBy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.result2Label = new System.Windows.Forms.Label();
            this.generateThirdReport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.apptTypeBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.customerBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // monthBox
            // 
            this.monthBox.FormattingEnabled = true;
            this.monthBox.Location = new System.Drawing.Point(42, 52);
            this.monthBox.Name = "monthBox";
            this.monthBox.Size = new System.Drawing.Size(121, 21);
            this.monthBox.TabIndex = 0;
            // 
            // monthLabel
            // 
            this.monthLabel.AutoSize = true;
            this.monthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthLabel.ForeColor = System.Drawing.Color.White;
            this.monthLabel.Location = new System.Drawing.Point(77, 20);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new System.Drawing.Size(50, 18);
            this.monthLabel.TabIndex = 1;
            this.monthLabel.Text = "Month";
            // 
            // typeLabel
            // 
            this.typeLabel.AutoSize = true;
            this.typeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeLabel.ForeColor = System.Drawing.Color.White;
            this.typeLabel.Location = new System.Drawing.Point(200, 20);
            this.typeLabel.Name = "typeLabel";
            this.typeLabel.Size = new System.Drawing.Size(126, 18);
            this.typeLabel.TabIndex = 3;
            this.typeLabel.Text = "Appointment Type";
            // 
            // typeBox
            // 
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Location = new System.Drawing.Point(203, 52);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(121, 21);
            this.typeBox.TabIndex = 2;
            // 
            // generateFirstReport
            // 
            this.generateFirstReport.Location = new System.Drawing.Point(353, 50);
            this.generateFirstReport.Name = "generateFirstReport";
            this.generateFirstReport.Size = new System.Drawing.Size(131, 23);
            this.generateFirstReport.TabIndex = 4;
            this.generateFirstReport.Text = "Generate Month Report";
            this.generateFirstReport.UseVisualStyleBackColor = true;
            this.generateFirstReport.Click += new System.EventHandler(this.generateFirstReport_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.ForeColor = System.Drawing.Color.White;
            this.resultLabel.Location = new System.Drawing.Point(527, 55);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 18);
            this.resultLabel.TabIndex = 5;
            // 
            // scheduleLabel
            // 
            this.scheduleLabel.AutoSize = true;
            this.scheduleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scheduleLabel.ForeColor = System.Drawing.Color.White;
            this.scheduleLabel.Location = new System.Drawing.Point(39, 136);
            this.scheduleLabel.Name = "scheduleLabel";
            this.scheduleLabel.Size = new System.Drawing.Size(144, 18);
            this.scheduleLabel.TabIndex = 6;
            this.scheduleLabel.Text = "Consultant Schedule";
            // 
            // scheduleGrid
            // 
            this.scheduleGrid.AllowUserToAddRows = false;
            this.scheduleGrid.AllowUserToDeleteRows = false;
            this.scheduleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.scheduleGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.customerID,
            this.userID,
            this.title,
            this.description,
            this.location,
            this.contact,
            this.type,
            this.url,
            this.start,
            this.end,
            this.createDate,
            this.lastUpdate,
            this.lastUpdateBy});
            this.scheduleGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.scheduleGrid.Location = new System.Drawing.Point(203, 136);
            this.scheduleGrid.Name = "scheduleGrid";
            this.scheduleGrid.ReadOnly = true;
            this.scheduleGrid.RowHeadersVisible = false;
            this.scheduleGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.scheduleGrid.Size = new System.Drawing.Size(845, 233);
            this.scheduleGrid.TabIndex = 7;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "dataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // userBox
            // 
            this.userBox.FormattingEnabled = true;
            this.userBox.Location = new System.Drawing.Point(42, 179);
            this.userBox.Name = "userBox";
            this.userBox.Size = new System.Drawing.Size(121, 21);
            this.userBox.TabIndex = 8;
            // 
            // genSchedule
            // 
            this.genSchedule.Location = new System.Drawing.Point(42, 223);
            this.genSchedule.Name = "genSchedule";
            this.genSchedule.Size = new System.Drawing.Size(121, 23);
            this.genSchedule.TabIndex = 9;
            this.genSchedule.Text = "Generate Schedule";
            this.genSchedule.UseVisualStyleBackColor = true;
            this.genSchedule.Click += new System.EventHandler(this.genSchedule_Click);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "Appointment ID";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // customerID
            // 
            this.customerID.DataPropertyName = "customerID";
            this.customerID.HeaderText = "Customer ID";
            this.customerID.Name = "customerID";
            this.customerID.ReadOnly = true;
            // 
            // userID
            // 
            this.userID.DataPropertyName = "userID";
            this.userID.HeaderText = "User ID";
            this.userID.Name = "userID";
            this.userID.ReadOnly = true;
            // 
            // title
            // 
            this.title.DataPropertyName = "title";
            this.title.HeaderText = "Title";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = "Description";
            this.description.Name = "description";
            this.description.ReadOnly = true;
            // 
            // location
            // 
            this.location.DataPropertyName = "location";
            this.location.HeaderText = "Location";
            this.location.Name = "location";
            this.location.ReadOnly = true;
            // 
            // contact
            // 
            this.contact.DataPropertyName = "contact";
            this.contact.HeaderText = "Contact";
            this.contact.Name = "contact";
            this.contact.ReadOnly = true;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "Type";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // url
            // 
            this.url.DataPropertyName = "url";
            this.url.HeaderText = "URL";
            this.url.Name = "url";
            this.url.ReadOnly = true;
            // 
            // start
            // 
            this.start.DataPropertyName = "startTime";
            this.start.HeaderText = "Start Time";
            this.start.Name = "start";
            this.start.ReadOnly = true;
            this.start.Width = 200;
            // 
            // end
            // 
            this.end.DataPropertyName = "endTime";
            this.end.HeaderText = "End Time";
            this.end.Name = "end";
            this.end.ReadOnly = true;
            this.end.Width = 200;
            // 
            // createDate
            // 
            this.createDate.DataPropertyName = "createDate";
            this.createDate.HeaderText = "Create Date";
            this.createDate.Name = "createDate";
            this.createDate.ReadOnly = true;
            this.createDate.Width = 200;
            // 
            // lastUpdate
            // 
            this.lastUpdate.DataPropertyName = "lastUpdate";
            this.lastUpdate.HeaderText = "Last Update";
            this.lastUpdate.Name = "lastUpdate";
            this.lastUpdate.ReadOnly = true;
            this.lastUpdate.Width = 200;
            // 
            // lastUpdateBy
            // 
            this.lastUpdateBy.DataPropertyName = "lastUpdatedBy";
            this.lastUpdateBy.HeaderText = "Last Updated By";
            this.lastUpdateBy.Name = "lastUpdateBy";
            this.lastUpdateBy.ReadOnly = true;
            // 
            // result2Label
            // 
            this.result2Label.AutoSize = true;
            this.result2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result2Label.ForeColor = System.Drawing.Color.White;
            this.result2Label.Location = new System.Drawing.Point(527, 453);
            this.result2Label.Name = "result2Label";
            this.result2Label.Size = new System.Drawing.Size(0, 18);
            this.result2Label.TabIndex = 15;
            // 
            // generateThirdReport
            // 
            this.generateThirdReport.Location = new System.Drawing.Point(353, 448);
            this.generateThirdReport.Name = "generateThirdReport";
            this.generateThirdReport.Size = new System.Drawing.Size(146, 23);
            this.generateThirdReport.TabIndex = 14;
            this.generateThirdReport.Text = "Generate Customer Report";
            this.generateThirdReport.UseVisualStyleBackColor = true;
            this.generateThirdReport.Click += new System.EventHandler(this.generateThirdReport_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(200, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Appointment Type";
            // 
            // apptTypeBox2
            // 
            this.apptTypeBox2.FormattingEnabled = true;
            this.apptTypeBox2.Location = new System.Drawing.Point(205, 450);
            this.apptTypeBox2.Name = "apptTypeBox2";
            this.apptTypeBox2.Size = new System.Drawing.Size(121, 21);
            this.apptTypeBox2.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(65, 418);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Customer";
            // 
            // customerBox
            // 
            this.customerBox.FormattingEnabled = true;
            this.customerBox.Location = new System.Drawing.Point(42, 450);
            this.customerBox.Name = "customerBox";
            this.customerBox.Size = new System.Drawing.Size(121, 21);
            this.customerBox.TabIndex = 10;
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1109, 581);
            this.Controls.Add(this.result2Label);
            this.Controls.Add(this.generateThirdReport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.apptTypeBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.customerBox);
            this.Controls.Add(this.genSchedule);
            this.Controls.Add(this.userBox);
            this.Controls.Add(this.scheduleGrid);
            this.Controls.Add(this.scheduleLabel);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.generateFirstReport);
            this.Controls.Add(this.typeLabel);
            this.Controls.Add(this.typeBox);
            this.Controls.Add(this.monthLabel);
            this.Controls.Add(this.monthBox);
            this.Name = "Report";
            this.Text = "Report";
            this.Load += new System.EventHandler(this.Report_Load);
            ((System.ComponentModel.ISupportInitialize)(this.scheduleGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox monthBox;
        private System.Windows.Forms.Label monthLabel;
        private System.Windows.Forms.Label typeLabel;
        private System.Windows.Forms.ComboBox typeBox;
        private System.Windows.Forms.Button generateFirstReport;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label scheduleLabel;
        private System.Windows.Forms.DataGridView scheduleGrid;
        private dataSet dataSet;
        private System.Windows.Forms.ComboBox userBox;
        private System.Windows.Forms.Button genSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn userID;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn location;
        private System.Windows.Forms.DataGridViewTextBoxColumn contact;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn url;
        private System.Windows.Forms.DataGridViewTextBoxColumn start;
        private System.Windows.Forms.DataGridViewTextBoxColumn end;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdate;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastUpdateBy;
        private System.Windows.Forms.Label result2Label;
        private System.Windows.Forms.Button generateThirdReport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox apptTypeBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox customerBox;
    }
}