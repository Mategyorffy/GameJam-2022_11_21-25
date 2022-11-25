using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameJam
{
    public class EnemyShipStateMachine : MonoBehaviour
    {
        public CharacterStat enemySO;

        public enum TurnState
        {
            Processing,
            Waiting,
            Action,
            Dead
        }


        public TurnState currentState;

        [SerializeField] private Slider hpSlider;
        [SerializeField] private TMP_Text hpText;
        [SerializeField] private Canvas healthCanvas;
        [SerializeField] internal float currentCooldown = 0f;
        private float maxCooldown = 100f;
       [SerializeField] PlayerShipStateMachine player;

        [SerializeField] ShipBattleStateMachine shipbattle;

        

        [SerializeField] GameObject RocketObj;
        [SerializeField] GameObject LaserObj;
        [SerializeField] GameObject MachineGunObj;
        private GameObject currentAttackObj;

        private bool ProjectileInbound;
        private bool _isDead = false;


        private void Start()
        {
            
            healthCanvas.worldCamera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Camera>();
            shipbattle = GameObject.Find("BattleManager").GetComponent<ShipBattleStateMachine>();
            hpText.text = $"{enemySO.currentHP} HP";


        }
        

        private void Update()
        {
            switch (currentState)
            {
                case TurnState.Processing:
                    UpgradeTimerBar();
                    break;
                case TurnState.Action:

                    AttackPlayer();
                    break;
                case TurnState.Waiting:
                    currentCooldown = 0f;
                    currentState = TurnState.Processing;
                    break;
                case TurnState.Dead:
                    if (_isDead)
                    {
                        return;
                    }
                    else
                    {
                        //Change tag
                        ProjectileInbound = false;
                        //Make the object not able to be hit
                        shipbattle.EnemiesInGame.Remove(this.gameObject);
                        Destroy(this.gameObject);
                    }
                    break;

            }

            if (ProjectileInbound)
            {
                if(currentAttackObj != null)
                {
                   

                    currentAttackObj.transform.position = Vector3.MoveTowards(currentAttackObj.transform.position, player.transform.position, 10f * Time.deltaTime);

                    if(currentAttackObj.transform.position == player.transform.position)
                    {
                        Destroy(currentAttackObj);
                        ProjectileInbound = false; 
                    }

                }
            }
            else if (!ProjectileInbound)
            {
                Destroy(currentAttackObj);  
            }
        }
        public void EnemyHPChange(float health)
        {
            

            if (enemySO.currentHP < 0)
            {
                currentState = TurnState.Dead;
                enemySO.currentHP = 0;
            }
            else if (enemySO.currentHP > enemySO.maxHP)
            {
                enemySO.currentHP = enemySO.maxHP;
            }
            hpSlider.value = (health / enemySO.maxHP) * 100;
            hpText.text = $"{enemySO.currentHP} HP";

        }
        void UpgradeTimerBar()
        {

            currentCooldown += (enemySO.crewSpeed * Time.deltaTime);
          


            if (currentCooldown >= maxCooldown)
            {

                currentState = TurnState.Action;
            }
        }

        public void AttackPlayer()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShipStateMachine>();
            int randomAttack = Random.Range(0, 10);
            Debug.Log($"{this.gameObject.name} IS ATTACKING -  {randomAttack.ToString()} ATTACK NUm; ");
            switch (randomAttack)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    MachineGunAttack();
                    break;
                case 6:
                case 7:
                case 8:
                    LaserAttack();
                    break;
                case 9:
                case 10:
                    RocketAttack();
                    break;
            }
        }




        public void MachineGunAttack()
        {

            currentAttackObj = GameObject.Instantiate(MachineGunObj, transform.position, transform.rotation);
            ProjectileInbound = true;
            player.TakeMachineGunDamage(enemySO.machinegunfirepower);
            Debug.Log($"{currentAttackObj.name} IS INBOUND FOR PLAYER");
            currentState = TurnState.Waiting;

        }
        public void LaserAttack()
        {

            currentAttackObj = GameObject.Instantiate(LaserObj, transform.position, transform.rotation);
            ProjectileInbound = true;
            player.TakeLaserDamage(enemySO.laserfirepower);
            Debug.Log($"{currentAttackObj.name} IS INBOUND FOR PLAYER");
            currentState = TurnState.Waiting;
        }
        public void RocketAttack()
        {

            currentAttackObj = GameObject.Instantiate(RocketObj, transform.position, transform.rotation);
            ProjectileInbound = true;
            player.TakeRocketDamage(enemySO.rocketfirepower);
            Debug.Log($"{currentAttackObj.name} IS INBOUND FOR PLAYER");
            currentState = TurnState.Waiting;
        }

       public void TakeMachineGunDamage(float damage)
        {
            enemySO.currentHP = enemySO.currentHP - damage;
            EnemyHPChange(enemySO.currentHP);
            if (enemySO.currentHP <= 0)
            {
                currentState = TurnState.Dead;
            }
        }
        public void TakeLaserDamage(float damage)
        {
            enemySO.currentHP = enemySO.currentHP - damage;
            EnemyHPChange(enemySO.currentHP);
            if (enemySO.currentHP <= 0)
            {
                currentState = TurnState.Dead;
            }
        }
        public void TakeRocketDamage(float damage)
        {
            enemySO.currentHP = enemySO.currentHP - damage;
            EnemyHPChange(enemySO.currentHP);
            if (enemySO.currentHP <= 0)
            {
                currentState = TurnState.Dead;
            }
        }

    }
}