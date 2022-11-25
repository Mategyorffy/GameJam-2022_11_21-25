using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GameJam
{


    public class ButtonSelect : MonoBehaviour
    {
        public GameObject enemyPrefab;
        private bool _isSelected;

     


        public void ShowEnemySelection()
        {
            enemyPrefab.transform.Find("TurnIcon").gameObject.SetActive(true);
        }
        public void HideEnemySelection()
        {
            enemyPrefab.transform.Find("TurnIcon").gameObject.SetActive(true);
        }

  
    }
}