using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    public Vector2 from;
    public Vector2 to;
    public float speed = .1f;
    Vector2 dir;

    bool fromOrTo = false;

    private void Start()
    {
        transform.position = from;
        dir = to - from;
    }

    private void Update()
    {
        if(!fromOrTo)
        {
            transform.Translate(dir * Time.deltaTime * speed);
            if (Vector2.Distance((Vector2)transform.position, to) < .1f)
            {
                fromOrTo = true;
            }

        }
        
        if (fromOrTo)
        {
            transform.Translate(-dir * Time.deltaTime * speed);
            if (Vector2.Distance((Vector2)transform.position, from) < .1f)
            {
                fromOrTo = false;
            }
        }
        

        /*
        if(!fromOrTo)
        {
            Debug.Log(Vector2.Distance((Vector2)transform.position, to));
            if (Vector2.Distance((Vector2)transform.position, to) > .1f)
            {
                transform.Translate(dir * Time.deltaTime * speed);
            }
            fromOrTo = true;
        }

        if(fromOrTo)
        {
            if (Vector2.Distance((Vector2)transform.position, from) > .1f)
            {
                transform.Translate(-dir * Time.deltaTime * speed);
            }
            fromOrTo = false;
        }
        */
    }
}
