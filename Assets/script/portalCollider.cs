using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portalCollider : MonoBehaviour
{
    public playerController controller;
    public GameObject bubbleChat;
    // Start is called before the first frame update
    void Start()
    {
        bubbleChat.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (controller.winAble == false)
            {
                bubbleChat.GetComponent<SpriteRenderer>().enabled = true;
            }            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        bubbleChat.GetComponent<SpriteRenderer>().enabled = false;
    }
}
