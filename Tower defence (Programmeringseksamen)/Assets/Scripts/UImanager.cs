using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using JetBrains.Annotations;
using System.Runtime.CompilerServices;

public class UImanager : MonoBehaviour
{
    //https://gamedevbeginner.com/singletons-in-unity-the-right-way/
    public static UImanager Instance { get; private set; }
    [HideInInspector] public TowerUpgrade tower;
    public TowerDetection detection;
    public TowerShooting shooting;
    public TextMeshProUGUI levelText, damageText, accuracyText, fireRateText, rangeText, UpgradePriceText, balanceText;
    public TMP_Dropdown targetModeChooser;
    private int upgradeprice;
    private int balance;
    public static bool uishown;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        else
        { Instance = this; }
    }
    void Update()
    {
        if (tower != null && tower.isPressed == true)
        {
            Display();
        }

    }
    void Display()
    {
        if (tower != null)
        {
            levelText.text = tower.level.ToString();
            damageText.text = tower.damage.ToString();
            accuracyText.text = tower.accuracy.ToString();
            fireRateText.text = tower.fireRate.ToString();
            rangeText.text = tower.range.ToString();
            UpgradePriceText.text = (tower.level * 2).ToString();
            Instance.targetModeChooser.SetValueWithoutNotify(shooting.targetModeIndex);
        }
    }

    public void upgradeButton()
    {
        if (balance >= upgradeprice)
        {
            balance = -upgradeprice;
            tower.level++;
            tower.upgrade();
            tower.damage = tower.orgDamage * tower.level;
            tower.accuracy = tower.orgAccuracy * tower.level;
            tower.fireRate = tower.orgFireRate * tower.level;
            tower.range = tower.orgRange * tower.level;
            detection.RangeUpdate();
            Display();
        }

    }

    public void updateBalance(int value)
    {
        balance = +value;
        balanceText.text = balance.ToString();
    }

    public void TargetMode(int val)
    {
        shooting.targetModeIndex = val;
        switch (val)
        {
            case 0:
                shooting.targetMode = "First";
                break;
            case 1:
                shooting.targetMode = "Last";
                break;
            case 2:
                shooting.targetMode = "Closest";
                break;
            case 3:
                shooting.targetMode = "Strongest";
                break;
            case 4:
                shooting.targetMode = "Weakest";
                break;
            default:
                break;
        }
    }
}
