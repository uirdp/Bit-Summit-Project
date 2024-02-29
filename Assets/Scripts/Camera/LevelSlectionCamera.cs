using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSlectionCamera : MonoBehaviour
{
    public Transform Target; // 注目する対象(プレイヤー)

    public float AttenRate = 3.0f; // 減衰比率

    public void Awake()
    {
        this.GetComponent<LevelSlectionCamera>().enabled = false;
    }

    public void StartLerp()
    {
        this.GetComponent<LevelSlectionCamera>().enabled = true;
    }
    void Update()
    {
        var pos = Target.position; // 本来到達しているべきカメラ位置
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * AttenRate); // Lerp減衰
    }
}
