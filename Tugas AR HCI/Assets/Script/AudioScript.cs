using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public static AudioScript instance;
    public AudioClip[] infoSuara;
    List<AudioSource> audioSources = new List<AudioSource>();
    private AudioSource[] allaudio;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        audioSources.Clear();
        for(int i = 0; i < infoSuara.Length; i++)
        {
            audioSources.Add(gameObject.AddComponent<AudioSource>());
            audioSources[i].clip = infoSuara[i];
        }
    }

    public void CallAudio(int i)
    {
        audioSources[i].Play();
    }

    public void StopAudio()
    {
        allaudio = FindObjectsOfTypeAll(typeof(AudioSource)) as AudioSource[];
        foreach(AudioSource audioSource in allaudio)
        {
            audioSource.Stop();
        }
    }
}
