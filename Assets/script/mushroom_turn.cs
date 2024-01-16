using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mushroom_turn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "wall" || collision.tag == "platformKeeper" || collision.tag == "brickSide" )
        {
            transform.parent.GetComponent<mushroom_script>().speed *= -1;
        }
    }
}
