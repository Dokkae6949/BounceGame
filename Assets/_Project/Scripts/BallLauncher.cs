using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public Camera camera;
    
    public bool canLaunch;
    
    private Vector2 _start;
    private Vector2 _end;
    
    void Update()
    {
        if (!camera) return;
        if (!canLaunch) return;

        if (Input.GetMouseButtonDown(0))
        {
            _start = camera.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _end = camera.ScreenToWorldPoint(Input.mousePosition);
            canLaunch = false;
        }
    }
}
