using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAmulete : MonoBehaviour
{
    public Sprite sprite;

    public Image image;

    public PlayerAmulete(Sprite sprite)
    {
        this.sprite = sprite;
    }

    private void Start()
    {
        image.sprite = sprite;
    }
}
