using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUpgradableTool : MonoBehaviour
{
    public int effect;
    public int level;
    public Sprite sprite;
    public UpgradableTools type;

    public Image image;

    public PlayerUpgradableTool(UpgradableTools type, int effect, int level, Sprite sprite)
    {
        this.type = type;
        this.effect = effect;
        this.level = level;
        this.sprite = sprite;
    }

    private void Start()
    {
        image.sprite = sprite;
    }
}
