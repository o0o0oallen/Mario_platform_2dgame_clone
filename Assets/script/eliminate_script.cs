using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eliminate_script : MonoBehaviour
{    
    public int jumpCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if(collision.tag == "fallDetect" || collision.tag == "spike")
        {
            transform.parent.GetComponent<playerController>().reSpawning();
        }
        if (collision.tag == "skyblock")
        {
            transform.parent.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        if (collision.tag == "brick"|| collision.tag == "skyblock" || collision.tag == "wallHit")// kiem tra reset double jump
        {
            jumpCount = 0;
            transform.parent.GetComponent<Collider2D>().isTrigger = false;
        }
        /*if(collision.tag == "turd")
        {
            Destroy(collision.gameObject);
        }*/
    }
    
}
