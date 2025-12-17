using PlayFab.ClientModels;
using PlayFab;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class mine : MonoBehaviour
{
    [Header("Script by NonsenseTrey, give credit even if edited.")]
    [Header("Script originally shared at https://github.com/NonsenseTrey/Gorilla-Collect-Shared-Scripts")]
    [Header("Script originally developed for the VR game on the Horizons Store Gorilla Collect.")]
    [Header("I didn't expect sharing these scripts so all the variables will look like gibbresh.")]
    public string minetag;
    public int cost;
    public string codeword;
    public float respawntime;
    public AudioSource stonebreake;
    public AudioSource gain;
    public bool nocooldown = false;
    public bool destroy;
    public bool teleport = false;
    public Transform teleportarea;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(minetag))
        {
            if (!teleport)
            {
                if (!nocooldown)
                {
                    this.gameObject.SetActive(false);
                }
            }
            Getstuff();
            stonebreake.Play();
            gain.Play();
            if (teleport)
            {
                this.transform.position = teleportarea.position;
            }
            else {
                if (destroy)
                {
                    PhotonNetwork.Destroy(this.gameObject);
                }
                else
                {
                    StartCoroutine(wait(respawntime));
                }
            }
        }
    }
    public void Getstuff()
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

    IEnumerator wait(float timetowait)
    {
        yield return new WaitForSeconds(timetowait);
        this.gameObject.SetActive(true);
    }
}

