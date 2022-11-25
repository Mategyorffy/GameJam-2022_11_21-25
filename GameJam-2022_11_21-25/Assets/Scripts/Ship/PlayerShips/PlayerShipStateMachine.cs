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


      [SerializeField]  public bool PlayerProjectileInbound;

        [SerializeField] GameObject RocketObj;
        [SerializeField] GameObject LaserObj;
        [SerializeField] GameObject MachineGunObj;
        private GameObject currentAttackObj;
        [SerializeField] private Transform AttackPoint;
        [Space]
        
        [Space]
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
        [SerializeField] private GameObject machineGunButton;
        [SerializeField] private GameObject laserButton;
        [SerializeField] private GameObject RocketButton;
        public bool buttonPressable = false;

        [SerializeField] Animator _cameraAnimatior;

        public EnemyShipStateMachine enemyToAttack;
        int currentPower;
        [Space]
        [SerializeField] private AudioSource NotifySoundSource;
        [SerializeField] private AudioSource MainAudioSource;
        [SerializeField] private AudioSource ExplosionAudioSource;
        [SerializeField] private AudioClip energyDown;
        [SerializeField] private AudioClip energyUp;
        [SerializeField] private AudioClip HpLow;
        [SerializeField] private AudioClip Explosion1;
        [SerializeField] private AudioClip Explosion2;
        [Space]
        [SerializeField] private List<Light> HudLights = new List<Light>();
        


        private void Start()
        {
            hpSlider.value = playerSO.currentHP;
            shipBattle = GameObject.Find("BattleManager").GetComponent<ShipBattleStateMachine>();
            NotifySoundSource.clip = energyDown;
            NotifySoundSource.Play();
            playerSO.OnPlayerHealthChange += PlayerHPChange;
            playerSO.OnLaserChange += UpdateLaserAmmoAmount;
            playerSO.OnRocketChange += UpdateRocketAmmoAmount;
            rocketAmmoCount.text = playerSO.currentRocketAmmo.ToString();
            laserAmmoCount.text = playerSO.currentLaserAmmo.ToString();
            reloadText.text = "Reloading..";
            machineGunButtonImage.color = Color.gray;
            rocketButtonImage.color = Color.gray;
            laserButtonImage.color = Color.gray;
            if(playerSO.currentHP <= 50)
            {
                foreach(Light lights in HudLights)
                {
                    lights.color = Color.red;
                }
                
            }
            if(playerSO.currentHP >= 51)
            {
                foreach (Light lights in HudLights)
                {
                    lights.color = Color.green;
                }
            }
                    

        }


        public void PlayerHPChange(float health)
        {
            if (playerSO.currentHP < 0)
            {
                playerSO.currentHP = 0;
            }
            if(playerSO.currentHP <= 50)
            {
                PlayLowHpSound();
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
                    
                    break;
                case TurnState.Waiting:
                    
                    break;
                case TurnState.Action:
                   
                    break;
            }
            if (PlayerProjectileInbound)
            {
                currentState = TurnState.Processing;
                if (currentAttackObj != null)
                {
                    currentAttackObj.transform.position = Vector3.MoveTowards(currentAttackObj.transform.position, enemyToAttack.transform.position, 20f * Time.deltaTime);
                    currentAttackObj.transform.LookAt(enemyToAttack.transform);
                    Debug.Log("Good 1");
                    if(currentAttackObj.transform.position == enemyToAttack.transform.position)
                    {
                        Debug.Log("Good 2");
                        if (currentPower == 1)
                        {
                            enemyToAttack.TakeMachineGunDamage(playerSO.machinegunfirepower);
                            Destroy(currentAttackObj);
                            PlayerProjectileInbound = false;

                        }
                        if (currentPower == 2)
                        {
                            enemyToAttack.TakeLaserDamage(playerSO.laserfirepower);
                            Destroy(currentAttackObj);
                            PlayerProjectileInbound = false;


                        }
                        if (currentPower == 3)
                        {
                            enemyToAttack.TakeRocketDamage(playerSO.rocketfirepower);
                            Destroy(currentAttackObj);
                            PlayerProjectileInbound = false;


                        }
                       
                    }
                }
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
                NotifySoundSource.clip = energyUp;
                NotifySoundSource.Play();
                currentState = TurnState.ButtonsLightUp;
            }
        }
        public void PlayLowHpSound()
        {
            MainAudioSource.clip = HpLow;
            MainAudioSource.Play();
            foreach (Light lights in HudLights)
            {
                lights.color = Color.red;
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
            currentState = TurnState.Waiting;

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
        public void ReactivateAttackButtons()
        {
           
            machineGunButton.SetActive(true);
            laserButton.SetActive(true);
            RocketButton.SetActive(true);
        }

    

        public void FireMachineGun()
        {
            
            if (buttonPressable)
            {
                Debug.Log("FIRING MACHINE GUN");
                currentCooldown = 0;
                timerBar.value = currentCooldown;
                machineGunButton.SetActive(false);
                laserButton.SetActive(false);
                RocketButton.SetActive(false);
                shipBattle.EnableEnemyButtons();
                currentPower = 1;
                buttonPressable = false;
                machineGunButtonImage.color = Color.gray;
                rocketButtonImage.color = Color.gray;
                laserButtonImage.color = Color.gray;
                reloadText.text = "Reloading..";
                currentAttackObj = GameObject.Instantiate(MachineGunObj, AttackPoint.transform);
                


            }
            else
            {
                return;
            }
        }
        public void FireLaser()
        {
            if (playerSO.currentLaserAmmo > 0)
            {
                if (buttonPressable)
                {
                    Debug.Log("FIRING LASER");
                    currentCooldown = 0;
                    timerBar.value = currentCooldown;
                    machineGunButton.SetActive(false);
                    laserButton.SetActive(false);
                    RocketButton.SetActive(false);
                    shipBattle.EnableEnemyButtons();
                    currentPower = 2;
                    buttonPressable = false;
                    machineGunButtonImage.color = Color.gray;
                    rocketButtonImage.color = Color.gray;
                    laserButtonImage.color = Color.gray;
                    reloadText.text = "Reloading..";
                    playerSO.currentLaserAmmo--;
                    if(playerSO.currentLaserAmmo < 0)
                    {
                        playerSO.currentLaserAmmo = 0;
                    }
                    currentAttackObj = GameObject.Instantiate(LaserObj, AttackPoint.transform);
                   

                }
                else
                {
                    return;
                }
            }

        }
        public void CameraShakeEffect()
        {
            _cameraAnimatior.SetTrigger("TiggerCameraShake");
            int randomInt = Random.Range(0, 1);

            switch (randomInt)
            {
                case 0:
                    ExplosionAudioSource.clip = Explosion1;
                    ExplosionAudioSource.Play();
                    break;
                case 1:
                    ExplosionAudioSource.clip = Explosion2;
                    ExplosionAudioSource.Play();
                    break;
                
            }

        }
        public void FireRockets()
        {
            if (playerSO.currentRocketAmmo > 0)
            {

                if (buttonPressable)
                {
                    Debug.Log("FIRING ROCKETS");
                    currentCooldown = 0;
                    timerBar.value = currentCooldown;
                    machineGunButton.SetActive(false);
                    laserButton.SetActive(false);
                    RocketButton.SetActive(false);
                    shipBattle.EnableEnemyButtons();
                    currentPower = 3;
                    buttonPressable = false;
                    machineGunButtonImage.color = Color.gray;
                    rocketButtonImage.color = Color.gray;
                    laserButtonImage.color = Color.gray;
                    reloadText.text = "Reloading..";
                    playerSO.currentRocketAmmo--;
                    if (playerSO.currentRocketAmmo < 0)
                    {
                        playerSO.currentRocketAmmo = 0;
                    }
                    currentAttackObj = GameObject.Instantiate(RocketObj, AttackPoint.transform);
                    
                   
                }
                else
                {
                    return;

                }

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