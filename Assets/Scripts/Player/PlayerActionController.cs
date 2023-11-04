using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(PlayerController))]
public class PlayerActionController : MonoBehaviour
{
	public GameObject ETapBanner;
	private List<GameObject> _currentCollisions = new List<GameObject>();


	private PlayerController player;

    private void Start()
    {
		player = GetComponent<PlayerController>();

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
				var isDestroyed = objs[0].GetComponent<AbstractMapObject>().OnDamage(player.PlayerDamage);
				if (isDestroyed)
				{
					// Здесь предположительно нашему персу будут засчитываться ресурсы уничтоженного объекта (у него есть тип ресурса)
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
