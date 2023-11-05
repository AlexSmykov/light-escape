
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
    public string Description;

    public Image craftButtonSprite;
    public TextMeshProUGUI descriptionText;

    public Color ActiveColor;
    public Color DeactiveColor;

    public ItemType type;

    private PlayerResourcesController playerResources;
    private bool isCraftAvailable = false;

    private void Start()
    {
        playerResources = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerResourcesController>();
        playerResources.ResourceChanged += UpdateCraftButton; // ѕрив€зка на событие изменени€ ресурсов
        descriptionText.text = Description;
        UpdateCraftButton();
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
