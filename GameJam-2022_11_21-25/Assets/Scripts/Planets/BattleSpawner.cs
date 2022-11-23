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

        private int numberOfEnemies;
        private int whatEnemy;
        private int enemyCount;
        private GameObject newEnemy;
        private  void Start()
        {
            

            GameObject.Instantiate(playerToSpawn, playerSpawnlocation);




            numberOfEnemies = Random.Range(1, enemies.Count);
            for (int i = 1; i <= numberOfEnemies; i++)
            {
                PickEnemyFromList();
                switch (i)
                {
                    case 1:
                        Debug.Log("Made it to one");
                        shipbattle.EnemiesInGame.Add(newEnemy);
                        break;



                    case 2:
                        Debug.Log("Made it to two");
                        shipbattle.EnemiesInGame.Add(newEnemy);
                        break;

                    case 3:
                        Debug.Log("Made it to three");
                        shipbattle.EnemiesInGame.Add(newEnemy);
                        break;

                    case 4:
                        Debug.Log("Made it to four");
                        shipbattle.EnemiesInGame.Add(newEnemy); 
                        break;
                }
                enemyCount++;
            }
            shipbattle.EnemyButtons();

            foreach (Transform loc in enemySpawnLocations)
            {


               
            }

        }

        void PickEnemyFromList()
        {
            whatEnemy = Random.Range(0, enemies.Count);

            newEnemy = Instantiate(enemies[whatEnemy], enemySpawnLocations[enemyCount].position, enemySpawnLocations[enemyCount].rotation);
            //Debug.Log($"{newEnemy.name} Spawned at location {EnemySpawnLocations[enemyCount]}");
            newEnemy.gameObject.name = enemies[whatEnemy].name + enemyCount;

        }

    }
}