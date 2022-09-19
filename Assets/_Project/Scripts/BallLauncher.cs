using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public Camera camera;
    public Rigidbody2D ball;
    public LineRenderer lr;

    public float power;
    public bool canLaunch;
    
    private Vector2 _start;
    private Vector2 _end;
    private Vector2 _direction;
    private float _angle;

    private int _roundTo;

    SpriteRenderer sr;


    private void Start()
    {
        lr.enabled = false;
        sr = GetComponent<SpriteRenderer>();
        sr.enabled = false;
    }

    void Update()
    {
        _end = camera.ScreenToWorldPoint(Input.mousePosition);
        _direction = _end - _start;
        _angle = Vector2.Angle(Vector2.right, _direction);

        if(camera.ScreenToWorldPoint(Input.mousePosition).y < _start.y)
        {
            _angle = _angle * -1;
        }

        if (_angle <= 95 && _angle >= 85)
        {
            _roundTo = 90;
        }
        else if (_angle >= 175 || _angle <= -175)
        {
            _roundTo = 180;
        }
        else if (_angle <= 5 && _angle >= -5)
        {
            _roundTo = 0;
        }
        else if (_angle >= -95 && _angle <= -85)
        {
            _roundTo = -90;
        }
        else
        {
            _roundTo = 69;
        }


        if (_roundTo == 90)
        {
            _end = new Vector2(_start.x, camera.ScreenToWorldPoint(Input.mousePosition).y);
        }
        else if (_roundTo == -90)
        {
            _end = new Vector2(_start.x, camera.ScreenToWorldPoint(Input.mousePosition).y);
        }
        else if (_roundTo == 180)
        {
            _end = new Vector2(camera.ScreenToWorldPoint(Input.mousePosition).x, _start.y);
        }
        else if (_roundTo == 0)
        {
            _end = new Vector2(camera.ScreenToWorldPoint(Input.mousePosition).x, _start.y);
        }
        else if (_roundTo == 69)
        {
            _end = camera.ScreenToWorldPoint(Input.mousePosition);
        }


        if (!camera) return;
        if (!ball) return;
        if (!canLaunch) return;

        
        if (Input.GetMouseButtonDown(0))
        {
            if (canLaunch)
            {
                sr.enabled = true;
            }
            transform.position = (Vector2)camera.ScreenToWorldPoint(Input.mousePosition);
            _start = camera.ScreenToWorldPoint(Input.mousePosition);
            lr.enabled = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            var dir = _start - _end;
            ball.AddForce(power * -dir.normalized, ForceMode2D.Impulse);
            lr.enabled = false;
            canLaunch = false;
        }
        


        if (lr.enabled)
        {
            lr.SetPosition(0, _start);
            lr.SetPosition(1, new Vector3(_end.x, _end.y, 0));
        }
    }

}
