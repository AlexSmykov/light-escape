using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAmulete : MonoBehaviour
{
    public Sprite sprite;

    public float playerSpeedMove = 1;
    public float swordDamage = 1;
    public float axeDamage = 1;
    public float pickaxeDamage = 1;
    public float loot = 1;
    public float darknessSpeed = 1;

    private Image image;

    public PlayerAmulete(Sprite sprite)
    {
        this.sprite = sprite;
    }

    public void UpdateSprite()
    {
        image = GetComponent<Image>();
        image.sprite = sprite;
    }
}
