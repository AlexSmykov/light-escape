using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class ResourceObject : AbstractMapObject
{
    public UpgradableTools NeededUpgradableTool;
    public Tools NeededTool;

    public Resources type;
    public int count;
    private Animator animator;

    private FloatingTextManager ftManager;
    public int hp;


    void Start()
    {
        ftManager = FindObjectOfType<FloatingTextManager>();
        animator = GetComponent<Animator>();
        tag = "Resource";
    }

    public bool OnDamage(int damage)
    {
        hp -= damage;


        if (hp <= 0)
        {
            Destroy(gameObject);
            return true;
        }
        animator.Play("objectDamaged", -1, 0f);
        ftManager.Spawn(transform.position, "-" + damage);

        return false;
    }

}
