using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class shipping : MonoBehaviour
{
    public string tagg;                         // Tag to detect on collision
    public GameObject door;                    // Door to destroy
    public Transform spawn;                    // Fixed spawn point
    public string[] objects;                   // Names of prefabs to spawn
    public bool destroy = true;
    public bool client = false;
    public int min = 5;
    public int max = 8;
    public bool master = false;
    private GameObject key;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagg))
        {
            int amount = Random.Range(min, max); // Random number of items (4 to 6)

            for (int i = 0; i < amount; i++)
            {
                string prefabName = objects[Random.Range(0, objects.Length)];

                // Try to instantiate the prefab, fallback to "error" if it fails
                if(master)
                {
                    if (PhotonNetwork.IsMasterClient)
                    {
                        try
                        {
                            GameObject clone = PhotonNetwork.Instantiate(prefabName, spawn.position, Quaternion.identity);
                            clone.transform.rotation = spawn.rotation;
                            clone.gameObject.SetActive(true);
                        }
                        catch
                        {
                            Debug.LogWarning($"Failed to load prefab '{prefabName}', spawning 'error' instead.");
                            GameObject clone = PhotonNetwork.Instantiate("error", spawn.position, Quaternion.identity);
                            clone.transform.rotation = spawn.rotation;
                            clone.gameObject.SetActive(true);
                        }
                    }
                } else
                {
                    try
                    {
                        GameObject clone = PhotonNetwork.Instantiate(prefabName, spawn.position, Quaternion.identity);
                        clone.transform.rotation = spawn.rotation;
                        clone.gameObject.SetActive(true);
                    }
                    catch
                    {
                        Debug.LogWarning($"Failed to load prefab '{prefabName}', spawning 'error' instead.");
                        GameObject clone = PhotonNetwork.Instantiate("error", spawn.position, Quaternion.identity);
                        clone.transform.rotation = spawn.rotation;
                        clone.gameObject.SetActive(true);
                    }
                }
            }

            if (other.transform.parent != null)
            {
                key = other.transform.parent.gameObject;
                PhotonNetwork.Destroy(key); // Destroy the parent if it holds the key
            }

            if (destroy)
            {
                if (door != null)
                {
                    if (client)
                    {
                        Destroy(door.gameObject);
                    }
                    else
                    {
                        PhotonNetwork.Destroy(door); // Destroy the door network-wide
                    }
                }
                else
                {
                    Debug.LogWarning("Door object not assigned in inspector.");
                }
            }
        }
    }
}
