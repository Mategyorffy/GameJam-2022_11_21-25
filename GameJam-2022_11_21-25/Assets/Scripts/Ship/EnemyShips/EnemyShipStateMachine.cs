using System.Collections;
using System.Collections.Generic;
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
        [SerializeField] private Canvas healthCanvas;
        [SerializeField] internal float currentCooldown = 0f;
        private float maxCooldown = 100f;
       [SerializeField] PlayerShipStateMachine player;

        [SerializeField] GameObject RocketObj;
        [SerializeField] GameObject LaserObj;
        [SerializeField] GameObject MachineGunObj;
        private GameObject currentAttackObj;

        private bool ProjectileInbound;

        private void Start()
        {
            healthCanvas.worldCamera = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Camera>();
           
           
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

            currentAttackObj = GameObject.Instantiate(MachineGunObj, transform.position, transform.rotation);
            ProjectileInbound = true;
            player.TakeLaserDamage(enemySO.laserfirepower);
            Debug.Log($"{currentAttackObj.name} IS INBOUND FOR PLAYER");
            currentState = TurnState.Waiting;
        }
        public void RocketAttack()
        {

            currentAttackObj = GameObject.Instantiate(MachineGunObj, transform.position, transform.rotation);
            ProjectileInbound = true;
            player.TakeRocketDamage(enemySO.rocketfirepower);
            Debug.Log($"{currentAttackObj.name} IS INBOUND FOR PLAYER");
            currentState = TurnState.Waiting;
        }

        
    }
}