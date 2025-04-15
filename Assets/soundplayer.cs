using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundplayer : MonoBehaviour
{
    /// <summary>
    /// There will only ever be one soundplayer object
    /// </summary>
    public static soundplayer soundobject;

    public AudioClip themesound;
    public AudioClip coinsound;
    public AudioClip explodesound;
    public AudioClip shootsound;
    public AudioClip missionsuccess;
    public AudioClip missionfailure;
    public AudioClip destroythem;
    public AudioClip chaostheme;
    private static AudioClip[] audioClips;
    private static AudioSource[] audiosources;

    // Start is called before the first frame update
    void Start()
    {
        soundobject = this;
        audiosources = GetComponents<AudioSource>();
        audioClips = new AudioClip[] { themesound, coinsound, explodesound, shootsound, missionsuccess, missionfailure, destroythem, chaostheme  };

        for (int i = 0; i < audiosources.Length; i++)
        {
            audiosources[i].clip = audioClips[i];

            if (i == 0)
            {
                audiosources[i].loop = true;
                audiosources[i].Play();
            }

        }

    }

    public static void playsound( int i)
    {
        audiosources[i].Play();
    }

    public static void stopsound(int i)
    {
        audiosources[i].Stop();
    }

    public static IEnumerator playsuccess()
    {
        
        audiosources[4].Play();
        yield return new WaitForSeconds(audiosources[4].clip.length);
        audiosources[6].Play();
        yield return new WaitForSeconds(audiosources[6].clip.length);
        stopsound(0);
        audiosources[7].loop = true;
        audiosources[7].Play();

        FindObjectOfType<player>().unhinge();
    }

    public static IEnumerator playfailure()
    {
        audiosources[5].Play();
        yield return new WaitForSeconds(audiosources[4].clip.length + 5);
        spawner spawner_obj = FindObjectOfType<spawner>();
        spawner_obj.Resetgame();
    }
}
