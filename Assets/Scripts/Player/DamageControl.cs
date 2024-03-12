using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using Michsky.UI.Heat;
using UnityEngine.Events;
using StarterAssets;


//I hate this code so much fuck

public class DamageControl : MonoBehaviour
{
    public MMFeedbacks damageFeedback;
    public GameObject player;
    public ThirdPersonController controller;

    public float health = 100.0f;
    public float damageAmount = 10.0f;

    public Vector3 respawnPoint;

    public bool isGuarded = true;

    public float GroundedOffset = -0.14f;
    public float GroundedRadius = 0.28f;

    public LayerMask GroundLayers;

    private bool _isInvincible = false; //trueの間DamageCheckを無視
    public float invincibleDuration = 1.0f;
    [Tooltip("Time until player can move after respawning")]
    public float stiffDuration = 0.02f;


    public Player playerInstance;
    public bool isActive;

    public void Start()
    {
        respawnPoint = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        controller = player.GetComponent<ThirdPersonController>();
    }

    private void DamageCheck()
    {
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset,
                transform.position.z);

        Collider[] cols = Physics.OverlapSphere(spherePosition, GroundedRadius, GroundLayers);
        foreach (var col in cols)
        {
            if (col.gameObject.tag == "Dangerous")
            {
                StartCoroutine(GiveInvincibility(invincibleDuration));
                
                OnPlayerTakeDamage();
                playerInstance?.OnPlayerTakeDamage.Invoke();

                //UIの更新
                //無敵の付与
                //演出
                break;
            }

        }
    }

    private IEnumerator GiveInvincibility(float dur)
    {
        _isInvincible = true;
        yield return new WaitForSeconds(dur);
        _isInvincible = false;
    }

    private IEnumerator DisablePlayerController()
    {
        controller.enabled = false;

        Debug.Log(controller.isStill);
        yield return new WaitForSeconds(stiffDuration);

        controller.enabled = true;
    }
    public void OnPlayerTakeDamage()
    {
        damageFeedback?.PlayFeedbacks();
        if (!isGuarded) RespawnPlayer();
        else isGuarded = false;
    }

    //doesnt work? why
    [ContextMenu("respawn")]
    public void RespawnPlayer()
    {
        StartCoroutine(DisablePlayerController());
        
        Debug.Log("respawn");
        health -= damageAmount;

        Transform playerPos = this.transform;
        playerPos.position = respawnPoint;
        
      
        isGuarded = true;

    }

    public void Update()
    {
        if (!_isInvincible) DamageCheck();
    }
}
