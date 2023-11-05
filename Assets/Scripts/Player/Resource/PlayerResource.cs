using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerResource : MonoBehaviour
{
    public int count;
    public Sprite sprite;
    public Resources type;

    public TextMeshProUGUI text;
    public Image image;

    public PlayerResource(Resources type, int count, Sprite sprite)
    {
        this.type = type;
        this.count = count;
        this.sprite = sprite;
    }

    public void ChangeResource(int value)
    {
        count += value;
        text.text = count + "";
    }

    private void Start()
    {
        text.text = count + "";
        image.sprite = sprite;
    }
}
