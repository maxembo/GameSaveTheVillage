using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Timer harvestTimer;
    [SerializeField] private Timer eatingTimer;
    [SerializeField] private Image raidTimerImg;
    [SerializeField] private SettingMusic music;
    
    [SerializeField] private Image peasantTimerImg;
    [SerializeField] private Image warriorTimerImg;

    [SerializeField] private GameObject upgradeWarrior;
    [SerializeField] private GameObject upgradePeasant;

    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject winGame;
    [SerializeField] private GameObject menuPause;
    [SerializeField] private GameObject informMenu;
    

    [SerializeField] private Button peasantButton;
    [SerializeField] private Button warriorButton;

    [SerializeField] private Text resourcesText;
    [SerializeField] private Text waveOfEnemies;

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
    public float eatingTimerWarrior;
    public int upgradeCostWarrior;
    public int upgradeCostPeasant;
    public float upgradeMaxTimer;
    public int WinGameWheatCount;

    private float upgradeTimer;
    private float peasantTimer = -2;
    private float warriorTimer = -2;
    private float raidTimer;
    private int wave = 1;
    

    private bool paused;

    private void Start()
    {
        raidTimer = raidMaxTime;
        upgradeTimer = upgradeMaxTimer;
        music.audio = GetComponent<AudioSource>();
        Time.timeScale = 1;
        music.audio.Play();
    }

    private void Update()
    {
        RaidTimer();

        HarvestAndEatingTimer();

        PeasantTimer();

        WarriorTimer();

        UpdateText();

        TimerUpgrade();

        WinGame();

        GameOver();
    }

    public void CreatePeasant()
    {
        if(wheatCount >= peasantCost) 
        {
            wheatCount -= peasantCost;
            peasantTimer = peasantCreateTime;
            peasantButton.interactable = false;
            music.PeasantMusic();
        }
    }

    public void CreateWarrior()
    {
        if(wheatCount >= warriorCost)
        {
            wheatCount -= warriorCost;
            warriorTimer = warriorCreateTime;
            warriorButton.interactable = false;
            music.WarriorMusic();
        }
    }
    public void GameOver()
    {
        if (warriorCount < 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
            music.audio.Pause();
        }
    }

    public void WinGame()
    {
        if(wheatCount >= WinGameWheatCount)
        {
            winGame.SetActive(true);
            Time.timeScale = 0;
            music.audio.Pause();
        }
    }
    public void Pause()
    {
        if (paused)
        {
            Time.timeScale = 1;
            menuPause.SetActive(false);
            music.audio.Play();
        }
        else
        {
            ContinueGame();
        }
        paused = !paused;
    }

    public void UpgradePeasant()
    {
        if(wheatCount >= upgradeCostPeasant && peasantButton.interactable == true)
        {
            wheatCount -= upgradeCostPeasant;
            wheatPerPeasant *= 2;
            upgradePeasant.SetActive(false);
        }
    }
    public void UpgradeWarrior()
    {
        if (wheatCount >= upgradeCostWarrior && warriorButton.interactable == true)
        {
            wheatCount -= upgradeCostWarrior;
            warriorCreateTime /= 4;
            upgradeWarrior.SetActive(false);
        }
    }

    private void ContinueGame()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            menuPause.SetActive(true);
            music.audio.Pause();
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
            music.raid.Play();
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

        if(warriorCount == 0)
        {
            eatingTimer.maxTime = 0;
        }

        else if (warriorCount > 0 && eatingTimer.tick )
        {
            eatingTimer.maxTime = eatingTimerWarrior;
            if(eatingTimer)
            wheatCount -= warriorCount * wheatToWarriors;
        }
        if(wheatCount < 0)
        {
            peasantCount -= 1;
            wheatCount = 0;
        }
    }

    private void TimerUpgrade()
    {
        if(upgradeTimer > 0)
        {
            upgradeTimer -= Time.deltaTime;
        }
        else if (upgradeTimer > -1)
        {
            upgradeTimer = -2;
            upgradeWarrior.SetActive(true);
            upgradePeasant.SetActive(true);
        }
    }
   
}
