using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
    [Header("Script by NonsenseTrey, give credit even if edited.")]
    [Header("Script originally shared at https://github.com/NonsenseTrey/Gorilla-Collect-Shared-Scripts")]
    [Header("Script originally developed for the VR game on the Horizons Store Gorilla Collect.")]
    [Header("I didn't expect sharing these scripts so all the variables will look like gibbresh.")]
    public GameObject ghosttt;
    public Transform posit;
    public float timeee;
    public float timeee2;
    void Start()
    {
        StartCoroutine(hauntening(ghosttt, posit, timeee, timeee2));
    }

    IEnumerator hauntening(GameObject ghostt, Transform pos, float tim, float tim2)
    {
        while (true)
        {
            yield return new WaitForSeconds(tim);
            ghostt.SetActive(true);
            ghostt.transform.position = pos.position;
            yield return new WaitForSeconds(tim2);
            ghostt.SetActive(false);
        }
    }
}

