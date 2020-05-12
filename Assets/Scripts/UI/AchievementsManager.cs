using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsManager : MonoBehaviour
{
    [SerializeField] private List<Image> achievements;
    [SerializeField] private Image achv_of_game;

    private void Start()
    {
        achv_of_game.sprite=getAchvImage().sprite;
        foreach (Image img in achievements)
        {
            if (GameData.achievements[img.name] == 0)
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

    private Image getAchvImage()
    {
        string nameOfAchv = GameData.getGameAchv();
        foreach (Image img in achievements)
            if (img.name.Equals(nameOfAchv))
                return img;
        return achievements[0];
    }
}
