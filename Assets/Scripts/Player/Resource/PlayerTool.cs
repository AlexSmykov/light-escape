using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTool : MonoBehaviour
{
    public Sprite sprite;
    public Tools type;

    public Image image;

    public PlayerTool(Tools type, Sprite sprite)
    {
        this.type = type;
        this.sprite = sprite;
    }

    private void Start()
    {
        image.sprite = sprite;
    }
}
