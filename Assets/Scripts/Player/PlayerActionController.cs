using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerResourcesController))]
public class PlayerActionController : MonoBehaviour
{
	public GameObject ETapBanner;
	private List<GameObject> _currentCollisions = new List<GameObject>();
	private List<Tools> acquiredTools = new List<Tools>();

	private PlayerController player;
	private PlayerResourcesController playerResources;
	private FloatingTextManager ftManager;

	public Image swordIconImage;
	public Image axeIconImage;
	public Image pickaxeIconImage;

	private UpgradableTools currentTool = UpgradableTools.Sword;

	private void Start()
    {
		player = GetComponent<PlayerController>();
		playerResources = GetComponent<PlayerResourcesController>();
		ftManager = FindObjectOfType<FloatingTextManager>();
	}


    void OnTriggerEnter2D(Collider2D col)
	{
		_currentCollisions.Add(col.gameObject);
		checkActiveCollisions();
	}

	void OnTriggerExit2D(Collider2D col)
	{
		_currentCollisions.Remove(col.gameObject);
		checkActiveCollisions();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Mouse0) && ETapBanner.activeSelf)
		{
			var objs = GetResourceObjectList();
			if (objs.Count > 0)
			{
				var resObj = objs[0].GetComponent<ResourceObject>();
				var isDestroyed = resObj.OnDamage(player.GetDamage(currentTool));
				if (isDestroyed)
				{
					var reward = Mathf.RoundToInt(resObj.count * player.loot);
					ftManager.Spawn(transform.position, "Получено: " + reward);
					playerResources.AddResource(resObj.type, reward);
				}
			}
		}

		if (Input.GetKeyDown("1"))
		{
			currentTool = UpgradableTools.Sword;
			checkActiveCollisions();

			swordIconImage.color = Color.yellow;
			axeIconImage.color = Color.white;
			pickaxeIconImage.color = Color.white;

			Debug.Log(currentTool);
		}

		else if (Input.GetKeyDown("2"))
		{
			currentTool = UpgradableTools.Axe;
			checkActiveCollisions();

			swordIconImage.color = Color.white;
			axeIconImage.color = Color.yellow;
			pickaxeIconImage.color = Color.white;

			Debug.Log(currentTool);
		}

		else if (Input.GetKeyDown("3"))
		{
			currentTool = UpgradableTools.Pickaxe;
			checkActiveCollisions();

			swordIconImage.color = Color.white;
			axeIconImage.color = Color.white;
			pickaxeIconImage.color = Color.yellow;

			Debug.Log(currentTool);
		}
	}

	List<GameObject> GetResourceObjectList()
	{
		return _currentCollisions.Where((item) => { return item.tag == "Resource"; }).ToList();
	}

	void checkActiveCollisions()
	{
		ETapBanner.SetActive(false);

		var resoursableCollisions = GetResoursableCollisions(_currentCollisions, "Resource");
		if (resoursableCollisions.Count > 0)
		{
			if (resoursableCollisions.Where((item) => {
				Debug.Log(item.GetComponent<ResourceObject>().NeededUpgradableTool == currentTool);
				Debug.Log(acquiredTools.Contains(item.GetComponent<ResourceObject>().NeededTool));
				Debug.Log(item.GetComponent<ResourceObject>().NeededUpgradableTool == UpgradableTools.None);
				Debug.Log(item.GetComponent<ResourceObject>().NeededTool == Tools.None);

				return (item.GetComponent<ResourceObject>().NeededUpgradableTool == currentTool) ||
					acquiredTools.Contains(item.GetComponent<ResourceObject>().NeededTool) ||
					(item.GetComponent<ResourceObject>().NeededUpgradableTool == UpgradableTools.None) &&
					(item.GetComponent<ResourceObject>().NeededTool == Tools.None);
				}).ToList().Count > 0)
			{
				ETapBanner.SetActive(true);
			}
		}
	}

	private List<GameObject> GetResoursableCollisions(List<GameObject> myCollisions, string tag)
	{
		return myCollisions.Where((item) => { return item.tag == tag; }).ToList();
	}
}
