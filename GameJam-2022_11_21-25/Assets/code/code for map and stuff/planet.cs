using GameJam;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class planet : MonoBehaviour
{

    public bool isPlayerHere = false;
    public bool playerWasHere = false;

    [SerializeField] private bool safePlanet;
    [SerializeField] private bool asteroid;
    [SerializeField] private bool enemyPlanet;
    [SerializeField] private bool wormHole;
    [SerializeField] private bool finalPlanet;
    [SerializeField] private bool wormHoleUsed;


    [SerializeField] GameObject startPlanet; 
    [SerializeField] ship shipship; 

    [SerializeField] GameObject prArrow1; //possibleRoute
    [SerializeField] GameObject prArrow2; //possibleRoute
    [SerializeField] GameObject prArrow3; //possibleRoute

    [SerializeField] private TextMeshProUGUI information;
    [SerializeField] private int safePlanetGold;
    [SerializeField] private int asteroidChance;
    [SerializeField] private int wormHoleChance;
    [SerializeField] CharacterStat shipInfo;
    [SerializeField] private GameObject startingPlanet;
    [SerializeField] private int wormholeGold;
    [SerializeField] private GameObject wormHoleChoice;
    [SerializeField] private GameObject infoPanel;
    public static bool wasCalledOnce;
    private Color customGrayColor;


    private void Start()
    {
        customGrayColor = new Color(0.70f, 0.70f, 0.70f, 1.0f);
        shipInfo = GameObject.Find("Manager").GetComponent<CharacterStat>();
        safePlanetGold = 100;
        wasCalledOnce= true;
    }

    void Update()
    {
        if (ShipBattleStateMachine.combat)
        { 
            infoPanel.SetActive(false);
        }
        if (!ShipBattleStateMachine.combat)
        {
            if (!wasCalledOnce)
            { 
                StartCoroutine(BattleWait());
            }
        }
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
            information.text = "Everything seems fine here we even found some gold!";
            shipInfo.currentMoney += 100;
        }
        if (asteroid)
        {
            asteroidChance = Random.Range(0, 100);
            switch (asteroidChance) 
            {
                case < 50:
                    shipInfo.currentHP -= 25f;
                    information.text = "Captain, the asteroid was loaded with explosives!";
                    break;
                case >= 50:
                    shipInfo.currentMoney += 150;
                    information.text = "We're quite lucky Captain, there was gold in that asteroid.";
                    break;
            }
        }
        if (enemyPlanet)
        {
            StartCoroutine(EnemyEncounter());
        }
        if (wormHole)
        {
            information.text = "This takes us back to the station Captain...but for a price \n Use Wormhole for " + wormholeGold + "?";
            wormHoleChoice.SetActive(true);
        }
        if (finalPlanet)
        {
            StartCoroutine(FinalScene());
        }
    }

    public void WormHoleYes()
    {
        //move it here!
        wormHoleChance = Random.Range(0, 100);
        switch (wormHoleChance)
        {
            case < 60:
                shipInfo.currentHP -= (shipInfo.maxHP/2);
                information.text = "Captain, we've suffered extreme casualties!";
                break;
            case >= 50:
                shipInfo.currentMoney += 300;
                information.text = "There were a lot of resources we can use!";
                break;
        }
        wormHoleChoice.SetActive(false);
        
    }

    public void WormHoleNo()
    {
        information.text = "Very well Captain, keep moving forward!";
        wormHoleChoice.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().material.color = customGrayColor;
        playerWasHere = true;
    }

    public IEnumerator EnemyEncounter()
    {
        wasCalledOnce = true;
        information.text = "Enemy detected Battle stations!";
        yield return new WaitForSeconds(3);
        infoPanel.SetActive(false);
        SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
    }

    public IEnumerator FinalScene()
    {
        information.text = "Captain we seem to have reached the end, the enemies have retreated!";
        yield return new WaitForSeconds(3);
        information.text = "Thanks for playing!";
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(0);
    }

    public IEnumerator BattleWait()
    {
        yield return new WaitForSeconds(3);
        information.text = "Onward!";
        infoPanel.SetActive(true);
        wasCalledOnce = true;
    }
}
