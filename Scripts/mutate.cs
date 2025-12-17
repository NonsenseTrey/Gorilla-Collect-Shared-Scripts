using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mutate : MonoBehaviour
{
    [Header("Script by NonsenseTrey, give credit even if edited.")]
    [Header("Script originally shared at https://github.com/NonsenseTrey/Gorilla-Collect-Shared-Scripts")]
    [Header("Script originally developed for the VR game on the Horizons Store Gorilla Collect.")]
    [Header("I didn't expect sharing these scripts so all the variables will look like gibbresh.")]
    public string tagg;
    public float min;
    public float max;
    private float scale;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(tagg))
        {
            scale = Random.Range(min, max);
            other.transform.localScale = new Vector3(scale, scale, scale);
            this.gameObject.SetActive(false);
        }
    }
}

