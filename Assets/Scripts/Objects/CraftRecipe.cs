
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CraftRecipe : MonoBehaviour
{
    public bool isOneTimeCraft;

    public List<PlayerResource> cost;

    public PlayerTool resultTool;
    public PlayerUpgradableTool resultUpgradableTool;
    public PlayerAmulete resultAmulete;
    public Sprite ResultIcon;

    public string Name;
    public string Description;
    public Image ResultImage;

    public Image craftButtonSprite;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    public Color ActiveColor;
    public Color DeactiveColor;

    public ItemType type;

    private PlayerResourcesController playerResources;
    private bool isCraftAvailable = false;

    private void Awake()
    {
        playerResources = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerResourcesController>();
        playerResources.ResourceChanged += UpdateCraftButton; // ѕрив€зка на событие изменени€ ресурсов
        UpdateCraftButton();

        nameText.text = Name;
        descriptionText.text = Description;
        ResultImage.sprite = ResultIcon;
    }

    public void UpdateCraftButton()
    {
        if (playerResources.CanCraft(cost))
        {
            craftButtonSprite.color = ActiveColor;
            isCraftAvailable = true;
        }
        else
        {
            craftButtonSprite.color = DeactiveColor;
            isCraftAvailable = false;
        }
    }

    public void OnCraftButtonClick()
    {
        if (isCraftAvailable)
        {
            switch (type)
            {
                case ItemType.Tool:
                    playerResources.CraftTool(cost, resultTool);
                    break;

                case ItemType.UpgradableTool:
                    playerResources.CraftUpgradable(cost, resultUpgradableTool);
                    break;

                case ItemType.Amulete:
                    playerResources.CraftAmulete(cost, resultAmulete);
                    break;

                default:
                    return;
            }

            if (isOneTimeCraft)
            {
                gameObject.SetActive(false);
            }
        }
    }
}
