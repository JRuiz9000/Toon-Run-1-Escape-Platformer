using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectManager : MonoBehaviour
{
    AudioSource[] audioSources;
   
    int audioSourceIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play(AudioClip clip)
    {
        audioSources[audioSourceIndex].clip = clip;
        audioSources[audioSourceIndex].Play();
  
        audioSourceIndex++;

        if (audioSourceIndex >= audioSources.Length) audioSourceIndex = 0;
    }
}
