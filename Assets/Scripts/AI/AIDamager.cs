using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIDamager : MonoBehaviour
{

    public static Action<GameObject> onPlayerHit;

    [SerializeField] private int _damage;
    [SerializeField] private float forceMultiplier = 10;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
 
        }
    }


    private void Damage()
    {
      
    }
}
