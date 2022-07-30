using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InformChanger : MonoBehaviour
{
    [SerializeField] private GameObject informGame;


    public void InformClick()
    {
        informGame.SetActive(true);
        Time.timeScale = 0;
    }
}
