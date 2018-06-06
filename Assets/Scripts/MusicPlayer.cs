﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    public AudioSource efxSource;                   //Drag a reference to the audio source which will play the sound effects.
    public AudioSource musicSource;                 //Drag a reference to the audio source which will play the music.
    public static MusicPlayer instance = null;      //Allows other scripts to call functions from SoundManager.
    public float lowPitchRange = .95f;              //The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;            //The highest a sound effect will be randomly pitched.

    private void Awake() {
        if (instance != null) {
            Destroy(gameObject);
            print("Duplicate music player self-destructing");
        }
        else {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    //Used to play single sound clips.
    public void PlaySingle(string name) {

        AudioClip clip = Resources.Load("Sounds/" + name) as AudioClip;

        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = clip;

        //Play the clip.
        efxSource.Play();
    }

    //RandomizeSfx chooses randomly between various audio clips and slightly changes their pitch.
    public void RandomizeSfx(params AudioClip[] clips) {
        //Generate a random number between 0 and the length of our array of clips passed in.
        int randomIndex = Random.Range(0, clips.Length);

        //Choose a random pitch to play back our clip at between our high and low pitch ranges.
        float randomPitch = Random.Range(lowPitchRange, highPitchRange);

        //Set the pitch of the audio source to the randomly chosen pitch.
        efxSource.pitch = randomPitch;

        //Set the clip to the clip at our randomly chosen index.
        efxSource.clip = clips[randomIndex];

        //Play the clip.
        efxSource.Play();
    }

    // Use this for initialization
    void Start () {
        musicSource = GetComponentsInChildren<AudioSource>()[0];
        efxSource = GetComponentsInChildren<AudioSource>()[1];

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}