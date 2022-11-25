using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameJam
{
    public class ShipBattleStateMachine : MonoBehaviour
    {
        public List<GameObject> EnemiesInGame = new List<GameObject>();



        [SerializeField] private PlayerShipStateMachine player;

        [SerializeField] private GameObject Button1;
        [SerializeField] private GameObject Button2;
        [SerializeField] private GameObject Button3;
        [SerializeField] private GameObject Button4;

        public static bool combat;
        [SerializeField] private AudioSource MainAudio;

        [SerializeField] private CharaterLevelSystem characterLevelUp;


        private void Start()
        {
            MainAudio.Play();
            combat = true;
        }


        public enum PlayerUI
        {
            Activate,
            Done
        }
        public PlayerUI playerUI;

        private void Update()
        {
            switch (playerUI)
            {
                case PlayerUI.Activate:
                    
                    break;
                case PlayerUI.Done:
                    
                    break;
            }

            if(EnemiesInGame.Count < 1)
            {
                BattleWon();
                combat= false;
                planet.wasCalledOnce = false;
            }
            if(player.playerSO.currentHP <= 0)
            {
                BattleLost();
                combat= false;  
            }
        }

        public void DisableEnemyButtons()
        {


            Button1.SetActive(false);
            Button2.SetActive(false);
            Button3.SetActive(false);
            Button4.SetActive(false);
        }







        public void BattleWon()
        {
            StartCoroutine(LevelUpSeQuence());
          
        }

        public void BattleLost()
        {
            SceneManager.LoadScene(0);
        }







        public void EnableEnemyButtons()
        {

            for (int i = 0; i < EnemiesInGame.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        Button1.SetActive(true);
                        break;
                    case 1:
                        Button2.SetActive(true);
                        break;
                    case 2:
                        Button3.SetActive(true);
                        break;
                    case 3:
                        Button4.SetActive(true);
                        break;
                }

            }



        }

        public IEnumerator LevelUpSeQuence() 
        {
            characterLevelUp.LevelUpShip();
            yield return new WaitForSeconds(3);
            SceneManager.UnloadSceneAsync("BattleScene", UnloadSceneOptions.None);
        }
    }
}