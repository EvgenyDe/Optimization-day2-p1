using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour,IUpdateble
{
   // private GameObject player;

    private void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {

          
    }

    public void Tik()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            transform.LookAt(player.transform.position);
            transform.Translate(0, 0, 0.05f);
        }
    }
}
