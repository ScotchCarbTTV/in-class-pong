using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    private enum PlayerIdentity { P1, P2 };

    [SerializeField] private PlayerIdentity pIdentity = new PlayerIdentity();

    [SerializeField] private float speed;

    private Vector3 startPos;

    public float dir { get; private set; }

    private void Awake()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Controls();
    }

    private void Controls()
    {
        if (pIdentity == PlayerIdentity.P1) 
        { 
            dir = Input.GetAxis("P1_Vertical");
            dir = Mathf.Clamp(dir, -1, 1);
            float velocity = dir * speed * Time.deltaTime;
            

            if (dir != 0)
            {
                if (transform.position.y > 3.4f)
                {
                    velocity = Mathf.Clamp(velocity, -1, 0);
                }
                else if(transform.position.y < -3.4f)
                {
                    velocity = Mathf.Clamp(velocity, 0, 1);
                }
                transform.position += new Vector3(0, velocity, 0);
            }
            
        }
        else if(pIdentity == PlayerIdentity.P2)
        {
            dir = Input.GetAxis("P2_Vertical");
            dir = Mathf.Clamp(dir, -1, 1);
            float velocity = dir * speed * Time.deltaTime;

            if (dir != 0)
            {
                if (transform.position.y > 3.4f)
                {
                    velocity = Mathf.Clamp(velocity, -1, 0);
                }
                else if (transform.position.y < -3.4f)
                {
                    velocity = Mathf.Clamp(velocity, 0, 1);
                }
                transform.position += new Vector3(0, velocity, 0);                
            }
        }
    }

    public void ResetPosition()
    {
        transform.position = startPos;
    }

}
