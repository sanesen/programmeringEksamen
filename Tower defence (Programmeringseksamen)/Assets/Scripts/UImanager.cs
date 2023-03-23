using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{
    //https://gamedevbeginner.com/singletons-in-unity-the-right-way/
    public static UImanager Instance { get; private set; }
    public TowerUpgrade tower;
    public TowerDetection detection;
    public TextMeshProUGUI levelText, damageText, accuracyText, fireRateText, rangeText, UpgradePriceText;
    public float damageUpgradeFactor, accuracyUpgradeFactor, fireRateUpgradeFactor, rangeUpgradeFactor;

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
        }
    }

    public void upgradeButton()
    {
        tower.level++;
        tower.upgrade();
        tower.damage = tower.orgDamage * damageUpgradeFactor;
        tower.accuracy = tower.orgAccuracy * accuracyUpgradeFactor;
        tower.fireRate = tower.orgFireRate * fireRateUpgradeFactor;
        tower.range = tower.orgRange * rangeUpgradeFactor;
        detection.RangeUpdate();
        Display();
    }
}
