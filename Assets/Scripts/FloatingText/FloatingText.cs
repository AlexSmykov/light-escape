using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public float lifetime = 0.0f;
    public float startLifetime = 0.0f;
    public string text;

    void Start()
    {
        startLifetime = lifetime;
        if (lifetime != 0)
        {
            Destroy(this.gameObject, lifetime);
            this.GetComponent<TextMeshPro>().text = text;
        }
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 0.005f, transform.position.z);
        var tmp = GetComponent<TextMeshPro>();
        tmp.color = new Color(tmp.color.r, tmp.color.g, tmp.color.b, lifetime / startLifetime);
    }
}
