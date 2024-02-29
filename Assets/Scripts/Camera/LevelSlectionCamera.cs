using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSlectionCamera : MonoBehaviour
{
    public Transform Target; // ���ڂ���Ώ�(�v���C���[)

    public float AttenRate = 3.0f; // �����䗦

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
        var pos = Target.position; // �{�����B���Ă���ׂ��J�����ʒu
        transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * AttenRate); // Lerp����
    }
}
