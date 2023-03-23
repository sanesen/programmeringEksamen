using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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

    void Update()
    {

    }

    private void OnMouseDown()
    {
        isPressed = true;

        UImanager.Instance.tower = this;
        UImanager.Instance.detection = GetComponentInChildren<TowerDetection>();

        if (UI.activeSelf)
        {
            UI.SetActive(false);
        }

        else
        {
            UI.SetActive(true);
        }

        RectTransform rect = UI.GetComponent<RectTransform>();
        UI.GetComponent<RectTransform>().position = Input.mousePosition + new Vector3(rect.sizeDelta.x / 2 + 100, -rect.sizeDelta.y / 2, 0);

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
