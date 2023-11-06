using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Altar : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<PlayerResourcesController>().GetResourceByType(Resources.Crystal).count >= 5)
        {
            SceneManager.LoadScene("Congrats");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
