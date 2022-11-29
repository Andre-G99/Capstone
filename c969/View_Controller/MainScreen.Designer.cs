
namespace c969.View
{
    partial class MainScreen
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
            this.components = new System.ComponentModel.Container();
            this.dayContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.appointmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new c969.dataSet();
            this.addressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sundayLabel = new System.Windows.Forms.Label();
            this.mondayLabel = new System.Windows.Forms.Label();
            this.tuesdayLabel = new System.Windows.Forms.Label();
            this.wednesdayLabel = new System.Windows.Forms.Label();
            this.thursdayLabel = new System.Windows.Forms.Label();
            this.fridayLabel = new System.Windows.Forms.Label();
            this.saturdayLabel = new System.Windows.Forms.Label();
            this.appointmentTableAdapter = new c969.dataSetTableAdapters.appointmentTableAdapter();
            this.addressTableAdapter = new c969.dataSetTableAdapters.addressTableAdapter();
            this.tableAdapterManager = new c969.dataSetTableAdapters.TableAdapterManager();
            this.prevButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.monthLabel = new System.Windows.Forms.Label();
            this.addApp = new System.Windows.Forms.Button();
            this.editApp = new System.Windows.Forms.Button();
            this.deleteApp = new System.Windows.Forms.Button();
            this.manageCust = new System.Windows.Forms.Button();
            this.genReport = new System.Windows.Forms.Button();
            this.changeViewButton = new System.Windows.Forms.Button();
            this.tableUpdateStatementBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.logoutButton = new System.Windows.Forms.Button();
            this.weekLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableUpdateStatementBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dayContainer
            // 
            this.dayContainer.Location = new System.Drawing.Point(134, 120);
            this.dayContainer.Name = "dayContainer";
            this.dayContainer.Size = new System.Drawing.Size(1538, 635);
            this.dayContainer.TabIndex = 0;
            // 
            // appointmentBindingSource
            // 
            this.appointmentBindingSource.DataMember = "appointment";
            this.appointmentBindingSource.DataSource = this.dataSet;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "dataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // addressBindingSource
            // 
            this.addressBindingSource.DataMember = "address";
            this.addressBindingSource.DataSource = this.dataSetBindingSource;
            // 
            // dataSetBindingSource
            // 
            this.dataSetBindingSource.DataSource = this.dataSet;
            this.dataSetBindingSource.Position = 0;
            // 
            // sundayLabel
            // 
            this.sundayLabel.AutoSize = true;
            this.sundayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sundayLabel.ForeColor = System.Drawing.Color.White;
            this.sundayLabel.Location = new System.Drawing.Point(203, 93);
            this.sundayLabel.Name = "sundayLabel";
            this.sundayLabel.Size = new System.Drawing.Size(80, 24);
            this.sundayLabel.TabIndex = 1;
            this.sundayLabel.Text = "Sunday";
            // 
            // mondayLabel
            // 
            this.mondayLabel.AutoSize = true;
            this.mondayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mondayLabel.ForeColor = System.Drawing.Color.White;
            this.mondayLabel.Location = new System.Drawing.Point(409, 93);
            this.mondayLabel.Name = "mondayLabel";
            this.mondayLabel.Size = new System.Drawing.Size(84, 24);
            this.mondayLabel.TabIndex = 2;
            this.mondayLabel.Text = "Monday";
            // 
            // tuesdayLabel
            // 
            this.tuesdayLabel.AutoSize = true;
            this.tuesdayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuesdayLabel.ForeColor = System.Drawing.Color.White;
            this.tuesdayLabel.Location = new System.Drawing.Point(603, 93);
            this.tuesdayLabel.Name = "tuesdayLabel";
            this.tuesdayLabel.Size = new System.Drawing.Size(90, 24);
            this.tuesdayLabel.TabIndex = 3;
            this.tuesdayLabel.Text = "Tuesday";
            // 
            // wednesdayLabel
            // 
            this.wednesdayLabel.AutoSize = true;
            this.wednesdayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wednesdayLabel.ForeColor = System.Drawing.Color.White;
            this.wednesdayLabel.Location = new System.Drawing.Point(800, 93);
            this.wednesdayLabel.Name = "wednesdayLabel";
            this.wednesdayLabel.Size = new System.Drawing.Size(120, 24);
            this.wednesdayLabel.TabIndex = 7;
            this.wednesdayLabel.Text = "Wednesday";
            // 
            // thursdayLabel
            // 
            this.thursdayLabel.AutoSize = true;
            this.thursdayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thursdayLabel.ForeColor = System.Drawing.Color.White;
            this.thursdayLabel.Location = new System.Drawing.Point(1008, 93);
            this.thursdayLabel.Name = "thursdayLabel";
            this.thursdayLabel.Size = new System.Drawing.Size(97, 24);
            this.thursdayLabel.TabIndex = 7;
            this.thursdayLabel.Text = "Thursday";
            // 
            // fridayLabel
            // 
            this.fridayLabel.AutoSize = true;
            this.fridayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fridayLabel.ForeColor = System.Drawing.Color.White;
            this.fridayLabel.Location = new System.Drawing.Point(1231, 93);
            this.fridayLabel.Name = "fridayLabel";
            this.fridayLabel.Size = new System.Drawing.Size(68, 24);
            this.fridayLabel.TabIndex = 8;
            this.fridayLabel.Text = "Friday";
            // 
            // saturdayLabel
            // 
            this.saturdayLabel.AutoSize = true;
            this.saturdayLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saturdayLabel.ForeColor = System.Drawing.Color.White;
            this.saturdayLabel.Location = new System.Drawing.Point(1435, 93);
            this.saturdayLabel.Name = "saturdayLabel";
            this.saturdayLabel.Size = new System.Drawing.Size(91, 24);
            this.saturdayLabel.TabIndex = 9;
            this.saturdayLabel.Text = "Saturday";
            // 
            // appointmentTableAdapter
            // 
            this.appointmentTableAdapter.ClearBeforeFill = true;
            // 
            // addressTableAdapter
            // 
            this.addressTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = c969.dataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // prevButton
            // 
            this.prevButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.prevButton.FlatAppearance.BorderSize = 7;
            this.prevButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prevButton.Location = new System.Drawing.Point(1421, 782);
            this.prevButton.Name = "prevButton";
            this.prevButton.Size = new System.Drawing.Size(75, 40);
            this.prevButton.TabIndex = 10;
            this.prevButton.Text = "Previous";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextButton.Location = new System.Drawing.Point(1502, 782);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 40);
            this.nextButton.TabIndex = 11;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // monthLabel
            // 
            this.monthLabel.AutoSize = true;
            this.monthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthLabel.ForeColor = System.Drawing.Color.White;
            this.monthLabel.Location = new System.Drawing.Point(755, 31);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new System.Drawing.Size(211, 37);
            this.monthLabel.TabIndex = 12;
            this.monthLabel.Text = "Month + Year";
            // 
            // addApp
            // 
            this.addApp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.addApp.FlatAppearance.BorderSize = 7;
            this.addApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addApp.Location = new System.Drawing.Point(12, 130);
            this.addApp.Name = "addApp";
            this.addApp.Size = new System.Drawing.Size(100, 57);
            this.addApp.TabIndex = 13;
            this.addApp.Text = "Add Appointment";
            this.addApp.UseVisualStyleBackColor = true;
            this.addApp.Click += new System.EventHandler(this.addApp_Click);
            // 
            // editApp
            // 
            this.editApp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.editApp.FlatAppearance.BorderSize = 7;
            this.editApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editApp.Location = new System.Drawing.Point(12, 193);
            this.editApp.Name = "editApp";
            this.editApp.Size = new System.Drawing.Size(100, 57);
            this.editApp.TabIndex = 14;
            this.editApp.Text = "Edit Appointment";
            this.editApp.UseVisualStyleBackColor = true;
            this.editApp.Click += new System.EventHandler(this.editApp_Click);
            // 
            // deleteApp
            // 
            this.deleteApp.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.deleteApp.FlatAppearance.BorderSize = 7;
            this.deleteApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteApp.Location = new System.Drawing.Point(12, 256);
            this.deleteApp.Name = "deleteApp";
            this.deleteApp.Size = new System.Drawing.Size(100, 57);
            this.deleteApp.TabIndex = 15;
            this.deleteApp.Text = "Delete Appointment";
            this.deleteApp.UseVisualStyleBackColor = true;
            this.deleteApp.Click += new System.EventHandler(this.deleteApp_Click);
            // 
            // manageCust
            // 
            this.manageCust.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.manageCust.FlatAppearance.BorderSize = 7;
            this.manageCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageCust.Location = new System.Drawing.Point(12, 376);
            this.manageCust.Name = "manageCust";
            this.manageCust.Size = new System.Drawing.Size(100, 57);
            this.manageCust.TabIndex = 16;
            this.manageCust.Text = "Manage Customers";
            this.manageCust.UseVisualStyleBackColor = true;
            this.manageCust.Click += new System.EventHandler(this.manageCust_Click);
            // 
            // genReport
            // 
            this.genReport.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.genReport.FlatAppearance.BorderSize = 7;
            this.genReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.genReport.Location = new System.Drawing.Point(12, 439);
            this.genReport.Name = "genReport";
            this.genReport.Size = new System.Drawing.Size(100, 57);
            this.genReport.TabIndex = 17;
            this.genReport.Text = "Generate Report";
            this.genReport.UseVisualStyleBackColor = true;
            this.genReport.Click += new System.EventHandler(this.genReport_Click);
            // 
            // changeViewButton
            // 
            this.changeViewButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.changeViewButton.FlatAppearance.BorderSize = 7;
            this.changeViewButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.changeViewButton.Location = new System.Drawing.Point(12, 555);
            this.changeViewButton.Name = "changeViewButton";
            this.changeViewButton.Size = new System.Drawing.Size(100, 57);
            this.changeViewButton.TabIndex = 18;
            this.changeViewButton.Text = "Change View";
            this.changeViewButton.UseVisualStyleBackColor = true;
            this.changeViewButton.Click += new System.EventHandler(this.changeViewButton_Click);
            // 
            // tableUpdateStatementBindingSource
            // 
            this.tableUpdateStatementBindingSource.DataSource = typeof(MySqlX.XDevAPI.Relational.TableUpdateStatement);
            // 
            // logoutButton
            // 
            this.logoutButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.logoutButton.FlatAppearance.BorderSize = 7;
            this.logoutButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutButton.Location = new System.Drawing.Point(12, 698);
            this.logoutButton.Name = "logoutButton";
            this.logoutButton.Size = new System.Drawing.Size(100, 57);
            this.logoutButton.TabIndex = 19;
            this.logoutButton.Text = "Logout";
            this.logoutButton.UseVisualStyleBackColor = true;
            this.logoutButton.Click += new System.EventHandler(this.logoutButton_Click);
            // 
            // weekLabel
            // 
            this.weekLabel.AutoSize = true;
            this.weekLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weekLabel.ForeColor = System.Drawing.Color.White;
            this.weekLabel.Location = new System.Drawing.Point(623, 31);
            this.weekLabel.Name = "weekLabel";
            this.weekLabel.Size = new System.Drawing.Size(126, 37);
            this.weekLabel.TabIndex = 20;
            this.weekLabel.Text = "week of";
            this.weekLabel.Visible = false;
            // 
            // MainScreen
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1684, 851);
            this.Controls.Add(this.weekLabel);
            this.Controls.Add(this.logoutButton);
            this.Controls.Add(this.changeViewButton);
            this.Controls.Add(this.genReport);
            this.Controls.Add(this.manageCust);
            this.Controls.Add(this.deleteApp);
            this.Controls.Add(this.editApp);
            this.Controls.Add(this.addApp);
            this.Controls.Add(this.monthLabel);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.saturdayLabel);
            this.Controls.Add(this.fridayLabel);
            this.Controls.Add(this.tuesdayLabel);
            this.Controls.Add(this.mondayLabel);
            this.Controls.Add(this.sundayLabel);
            this.Controls.Add(this.dayContainer);
            this.Controls.Add(this.wednesdayLabel);
            this.Controls.Add(this.thursdayLabel);
            this.Name = "MainScreen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainScreen_FormClosed);
            this.Load += new System.EventHandler(this.MainScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.appointmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.addressBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tableUpdateStatementBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel dayContainer;
        private System.Windows.Forms.Label sundayLabel;
        private System.Windows.Forms.Label mondayLabel;
        private System.Windows.Forms.Label tuesdayLabel;
        private System.Windows.Forms.Label wednesdayLabel;
        private System.Windows.Forms.Label thursdayLabel;
        private System.Windows.Forms.Label fridayLabel;
        private System.Windows.Forms.Label saturdayLabel;
        private System.Windows.Forms.BindingSource tableUpdateStatementBindingSource;
        private System.Windows.Forms.BindingSource dataSetBindingSource;
        private dataSet dataSet;
        private System.Windows.Forms.BindingSource appointmentBindingSource;
        private dataSetTableAdapters.appointmentTableAdapter appointmentTableAdapter;
        private System.Windows.Forms.BindingSource addressBindingSource;
        private dataSetTableAdapters.addressTableAdapter addressTableAdapter;
        private dataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label monthLabel;
        private System.Windows.Forms.Button addApp;
        private System.Windows.Forms.Button editApp;
        private System.Windows.Forms.Button deleteApp;
        private System.Windows.Forms.Button manageCust;
        private System.Windows.Forms.Button genReport;
        private System.Windows.Forms.Button changeViewButton;
        private System.Windows.Forms.Button logoutButton;
        private System.Windows.Forms.Label weekLabel;
    }
}