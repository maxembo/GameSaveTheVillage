using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangerImage : MonoBehaviour
{
    private Image genderIcon;

    public Sprite sprite1;
    public Sprite sprite2;

    private void Start()
    {
        genderIcon = GetComponent<Image>();
        if (genderIcon == null)
        {
            genderIcon.sprite = sprite1;
        }
    }

    public void SpriteChanges()
    {
        if(genderIcon.sprite == sprite1)
        {
            genderIcon.sprite = sprite2;
        }
        else
        {
            genderIcon.sprite = sprite1;
        }
  
    }
}
