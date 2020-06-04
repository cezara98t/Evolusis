using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    public static SoundManager Instance { get { return _instance; } }
    public AudioClip[] background_sounds;
    public AudioClip[] jobSounds;
    public GameObject soundManagerGO;
    public Text soundButtonText;

    private AudioSource audioSourceBackground;
    private AudioSource audioSourceJob;
    //perechi de forma (nume activitate, indice sunet din lista de sunete jobSounds)
    private Dictionary<string, int> jobSoundsByName = new Dictionary<string, int> { {"Era1/Health", 0 }, { "Era2/Health", 0 } , { "Era3/Health", 0 },
                                                                                    {"Era2/House",1 }, {"Era3/House",1},
                                                                                    {"Era2/Food",2}, {"Era6/Food",2}, {"Era7/Food",2},
                                                                                    {"Era5/Food",3},
                                                                                    {"Era8/Health",4},
                                                                                    {"Era8/Food",5},
                                                                                    {"Era9/Health",6 } };
    //perechi de forma (nume era, indice sunet din lista de sunete background_sounds)
    private Dictionary<string, int> eraSoundsByName = new Dictionary<string, int> { { "Era1",0}, { "Era2", 0 }, { "Era3", 0 }, { "Era4",1},
                                                                            { "Era5",2},{ "Era6",3}, { "Era7",4}, { "Era8",5}, { "Era9",6}};
    private bool muted = false;


    //singleton
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }


    void Start()
    {
        //cele doua elemente de sunet din GameObject-ul SoundManager
        audioSourceBackground = soundManagerGO.GetComponents<AudioSource>()[0];
        audioSourceJob = soundManagerGO.GetComponents<AudioSource>()[1];

        //setare si pornire primul sunet pentru main
        audioSourceBackground.clip = background_sounds[0];
        audioSourceBackground.Play();
    }

    //primeste ca parametru numele job-ului pentru care trebuie pornit sunetul
    public void playJobSound()
    {
        try
        {
            audioSourceJob.clip = jobSounds[jobSoundsByName[GameData.mainPanel.name + "/" + GameData.currentJobPanel.name]];
            if (muted == false) audioSourceJob.Play();
            audioSourceJob.volume = 1;
        }
        catch(Exception e)
        {
            // nu este o melodie pentru activitatea curenta
        }
    }

    public void stopJobSound()
    {
        if (audioSourceJob != null)
        {
            audioSourceJob.Stop();
            audioSourceJob.clip = null;
        }
    }


    //la terminarea erei se apeleaza functia si schimba sunetul de fundal
    public void playMainSound() {
        audioSourceBackground.clip = background_sounds[eraSoundsByName[GameData.mainPanel.name]];
        audioSourceBackground.Play();
        audioSourceBackground.volume = 1;
    }

    private void mute() {
        audioSourceJob.volume = 0;
        audioSourceBackground.volume = 0;
    }

    private void unmute() {
        audioSourceBackground.volume = 1;
        if (audioSourceJob.clip != null)
            audioSourceJob.volume = 1;
    }

    public void changeMute() {
        if (muted == true) {
            muted = false;
            unmute();
            soundButtonText.text = "Sunet : DA";
        }
        else {
            muted = true;
            mute();
            soundButtonText.text = "Sunet : NU";
        }
    }

}
