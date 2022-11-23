using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public class BattleSpawner : MonoBehaviour
    {
        [SerializeField] ShipBattleStateMachine shipbattle;
        [Space]
        [SerializeField] CharacterStat thePlayer;
        [SerializeField] List<EnemyShipStateMachine> enemies = new List<EnemyShipStateMachine>();

        [SerializeField] List<Transform> enemySpawnLocations = new List<Transform>();



            
        
    }
}