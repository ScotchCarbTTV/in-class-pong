using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //vector2 for direction the ball will move in
    [SerializeField] private Vector2 velocity = new Vector2(-1, 0);

    private Paddle paddle;
    private Endzone endZone;
    private Vector3 startPos;

    //value to store and change the value of speed
    [SerializeField] private float speed;

    private void Awake()
    {
        startPos = transform.position;
    }

    void Update()
    {
        MoveBall();
    }

    //method for moving the ball in it's current direction & speed
    private void MoveBall()
    {
        //increase the current position of the ball by the velocity modified by the speed and time.deltatime
        transform.position += (Vector3)velocity * speed * Time.deltaTime;
    }

    public Vector2 NewVelocity(float dir)
    {
        float angle = velocity.y + dir * 0.1f;
        Vector2 newVelocity = new Vector2(-velocity.x, angle);
        return newVelocity;
    }
    public Vector2 Bounce()
    {
        float bounce = -velocity.y;
        return velocity = new Vector3(velocity.x, bounce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if(collision.gameObject.TryGetComponent<Paddle>(out paddle))
        {
            velocity = NewVelocity(paddle.dir);
        }
        else if(collision.gameObject.tag == "Wall")
        {
            velocity = Bounce();
        }
        else if(collision.gameObject.TryGetComponent<Endzone>(out endZone))
        {
            endZone.UpdateScore();
        }

    }

    public void ResetPos()
    {
        transform.position = startPos;
        velocity = new Vector2(-1, 0);
    }

}
