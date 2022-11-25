using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace GameJam
{
    public class Store : MonoBehaviour
    {
        //Statice int for upgrade yes button 
        private static int shopVerify;

        //Accesses the ship's stats, gold, ammo and fuel count
        [SerializeField] private CharacterStat shipInventory;
        //Main canvas for all the shops
        [SerializeField] internal GameObject shopsCanvas;
        //Gameobjects in the canvas for each individual shop
        [SerializeField] private GameObject fuelShop;
        [SerializeField] private GameObject repairShop;
        [SerializeField] private GameObject upgradeShop;
        [SerializeField] private GameObject InformationPanel;

        //Cost amounts for shop functions
        [SerializeField] private int fuelCost;
        [SerializeField] private int repairCost;
        [SerializeField] private int singleLaserCost;
        [SerializeField] private int singleRocketCost;
        [SerializeField] private int totalLaserCost;
        [SerializeField] private int totalRocketCost;

        //Textbox to display information
        [SerializeField] private TextMeshProUGUI informationText;
        [SerializeField] private TextMeshProUGUI repairText;
        [SerializeField] private TextMeshProUGUI fuelText;

        //Upgrade choice object
        [SerializeField] private GameObject upgradeShopChoice;

        //Total cost for a shop ugrade
        [SerializeField] private int totalGoldCost;

        //RNG to see what shop was opened
        internal int shopRoll;

        //Used to stop moving while in shop
        public static bool wasShopOpened;

        //Used to show if the shop was used/opened to prevent from reopening the shop
        [SerializeField] internal bool wasShopUsed;

        //Placeholder for buff
        [SerializeField] private Buff buffHolder;

        //All the buttons
        [SerializeField] private GameObject buttons;

        //Bools for rocket and laser purchases
        [SerializeField] private bool rocketPurchase;
        [SerializeField] private bool laserPurchase;

        private void Start()
        {
            informationText.text = "Navigate to the end";   
        }

        public void OnUpgradeBuffButton(Buff buff)
        {
            totalGoldCost = buff.goldCost * buff.shopPurchaseAmount;
            if (shipInventory.currentMoney < totalGoldCost)
            {
                informationText.text = "You don't have enough gold";
                return;
            }
            else
            {
                informationText.text = buff.shopInfoText;
                buffHolder = buff;
                upgradeShopChoice.SetActive(true);
                buttons.SetActive(false);

            }
        }

        public void OnUpgradeYes()
        {
            if (laserPurchase)
            {
                shipInventory.currentMoney -= totalLaserCost;
                shipInventory.currentLaserAmmo = shipInventory.maxLaserAmmo;
                upgradeShopChoice.SetActive(false);
                buttons.SetActive(true);
                laserPurchase = false;
                informationText.text = "Purchase another upgrade?";
                return;
            }
            else if (rocketPurchase)
            {
                shipInventory.currentMoney -= totalRocketCost;
                shipInventory.currentRocketAmmo = shipInventory.maxRocketAmmo;
                upgradeShopChoice.SetActive(false);
                buttons.SetActive(true);
                rocketPurchase = false;
                informationText.text = "Purchase another upgrade?";
                return;
            }
            shipInventory.currentMoney -= totalGoldCost;
            buffHolder.AddGenericUpgrade(shipInventory);
            buffHolder.shopPurchaseAmount++;
            upgradeShopChoice.SetActive(false);
            buttons.SetActive(true);
            informationText.text = "Purchase another upgrade?";
        }

        public void OnUpgradeNo() 
        {
            if (laserPurchase)
            {
                laserPurchase = false;
            }
            else if (rocketPurchase)
            {
                rocketPurchase = false;
            }
            upgradeShopChoice.SetActive(false);
            buttons.SetActive(true);
            informationText.text = "Changed your mind?";
        }

        public void OnLaserBuy()
        {
            totalLaserCost = (shipInventory.maxLaserAmmo - shipInventory.currentLaserAmmo) * singleLaserCost;
            if (shipInventory.currentMoney < totalLaserCost)
            {
                informationText.text = "You don't have enough gold";
                return;
            }
            if (shipInventory.currentLaserAmmo == shipInventory.maxLaserAmmo)
            {
                informationText.text = "You already have all you can hold!";
                return;
            }
            informationText.text = "Refill your missing " + (shipInventory.maxLaserAmmo - shipInventory.currentLaserAmmo) + " lasers \nfor" + totalLaserCost + " gold?";
            laserPurchase = true;
            buttons.SetActive(false);
            upgradeShopChoice.SetActive(true);
        }

        public void OnRocketBuy() 
        {
            totalRocketCost = (shipInventory.maxRocketAmmo - shipInventory.currentRocketAmmo) * singleRocketCost;
            if (shipInventory.currentMoney < totalRocketCost)
            {
                informationText.text = "You don't have enough gold";
                return;
            }
            if (shipInventory.currentRocketAmmo == shipInventory.maxRocketAmmo)
            {
                informationText.text = "You already have all you can hold!";
                return;
            }
            informationText.text = "Refill your missing " + (shipInventory.maxRocketAmmo - shipInventory.currentRocketAmmo) + " rockets \nfor" + totalRocketCost + " gold?";
            rocketPurchase= true;
            buttons.SetActive(false);
            upgradeShopChoice.SetActive(true);
        }

        public void OnShopDoneButton()
        { 
            wasShopOpened = false;
            wasShopUsed = true;
            StartCoroutine(RejectText());
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

        public void OpenShop()
        {
            switch (shopRoll)
            {
                case 1:
                    repairShop.SetActive(true);
                    repairText.text = "Do you want to repair your ship for: " + repairCost + " gold?";
                    InformationPanel.SetActive(false);
                    break;
                case 2:
                    fuelShop.SetActive(true);
                    fuelText.text = "Do you want to refuel your ship for: " + fuelCost + " gold?";
                    InformationPanel.SetActive(false);
                    break;
                case 3:
                    upgradeShop.SetActive(true);
                    informationText.text = "Welcome to the upgrade shop";
                    break;
            }
        }

        public void FuelYes()
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

        public void FuelNo() 
        {
            StartCoroutine(RejectText());
        }

        public void RepairYes()
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

        public void RepairNo ()
        {
            StartCoroutine(RejectText());
        }

        private IEnumerator ConfirmText()
        {
            yield return new WaitForSeconds(3);
            informationText.text = "Thank you for your purchase";
            wasShopUsed = true;
            yield return new WaitForSeconds (2);
            CloseShops();
            informationText.text = "";
            InformationPanel.SetActive(true);

        }

        private IEnumerator RejectText() 
        {
            informationText.text = "Thanks for stopping by.";
            wasShopUsed = true;
            yield return new WaitForSeconds (2);
            CloseShops();
            informationText.text = "";
            InformationPanel.SetActive(true);
        }
        public void CloseShops()
        { 
            fuelShop.SetActive(false);
            repairShop.SetActive(false);
            upgradeShop.SetActive(false);
            shopsCanvas.SetActive(false);
        }
    }
}