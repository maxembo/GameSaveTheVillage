using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Timer harvestTimer;
    public Timer eatingTimer;
    public Image raidTimerImg;

    public Image peasantTimerImg;
    public Image warriorTimerImg;

    public Button peasantButton;
    public Button warriorButton;

    public Text resourcesText;

    public int peasantCount;
    public int warriorCount;
    public int wheatCount;

    public int wheatPerPeasant;
    public int wheatToWarriors;

    public int peasantCost;
    public int warriorCost;

    public int raidIncrease;
    public int raidNext;
    public float peasantCreateTime;
    public float warriorCreateTime;
    public float raidMaxTime;

    private float peasantTimer = - 2;
    private float warriorTimer = - 2;
    private float raidTimer;



    private void Start()
    {
        UpdateText();
        raidTimer = raidMaxTime;
    }

    private void Update()
    {
        raidTimer -= Time.deltaTime;
        raidTimerImg.fillAmount = raidTimer / raidMaxTime;

        if(raidTimer <= 0)
        {
            raidTimer = raidMaxTime;
            warriorCount -= raidNext;
            raidNext += raidIncrease;
        }

        if (harvestTimer.tick)
        {
            wheatCount += peasantCount * wheatPerPeasant;
        }

        if (eatingTimer.tick)
        {
            wheatCount -= warriorCount * wheatToWarriors;
        }

        if(peasantTimer > 0)
        {
            peasantTimer -= Time.deltaTime;
            peasantTimerImg.fillAmount = peasantTimer / peasantCreateTime;
        }
        else if (peasantTimer > -1)
        {
            peasantTimerImg.fillAmount = 1;
            peasantTimer = -2;
            peasantButton.interactable = true;
            peasantCount += 1; 
        }


        if(warriorTimer > 0)
        {
            warriorTimer -= Time.deltaTime;
            warriorTimerImg.fillAmount = warriorTimer / warriorCreateTime;
        }
        else if (warriorTimer > -1)
        {
            warriorTimerImg.fillAmount = 1;
            warriorTimer = -2;
            warriorButton.interactable = true;
            warriorCount += 1;
        }

        UpdateText();

    }
    public void CreatePeasant()
    {
        wheatCount -= peasantCost;
        peasantTimer = peasantCreateTime;
        peasantButton.interactable = false;

    }
    public void CreateWarrior()
    {
        wheatCount -= warriorCost;
        warriorTimer = warriorCreateTime;
        warriorButton.interactable = false;

    }
    private void UpdateText()
    {
        resourcesText.text = peasantCount + "\n\n" + warriorCount + "\n\n" + wheatCount;
    }
}
