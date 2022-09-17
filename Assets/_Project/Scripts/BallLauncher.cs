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


    private void Start()
    {
        lr.enabled = false;
    }

    void Update()
    {
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

        if (lr.enabled)
        {
            lr.SetPosition(0, _start);
            lr.SetPosition(1, (Vector2)camera.ScreenToWorldPoint(Input.mousePosition));
        }
    }
}
