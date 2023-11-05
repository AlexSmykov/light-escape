using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AbstractMapObject : MonoBehaviour
{
    public string objName;
    public int hp;

    public bool OnDamage(int damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Destroy(gameObject);
            return true;
        }

        return false;
    }
}
