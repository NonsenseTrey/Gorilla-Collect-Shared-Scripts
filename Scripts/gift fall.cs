using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun;

public class giftfall : MonoBehaviour
{
    public string item;
    public GameObject[] spawn;
    public float tim;
    public bool onlymaster = false;
    private GameObject giftclone;

    void Start()
    {
        StartCoroutine(waitsec(tim));
    }

    IEnumerator waitsec(float timey)
    {
        while (true)
        {
            yield return new WaitForSeconds(timey);
            int point = Random.Range(1, spawn.Length);
            float x = spawn[point].transform.position.x;
            float y = spawn[point].transform.position.y;
            float z = spawn[point].transform.position.z;

            // Try to instantiate the item, fallback to "error" if it fails
            if (onlymaster)
            {
                if (PhotonNetwork.IsMasterClient)
                {
                    try
                    {
                        giftclone = PhotonNetwork.Instantiate(item, new Vector3(x, y, z), Quaternion.identity);
                    }
                    catch
                    {
                        Debug.LogWarning($"Failed to load item '{item}', spawning 'error' instead.");
                        giftclone = PhotonNetwork.Instantiate("error", new Vector3(x, y, z), Quaternion.identity);
                    }
                }
            }
            else
            {
                try
                {
                    giftclone = PhotonNetwork.Instantiate(item, new Vector3(x, y, z), Quaternion.identity);
                }
                catch
                {
                    Debug.LogWarning($"Failed to load item '{item}', spawning 'error' instead.");
                    giftclone = PhotonNetwork.Instantiate("error", new Vector3(x, y, z), Quaternion.identity);
                }
            }
        }
    }
}
