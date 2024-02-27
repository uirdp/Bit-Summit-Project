using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using Michsky.UI.Heat;


//I hate this code so much fuck

public class DamageControl : MonoBehaviour
{
    public MMFeedbacks damageFeedback;
    public ProgressBar healthBar;
    public GameObject player;

    public float health = 100.0f;
    public float damageAmout = 50.0f;
    

    public Vector3 respawnPoint;


    public void Start()
    {
        respawnPoint = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        healthBar.Initialize();

        healthBar.UpdateUI();
    }
    public void OnPlayerTakeDamage()
    {
        damageFeedback?.PlayFeedbacks();

        health -= damageAmout;
        
        if (health <= 0) RespawnPlayer();
    }

    //doesnt work? why
    public void RespawnPlayer()
    {
        
        Vector3 pos = new Vector3(respawnPoint.x, respawnPoint.y, respawnPoint.z);

        player.transform.position = respawnPoint;
    }

    public void Update()
    {
        Debug.Log(respawnPoint);     
    }
}

