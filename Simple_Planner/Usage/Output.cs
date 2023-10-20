using System.ComponentModel;
using Simple_Planner.Models;
using System.IO;
using Newtonsoft.Json;

namespace Simple_Planner.Usage
{
    internal class Planner_Output
    {
        private string PATH;

        public Planner_Output(string path)
        {
            PATH = path;
        }

        public BindingList<PlannerModel> LoadPlannerData()
        {
            bool FileExist = File.Exists(PATH);
            if (!FileExist)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<PlannerModel>();
            }
            using (var reader = File.OpenText(PATH)) 
            {
                var FileText = reader.ReadToEnd();
                if (FileText == "") { return new BindingList<PlannerModel>(); }
                return JsonConvert.DeserializeObject<BindingList<PlannerModel>>(FileText);
            }
        }

        public BindingList<QuickNotesModel> LoadQuickNotesData()
        {
            bool FileExist = File.Exists(PATH);
            if (!FileExist)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<QuickNotesModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var FileText = reader.ReadToEnd();
                if (FileText == "") { return new BindingList<QuickNotesModel>(); }
                return JsonConvert.DeserializeObject<BindingList<QuickNotesModel>>(FileText);
            }
        }

        public void SaveData(object Data)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(Data);
                writer.Write(output);
            }
        }
    }

    internal class QuickNotes_Output
    {
        private string PATH;

        public QuickNotes_Output(string path)
        {
            PATH = path;
        }

        public BindingList<QuickNotesModel> LoadQuickNotesData()
        {
            bool FileExist = File.Exists(PATH);
            if (!FileExist)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<QuickNotesModel>();
            }
            using (var reader = File.OpenText(PATH))
            {
                var FileText = reader.ReadToEnd();
                if (FileText == "") { return new BindingList<QuickNotesModel>(); }
                return JsonConvert.DeserializeObject<BindingList<QuickNotesModel>>(FileText);
            }
        }

        public void SaveData(object Data)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(Data);
                writer.Write(output);
            }
        }
    }
}
