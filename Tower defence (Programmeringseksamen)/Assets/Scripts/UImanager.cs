using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UImanager : MonoBehaviour
{
    public static UImanager Instance { get; private set; }
    public TowerUpgrade tower;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI accuracyText;
    public TextMeshProUGUI fireRateText;

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
        }
    }

    public void upgradeButton()
    {
        tower.level++;
        Display();
        tower.upgrade();

        tower.damage *= tower.level;
        tower.accuracy *= tower.level;
        tower.fireRate *= tower.level;
    }
}
