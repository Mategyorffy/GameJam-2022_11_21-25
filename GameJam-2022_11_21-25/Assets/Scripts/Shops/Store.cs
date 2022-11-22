using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace GameJam
{
    public class Store : MonoBehaviour
    {
        //Accesses the ship's stats, gold, ammo and fuel count
        [SerializeField] private CharacterStat shipInventory;
        //Main canvas for all the shops
        [SerializeField] private GameObject shopsCanvas;
        //Gameobjects in the canvas for each individual shop
        [SerializeField] private GameObject fuelShop;
        [SerializeField] private GameObject repairShop;
        [SerializeField] private GameObject upgradeShop;

        //Cost amounts for shop functions
        [SerializeField] private int fuelCost;
        [SerializeField] private int repairCost;


        //Textbox to display information
        [SerializeField] private TextMeshPro informationText;

        //RNG to see what shop was opened
        private int shopRoll;

        //Used to stop moving while in shop
        public static bool wasShopOpened;

        //Used to show if the shop was used/opened to prevent from reopening the shop
        [SerializeField] private bool wasShopUsed;

        public void OnUpgradeBuffButton(Buff buff)
        {
           int totalGoldCost = buff.goldCost * buff.shopPurchaseAmount;
            if (shipInventory.currentMoney <= totalGoldCost)
            {
                informationText.text = "You don't have enough gold";
                return;
            }
            else
            {
                shipInventory.currentMoney -= totalGoldCost;
                buff.AddUpgrade(shipInventory);

            }
        }


        public void OnShopDoneButton()
        { 
            wasShopOpened = false;
            wasShopUsed = true;
            CloseShops();
        }

        private void Awake()
        {
            CloseShops();
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                if (wasShopOpened)
                {
                    return;
                }
                shopsCanvas.SetActive(true);    
                shopRoll = Random.Range(1, 4);
                OpenShop();
              
            }
        }

        private void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                CloseShops();
                wasShopUsed = false;
            }
        }

        private void OpenShop()
        {
            switch (shopRoll)
            {
                case 1:
                    repairShop.SetActive(true);
                    informationText.text = "Do you want to repair your ship for: " + repairCost + "?";
                    break;
                case 2:
                    fuelShop.SetActive(true);
                    informationText.text = "Do you want to refuel your ship for: " + fuelCost + "?";
                    break;
                case 3:
                    upgradeShop.SetActive(true);
                    informationText.text = "Welcome to the upgrade shop";
                    break;
            }
        }

        private void FuelYes()
        {
            if (shipInventory.currentMoney >= fuelCost)
            {
                shipInventory.currentMoney -= fuelCost;
                informationText.text = "Tank filled, we fixed some dents in your Hull...free of charge of course.";
                shipInventory.currentFuel = shipInventory.maxFuel;
                shipInventory.currentHP += shipInventory.maxHP * .25f;
                StartCoroutine(ConfirmText());
                
            }
            else
            {
                informationText.text = "You don't have enough to purchase this.";
            }
        }

        private void FuelNo() 
        {
            StartCoroutine(RejectText());
        }

        private void RepairYes()
        {
            if (shipInventory.currentMoney >= repairCost)
            {
                shipInventory.currentMoney -= repairCost;
                informationText.text = "Ship repaired, we filled your tank a little...free of charge of course.";
                shipInventory.currentHP = shipInventory.maxHP;
                shipInventory.currentFuel += shipInventory.maxFuel * .25f;
                StartCoroutine(ConfirmText());
            }
            else
            {
                informationText.text = "You don't have enough to purchase this.";
            }
        }

        private void RepairNo ()
        {
            StartCoroutine(RejectText());
        }

        private IEnumerator ConfirmText()
        {
            yield return new WaitForSeconds(3);
            informationText.text = "Thank you for your purchase";
            wasShopUsed = true;
            yield return new WaitForSeconds (3);
            CloseShops();
        }

        private IEnumerator RejectText() 
        {
            informationText.text = "Thanks for stopping by.";
            wasShopUsed = true;
            yield return new WaitForSeconds (3);
        }
        private void CloseShops()
        { 
            fuelShop.SetActive(false);
            repairShop.SetActive(false);
            upgradeShop.SetActive(false);
            shopsCanvas.SetActive(false);
        }
    }
}