using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using Michsky.UI.Heat;


//I hate this code so much fuck

public class DamageControl : MonoBehaviour
{
    public MMFeedbacks damageFeedback;
    public GameObject player;

    public float health = 100.0f;
    public float damageAmount = 10.0f;

    public Vector3 respawnPoint;

    public bool isGuarded = true;

    public void Start()
    {
        respawnPoint = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
    }
    public void OnPlayerTakeDamage()
    {
        RespawnPlayer();
        damageFeedback?.PlayFeedbacks();

        if(!isGuarded) RespawnPlayer();
        else isGuarded = false;
    }

    //doesnt work? why
    public void RespawnPlayer()
    {
        health -= damageAmount;

        Transform playerPos = this.transform;
        //Vector3 pos = new Vector3(respawnPoint.x, respawnPoint.y, respawnPoint.z);
        playerPos.position = respawnPoint;

        Debug.Log(transform.position + " " + respawnPoint);

        isGuarded = true;
    }

    public void Update()
    {
        Debug.Log(transform.position);
    }
}

