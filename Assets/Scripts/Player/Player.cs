using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSX.UniversalVehicleCombat;
using Michsky.UI.Heat;
using UnityEngine.Events;

//rename to player status?
public class Player : MonoBehaviour
{
    public Vehicle player;
    public GameAgent gameAgent;

    public ProgressBar healthBar;

    public UnityEvent OnPlayerTakeDamage;

    public void GetPlayer(Vehicle v)
    {
        player = v;
    }

    public void RespawnPlayer()
    {
        player.transform.position = gameAgent.transform.position;
    }

}
