using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionButtonData
{
    public string text { get; set; }
    public string subtext { get; set; }
    public string requested_ability { get; set; }
    public double requested_ability_percentage { get; set; }
    public int affected_food { get; set; } //e cu + daca actiunea aduce, e cu - daca actiunea are nevoie
    public int affected_resources { get; set; }
    public int affected_people { get; set; }
    public string bad_message { get; set; }
    public int lose_food { get; set; }
    public int lose_resources { get; set; }
    public int lose_people { get; set; }
    public Chromozome affected_chromozome { get; set; }
    
}
