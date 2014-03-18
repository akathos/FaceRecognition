using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.GPU;
using Emgu.Util;

namespace FaceRecognition
{
    public partial class frmFaceRecognition : Form
    {
        private List<RecognizerResult> rcgnResultList;

        public frmFaceRecognition()
        {
            InitializeComponent();

            showTrainingSet();
            showEigenFaces();
        }

        public void showTrainingSet()
        {
            DirectoryInfo di = new DirectoryInfo(Program.trainingSetDir);
            FileInfo[] fi = di.GetFiles("*" + Program.imageExt, SearchOption.TopDirectoryOnly);
            
            int i = 0;
            foreach (FileInfo file in fi)
            {
                ilTrainingSet.Images.Add(System.Drawing.Image.FromFile(file.FullName));
                lvTrainingSet.Items.Add(file.Name, i);
                i++;
            }
        }

        public void showEigenFaces()
        {
            DirectoryInfo di = new DirectoryInfo(Program.eigenImageDir);
            FileInfo[] fi = di.GetFiles("*" + Program.imageExt, SearchOption.TopDirectoryOnly);

            int i = 0;
            foreach (FileInfo file in fi)
            {
                ilEigenFaces.Images.Add(System.Drawing.Image.FromFile(file.FullName));
                lvEigenFaces.Items.Add(file.Name, i);
                i++;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Clear the prediction and distance labels
            lblDistance.Text = string.Empty;
            lblPrediction.Text = string.Empty;
            txtLabel.Text = string.Empty;

            // Open the file dialog for user to select their testing image
            OpenFileDialog fileDialog = new OpenFileDialog();
        
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtImagePath.Text = fileDialog.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }

                rcgnResultList = Program.Detect(fileDialog.FileName);
                
                // Display the marked image
                Image<Bgr, Byte> image = new Image<Bgr, Byte>(
                    "./testingset/marked/" + Path.GetFileName(fileDialog.FileName) + ".bmp");

                imgTest.Image = image;

                ilResults.Images.Clear();
                lvResults.Items.Clear();

                int i = 0;
                foreach (RecognizerResult rcgnResult in rcgnResultList)
                {
                    ilResults.Images.Add(System.Drawing.Image.FromFile(rcgnResult.FileName));
                    lvResults.Items.Add(String.Format("{0}, {1:F2}%", rcgnResult.Label, rcgnResult.accuracy()), i);
                    i++;
                }
            }
        }

        private void lvResults_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            int selectedIndex = lvResults.SelectedIndices[0];
            if(selectedIndex >= 0 && selectedIndex < rcgnResultList.Count)
            {
                lblDistance.Text = String.Format("Distance: {0:F2}", rcgnResultList[selectedIndex].Distance);
                lblPrediction.Text = String.Format("Prediction: {0:F2}%", rcgnResultList[selectedIndex].accuracy());
                txtLabel.Text = rcgnResultList[selectedIndex].Label;
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            int selectedIndex = lvResults.SelectedIndices[0];
            if (selectedIndex >= 0 && selectedIndex < rcgnResultList.Count)
            {
                string sourceFile = rcgnResultList[selectedIndex].FileName;
                string destFile = Program.trainingSetDir + @"\" + Path.GetFileName(sourceFile);

                // Check if this image is already part of the training set
                if (File.Exists(destFile))
                {
                    System.Windows.Forms.MessageBox.Show("This image already exist in the training set.");
                    return;
                }

                // Copy the result image file to training set folder
                System.IO.File.Copy(sourceFile, destFile, true);

                // Add the item to the training set
                TrainingItem item = new TrainingItem();
                item.FileName = Path.GetFileName(sourceFile);
                item.Label = txtLabel.Text;
                item.AddToCSV(Program.trainingSetCSVFile);

                // Process the update training set and update the display tabs
                //ilTrainingSet.Images.Clear();
                //lvTrainingSet.Items.Clear();
                //ilEigenFaces.Images.Clear();
                //lvEigenFaces.Items.Clear();
                //Program.Train();
                //showTrainingSet();
                //showEigenFaces();
            }
        }
    }
}
