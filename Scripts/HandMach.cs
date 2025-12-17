using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMach : MonoBehaviour
{
    [Header("Script by NonsenseTrey, give credit even if edited.")]
    [Header("Script originally shared at https://github.com/NonsenseTrey/Gorilla-Collect-Shared-Scripts")]
    [Header("Script originally developed for the VR game on the Horizons Store Gorilla Collect.")]
    [Header("I didn't expect sharing these scripts so all the variables will look like gibbresh.")]
    public Transform hand;
    public Transform cos;
    void Update()
    {
        cos.position = hand.position;
        cos.rotation = hand.rotation;
    }
}

