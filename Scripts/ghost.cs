using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghost : MonoBehaviour
{
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
