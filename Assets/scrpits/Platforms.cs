using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
     float speed;
    float speed1;

    [SerializeField] Vector3 start;
    [SerializeField] Vector3 offset;
    int direction;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector2(Random.Range(-3, 3), transform.position.y);
        offset.x += Random.Range(-7, 7);
        direction = Random.Range(0, 1);
        speed = Random.Range(1, 3);
        speed1 = Random.Range(0, 4);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Move's the platform's that are on one of these points left and right
        // THe movement (speed1) has to increase and change
        // Speed1 controls speed of patfrom speed is the amplitude
        if (direction < 0.5)
        {
            transform.position = offset + new Vector3(Mathf.Sin(Time.time * speed1) * speed, transform.position.y);
        }
        else
        {
            transform.position = offset + new Vector3(Mathf.Cos(Time.time * speed1) * speed, transform.position.y);
        }

        if (gameObject.transform.position.y < Camera.main.transform.position.y - Camera.main.orthographicSize - 14)
        {
            Destroy(gameObject);
            
        }



    }

}

