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
            ButtonsLightUp,
            Waiting,
            Action,
            Dead
        }


        public TurnState currentState;

        [SerializeField] private Slider hpSlider;
        [SerializeField] private Canvas healthCanvas;

        private void Start()
        {
            

            hpSlider.gameObject.transform.position = this.gameObject.transform.position;
        }

    }
}