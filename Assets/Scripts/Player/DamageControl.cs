using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour
{
    public MaterialList materialList;
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("colliding");
        if (collision.gameObject.tag == "dangerous")
        {
            Debug.Log("Take Damage");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L)) { Debug.Log(transform.position); }
       
    }
}

