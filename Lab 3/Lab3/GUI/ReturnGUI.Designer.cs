namespace Lab3.GUI
{
    partial class ReturnGUI
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtMemberCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.btCheckMember = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.libraryDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.libraryDataSet = new Lab3.LibraryDataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtReturnDate = new System.Windows.Forms.TextBox();
            this.txtFindAmount = new System.Windows.Forms.TextBox();
            this.btConfirmFine = new System.Windows.Forms.Button();
            this.btReturn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lbNumberOfBorrowedBooks = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(49, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Member Code :";
            // 
            // txtMemberCode
            // 
            this.txtMemberCode.Location = new System.Drawing.Point(216, 31);
            this.txtMemberCode.Name = "txtMemberCode";
            this.txtMemberCode.Size = new System.Drawing.Size(169, 20);
            this.txtMemberCode.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(118, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 24);
            this.label3.TabIndex = 1;
            this.label3.Text = "Name : ";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(216, 76);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(169, 20);
            this.txtName.TabIndex = 2;
            // 
            // btCheckMember
            // 
            this.btCheckMember.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btCheckMember.Location = new System.Drawing.Point(433, 31);
            this.btCheckMember.Name = "btCheckMember";
            this.btCheckMember.Size = new System.Drawing.Size(139, 32);
            this.btCheckMember.TabIndex = 3;
            this.btCheckMember.Text = " Check Member";
            this.btCheckMember.UseVisualStyleBackColor = true;
            this.btCheckMember.Click += new System.EventHandler(this.btCheckMember_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "The number of borrowed books : ";
            // 
            // libraryDataSetBindingSource
            // 
            this.libraryDataSetBindingSource.DataSource = this.libraryDataSet;
            this.libraryDataSetBindingSource.Position = 0;
            // 
            // libraryDataSet
            // 
            this.libraryDataSet.DataSetName = "LibraryDataSet";
            this.libraryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(49, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 24);
            this.label4.TabIndex = 1;
            this.label4.Text = "Returned  Date : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(518, 371);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(135, 24);
            this.label5.TabIndex = 1;
            this.label5.Text = "Fine amount :";
            // 
            // txtReturnDate
            // 
            this.txtReturnDate.Enabled = false;
            this.txtReturnDate.Location = new System.Drawing.Point(206, 371);
            this.txtReturnDate.Name = "txtReturnDate";
            this.txtReturnDate.Size = new System.Drawing.Size(146, 20);
            this.txtReturnDate.TabIndex = 2;
            this.txtReturnDate.Validating += new System.ComponentModel.CancelEventHandler(this.txtReturnDate_Validating);
            // 
            // txtFindAmount
            // 
            this.txtFindAmount.Enabled = false;
            this.txtFindAmount.Location = new System.Drawing.Point(676, 372);
            this.txtFindAmount.Name = "txtFindAmount";
            this.txtFindAmount.Size = new System.Drawing.Size(117, 20);
            this.txtFindAmount.TabIndex = 2;
            // 
            // btConfirmFine
            // 
            this.btConfirmFine.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btConfirmFine.Location = new System.Drawing.Point(135, 419);
            this.btConfirmFine.Name = "btConfirmFine";
            this.btConfirmFine.Size = new System.Drawing.Size(134, 29);
            this.btConfirmFine.TabIndex = 3;
            this.btConfirmFine.Text = "Confirm Fine";
            this.btConfirmFine.UseVisualStyleBackColor = true;
            this.btConfirmFine.Click += new System.EventHandler(this.btConfirmFine_Click);
            // 
            // btReturn
            // 
            this.btReturn.Enabled = false;
            this.btReturn.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btReturn.Location = new System.Drawing.Point(324, 419);
            this.btReturn.Name = "btReturn";
            this.btReturn.Size = new System.Drawing.Size(131, 29);
            this.btReturn.TabIndex = 3;
            this.btReturn.Text = "Return";
            this.btReturn.UseVisualStyleBackColor = true;
            this.btReturn.Click += new System.EventHandler(this.btReturn_Click);
            // 
            // button3
            // 
            this.button3.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.button3.Location = new System.Drawing.Point(80, 803);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(129, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = " Check Member";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // lbNumberOfBorrowedBooks
            // 
            this.lbNumberOfBorrowedBooks.AutoSize = true;
            this.lbNumberOfBorrowedBooks.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNumberOfBorrowedBooks.Location = new System.Drawing.Point(299, 139);
            this.lbNumberOfBorrowedBooks.Name = "lbNumberOfBorrowedBooks";
            this.lbNumberOfBorrowedBooks.Size = new System.Drawing.Size(19, 21);
            this.lbNumberOfBorrowedBooks.TabIndex = 6;
            this.lbNumberOfBorrowedBooks.Text = "0";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(47, 182);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(765, 150);
            this.dataGridView1.TabIndex = 7;
            // 
            // ReturnGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 483);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbNumberOfBorrowedBooks);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btReturn);
            this.Controls.Add(this.btConfirmFine);
            this.Controls.Add(this.btCheckMember);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtFindAmount);
            this.Controls.Add(this.txtReturnDate);
            this.Controls.Add(this.txtMemberCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "ReturnGUI";
            this.Text = "Return";
            ((System.ComponentModel.ISupportInitialize)(this.libraryDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.libraryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMemberCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btCheckMember;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource libraryDataSetBindingSource;
        private LibraryDataSet libraryDataSet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtReturnDate;
        private System.Windows.Forms.TextBox txtFindAmount;
        private System.Windows.Forms.Button btConfirmFine;
        private System.Windows.Forms.Button btReturn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbNumberOfBorrowedBooks;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}