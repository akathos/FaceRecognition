using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FaceRecognition
{
    class RecognizerResult
    {
        public const string saveFile = @".\testingset\tests\save.csv";
        public string FileName { get; set; }
        public string Label { get; set; }
        public float Distance { get; set; }  // prediction accuracy
        public Dictionary<string, float> Distances { get; set; }

        public RecognizerResult()
        {
            this.Distances = new Dictionary<string, float>();
        }

        // returns the percent of the prediction accuracy
        public float accuracy()
        {
            return (((float)Program.eigenDistanceThreshold - this.Distance) / (float)Program.eigenDistanceThreshold) * 100;;
        }

        // write the results to a file
        public void header()
        {
            File.AppendAllText(saveFile, string.Empty);

            foreach (KeyValuePair<string, float> pair in this.Distances)
            {
                File.AppendAllText(saveFile, String.Format("{0}, ", pair.Key));
            }

            File.AppendAllText(saveFile, String.Format("{0}", Environment.NewLine));
        }

        // write the results to a file
        public void save()
        {
            //this.header();

            foreach (KeyValuePair<string, float> pair in this.Distances)
            {
                File.AppendAllText(saveFile, String.Format("{0}, ", pair.Value));
            }

            File.AppendAllText(saveFile, String.Format("{0}, {1}, {2}, {3}", Path.GetFileName(this.FileName), this.Label, this.Distance, this.accuracy()) + Environment.NewLine);
        }
    }
}
