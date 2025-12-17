using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class giftcollect : MonoBehaviour
{
    [Header("Script by NonsenseTrey, give credit even if edited.")]
    [Header("Script originally shared at https://github.com/NonsenseTrey/Gorilla-Collect-Shared-Scripts")]
    [Header("Script originally developed for the VR game on the Horizons Store Gorilla Collect.")]
    [Header("I didn't expect sharing these scripts so all the variables will look like gibbresh.")]
    public string[] items;
    private GameObject cloneditem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HandTag")
        {
            int item = Random.Range(1, items.Length);
            float x = this.transform.position.x;
            float y = this.transform.position.y;
            float z = this.transform.position.z;

            // Try to instantiate selected item, fallback to "error" if it fails
            try
            {
                cloneditem = PhotonNetwork.Instantiate(items[item], new Vector3(x, y, z), Quaternion.identity);
            }
            catch
            {
                Debug.LogWarning($"Failed to load item '{items[item]}', spawning 'error' instead.");
                cloneditem = PhotonNetwork.Instantiate("error", new Vector3(x, y, z), Quaternion.identity);
            }

            PhotonNetwork.Destroy(this.gameObject);
        }
    }
}

