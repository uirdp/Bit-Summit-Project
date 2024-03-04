using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyMovement : MonoBehaviour
{
    [Tooltip("set one of them to distance, others to 0")]
    public Vector3 distance;

    public Vector3 startPosition;
    public Vector3 destination;

    public float atten = 0.2f;

    public bool doRoundTrip;

    public void RoundTrip()
    {
        float t = NormalizeSine(Mathf.Sin(Time.time * atten));
        Debug.Log(t);
        transform.localPosition = Vector3.Lerp(startPosition, destination, t);
    }

    public float NormalizeSine(float val)
    {
        val *= 0.5f; // [-1, 1] -> [-0.5, 0.5]
        val += 0.5f; //         -> [0, 1]

        return val;
    }

    public void SetTripDestinations()
    {
        startPosition = transform.localPosition + distance;
        destination = transform.localPosition - distance;
    }

    private void Start()
    {
        //SetTripDestinations();
    }
    private void Update()
    {
        
        if (doRoundTrip) RoundTrip();
    }
}
