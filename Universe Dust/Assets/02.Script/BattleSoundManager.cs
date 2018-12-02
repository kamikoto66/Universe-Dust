using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSoundManager : MonoBehaviour {

    public static BattleSoundManager instance;
    AudioSource myAudio;
    public AudioClip[] sounds;


    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void SetMusic(int n)
    {
        myAudio.PlayOneShot(sounds[n]);
    }

}
