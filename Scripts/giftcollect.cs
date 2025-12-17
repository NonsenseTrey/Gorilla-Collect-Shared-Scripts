using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class giftcollect : MonoBehaviour
{
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
