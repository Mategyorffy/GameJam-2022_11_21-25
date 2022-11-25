using GameJam;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GameJam
{
    public class HUD : MonoBehaviour
    {
        [SerializeField] private CharacterStat shipStats;
        [SerializeField] private TextMeshProUGUI health;
        [SerializeField] private TextMeshProUGUI fuel;
        [SerializeField] private TextMeshProUGUI gold;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            health.text = "Health: " + shipStats.currentHP;
            fuel.text = "Fuel: " + shipStats.currentFuel;
            gold.text = "Gold: " + shipStats.currentMoney;
        }
    }
}