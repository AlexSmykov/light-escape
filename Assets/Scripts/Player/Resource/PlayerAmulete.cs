using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAmulete : MonoBehaviour
{
    public Sprite sprite;

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
