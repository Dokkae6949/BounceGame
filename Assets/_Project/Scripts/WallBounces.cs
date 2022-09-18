using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBounces : MonoBehaviour
{
    public GameManager gM;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gM.deactivationAmount++;
            gameObject.SetActive(false);
        }
    }
}
