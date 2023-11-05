using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerResourcesController))]
public class PlayerActionController : MonoBehaviour
{
	public GameObject ETapBanner;
	private List<GameObject> _currentCollisions = new List<GameObject>();

	private PlayerController player;
	private PlayerResourcesController playerResources;

	private void Start()
    {
		player = GetComponent<PlayerController>();
		playerResources = GetComponent<PlayerResourcesController>();
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
		if (Input.GetKeyDown(KeyCode.E) && ETapBanner.activeSelf)
		{
			var objs = GetResourceObjectList();
			if (objs.Count > 0)
			{
				var resObj = objs[0].GetComponent<ResourceObject>();
				var isDestroyed = resObj.OnDamage(player.PlayerDamage);
				if (isDestroyed)
				{
					playerResources.AddResource(resObj.type, resObj.count);

					// Также можно будет навешать всплывающий текст о добытых ресурсах.
				}

			}
		}
	}

	List<GameObject> GetResourceObjectList()
	{
		return _currentCollisions.Where((item) => { return item.tag == "Resource"; }).ToList();
	}

	void checkActiveCollisions()
	{
		if (IsCollisionsHasTag(_currentCollisions, "Resource"))
		{
			ETapBanner.SetActive(true);
		}
		else
		{
			ETapBanner.SetActive(false);
		}
	}

	bool IsCollisionsHasTag(IEnumerable<GameObject> myCollisions, string tag)
	{
		foreach (var collision in myCollisions)
		{
			if (collision.tag == tag) return true;
		}

		return false;
	}
}
