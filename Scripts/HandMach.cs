using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandMach : MonoBehaviour
{
    public Transform hand;
    public Transform cos;
    void Update()
    {
        cos.position = hand.position;
        cos.rotation = hand.rotation;
    }
}
