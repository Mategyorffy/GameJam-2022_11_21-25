using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    public class BattleSpawner : MonoBehaviour
    {
        [SerializeField] ShipBattleStateMachine shipbattle;
        [Space]
        [SerializeField] GameObject playerToSpawn;
        [SerializeField] List<GameObject> enemies = new List<GameObject>();
        [SerializeField] List<Transform> enemySpawnLocations = new List<Transform>();
        [SerializeField] Transform playerSpawnlocation;
       

        private  void Start()
        {
            

            GameObject.Instantiate(playerToSpawn, playerSpawnlocation);


            foreach (Transform loc in enemySpawnLocations)
            {


                GameObject.Instantiate(enemies[0], loc.position, loc.rotation);
            }

        }



    }
}