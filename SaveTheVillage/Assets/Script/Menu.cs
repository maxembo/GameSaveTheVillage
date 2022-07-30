using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject canvas1;
    [SerializeField] private GameObject canvas2;

    public void MenuChanger(GameObject canvas)
    {
        canvas1.SetActive(false);
        canvas.SetActive(true);
        
    }
}
