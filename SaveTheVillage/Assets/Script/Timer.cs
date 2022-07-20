using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Image imgTimer;

    public float maxTime;
    private float currentTime;
    public bool tick;

    private void Start()
    {
        imgTimer = GetComponent<Image>();
        currentTime = maxTime;
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        tick = false;
        if (currentTime <= 0)
        {
            currentTime = maxTime;
            tick = true;
        }

        imgTimer.fillAmount = currentTime / maxTime;
        
    }
}
