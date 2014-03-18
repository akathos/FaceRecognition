using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
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
    static class Program
    {
        public const string trainingSetDir = @".\trainingset";
        public const string trainingSetCSVFile = trainingSetDir + @"\data.csv";
        public const string eigenImageDir = trainingSetDir + @"\eigen";
        public const string averageImageName = eigenImageDir + @"\average.bmp";
        public const string eigenImageName = eigenImageDir + @"\eigenimage";
        public const string imageExt = ".bmp";
        public const int trainingImgHeight = 100;
        public const int trainingImgWidth = 100;
        public const int maxEigenFaces = 18;
        public const double eigenDistanceThreshold = 10000;

        public static EigenObjectRecognizer recognizer;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Convert();

            // Train training set
            Train();

            //Test();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmFaceRecognition());
        }

        // Converts the images in a directory into the appropriate dimension 
        // and saves them to the trianing set directory
        public static void Convert()
        {
            // Load the images in the directory with training set images
            DirectoryInfo di = new DirectoryInfo(@".\trainingset\tests");
            FileInfo[] fi = di.GetFiles("*", SearchOption.TopDirectoryOnly);

            // Empty the data csv file
            System.IO.File.WriteAllText(trainingSetCSVFile, "FileName, Label\r\n");

            foreach (FileInfo file in fi)
            {
                //// Convert the image into gray and the training width and height
                //Image<Gray, Byte> image = new Image<Gray, Byte>(file.FullName);
                //image = image.Resize(trainingImgWidth, trainingImgHeight, INTER.CV_INTER_CUBIC);

                //// Save file in bmp
                //string label = Path.GetFileNameWithoutExtension(file.FullName);
                //string fileName = label + imageExt;
                //image.Save(@".\trainingset\" + fileName);

                List<RecognizerResult> list = Detect(file.FullName);
                string fileName = Path.GetFileName(list[0].FileName);
                File.Move(list[0].FileName, trainingSetDir + @"/" + fileName);

                // Add item to CSV
                TrainingItem item = new TrainingItem();
                item.FileName = fileName;
                item.Label = Path.GetFileNameWithoutExtension(list[0].FileName);
                item.AddToCSV(trainingSetCSVFile);
            }
        }

        public static void Test()
        {
            // Load the images in the directory with training set images
            DirectoryInfo di = new DirectoryInfo(@".\testingset\tests");
            FileInfo[] fi = di.GetFiles("*", SearchOption.TopDirectoryOnly);

            foreach (FileInfo file in fi)
            {
                List<RecognizerResult> resultList = Detect(file.FullName);

                foreach (RecognizerResult result in resultList)
                {
                    result.save();
                }
            }
        }

        public static List<RecognizerResult> Detect(string imageFile)
        {
            List<RecognizerResult> rcgnResultList = new List<RecognizerResult>();

            Image<Bgr, Byte> image;

            try
            {
                image = new Image<Bgr, byte>(imageFile); //Read the files as an 8-bit Bgr image  
            }
            catch(Exception e)
            {
                return rcgnResultList;
            }

            // if image is too large, resize it
            if (image.Width > 480)
                image = image.Resize(((double)480 / (double)image.Width), INTER.CV_INTER_CUBIC);

            List<Rectangle> faces = new List<Rectangle>();
            DetectFace.Detect(image, "haarcascade_frontalface_default.xml", faces);

            Image<Bgr, Byte> markedImage = image.Copy();

            for(int index = 0; index < faces.Count; index++)
            {
                Rectangle face = faces[index];
                
                // Save the detected faces to testing set
                Image<Gray, Byte> result = image.Copy(face).Convert<Gray, Byte>();
                result = result.Resize(trainingImgWidth, trainingImgHeight, INTER.CV_INTER_CUBIC);

                string fileName = String.Format(@".\testingset\{0}.face{1}.bmp", 
                    Path.GetFileName(imageFile), index);
                result.Save(fileName);

                // Mark the detected face on the image
                markedImage.Draw(face, new Bgr(Color.Blue), 2);

                // Try to recognize the face
                RecognizerResult rcgnResult = Recognize(fileName);
                rcgnResultList.Add(rcgnResult);
            }

            // Save the marked image to testing set
            markedImage.Save(String.Format(@".\testingset\marked\{0}.bmp", Path.GetFileName(imageFile)));
            return rcgnResultList;
        }

        public static RecognizerResult Recognize(string unknownImg)
        {
            RecognizerResult rcgnResult = new RecognizerResult();

            if (recognizer == null)
                return null;

            // Recognize the image
            Image<Gray, Byte> testImage = new Image<Gray, Byte>(unknownImg);


            float[] distances = recognizer.GetEigenDistances(testImage);
            string[] labels = recognizer.Labels;
            int num = labels.Count();

            for (int i = 0; i < num; i++)
            {
                rcgnResult.Distances.Add(labels[i], distances[i]);
            }

            EigenObjectRecognizer.RecognitionResult result = recognizer.Recognize(testImage);
            
            if (result != null)
            {
                rcgnResult.Distance = result.Distance;
                rcgnResult.Label = result.Label;
            }
            rcgnResult.FileName = Path.GetFullPath(unknownImg);

            return rcgnResult;
        }

        public static void Train()
        {
            List < TrainingItem > items = TrainingItem.Load(trainingSetCSVFile);

            Image<Gray, Byte>[] trainingImages = new Image<Gray, Byte>[items.Count];
            String[] labels = new String[items.Count];

            for (int index = 0; index < items.Count; index++)
            {
                trainingImages[index] = new Image<Gray, byte>(trainingSetDir + @"\" + items[index].FileName);
                labels[index] = Path.GetFileNameWithoutExtension(items[index].Label); 
            }

            MCvTermCriteria termCrit = new MCvTermCriteria(maxEigenFaces, 0.001);

            // Initialize Eigen Recognizer Object
            recognizer = new EigenObjectRecognizer(
                trainingImages,
                labels,
                eigenDistanceThreshold,
                ref termCrit);

            // Remove all old eigen images
            DirectoryInfo eigenDir = new DirectoryInfo(eigenImageDir);
            FileInfo[] eigenFiles = eigenDir.GetFiles();
            foreach (FileInfo file in eigenFiles)
                file.Delete();

            // Save the average Image
            recognizer.AverageImage.Save(averageImageName);

            // Save all eigen images
            for (int index = 0; index < recognizer.EigenImages.Length; index++)
            {
                String fileName = eigenImageName + (index + 1) + imageExt;
                recognizer.EigenImages[index].ToBitmap().Save(fileName);
            }

            // Print eigen values
            Console.WriteLine(String.Format("Num eigen values: {0}", recognizer.EigenValues.Length));
            Console.WriteLine(String.Format("Num rows in eigen values: {0}", recognizer.EigenValues[0].Rows));
            Console.WriteLine(String.Format("Num cols in eigen values: {0}", recognizer.EigenValues[0].Cols));
        }      
    }
}
