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
    public GameObject gameOver;

    public Button peasantButton;
    public Button warriorButton;

    public Text resourcesText;
    public Text waveOfEnemies;

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

    private float peasantTimer = -2;
    private float warriorTimer = -2;
    private float raidTimer;
    private int wave = 1;



    private void Start()
    {
        raidTimer = raidMaxTime;
    }

    private void Update()
    {
        RaidTimer();

        HarvestAndEatingTimer();

        PeasantTimer();

        WarriorTimer();

        UpdateText();

        GameOver();


    }

    public void CreatePeasant()
    {
        if(wheatCount >= wheatPerPeasant) 
        {
            wheatCount -= peasantCost;
            peasantTimer = peasantCreateTime;
            peasantButton.interactable = false;
        }
    }

    public void CreateWarrior()
    {
        if(wheatCount >= wheatToWarriors)
        {
            wheatCount -= warriorCost;
            warriorTimer = warriorCreateTime;
            warriorButton.interactable = false;
        }
    }
    public void GameOver()
    {
        if (warriorCount < 0)
        {
            gameOver.SetActive(true);
        }
    }

    private void UpdateText()
    {
        resourcesText.text = peasantCount + "\n\n" + warriorCount + "\n\n" + wheatCount + "\n\n" + raidNext;
        waveOfEnemies.text = $"Набег врагов:\n {wave} волна";
    }

    private void PeasantTimer()
    {
        if (peasantTimer > 0)
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
    }

    private void WarriorTimer()
    {
        if (warriorTimer > 0)
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
    }

    private void RaidTimer()
    {
        raidTimer -= Time.deltaTime;
        raidTimerImg.fillAmount = raidTimer / raidMaxTime;

        if (raidTimer <= 0)
        {
            wave += 1;
            raidTimer = raidMaxTime;
            warriorCount -= raidNext;
            raidNext += raidIncrease;
        }
    }

    private void HarvestAndEatingTimer()
    {
        if (harvestTimer.tick)
        {
            wheatCount += peasantCount * wheatPerPeasant;
        }

        if (eatingTimer.tick)
        {
            wheatCount -= warriorCount * wheatToWarriors;
        }
    }
}
