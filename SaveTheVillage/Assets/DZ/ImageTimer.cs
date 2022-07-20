using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageTimer : MonoBehaviour
{
    private Image img;

    public float maxTime;

    
    private float currentTime;

    private void Start()
    {
        img = GetComponent<Image>();
        currentTime = 0;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= maxTime)  currentTime = 0;
      
       img.fillAmount =  currentTime / maxTime;
    }
}
