using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceObject : AbstractMapObject
{
    public Resources type;
    public int count;

    void Start()
    {
        tag = "Resource";
    }

}
