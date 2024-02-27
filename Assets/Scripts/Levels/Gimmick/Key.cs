using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public enum keyStatus
    {
        locked,
        unLocked
    };

    public keyStatus status = keyStatus.locked;
    //public KeyCollectionProgress Progress;
    public FloorManager floorManager;

    public int id;

    public float keyRadius = 1.0f; //please come up with a better name fr
    public LayerMask PlayerLayer;
    //check whether the key was obtained by the player

    public Color lockedColor = Color.green;
    public Color unlockedColor = Color.red;

    public float rotateSpeed = 35.0f;
    private float _angle = 0.0f;

    private void Awake()
    {
        Lock();
    }
    private void Update()
    {
        Rotate();
        ObtainedCheck();
    }

    //check whether the key was obtained by the player
    private void ObtainedCheck()
    {
        Vector3 SpherePosition = new Vector3(transform.position.x, transform.position.y,
                transform.position.z);


        Collider[] cols = Physics.OverlapSphere(SpherePosition, keyRadius, PlayerLayer);
        foreach (var col in cols)
        {
            if (col.gameObject.tag == "Player")
            {
                keyRadius = 0;  //turn off collider
                Unlock();
            }
        }
    }

    private void Lock()
    {
        status = keyStatus.locked;

        Transform crystal = transform.GetChild(0);
        crystal.GetComponent<Renderer>().material.color = lockedColor;
    }

    private void Unlock()
    {
        floorManager?.OnKeyCollected();

        Transform crystal = transform.GetChild(0);
        crystal.GetComponent<Renderer>().material.color = unlockedColor;

        status = keyStatus.unLocked;
    }

    private void Rotate()
    {
        _angle += Time.deltaTime * rotateSpeed;
        transform.rotation = Quaternion.Euler(0, _angle, 0);
    }


}
