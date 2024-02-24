using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VSX.UniversalVehicleCombat;
using Cinemachine;

public class ThirdPersonCamera : MonoBehaviour
{
    //������J�����ɂ��āALoadOut-����ǂ�ł�������
    private void StartFollowing(Vehicle target)
    {
        var followTarget = target.transform.GetChild(0);

        var vcam = GetComponent<CinemachineVirtualCamera>();
        vcam.Follow = followTarget;
    }
}
