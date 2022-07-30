using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMusic : MonoBehaviour
{
    [SerializeField] public AudioSource audio;
    [SerializeField] public AudioSource raid;

    [SerializeField] private AudioSource warriorMusic;
    [SerializeField] private AudioSource peasantMusic;
    
    private float musicVolume = 1f;
 
    private void Update()
    {
        audio.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
    public void MusicClick()
    {
        if (audio.isPlaying)
        {
            audio.Pause();
        }
        else
        {
            audio.Play();
        }
    }

    public void WarriorMusic()
    {
            warriorMusic.Play();
    }
    public void PeasantMusic()
    {
            
        peasantMusic.Play();
    }
}
