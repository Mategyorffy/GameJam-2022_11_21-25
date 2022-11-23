using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameJam
{
    public class PlayerShipStateMachine : MonoBehaviour
    {
        public CharacterStat playerSO;

        public enum TurnState
        {
            Processing,
            ButtonsLightUp,
            Waiting,
            Action,
            Dead
        }


        public TurnState currentState;

        [SerializeField] internal float currentCooldown = 0f;
        private float maxCooldown = 100f;
        public Slider timerBar;
        public TMP_Text reloadText;
        [SerializeField] private Slider hpSlider;
      
        private  ShipBattleStateMachine shipBattle;
        public TMP_Text rocketAmmoCount;
        public TMP_Text laserAmmoCount;
      
        [SerializeField] private Image machineGunButtonImage;
        [SerializeField] private Image laserButtonImage;
        [SerializeField] private Image rocketButtonImage;
        public bool buttonPressable;

        public List<GameObject> enemies = new List<GameObject>();

        private void Start()
        {
            hpSlider.value = playerSO.currentHP;
            shipBattle = GameObject.Find("BattleManager").GetComponent<ShipBattleStateMachine>();
            playerSO.OnPlayerHealthChange += PlayerHPChange;
            playerSO.OnLaserChange += UpdateLaserAmmoAmount;
            playerSO.OnRocketChange += UpdateRocketAmmoAmount;
            rocketAmmoCount.text = playerSO.currentRocketAmmo.ToString();
            laserAmmoCount.text = playerSO.currentLaserAmmo.ToString();
            reloadText.text = "Reloading..";
            machineGunButtonImage.color = Color.gray;
            rocketButtonImage.color = Color.gray;
            laserButtonImage.color = Color.gray;


        }


        public void PlayerHPChange(float health)
        {
            if (playerSO.currentHP < 0)
            {
                playerSO.currentHP = 0;
            }
            else if (playerSO.currentHP > playerSO.maxHP)
            {
                playerSO.currentHP = playerSO.maxHP;
            }
            hpSlider.value = (health / playerSO.maxHP) * 100;

      
        }

        private void Update()
        {
            switch (currentState)
            {
                case TurnState.Processing:
                    UpgradeTimerBar();
                    break;
                case TurnState.ButtonsLightUp:
                    buttonPressable = true;
                    ActivateAttackButtons();
                    currentState = TurnState.Waiting;
                    break;
            }

        }

        void UpgradeTimerBar()
        {

            currentCooldown += (playerSO.crewSpeed * Time.deltaTime);
            timerBar.value = currentCooldown;
           

            if (currentCooldown >= maxCooldown)
            {
                UpdateLaserAmmoAmount(playerSO.currentLaserAmmo);
                UpdateRocketAmmoAmount(playerSO.currentRocketAmmo);
                currentState = TurnState.ButtonsLightUp;
            }
        }
        void UpdateLaserAmmoAmount(int ammount)
        {

            laserAmmoCount.text = ammount.ToString();
        }
        void UpdateRocketAmmoAmount(int ammount)
        {

            rocketAmmoCount.text = ammount.ToString();
        }
        public void ActivateAttackButtons()
        {
            

            reloadText.text = "Take Action";
            // Machine Gun 0
            //Rockets 1
            //Laser 2
            machineGunButtonImage.color = Color.white;
            
            if (playerSO.currentLaserAmmo >= 0)
            {
                laserButtonImage.color = Color.white;

            }
            if(playerSO.currentRocketAmmo >= 0)
            {
                rocketButtonImage.color = Color.white;  
            }

        }

        private IEnumerator PlayerAction()
        {
            yield return new WaitForSeconds(5);
        }

        public void FireMachineGun()
        {
            if (buttonPressable)
            {
                Debug.Log("FIRING MACHINE GUN");
                currentCooldown = 0;
                timerBar.value = currentCooldown;
                buttonPressable = false;
                machineGunButtonImage.color = Color.gray;
                rocketButtonImage.color = Color.gray;
                laserButtonImage.color = Color.gray;
                reloadText.text = "Reloading..";
                currentState = TurnState.Processing;

            }
            else
            {
                return;
            }
        }
        public void FireLaser()
        {
            if (buttonPressable)
            {
                Debug.Log("FIRING LASER");
                currentCooldown = 0;
                timerBar.value = currentCooldown;
                buttonPressable = false;
                machineGunButtonImage.color = Color.gray;
                rocketButtonImage.color = Color.gray;
                laserButtonImage.color = Color.gray;
                reloadText.text = "Reloading..";
                playerSO.currentLaserAmmo--;
                currentState = TurnState.Processing;
            }
            else
            {
                return;
            }
        }
        public void FireRockets()
        {
            if (buttonPressable)
            {
                Debug.Log("FIRING ROCKETS");
                currentCooldown = 0;
                timerBar.value = currentCooldown;
                buttonPressable = false;
                machineGunButtonImage.color = Color.gray;
                rocketButtonImage.color = Color.gray;
                laserButtonImage.color = Color.gray;
                reloadText.text = "Reloading..";
                playerSO.currentRocketAmmo--;
                currentState = TurnState.Processing;
            }
            else
            {
                return;
            }
        }
        public void TakeMachineGunDamage(float Power)
        {
            playerSO.currentHP = playerSO.currentHP - Power;
        }
        public void TakeLaserDamage(float Power)
        {
            playerSO.currentHP = playerSO.currentHP - Power;
        }
        public void TakeRocketDamage(float power)
        {
            playerSO.currentHP = playerSO.currentHP - power;
        }

    }
}