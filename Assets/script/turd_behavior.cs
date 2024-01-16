using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turd_behavior : MonoBehaviour
{
    public float speed;    
    public GameObject falldetector;
    // Start is called before the first frame update
    void Start()
    {
        
    }    
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
        falldetector.transform.position = new Vector3(transform.position.x,falldetector.transform.position.y,transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D collisionData)
    {
        OnTriggerEnter2D(collisionData.collider);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {               
        if (collision.tag == "turd_detect")
        {
            Destroy(gameObject);
            Destroy(transform.gameObject.GetComponent<turd_behavior>().falldetector);
        }
    }
}
