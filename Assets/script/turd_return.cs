using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turd_return : MonoBehaviour
{
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
        if (collision.tag == "wall" || collision.tag == "platformKeeper" || collision.tag == "brickSide")
        {
            transform.parent.GetComponent<turd_behavior>().speed *= -1;
        }
    }
}
