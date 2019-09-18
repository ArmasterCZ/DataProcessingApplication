using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //check input
            List<string> input = ValidateUserInput(args);
            if (input.Count == 2)
            {
                //load file
                List<StudentGroup> loadedGroups = LoadFile(args[0]);
                DisplayInformation(loadedGroups);

                //transform and calculate
                OutputModel outputModel = TransformToOutput(loadedGroups);

                //save file
                string filePath = AppDomain.CurrentDomain.BaseDirectory;
                SaveFile(filePath, input[1], "all", outputModel);
            }
        }

        /// <summary>
        /// validate if file exist and what output is requested
        /// </summary>
        /// <returns>list[0] == path, list[1] == outputFormat</returns>
        private static List<string> ValidateUserInput(string[] userInput)
        {
            List<string> validatedOutput = new List<string>();

            if (userInput.Length == 1)
            {
                if (File.Exists(userInput[0]))
                {
                    validatedOutput.Add(userInput[0]);
                    validatedOutput.Add("xml");
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                    Console.WriteLine("Please write (Path to data file) and requested output (Xml or Json) separated by space.");
                }
                
            }
            else if (userInput.Length == 2)
            {
                if (File.Exists(userInput[0]))
                {
                    validatedOutput.Add(userInput[0]);
                    validatedOutput.Add(userInput[1].ToLower());
                }
                else
                {
                    Console.WriteLine("File does not exist.");
                    Console.WriteLine("Please write (Path to data file) and requested output (Xml or Json) separated by space.");
                }
            }
            else
            {
                Console.WriteLine("Number of input argument isnt right.");
                Console.WriteLine("Please write (Path to data file) and requested output (Xml or Json) separated by space.");
            }

            return validatedOutput;
        }

        /// <summary>
        /// read file and create models
        /// </summary>
        /// <param name="path">path to file with stored data</param>
        /// <returns>models from input data</returns>
        private static List<StudentGroup> LoadFile(string path)
        {
            FileLoader fileLoader = new FileLoader(path);
            List<StudentGroup> loadedGroups = fileLoader.LoadFile();
            return loadedGroups;
        }

        /// <summary>
        /// show number of loaded students/groups and error in console
        /// </summary>
        private static void DisplayInformation(List<StudentGroup> loadedGroups)
        {
            int studentCount = 0;
            int errorCount = 0;
            foreach (var group in loadedGroups)
            {
                studentCount += group.StudentList.Count;
                errorCount += group.ErrorList.Count;
            }
            Console.WriteLine($"Number of loaded groups: {loadedGroups.Count}");
            Console.WriteLine($"Number of loaded items:  {studentCount}");
            Console.WriteLine($"Number of Errors:  {errorCount}");
        }

        /// <summary>
        /// calculate all requested statistics
        /// </summary>
        /// <returns>models ready for serialize to file</returns>
        private static OutputModel TransformToOutput(List<StudentGroup> loadedGroups)
        {
            OutputModel output = new OutputModel();
            output.LoadData(loadedGroups);
            return output;
        }

        /// <summary>
        /// save serialized file
        /// </summary>
        /// <param name="filePath">where file will be saved</param>
        /// <param name="extension">json or xml</param>
        /// <param name="fileName">name of output file</param>
        /// <param name="loadedGroups">data for serialization</param>
        private static void SaveFile(string filePath,string extension, string fileName, OutputModel loadedGroups)
        {
            string fullpath;
            switch (extension)
            {
                case "xml":
                    fullpath = Path.Combine(filePath, fileName + ".xml");
                    FileSaver.SerialToXmlFile(fullpath, loadedGroups);
                    Console.WriteLine($"File saved to {fullpath}");
                    break;
                case "json":
                    fullpath = Path.Combine(filePath, fileName + ".json");
                    FileSaver.SerialToJsonFile(fullpath, loadedGroups);
                    Console.WriteLine($"File saved to {fullpath}");
                    break;
                default:
                    Console.WriteLine($"Not valid type of extension: '{extension}'");
                    break;
            }
        }

    }

}


