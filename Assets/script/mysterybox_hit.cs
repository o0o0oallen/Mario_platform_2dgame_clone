using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mysterybox_hit : MonoBehaviour
{
    public GameObject mystery_item;
    public Transform mystery_position;
    bool oneTimeSpawn = true;
    
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
        if (collision.tag == "headBox")
        {
            if(oneTimeSpawn)
            {
                Instantiate(mystery_item, mystery_position.position, mystery_position.rotation);
                oneTimeSpawn = false;
            }
        }
    }
}
