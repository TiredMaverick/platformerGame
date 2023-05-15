using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Update()
    {
                
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // follows the player in a side view going up
        if (player.transform.position.y > transform.position.y)
        {
            // Follow the player up in the positive y direction
            transform.position = new Vector3(transform.position.x, player.transform.position.y, -10);
        }
        else
        {
            // Stop following the player and stay at the current position
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }


    }
}
