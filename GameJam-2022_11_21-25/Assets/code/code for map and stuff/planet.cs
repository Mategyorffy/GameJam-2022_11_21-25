using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet : MonoBehaviour
{

    public bool isPlayerHere = false;
    public bool playerWasHere = false;

    private bool safePlanet;
    private bool asteroid;
    private bool shopPlanet;
    private bool enemyPlanet;
    private bool wormHole;
    private bool finalBoss;


    [SerializeField] GameObject prArrow1; //possibleRoute
    [SerializeField] GameObject prArrow2; //possibleRoute
    [SerializeField] GameObject prArrow3; //possibleRoute

    private Color customGrayColor;


    private void Start()
    {
        customGrayColor = new Color(0.70f, 0.70f, 0.70f, 0.8f);
    }

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

        if (safePlanet)
        {

        }
        if (asteroid)
        {

        }
        if (shopPlanet)
        {

        }
        if (enemyPlanet)
        {

        }
        if (wormHole)
        {
                
        }
        if (finalBoss)
        {

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerWasHere = true;
        GetComponent<SpriteRenderer>().material.color = customGrayColor;
    }



}
