using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turd_hitbox_script : MonoBehaviour
{
    private bool isdead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*private void OnCollisionEnter2D(Collision2D collisionData)
    {
        OnTriggerEnter2D(collisionData.collider);
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if(collision.tag == "eliminate")
        {
            if (!isdead)
            {
                transform.parent.GetComponent<turd_behavior>().tag = "deadTurd";
                transform.parent.GetComponent<PolygonCollider2D>().isTrigger = true;
                transform.parent.localScale = new Vector3(transform.parent.localScale.x, transform.parent.localScale.y * -1, transform.parent.localScale.z);
                transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y + 35 * Time.deltaTime, transform.parent.position.z);
                GetComponentInParent<turd_behavior>().enabled = false;                
                isdead = true;                
            }                                   
        }        
    }
}
