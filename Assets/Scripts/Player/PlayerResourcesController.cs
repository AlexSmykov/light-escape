using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AbstractPlayerObject : MonoBehaviour { }

public delegate void Notify();

[RequireComponent(typeof(Collider2D))]
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

    private PlayerController player;


    private void Start()
    {
        player = GetComponent<PlayerController>();
    }

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

        Debug.Log(axe.level);
        Debug.Log(sword.level);
        Debug.Log(pickaxe.level);

        SpendResources(resources);
    }


    public void CraftAmulete(List<PlayerResource> resources, PlayerAmulete amulete)
    {
        amuletes.Add(amulete);

        SpendResources(resources);

        var amuleteObj = Instantiate(amulete, Vector2.zero, Quaternion.identity);
        amuleteObj.transform.SetParent(amuletesTransform);
        amuleteObj.transform.localScale = new Vector3(1, 1, 1);
        amuleteObj.gameObject.AddComponent<Image>();
        amuleteObj.GetComponent<PlayerAmulete>().UpdateSprite();

        UpdateAmuleteStats();
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

    private void UpdateAmuleteStats()
    {
        player.swordDamage = 1;
        player.axeDamage = 1;
        player.pickaxeDamage = 1;
        player.loot = 1;
        player.playerSpeedMove = 1;
        player.darknessSpeed = 1;

        foreach (PlayerAmulete amulete in amuletes)
        {
            player.swordDamage *= amulete.swordDamage;
            player.axeDamage *= amulete.axeDamage;
            player.pickaxeDamage *= amulete.pickaxeDamage;
            player.loot *= amulete.loot;
            player.playerSpeedMove *= amulete.playerSpeedMove;
            player.darknessSpeed *= amulete.darknessSpeed;
        }
    }

    private void SpendResources(List<PlayerResource> resources)
    {
        resources.ForEach(resource =>
        {
            GetResourceByType(resource.type).ChangeResource(-resource.count);
        });

        ResourceChanged?.Invoke();
    }

    public PlayerResource GetResourceByType(Resources type)
    {
        return playerResources.Where(playerResource => { return playerResource.type == type; })
            .ToList()[0];
    }
}
