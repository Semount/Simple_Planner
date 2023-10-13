using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Simple_Planner.Models;
using System.IO;
using Newtonsoft.Json;

namespace Simple_Planner.Usage
{
    internal class Output
    {
        private string PATH;

        public Output(string path)
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
}
