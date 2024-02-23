using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSX.UniversalVehicleCombat;
using Cinemachine;

public class ThirdPersonCamera : MonoBehaviour
{
    //‚±‚ê‚ğƒJƒƒ‰‚É‚Â‚¯‚ÄALoadOut-‚©‚ç“Ç‚ñ‚Å‚­‚¾‚³‚¢
    private void StartFollowing(Vehicle player)
    {
        var followTarget = player.transform.GetChild(0);

        var vcam = GetComponent<CinemachineVirtualCamera>();
        vcam.Follow = followTarget;
    }
}
