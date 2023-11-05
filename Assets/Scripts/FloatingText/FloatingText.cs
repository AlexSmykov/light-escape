using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{
    public float lifetime = 0.0f;
    public string text;

    // Start is called before the first frame update
    void Start()
    {
        if (lifetime != 0)
        {
            Destroy(this.gameObject, lifetime);
            this.GetComponent<TextMeshPro>().text = text;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
