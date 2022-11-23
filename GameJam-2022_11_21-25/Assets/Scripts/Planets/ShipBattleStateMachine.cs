using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
namespace GameJam
{
    public class ShipBattleStateMachine : MonoBehaviour
    {
        public List<GameObject> EnemiesInGame = new List<GameObject>();

        private List<GameObject> EnemyBtns = new List<GameObject>();
        public GameObject enemyButton;
        public Transform spacer;

        public void EnemyButtons()
        {
            int enemyButtonCount = 0;
            foreach (GameObject enemyBtn in EnemyBtns)
            {
                Destroy(enemyBtn);
            }
            EnemyBtns.Clear();
            foreach (GameObject enemy in EnemiesInGame)
            {
                GameObject newButton = Instantiate(enemyButton) as GameObject;
                ButtonSelect button = newButton.GetComponent<ButtonSelect>();

                EnemyShipStateMachine currentEnemy = enemy.GetComponent<EnemyShipStateMachine>();
                //if buttons font work you may have to tweak
                TextMeshProUGUI buttonText = newButton.transform.Find("Name").gameObject.GetComponent<TextMeshProUGUI>();
                buttonText.text = currentEnemy.enemySO.name;
                newButton.name = "Enemy" + enemyButtonCount;
                button.enemyPrefab = enemy;
                newButton.transform.SetParent(spacer, false);
                EnemyBtns.Add(newButton);
                enemyButtonCount++;
            }
        }

        public void EnemySelectButton(GameObject enemyChoosen)
        {
            
           
        }
    }
}