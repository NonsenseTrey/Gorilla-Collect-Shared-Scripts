using Photon.Pun;
using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trash : MonoBehaviour
{
    [Header("Script by NonsenseTrey, give credit even if edited.")]
    [Header("Script originally shared at https://github.com/NonsenseTrey/Gorilla-Collect-Shared-Scripts")]
    [Header("Script originally developed for the VR game on the Horizons Store Gorilla Collect.")]
    [Header("I didn't expect sharing these scripts so all the variables will look like gibbresh.")]
    public bool money = false;
    public bool convert = false;
    public Transform spawn;
    private GameObject item;
    public void Getstuff(string codeword, int cost)
    {
        var request = new AddUserVirtualCurrencyRequest
        {
            VirtualCurrency = codeword,
            Amount = cost
        };
        PlayFabClientAPI.AddUserVirtualCurrency(request, OnAddCoinsSuccess, OnError);
    }

    void OnAddCoinsSuccess(ModifyUserVirtualCurrencyResult result)
    {
        Playfablogin.instance.GetVirtualCurrencies();
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error: " + error.ErrorMessage);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("item"))
        {
            PhotonNetwork.Destroy(other.gameObject);
            if (money)
            {
                Getstuff("GG", 50);
                Getstuff("CS", 1000);
            }
            if (convert)
            {
                float x = spawn.transform.position.x;
                float y = spawn.transform.position.y;
                float z = spawn.transform.position.z;
                item = PhotonNetwork.Instantiate("uranium", new Vector3(x, y, z), Quaternion.identity);
            }
        }
    }
}

