using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mutate : MonoBehaviour
{
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
