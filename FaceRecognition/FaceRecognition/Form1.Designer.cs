namespace FaceRecognition
{
    partial class frmFaceRecognition
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.lblLabel = new System.Windows.Forms.Label();
            this.lblDistance = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtLabel = new System.Windows.Forms.TextBox();
            this.lblPrediction = new System.Windows.Forms.Label();
            this.lvResults = new System.Windows.Forms.ListView();
            this.ilResults = new System.Windows.Forms.ImageList(this.components);
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtImagePath = new System.Windows.Forms.TextBox();
            this.imgTest = new Emgu.CV.UI.ImageBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvTrainingSet = new System.Windows.Forms.ListView();
            this.ilTrainingSet = new System.Windows.Forms.ImageList(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.lvEigenFaces = new System.Windows.Forms.ListView();
            this.ilEigenFaces = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTest)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(685, 496);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpResults);
            this.tabPage1.Controls.Add(this.btnBrowse);
            this.tabPage1.Controls.Add(this.txtImagePath);
            this.tabPage1.Controls.Add(this.imgTest);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(677, 470);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Image";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grpResults
            // 
            this.grpResults.Controls.Add(this.lblLabel);
            this.grpResults.Controls.Add(this.lblDistance);
            this.grpResults.Controls.Add(this.btnSave);
            this.grpResults.Controls.Add(this.txtLabel);
            this.grpResults.Controls.Add(this.lblPrediction);
            this.grpResults.Controls.Add(this.lvResults);
            this.grpResults.Location = new System.Drawing.Point(439, 0);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(231, 463);
            this.grpResults.TabIndex = 6;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Results";
            // 
            // lblLabel
            // 
            this.lblLabel.AutoSize = true;
            this.lblLabel.Location = new System.Drawing.Point(6, 416);
            this.lblLabel.Name = "lblLabel";
            this.lblLabel.Size = new System.Drawing.Size(38, 13);
            this.lblLabel.TabIndex = 10;
            this.lblLabel.Text = "Name:";
            // 
            // lblDistance
            // 
            this.lblDistance.AutoSize = true;
            this.lblDistance.Location = new System.Drawing.Point(129, 394);
            this.lblDistance.Name = "lblDistance";
            this.lblDistance.Size = new System.Drawing.Size(94, 13);
            this.lblDistance.TabIndex = 9;
            this.lblDistance.Text = "Distance: 5000.00";
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSave.Location = new System.Drawing.Point(3, 437);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(225, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Add To Training Set";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtLabel
            // 
            this.txtLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtLabel.Location = new System.Drawing.Point(47, 413);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(178, 20);
            this.txtLabel.TabIndex = 7;
            // 
            // lblPrediction
            // 
            this.lblPrediction.AutoSize = true;
            this.lblPrediction.Location = new System.Drawing.Point(6, 394);
            this.lblPrediction.Name = "lblPrediction";
            this.lblPrediction.Size = new System.Drawing.Size(86, 13);
            this.lblPrediction.TabIndex = 6;
            this.lblPrediction.Text = "Prediction: 100%";
            // 
            // lvResults
            // 
            this.lvResults.LargeImageList = this.ilResults;
            this.lvResults.Location = new System.Drawing.Point(3, 19);
            this.lvResults.Name = "lvResults";
            this.lvResults.Size = new System.Drawing.Size(225, 372);
            this.lvResults.TabIndex = 5;
            this.lvResults.UseCompatibleStateImageBehavior = false;
            this.lvResults.SelectedIndexChanged += new System.EventHandler(this.lvResults_SelectedIndexChanged);
            // 
            // ilResults
            // 
            this.ilResults.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilResults.ImageSize = new System.Drawing.Size(100, 100);
            this.ilResults.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(358, 437);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 4;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtImagePath
            // 
            this.txtImagePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtImagePath.Enabled = false;
            this.txtImagePath.Location = new System.Drawing.Point(3, 439);
            this.txtImagePath.Name = "txtImagePath";
            this.txtImagePath.Size = new System.Drawing.Size(349, 20);
            this.txtImagePath.TabIndex = 3;
            // 
            // imgTest
            // 
            this.imgTest.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.PanAndZoom;
            this.imgTest.Location = new System.Drawing.Point(3, 3);
            this.imgTest.Name = "imgTest";
            this.imgTest.Size = new System.Drawing.Size(430, 430);
            this.imgTest.TabIndex = 2;
            this.imgTest.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvTrainingSet);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(677, 470);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Training Set";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvTrainingSet
            // 
            this.lvTrainingSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTrainingSet.LargeImageList = this.ilTrainingSet;
            this.lvTrainingSet.Location = new System.Drawing.Point(3, 3);
            this.lvTrainingSet.Name = "lvTrainingSet";
            this.lvTrainingSet.Size = new System.Drawing.Size(671, 464);
            this.lvTrainingSet.TabIndex = 0;
            this.lvTrainingSet.UseCompatibleStateImageBehavior = false;
            // 
            // ilTrainingSet
            // 
            this.ilTrainingSet.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilTrainingSet.ImageSize = new System.Drawing.Size(100, 100);
            this.ilTrainingSet.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lvEigenFaces);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(677, 470);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Eigen Faces";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // lvEigenFaces
            // 
            this.lvEigenFaces.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvEigenFaces.LargeImageList = this.ilEigenFaces;
            this.lvEigenFaces.Location = new System.Drawing.Point(0, 0);
            this.lvEigenFaces.Name = "lvEigenFaces";
            this.lvEigenFaces.Size = new System.Drawing.Size(677, 470);
            this.lvEigenFaces.TabIndex = 0;
            this.lvEigenFaces.UseCompatibleStateImageBehavior = false;
            // 
            // ilEigenFaces
            // 
            this.ilEigenFaces.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilEigenFaces.ImageSize = new System.Drawing.Size(100, 100);
            this.ilEigenFaces.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmFaceRecognition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(685, 496);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmFaceRecognition";
            this.Text = "Face Recognition";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grpResults.ResumeLayout(false);
            this.grpResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTest)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtImagePath;
        private Emgu.CV.UI.ImageBox imgTest;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList ilTrainingSet;
        private System.Windows.Forms.ListView lvTrainingSet;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ListView lvEigenFaces;
        private System.Windows.Forms.ImageList ilEigenFaces;
        private System.Windows.Forms.ListView lvResults;
        private System.Windows.Forms.ImageList ilResults;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtLabel;
        private System.Windows.Forms.Label lblPrediction;
        private System.Windows.Forms.Label lblLabel;
        private System.Windows.Forms.Label lblDistance;
    }
}

