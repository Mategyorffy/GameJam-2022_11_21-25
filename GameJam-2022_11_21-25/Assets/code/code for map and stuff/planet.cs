using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet : MonoBehaviour
{

    public bool isPlayerHere = false;

    [SerializeField] GameObject prArrow1; //possibleRoute
    [SerializeField] GameObject prArrow2; //possibleRoute
    [SerializeField] GameObject prArrow3; //possibleRoute



    void Update()
    {

        if (isPlayerHere == true)
        {
            prArrow1.gameObject.GetComponent<Renderer>().enabled = true;
            prArrow1.gameObject.GetComponent<Collider2D>().enabled = true;

            prArrow2.gameObject.GetComponent<Renderer>().enabled = true;
            prArrow2.gameObject.GetComponent<Collider2D>().enabled = true;

            prArrow3.gameObject.GetComponent<Renderer>().enabled = true;
            prArrow3.gameObject.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            prArrow1.gameObject.GetComponent<Renderer>().enabled = false;
            prArrow1.gameObject.GetComponent<Collider2D>().enabled = false;

            prArrow2.gameObject.GetComponent<Renderer>().enabled = false;
            prArrow2.gameObject.GetComponent<Collider2D>().enabled = false;

            prArrow3.gameObject.GetComponent<Renderer>().enabled = false;
            prArrow3.gameObject.GetComponent<Collider2D>().enabled = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isPlayerHere = true;
    }

    

}
