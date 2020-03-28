using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonData : ButtonData
{
    public string requested_ability { get; set; }
    public double requested_ability_percentage { get; set; }
    public string bad_message { get; set; }
    public int lose_food { get; set; }
    public int lose_resources { get; set; }
    public int lose_people { get; set; }
    public Chromozome lose_affected_chromozome { get; set; }
    
}
