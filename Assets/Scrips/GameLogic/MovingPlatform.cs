using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform leftPoint, rightPoint;
    public float speed;
    private Vector2 leftPos, rightPos;
    private Rigidbody2D rig;

    private int dir = 1;

    private Rigidbody2D player;

    void Start()
    {
        rig = this.GetComponent<Rigidbody2D>();

        leftPos = leftPoint.position;
        rightPos = rightPoint.position;
        Destroy(leftPoint.gameObject);
        Destroy(rightPoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        rig.velocity = new Vector2(dir * speed, rig.velocity.y);
        
        if(player)
            player.GetComponent<PlayerMovement>().SetOutsideSpeed(rig.velocity);
        

        if (transform.position.x < leftPos.x)
        {
            dir = 1;
        }
        else if (transform.position.x > rightPos.x)
        {
            dir = -1;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            player = other.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            player = null;
        }
    }
}
