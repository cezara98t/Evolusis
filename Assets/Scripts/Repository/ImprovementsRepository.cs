using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ImprovementsRepository : IRepository<List<ButtonData>>
{
    public List<ButtonData> buttons { get; set; }

    public ImprovementsRepository()
    {
        read();
    }
    public void read()
    {
        string filename = "improvements";
        TextAsset t = Resources.Load<UnityEngine.TextAsset>("Jsons/"+filename);
        buttons = JsonConvert.DeserializeObject<List<ButtonData>>(t.ToString());
    }
}



