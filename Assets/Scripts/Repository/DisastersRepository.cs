using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class DisastersRepository : IRepository<List<DisasterButtonData>>
{
    public List<DisasterButtonData> buttons { get; set; }


    public DisastersRepository()
    {
        read();
    }
    public void read()
    {
        TextAsset t = Resources.Load<UnityEngine.TextAsset>("Jsons/disasters");
        buttons = JsonConvert.DeserializeObject<List<DisasterButtonData>>(t.ToString());
    }
}
