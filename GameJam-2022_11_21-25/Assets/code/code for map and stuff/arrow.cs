using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{

    [SerializeField] GameObject nextPlanet;
    [SerializeField] ship spaceShip;
    [SerializeField] planet planetscript;

    Color arrowOriginalColor = Color.white;
    Color arrowHoverOverColor = Color.green;


    
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }


    private void OnMouseDown()
    {
        planetscript.isPlayerHere = false;

        spaceShip.startPosition = spaceShip.transform.position;
        spaceShip.nextDestination = nextPlanet.transform.position;

        StartCoroutine(spaceShip.Lerp());
    }


    private void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().material.color = arrowHoverOverColor;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().material.color = arrowOriginalColor;
    }


}
