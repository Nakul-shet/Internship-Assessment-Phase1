using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentProject
{
    public class TeacherDataFile
    {
        private string filePath;

        public TeacherDataFile(string filePath)
        {
            this.filePath = filePath;
        }

        public void AddTeacherData(TeacherDataFormat teacherData)
        {

            using (FileStream fileStream = new FileStream(filePath, FileMode.Append, FileAccess.Write))
            {
                string line = $"{teacherData.Id},{teacherData.Name},{teacherData.ClassSection}\n";
                byte[] lineBytes = Encoding.UTF8.GetBytes(line);
                fileStream.Write(lineBytes, 0, lineBytes.Length);
            }
        }


        public TeacherDataFormat GetTeacherDataById(int id)
        {
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string[] lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(',');
                        if (int.Parse(fields[0]) == id)
                        {
                            return new TeacherDataFormat(id, fields[1], fields[2]);
                        }
                    }
                }
            }
            return null;
        }

        public void UpdateTeacherDataById(int id, string name, string classSection)
        {
            string tempFilePath = Path.GetTempFileName();
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            using (StreamWriter writer = new StreamWriter(tempFilePath))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string[] lines = data.Split('\n', StringSplitOptions.RemoveEmptyEntries);
                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(',');
                        if (int.Parse(fields[0]) == id)
                        {
                            writer.WriteLine($"{id},{name},{classSection}");
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
            }
            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
        }
    }
}
