using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.Heat;


//TODO damagecontrol -> health
//plz fix this later goosebumps fr
public class HealthBar : MonoBehaviour
{
    public ProgressBar healthBar;
    public float damageAmout = 50;
    public Player player;

    private DamageControl playerHealth;

    public void HealthUpdate()
    {
        healthBar.currentValue = playerHealth.health;
        healthBar.UpdateUI();
    }

    public void GetPlayer()
    {
        Debug.Log("get");

        playerHealth = player.player?.GetComponent<DamageControl>();
        if (playerHealth == null) Debug.Log("damage control null");
        if (player.player == null) Debug.Log("player null");

        Debug.Log("got");
    }

    private void Start()
    {
        //GetPlayer();
    }

    private void Update()
    {
        if (playerHealth != null) HealthUpdate();
    }
}

