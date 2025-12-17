using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

public class leverchoose : MonoBehaviour
{
    public GameObject[] levers;
    private int Pick;
    void Start()
    {
        Pick = Random.Range(1, levers.Length);
        levers[Pick].SetActive(true);
    }
}
