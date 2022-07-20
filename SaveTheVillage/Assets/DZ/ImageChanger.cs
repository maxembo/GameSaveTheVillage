using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    [SerializeField] private Sprite newSprite;
    public AudioClip clip;
    
    

    private Image img;
    private AudioSource audio;
    
    private void Start()
    {
        img = GetComponent<Image>();
        audio = GetComponent<AudioSource>();
        audio.Play();
    }

    public void ChangeSprite()
    {
        img.sprite = newSprite;
        img.SetNativeSize();
    }

    public void ChangeColor()
    {
        //img.color = Color.black;
        img.color = new Color(0.1f,0.2f,0.3f);
    }
    public void CgangeAudioPlay()
    {
        if (audio.isPlaying) audio.Pause();
        else audio.Play();
    }
    public void ChangeSound()
    {
        audio.clip = clip;
        audio.Play();
    }
}
