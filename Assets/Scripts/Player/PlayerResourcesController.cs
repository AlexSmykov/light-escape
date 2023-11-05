using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AbstractPlayerObject : MonoBehaviour { }

public delegate void Notify();

public class PlayerResourcesController : MonoBehaviour
{
    public GameObject InventoryMenu;

    public List<PlayerResource> playerResources;

    public PlayerUpgradableTool sword;
    public PlayerUpgradableTool axe;
    public PlayerUpgradableTool pickaxe;

    public PlayerUpgradableTool helmet;
    public PlayerUpgradableTool chestplate;
    public PlayerUpgradableTool leggings;
    public PlayerUpgradableTool boots;

    public PlayerTool boat;

    public Image swordImage;
    public Image axeImage;
    public Image pickaxeImage;

    public Image helmetImage;
    public Image chestplateImage;
    public Image leggingsImage;
    public Image bootsImage;

    public Image boatImage;

    public List<PlayerAmulete> amuletes;
    public Transform amuletesTransform;

    public event Notify ResourceChanged;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            InventoryMenu.SetActive(!InventoryMenu.activeSelf);
            ResourceChanged?.Invoke();
        }
    }

    public void CraftUpgradable(List<PlayerResource> resources, PlayerUpgradableTool tool)
    {
        switch (tool.type)
        {
            case UpgradableTools.Pickaxe:
                pickaxe = tool;
                pickaxeImage.sprite = tool.sprite;
                break;

            case UpgradableTools.Axe:
                axe = tool;
                axeImage.sprite = tool.sprite;
                break;

            case UpgradableTools.Sword:
                sword = tool;
                swordImage.sprite = tool.sprite;
                break;

            case UpgradableTools.Helmet:
                helmet = tool;
                helmetImage.sprite = tool.sprite;
                break;

            case UpgradableTools.Chestplate:
                chestplate = tool;
                chestplateImage.sprite = tool.sprite;
                break;

            case UpgradableTools.Leggings:
                leggings = tool;
                leggingsImage.sprite = tool.sprite;
                break;

            case UpgradableTools.Boots:
                boots = tool;
                bootsImage.sprite = tool.sprite;
                break;

            default:
                return;
        }

        SpendResources(resources);
    }

    public void CraftTool(List<PlayerResource> resources, PlayerTool tool)
    {
        switch (tool.type)
        {
            case Tools.Boat:
                boat = tool;
                boatImage.sprite = tool.sprite;
                break;

            default:
                return;
        }

        SpendResources(resources);
    }


    public void CraftAmulete(List<PlayerResource> resources, PlayerAmulete amulete)
    {
        amuletes.Add(amulete);

        SpendResources(resources);

        Instantiate(amulete, amuletesTransform);
    }

    public void AddResource(Resources type, int count)
    {
        GetResourceByType(type).ChangeResource(count);

        ResourceChanged?.Invoke();
    }


    public bool CanCraft(List<PlayerResource> resources)
    {
        foreach (PlayerResource resource in resources)  
        {
            if (GetResourceByType(resource.type).count - resource.count < 0)
            {
                return false;
            }
        }

        return true;
    }

    private void SpendResources(List<PlayerResource> resources)
    {
        resources.ForEach(resource =>
        {
            GetResourceByType(resource.type).ChangeResource(-resource.count);
        });

        ResourceChanged?.Invoke();
    }

    private PlayerResource GetResourceByType(Resources type)
    {
        return playerResources.Where(playerResource => { return playerResource.type == type; })
            .ToList()[0];
    }
}
