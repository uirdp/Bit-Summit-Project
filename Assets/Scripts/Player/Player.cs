using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSX.UniversalVehicleCombat;
using Michsky.UI.Heat;
using UnityEngine.Events;
using StarterAssets;

//omg it is a mess
//rename to player status?
public class Player : MonoBehaviour
{
    public Vehicle player;
    public ThirdPersonController controller;
    public GameAgent gameAgent;

    public ProgressBar healthBar;

    public UnityEvent OnPlayerTakeDamage;

    public void GetPlayer(Vehicle v, ThirdPersonController cntr)
    {
        player = v;
        controller = cntr;
    }

    public void RespawnPlayer()
    {
        player.transform.position = gameAgent.transform.position;
    }

    public void DisablePlayerControl()
    {
        controller.enabled = false;
    }
}
