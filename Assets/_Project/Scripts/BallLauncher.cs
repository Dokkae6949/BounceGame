using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
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
    private Vector2 _constantEndPos;
    private Vector2 _direction;
    private float _angle;

    private int _roundTo;


    private void Start()
    {
        lr.enabled = false;
    }

    void Update()
    {
        _constantEndPos = camera.ScreenToWorldPoint(Input.mousePosition);
        _direction = _constantEndPos - _start;
        _angle = Vector2.Angle(Vector2.right, _direction);
        if(camera.ScreenToWorldPoint(Input.mousePosition).y < _start.y)
        {
            _angle = _angle * -1;
        }
        Debug.Log(_angle);
        if (!camera) return;
        if (!ball) return;
        if (!canLaunch) return;

        if (Input.GetMouseButtonDown(0))
        {
            _start = camera.ScreenToWorldPoint(Input.mousePosition);
            lr.enabled = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _end = camera.ScreenToWorldPoint(Input.mousePosition);
            var dir = _start - _end;
            ball.AddForce(power * dir.magnitude * dir.normalized, ForceMode2D.Impulse);
            canLaunch = false;
            lr.enabled = false;
        }

        if(_angle <= 95 && _angle >= 85)
        {
            _roundTo = 90;
        }

        if(_angle >= 175 || _angle <= -175)
        {
            _roundTo = 180;
        }

        if(_angle <= 5 && _angle >= -5)
        {
            _roundTo = 0;
        }


        if (lr.enabled)
        {
            lr.SetPosition(0, _start);
            //lr.SetPosition(1, (Vector2)camera.ScreenToWorldPoint(Input.mousePosition));
            lr.SetPosition(1, new Vector3());
        }
    }
}
