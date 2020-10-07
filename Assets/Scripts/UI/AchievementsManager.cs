using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsManager : MonoBehaviour
{
    [SerializeField] private List<Image> achievements;
    [SerializeField] private Image achv_of_game;
    private void Update()
    {
        if (gameObject.activeSelf && GameData.showedAchv==false)
        {
            GameData.showedAchv = true;
            achv_of_game.sprite = getAchvImage().sprite;
            foreach (Image img in achievements)
            {
                if (GameData.achievements[img.name] == 0) // daca medalia nu a fost primita se va afisa neagra complet
                {
                    Color old = img.color;
                    old.r = 0;
                    old.g = 0;
                    old.b = 0;
                    img.color = old;
                }
                else
                {
                    Color old = img.color;
                    old.r = 255;
                    old.g = 255;
                    old.b = 255;
                    img.color = old;

                }
            }
        }
    }

    private Image getAchvImage() // retuneaza medalia (Image-ul din Unity)
    {
        string nameOfAchv = GameData.getGameAchv();
        foreach (Image img in achievements)     // cauta imaginea din Unity a carui nume este cel returnat de functia din GameData
            if (img.name.Equals(nameOfAchv))
                return img;
        return achievements[7]; // novice
    }
}