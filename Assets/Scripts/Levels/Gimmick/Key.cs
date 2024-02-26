using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    //public KeyCollectionProgress Progress;
    public FloorManager floorManager;

    public float keyRadius = 1.0f; //please come up with a better name fr
    public LayerMask PlayerLayer;
    //check whether the key was obtained by the player


    private void Update()
    {
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
                floorManager?.OnKeyCollected.Invoke();
                this.GetComponent<Renderer>().material.color = Color.green;
            }
        }
    }


}
