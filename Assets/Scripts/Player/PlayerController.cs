using UnityEngine;


[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(PlayerResourcesController))]
public class PlayerController : MonoBehaviour
{
	public int PlayerDamage = 1;
	[HideInInspector] public bool isRunning = false;

    public float playerSpeedMove = 1;
    public float swordDamage = 1;
    public float axeDamage = 1;
    public float pickaxeDamage = 1;
    public float loot = 1;
    public float darknessSpeed = 1;

    private PlayerResourcesController playerResourcesController;

    private void Start()
    {
        playerResourcesController = GetComponent<PlayerResourcesController>();
    }

    public int GetDamage(UpgradableTools type)
    {
        switch (type)
        {
            case UpgradableTools.Sword:
                return Mathf.RoundToInt(playerResourcesController.sword.effect * swordDamage);

            case UpgradableTools.Axe:
                return Mathf.RoundToInt(playerResourcesController.axe.effect * axeDamage);

            case UpgradableTools.Pickaxe:
                return Mathf.RoundToInt(playerResourcesController.pickaxe.effect * axeDamage);

                default: return 0;
        }
    }
}

