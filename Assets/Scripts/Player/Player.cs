using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSX.UniversalVehicleCombat;

public class Player : MonoBehaviour
{
    public Vehicle player;
    public GameAgent gameAgent;

    public void GetPlayer(Vehicle v)
    {
        player = v;
    }

    public void RespawnPlayer()
    {
        player.transform.position = gameAgent.transform.position;
    }
}
