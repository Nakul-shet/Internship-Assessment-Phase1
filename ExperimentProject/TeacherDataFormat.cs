using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentProject
{
    public class TeacherDataFormat
    {
        private int id;
        private string name;
        private string classSection;

        public TeacherDataFormat(int id, string name, string classSection)
        {
            this.id = id;
            this.name = name;
            this.classSection = classSection;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ClassSection
        {
            get { return classSection; }
            set { classSection = value; }
        }
    }
}
