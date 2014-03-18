using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FaceRecognition
{
    class TrainingItem
    {
        public string FileName { get; set; }
        public string Label { get; set; }

        // Writes this item to csv file
        public void AddToCSV(string csvFile)
        {
            File.AppendAllText(csvFile, String.Format("{0}, {1}", this.FileName, this.Label) + Environment.NewLine);
        }

        // Load an array of training set items from the csv file
        public static List<TrainingItem> Load(string csvFile)
        {
            List<TrainingItem> trainingItems = new List<TrainingItem>();
            string line;
            string[] items;

            // Read the file and display it line by line.
            System.IO.StreamReader file = new System.IO.StreamReader(csvFile);

            // Skip the first line since it is the header
            file.ReadLine();

            while ((line = file.ReadLine()) != null)
            {
                TrainingItem trainingItem = new TrainingItem();
                items = line.Split(',');
                trainingItem.FileName = items[0];
                trainingItem.Label = items[1];
                trainingItems.Add(trainingItem);
            }

            file.Close();

            return trainingItems;
        }
    }
}
