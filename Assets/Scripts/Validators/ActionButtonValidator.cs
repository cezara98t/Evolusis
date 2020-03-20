using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ActionButtonValidator
{
    ActionButtonData data;
    public string validate(ActionButtonData d)
    {
        data = d;
        //daca nu este energie, nu are rost sa afisez restul
        if (!String.IsNullOrEmpty(validateEnergy()))
            return validateEnergy();

        string error_string = validateFood() + validateResources();
        if (String.IsNullOrEmpty(error_string)) 
            return String.Empty;
        return error_string.Substring(0, error_string.Length - 1);
    }

    public string validateFood()
    {
        if (GameData.food + data.affected_food >= 0)
            return String.Empty;
        return "Nu ai destula mancare!\n";

    }

    public string validateResources()
    {
        if (GameData.resources + data.affected_resources >= 0)
            return String.Empty;
        return "Nu ai destule resurse!\n";

    }

    public string validateEnergy() {
        if (GameData.energy > 0)
            return String.Empty;
        return "Nu ai destula energie! ";
    }


}


