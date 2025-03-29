namespace lb2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.LookUpFiles = new System.Windows.Forms.Button();
            this.EncOrDec = new System.Windows.Forms.ComboBox();
            this.SelectedFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.FirstKey = new System.Windows.Forms.TextBox();
            this.FirstFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SecondKey = new System.Windows.Forms.TextBox();
            this.SecondFile = new System.Windows.Forms.TextBox();
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.SaveResult = new System.Windows.Forms.Button();
            this.CleanAll = new System.Windows.Forms.Button();
            this.Count = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LookUpFiles
            // 
            this.LookUpFiles.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LookUpFiles.Location = new System.Drawing.Point(388, 45);
            this.LookUpFiles.Name = "LookUpFiles";
            this.LookUpFiles.Size = new System.Drawing.Size(141, 33);
            this.LookUpFiles.TabIndex = 1;
            this.LookUpFiles.Text = "Обзор..";
            this.LookUpFiles.UseVisualStyleBackColor = true;
            this.LookUpFiles.Click += new System.EventHandler(this.LookUpFiles_Click);
            // 
            // EncOrDec
            // 
            this.EncOrDec.FormattingEnabled = true;
            this.EncOrDec.Items.AddRange(new object[] {
            "Шифровать",
            "Дешифровать"});
            this.EncOrDec.Location = new System.Drawing.Point(28, 94);
            this.EncOrDec.Name = "EncOrDec";
            this.EncOrDec.Size = new System.Drawing.Size(152, 24);
            this.EncOrDec.TabIndex = 2;
            // 
            // SelectedFile
            // 
            this.SelectedFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SelectedFile.Location = new System.Drawing.Point(28, 48);
            this.SelectedFile.Multiline = true;
            this.SelectedFile.Name = "SelectedFile";
            this.SelectedFile.ReadOnly = true;
            this.SelectedFile.Size = new System.Drawing.Size(344, 28);
            this.SelectedFile.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Выбранный файл";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(24, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Сеансовый ключ (27): ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(24, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Исходный файл";
            // 
            // FirstKey
            // 
            this.FirstKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstKey.Location = new System.Drawing.Point(28, 173);
            this.FirstKey.Multiline = true;
            this.FirstKey.Name = "FirstKey";
            this.FirstKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FirstKey.Size = new System.Drawing.Size(501, 52);
            this.FirstKey.TabIndex = 9;
            this.FirstKey.TextChanged += new System.EventHandler(this.FirstKey_TextChanged);
            // 
            // FirstFile
            // 
            this.FirstFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstFile.Location = new System.Drawing.Point(28, 268);
            this.FirstFile.Multiline = true;
            this.FirstFile.Name = "FirstFile";
            this.FirstFile.ReadOnly = true;
            this.FirstFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FirstFile.Size = new System.Drawing.Size(501, 192);
            this.FirstFile.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(574, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Сгенерированный ключ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(574, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(204, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Зашифрованный файл";
            // 
            // SecondKey
            // 
            this.SecondKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SecondKey.Location = new System.Drawing.Point(578, 48);
            this.SecondKey.Multiline = true;
            this.SecondKey.Name = "SecondKey";
            this.SecondKey.ReadOnly = true;
            this.SecondKey.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SecondKey.Size = new System.Drawing.Size(501, 177);
            this.SecondKey.TabIndex = 13;
            // 
            // SecondFile
            // 
            this.SecondFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SecondFile.Location = new System.Drawing.Point(578, 268);
            this.SecondFile.Multiline = true;
            this.SecondFile.Name = "SecondFile";
            this.SecondFile.ReadOnly = true;
            this.SecondFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SecondFile.Size = new System.Drawing.Size(501, 192);
            this.SecondFile.TabIndex = 14;
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.Location = new System.Drawing.Point(388, 483);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(141, 38);
            this.ExecuteButton.TabIndex = 15;
            this.ExecuteButton.Text = "Выполнить";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // SaveResult
            // 
            this.SaveResult.Location = new System.Drawing.Point(578, 483);
            this.SaveResult.Name = "SaveResult";
            this.SaveResult.Size = new System.Drawing.Size(141, 38);
            this.SaveResult.TabIndex = 16;
            this.SaveResult.Text = "Сохранить";
            this.SaveResult.UseVisualStyleBackColor = true;
            this.SaveResult.Click += new System.EventHandler(this.SaveResult_Click);
            // 
            // CleanAll
            // 
            this.CleanAll.Location = new System.Drawing.Point(938, 483);
            this.CleanAll.Name = "CleanAll";
            this.CleanAll.Size = new System.Drawing.Size(141, 38);
            this.CleanAll.TabIndex = 17;
            this.CleanAll.Text = "Очистить";
            this.CleanAll.UseVisualStyleBackColor = true;
            this.CleanAll.Click += new System.EventHandler(this.CleanAll_Click);
            // 
            // Count
            // 
            this.Count.AutoSize = true;
            this.Count.Location = new System.Drawing.Point(224, 154);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(14, 16);
            this.Count.TabIndex = 18;
            this.Count.Text = "0";
            this.Count.Click += new System.EventHandler(this.Count_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 547);
            this.Controls.Add(this.Count);
            this.Controls.Add(this.CleanAll);
            this.Controls.Add(this.SaveResult);
            this.Controls.Add(this.ExecuteButton);
            this.Controls.Add(this.SecondFile);
            this.Controls.Add(this.SecondKey);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.FirstFile);
            this.Controls.Add(this.FirstKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SelectedFile);
            this.Controls.Add(this.EncOrDec);
            this.Controls.Add(this.LookUpFiles);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LookUpFiles;
        private System.Windows.Forms.ComboBox EncOrDec;
        private System.Windows.Forms.TextBox SelectedFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox FirstKey;
        private System.Windows.Forms.TextBox FirstFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox SecondKey;
        private System.Windows.Forms.TextBox SecondFile;
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.Button SaveResult;
        private System.Windows.Forms.Button CleanAll;
        private System.Windows.Forms.Label Count;
    }
}

