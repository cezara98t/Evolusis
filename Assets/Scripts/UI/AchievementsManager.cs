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
        Debug.Log(getAchvImage().name);
        foreach (Image img in achievements)
        {
            if (GameData.achievements[img.name] == 0)
            {
                Color old = img.color;
                old.r = 0;
                old.g = 0;
                old.b = 0;
                img.color = old;
                Debug.Log(img.color.r);
            }
            else
            {
                Color old = img.color;
                old.r = 255;
                old.g = 255;
                old.b = 255;
                img.color = old;

                Debug.Log(img.color.r);
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
