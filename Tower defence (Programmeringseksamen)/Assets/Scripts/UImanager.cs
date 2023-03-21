using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Uimanager : MonoBehaviour
{
    public static Uimanager Instance { get; private set; }
    public TowerUpgrade tower;
    private TextMeshProUGUI levelText;
    private TextMeshProUGUI damageText;
    private TextMeshProUGUI accuracyText;
    private TextMeshProUGUI fireRateText;




    private void Awake()
    {
        FindText();

        if (Instance == null && Instance != this)
        {
            Destroy(this);
        }

        else
        { Instance = this; }
    }

    void Update()
    {
        Display();
    }

    void FindText()
    {
        levelText = GameObject.Find("levelText").GetComponent<TextMeshProUGUI>();
        damageText = GameObject.Find("damageText").GetComponent<TextMeshProUGUI>();
        accuracyText = GameObject.Find("accuracyText").GetComponent<TextMeshProUGUI>();
        fireRateText = GameObject.Find("fireRateText").GetComponent<TextMeshProUGUI>();
    }
    void Display()
    {
        levelText.text = tower.level.ToString();
        damageText.text = tower.damage.ToString();
        accuracyText.text = tower.accuracy.ToString();
        fireRateText.text = tower.fireRate.ToString();

    }
}
