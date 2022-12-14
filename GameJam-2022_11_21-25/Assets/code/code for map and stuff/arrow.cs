using GameJam;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{

    [SerializeField] GameObject nextPlanet;
    [SerializeField] ship spaceShip;
    [SerializeField] planet planetscript;
    [SerializeField] CharacterStat shipFuel;

    public Sprite arrowOff;
    public Sprite arrowOn;


    
    void Start()
    {
        gameObject.GetComponent<Renderer>().enabled = false;
        gameObject.GetComponent<Collider2D>().enabled = false;
    }


    private void OnMouseDown()
    {
        if (Store.wasShopOpened)
        {
            return;
        }
        if (ShipBattleStateMachine.combat)
        {
            return;
        }
        planetscript.isPlayerHere = false;

        spaceShip.startPosition = spaceShip.transform.position;
        spaceShip.nextDestination = nextPlanet.transform.position;

        StartCoroutine(spaceShip.Lerp());
        shipFuel.currentFuel--;
    }


    private void OnMouseOver()
    {
        GetComponent<SpriteRenderer>().sprite = arrowOn;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().sprite = arrowOff;
    }


}
