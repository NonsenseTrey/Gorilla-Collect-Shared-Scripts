using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class buyitem : MonoBehaviour
{
    [Header("Script by NonsenseTrey, give credit even if edited.")]
    [Header("Script originally shared at https://github.com/NonsenseTrey/Gorilla-Collect-Shared-Scripts")]
    [Header("Script originally developed for the VR game on the Horizons Store Gorilla Collect.")]
    [Header("I didn't expect sharing these scripts so all the variables will look like gibbresh.")]
    public int coinsPrice;
    public string item;
    public Playfablogin login;
    public Transform spawn;
    private GameObject bought;
    private GameObject monyy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HandTag")
        {
            if (login.coins >= coinsPrice)
            {
                BuyItem();
                float x = spawn.position.x;
                float y = spawn.position.y;
                float z = spawn.position.z;
                for (int i = 0; i < 5; i++)
                {
                    monyy = PhotonNetwork.Instantiate("money", this.transform.position, Quaternion.identity);
                }

                // Try to instantiate the item, fallback to "error" if it fails
                try
                {
                    bought = PhotonNetwork.Instantiate(item, new Vector3(x, y, z), Quaternion.identity);
                }
                catch
                {
                    Debug.LogWarning($"Failed to load item '{item}', spawning 'error' instead.");
                    bought = PhotonNetwork.Instantiate("error", new Vector3(x, y, z), Quaternion.identity);
                }
            }
        }
    }

    public void BuyItem()
    {
        var request = new SubtractUserVirtualCurrencyRequest
        {
            VirtualCurrency = "CS",
            Amount = coinsPrice
        };
        PlayFabClientAPI.SubtractUserVirtualCurrency(request, OnSubtractCoinsSuccess, OnError);
    }

    void OnSubtractCoinsSuccess(ModifyUserVirtualCurrencyResult result)
    {
        Playfablogin.instance.GetVirtualCurrencies();
    }

    void OnError(PlayFabError error)
    {
        Debug.Log("Error: " + error.ErrorMessage);
    }
}

