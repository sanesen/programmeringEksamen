using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;


public class TowerUpgrade : MonoBehaviour
{
    public float damage, accuracy, fireRate, range;
    public float orgDamage, orgAccuracy, orgFireRate, orgRange;
    public bool isPressed;
    public GameObject UI;
    public Sprite[] sprites;
    private SpriteRenderer spriteRenderer;
    public int level;
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        orgDamage = damage;
        orgAccuracy = accuracy;
        orgFireRate = fireRate;
        orgRange = range;
        upgrade();
     
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            if (UI.activeSelf) {
                UI.SetActive(false);
                UImanager.uishown = false;
            }
        }
    }

    private void OnMouseDown()
    {

        isPressed = true;
        if (UImanager.uishown == false)
        {
            UImanager.Instance.tower = this;
        }
        
        UImanager.Instance.detection = GetComponentInChildren<TowerDetection>();

        if (!UI.activeSelf)
        {
            RectTransform rect = UI.GetComponent<RectTransform>();

            Vector3 UIposition = Input.mousePosition + new Vector3(rect.sizeDelta.x / 2, -rect.sizeDelta.y / 2, 0);
            UI.GetComponent<RectTransform>().position = UIposition;

            if (rect.position.x > 570f)
            {
                rect.position = new Vector3(570f, rect.position.y, 0);
            }

            if (rect.position.y < 114f)
            {
                rect.position = new Vector3(rect.position.x, 114f, 0);
            }
            UI.SetActive(true);
            UImanager.uishown = true;
           
        }

 

    }

    private void OnMouseUp()
    {
        isPressed = false;
    }

    public void upgrade()
    {
        switch (level)
        {

            case 1:
                {
                    spriteRenderer.sprite = sprites[0]; break;
                }
            case 4:
                {
                    spriteRenderer.sprite = sprites[1]; break;
                }
            case 7:
                {
                    spriteRenderer.sprite = sprites[2]; break;
                }
            case 10:
                {
                    spriteRenderer.sprite = sprites[3]; break;
                }
        }
    }
}
