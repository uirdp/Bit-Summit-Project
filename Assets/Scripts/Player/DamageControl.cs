using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageControl : MonoBehaviour
{
    public MaterialList materialList;


    //Maybe use ray?
    public void Get()
    {
        Debug.Log("called");
    }
    private void OnCollisionStay(Collision collision)
    {
        //Project Setting -> Physics -> Sleeping Threshold -> 0
        //When player stops, rigid body will be turned off
        //maybe a lot of cost, but let's keep it that
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

