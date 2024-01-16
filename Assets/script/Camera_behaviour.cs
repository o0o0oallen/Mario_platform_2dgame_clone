using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_behaviour : MonoBehaviour
{
    public GameObject player;
    public float offset;    
    public float offsetSmoothing;
    private Vector3 player_position;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player_position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        if(player.transform.localScale.x < 0)
        {
            player_position = new Vector3(player_position.x - offset, player_position.y, player_position.z);
        }
        if (player.transform.localScale.x > 0)
        {
            player_position = new Vector3(player_position.x + offset, player_position.y, player_position.z);
        }
        transform.position = Vector3.Lerp(transform.position, player_position, offsetSmoothing * Time.deltaTime);
        /*background.transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);*/
    }
}
