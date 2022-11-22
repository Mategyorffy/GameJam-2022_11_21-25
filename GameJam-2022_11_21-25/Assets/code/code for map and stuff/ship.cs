using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ship : MonoBehaviour
{


    public Vector3 startPosition;
    public Vector3 nextDestination;
    private float lerpDuration = 3;



    public IEnumerator Lerp()
    {
        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            transform.position = Vector3.Lerp(startPosition, nextDestination, Mathf.SmoothStep(0, 1, timeElapsed / lerpDuration));
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = nextDestination;
    }




}
