using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;
    
    public AudioClip[] background_sounds;
    public AudioClip[] jobSounds;
    public GameObject soundManagerGO;
    public Text soundButtonText;

    private AudioSource audioSourceBackground;
    private AudioSource audioSourceJob;
    private Dictionary<string, AudioClip> jobSoundsByName;
    private int currentMainSoundIndex = 0;

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
    public static SoundManager Instance { get { return _instance; } }


    void Start()
    {
        //cele doua elemente de sunet din GameObject-ul SoundManager
        audioSourceBackground = soundManagerGO.GetComponents<AudioSource>()[0];
        audioSourceJob = soundManagerGO.GetComponents<AudioSource>()[1];

        //initializare dictionar cu perechi de tip (numeJob, soundJob)
        jobSoundsByName = new Dictionary<string, AudioClip>();
        foreach (AudioClip ac in jobSounds)
        {
            jobSoundsByName.Add(ac.name, ac);
        }

        //setare si pornire primul sunet pentru main
        audioSourceBackground.clip = background_sounds[currentMainSoundIndex++];
        audioSourceBackground.Play();
    }

    //primeste ca parametru numele job-ului pentru care trebuie pornit sunetul
    public void playJobSound(string jobName)
    {
        if (jobSoundsByName.ContainsKey(jobName))
        {
            audioSourceJob.clip = jobSoundsByName[jobName];
            if (muted == false) audioSourceJob.Play();
        }
    }

    public void stopJobSound()
    {
        audioSourceJob.Stop();
        audioSourceJob = null;
    }


    //la terminarea erei se apeleaza functia si schimba sunetul de fundal
    public void nextMainSound() {
        audioSourceBackground.clip = background_sounds[currentMainSoundIndex++];
    }

    private void mute() {
        audioSourceJob.Stop();
        audioSourceBackground.Stop();
    }

    private void unmute() {
        audioSourceBackground.Play();
        audioSourceJob.Play();
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
