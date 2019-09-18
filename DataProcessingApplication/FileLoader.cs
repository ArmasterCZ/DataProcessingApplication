using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataProcessingApplication
{
    /// <summary>
    /// load and convert file to List of Models <see cref="LoadFile"/>
    /// </summary>
    class FileLoader
    {
        public string FilePath { get; set; }

        public FileLoader(string filePath)
        {
            FilePath = filePath;
        }

        /// <summary>
        /// load file and create 
        /// </summary>
        /// <returns>list of loaded groups (with students)</returns>
        public List<StudentGroup> LoadFile()
        {
            int counter = 0;
            bool previousLineWasEmpty = false;
            List<StudentGroup> groups = new List<StudentGroup>();
            StudentGroup currentGroup = new StudentGroup();

            using (StreamReader sr = new StreamReader(FilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (counter == 0)
                    {
                        //to ignore begining
                    }
                    else if (line.Length == 0)
                    {
                        //to ignore empty line (determine begining of new group)
                        previousLineWasEmpty = true;
                    }
                    else if (previousLineWasEmpty)
                    {
                        //add group to list and create new one
                        if (!String.IsNullOrEmpty(currentGroup.Name))
                        {
                            groups.Add(currentGroup);
                        }
                        currentGroup = new StudentGroup();
                        currentGroup.Name = line;
                        previousLineWasEmpty = false;
                    } else
                    {
                        //add student to group (or save exception)
                        AddStudentToGroup(line, currentGroup);
                        previousLineWasEmpty = false;
                    }

                    counter++;
                }

                //add assembled group (in case file not end with empty line)
                if (!String.IsNullOrEmpty(currentGroup.Name))
                {
                    groups.Add(currentGroup);
                }
                else
                {
                    currentGroup.ErrorList.Add(new ErrorModel() { Type = "Group was not added", Description = $"Grop with '{currentGroup.StudentList.Count()}' students cannot have empty name." });
                }

                return groups;
            }

        }

        /// <summary>
        /// transform string from file to Student model
        /// </summary>
        /// <param name="line">string like "George Faust;Math=11;Physics=50;English=42"</param>
        /// <returns>filled model</returns>
        private StudentModel TransformStringToStudent(string line)
        {
            //splited line to Name/Math/Physics/English
            List<string> splitedLine = line.Split(';').ToList();
            StudentModel studentModel = new StudentModel();

            for (int i = 0; i < splitedLine.Count(); i++)
            {
                //first part of line is name
                if (i == 0)
                {
                    studentModel.Name = splitedLine[0];
                }
                else
                {
                    //other parts of line are matched by subject from (subject=value)
                    try
                    {
                        SubdivisionOfSubjects(splitedLine[i], studentModel);
                    }
                    catch (Exception)
                    {
                        throw new Exception($"Cannot process student {studentModel.Name} , from line {splitedLine[i]}");
                    }
                   
                }
            }
            return studentModel;
        }

        /// <summary>
        /// fill <see cref="StudentModel" /> properties
        /// </summary>
        /// <param name="splitedLine">part of the line like "Physics=50" or "Math=11"</param>
        /// <param name="studentModel">filled model</param>
        private void SubdivisionOfSubjects(string splitedLine, StudentModel studentModel)
        {
            string[] splitedSegment = splitedLine.Split('=');
            if (splitedSegment.Length == 2)
            {
                switch (splitedSegment[0].ToLower())
                {
                    case "math":
                        studentModel.Math = Convert.ToInt32(splitedSegment[1]);
                        break;
                    case "physics":
                        studentModel.Physics = Convert.ToInt32(splitedSegment[1]);
                        break;
                    case "english":
                        studentModel.English = Convert.ToInt32(splitedSegment[1]);
                        break;
                    default:
                        break;
                }
            }
            else
            {
                throw new Exception($"Cannot readed values from file in from line: {"'"} {splitedLine} {"'"}");
            }
        }

        /// <summary>
        /// add user to group or create error
        /// </summary>
        /// <param name="line">string like "George Faust;Math=11;Physics=50;English=42"</param>
        /// <param name="currentGroup">existing group of students</param>
        private void AddStudentToGroup(string line, StudentGroup currentGroup)
        {
            //add student to group (or save exception)
            try
            {
                var student = TransformStringToStudent(line);
                if (student.IsValid())
                {
                    currentGroup.StudentList.Add(student);
                }
                else
                {
                    throw new Exception($"Student with name '{student.Name}' have corrupted data in file.");
                }
            }
            catch (Exception exc)
            {
                currentGroup.ErrorList.Add(new ErrorModel() { Type = "Student not added", Description = exc.Message });
            }

        }

    }
}
