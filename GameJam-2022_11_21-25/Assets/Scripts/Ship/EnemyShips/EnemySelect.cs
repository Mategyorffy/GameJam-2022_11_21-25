using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public class EnemySelect : MonoBehaviour
    {
        [SerializeField] private PlayerShipStateMachine playerTarget;
        [SerializeField] private ShipBattleStateMachine shipbattle;
        
        public void EnemyButtonAssignToEnemy()
        {
            if(this.gameObject.name == "Enemy1")
            {
                playerTarget.enemyToAttack = shipbattle.EnemiesInGame[0].GetComponent<EnemyShipStateMachine>();
               
                shipbattle.DisableEnemyButtons();
                playerTarget.ReactivateAttackButtons();
                playerTarget.PlayerProjectileInbound = true;

            }
            if (this.gameObject.name == "Enemy2")
            {
                playerTarget.enemyToAttack = shipbattle.EnemiesInGame[1].GetComponent<EnemyShipStateMachine>();
               
                shipbattle.DisableEnemyButtons();
                playerTarget.ReactivateAttackButtons();
                playerTarget.PlayerProjectileInbound = true;
            }
            if (this.gameObject.name == "Enemy3")
            {
                playerTarget.enemyToAttack = shipbattle.EnemiesInGame[2].GetComponent<EnemyShipStateMachine>();
              
                shipbattle.DisableEnemyButtons();
                playerTarget.ReactivateAttackButtons();
                playerTarget.PlayerProjectileInbound = true;
            }
            if (this.gameObject.name == "Enemy4")
            {
                playerTarget.enemyToAttack = shipbattle.EnemiesInGame[3].GetComponent<EnemyShipStateMachine>();
               
                shipbattle.DisableEnemyButtons();
                playerTarget.ReactivateAttackButtons();
                playerTarget.PlayerProjectileInbound = true;
            }
        }
    }
}