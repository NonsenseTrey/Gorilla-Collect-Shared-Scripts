using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipmove : MonoBehaviour
{
    [Header("Script by NonsenseTrey, give credit even if edited.")]
    [Header("Script originally shared at https://github.com/NonsenseTrey/Gorilla-Collect-Shared-Scripts")]
    [Header("Script originally developed for the VR game on the Horizons Store Gorilla Collect.")]
    [Header("I didn't expect sharing these scripts so all the variables will look like gibbresh.")]
    public string handtag;
    public float speed;
    public Transform ship;
    public bool forward;
    public bool left;
    public bool right;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == handtag)
        {
            if (forward == true)
            {
                ship.position += new Vector3(speed, 0f, 0f);
            }
            if (right == true)
            {
                ship.Rotate(0f, speed, 0f);
            }
            if (left == true)
            {
                float baseopp = speed * 2;
                float opp = speed - baseopp;
                ship.Rotate(0f, opp, speed);
            }
        }
    }
}

