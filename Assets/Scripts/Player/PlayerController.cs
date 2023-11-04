using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[RequireComponent(typeof(Collider2D))]
public class PlayerController : MonoBehaviour
{
	public int PlayerDamage = 1;
	[HideInInspector] public bool isRunning = false;

}

