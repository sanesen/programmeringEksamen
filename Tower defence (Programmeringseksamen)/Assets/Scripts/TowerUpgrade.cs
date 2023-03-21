using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


public class TowerUpgrade : MonoBehaviour
{
    public float damage, accuracy, fireRate;
    private GameObject UI;
    private SpriteRenderer spriteRenderer;

 

    public int level;
    void Start()
    {
        UI = GameObject.Find("upgradeMenu");
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Uimanager.Instance.tower = this;

        if (UI.activeInHierarchy)
        {
            UI.SetActive(false);
        }
        
        else if (!UI.activeInHierarchy)
        {
            UI.SetActive(true);
        }
        
    }
}
