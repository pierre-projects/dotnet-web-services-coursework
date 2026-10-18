namespace SearchEngineWithServices
{
    partial class Form1
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
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.encryptInput = new System.Windows.Forms.TextBox();
            this.decryptInput = new System.Windows.Forms.TextBox();
            this.EncryptResult = new System.Windows.Forms.Label();
            this.DecryptionResult = new System.Windows.Forms.Label();
            this.EncryptButton = new System.Windows.Forms.Button();
            this.DecryptButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.stockQouteInput = new System.Windows.Forms.TextBox();
            this.stockQouteResult = new System.Windows.Forms.Label();
            this.stockQouteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(82, 39);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(100, 20);
            this.searchBox.TabIndex = 0;
            this.searchBox.TextChanged += new System.EventHandler(this.searchBox_TextChanged);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(203, 35);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 1;
            this.searchButton.Text = "search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(82, 92);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(714, 388);
            this.webBrowser1.TabIndex = 2;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // encryptInput
            // 
            this.encryptInput.Location = new System.Drawing.Point(831, 47);
            this.encryptInput.Name = "encryptInput";
            this.encryptInput.Size = new System.Drawing.Size(100, 20);
            this.encryptInput.TabIndex = 3;
            this.encryptInput.TextChanged += new System.EventHandler(this.encryptInput_TextChanged);
            // 
            // decryptInput
            // 
            this.decryptInput.Location = new System.Drawing.Point(831, 95);
            this.decryptInput.Name = "decryptInput";
            this.decryptInput.Size = new System.Drawing.Size(100, 20);
            this.decryptInput.TabIndex = 4;
            this.decryptInput.TextChanged += new System.EventHandler(this.decryptInput_TextChanged);
            // 
            // EncryptResult
            // 
            this.EncryptResult.AutoSize = true;
            this.EncryptResult.Location = new System.Drawing.Point(831, 76);
            this.EncryptResult.Name = "EncryptResult";
            this.EncryptResult.Size = new System.Drawing.Size(63, 13);
            this.EncryptResult.TabIndex = 5;
            this.EncryptResult.Text = "Encryption: ";
            this.EncryptResult.Click += new System.EventHandler(this.label1_Click);
            // 
            // DecryptionResult
            // 
            this.DecryptionResult.AutoSize = true;
            this.DecryptionResult.Location = new System.Drawing.Point(831, 122);
            this.DecryptionResult.Name = "DecryptionResult";
            this.DecryptionResult.Size = new System.Drawing.Size(64, 13);
            this.DecryptionResult.TabIndex = 6;
            this.DecryptionResult.Text = "Decryption: ";
            this.DecryptionResult.Click += new System.EventHandler(this.DecryptionResult_Click);
            // 
            // EncryptButton
            // 
            this.EncryptButton.Location = new System.Drawing.Point(938, 47);
            this.EncryptButton.Name = "EncryptButton";
            this.EncryptButton.Size = new System.Drawing.Size(75, 23);
            this.EncryptButton.TabIndex = 7;
            this.EncryptButton.Text = "Encrypt";
            this.EncryptButton.UseVisualStyleBackColor = true;
            this.EncryptButton.Click += new System.EventHandler(this.EncryptButton_Click);
            // 
            // DecryptButton
            // 
            this.DecryptButton.Location = new System.Drawing.Point(938, 92);
            this.DecryptButton.Name = "DecryptButton";
            this.DecryptButton.Size = new System.Drawing.Size(75, 23);
            this.DecryptButton.TabIndex = 8;
            this.DecryptButton.Text = "Decrypt";
            this.DecryptButton.UseVisualStyleBackColor = true;
            this.DecryptButton.Click += new System.EventHandler(this.DecryptButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(831, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Encryption and Decryption Service";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(831, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Stock Qoute Service";
            // 
            // stockQouteInput
            // 
            this.stockQouteInput.Location = new System.Drawing.Point(834, 212);
            this.stockQouteInput.Name = "stockQouteInput";
            this.stockQouteInput.Size = new System.Drawing.Size(100, 20);
            this.stockQouteInput.TabIndex = 11;
            this.stockQouteInput.TextChanged += new System.EventHandler(this.stockQouteInput_TextChanged);
            // 
            // stockQouteResult
            // 
            this.stockQouteResult.AutoSize = true;
            this.stockQouteResult.Location = new System.Drawing.Point(834, 239);
            this.stockQouteResult.Name = "stockQouteResult";
            this.stockQouteResult.Size = new System.Drawing.Size(16, 13);
            this.stockQouteResult.TabIndex = 12;
            this.stockQouteResult.Text = "...";
            this.stockQouteResult.Click += new System.EventHandler(this.stockQouteResult_Click);
            // 
            // stockQouteButton
            // 
            this.stockQouteButton.Location = new System.Drawing.Point(941, 208);
            this.stockQouteButton.Name = "stockQouteButton";
            this.stockQouteButton.Size = new System.Drawing.Size(75, 23);
            this.stockQouteButton.TabIndex = 13;
            this.stockQouteButton.Text = "go";
            this.stockQouteButton.UseVisualStyleBackColor = true;
            this.stockQouteButton.Click += new System.EventHandler(this.stockQouteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 484);
            this.Controls.Add(this.stockQouteButton);
            this.Controls.Add(this.stockQouteResult);
            this.Controls.Add(this.stockQouteInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DecryptButton);
            this.Controls.Add(this.EncryptButton);
            this.Controls.Add(this.DecryptionResult);
            this.Controls.Add(this.EncryptResult);
            this.Controls.Add(this.decryptInput);
            this.Controls.Add(this.encryptInput);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox encryptInput;
        private System.Windows.Forms.TextBox decryptInput;
        private System.Windows.Forms.Label EncryptResult;
        private System.Windows.Forms.Label DecryptionResult;
        private System.Windows.Forms.Button EncryptButton;
        private System.Windows.Forms.Button DecryptButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox stockQouteInput;
        private System.Windows.Forms.Label stockQouteResult;
        private System.Windows.Forms.Button stockQouteButton;
    }
}

