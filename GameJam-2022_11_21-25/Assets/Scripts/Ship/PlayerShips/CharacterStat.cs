using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "New Player", menuName = "Player")]
    public class CharacterStat : ScriptableObject
    {
        
        public string name;
        public event Action<float> OnPlayerHealthChange;
        public event Action<int> OnRocketChange;
        public event Action<int> OnLaserChange;
        public event Action<float> OnFuelChange;
        public event Action<int> OnMoneyChange;


        //Max health and current health sets and invokes an event for any stat HUDS that needed to be updated do to it's change
        public float maxHP;
        [SerializeField] private float _currentHP;
        public float currentHP
        {
            get => _currentHP;
            set
            {
                _currentHP = value;
                OnPlayerHealthChange?.Invoke(value);

            }
        }

        //Max fuel and current amount of fuel the Ship has and invokes an event for any stat HUDS that needed to be updated do to it's change
        public float maxFuel;
        [SerializeField] private float _currentFuel;
        public float currentFuel
        {
            get => _currentFuel;
            set
            {
                _currentFuel = value;
                OnFuelChange?.Invoke(value);

            }
        }

        //Max rocket and current amount of Rocket Ammo the Ship has and invokes an event for any stat HUDS that needed to be updated do to it's change
        public int maxRocketAmmo;
        [SerializeField] private int _currentRocketAmmo;
        public int currentRocketAmmo
        {
            get => _currentRocketAmmo;
            set
            {
                _currentRocketAmmo = value;
                OnRocketChange?.Invoke(value);

            }
        }

        //Max laser and current amount of Laser Ammo the Ship has and invokes an event for any stat HUDS that needed to be updated do to it's change
        public int maxLaserAmmo;
        [SerializeField] private int _currentLaserAmmo;
        public int currentLaserAmmo
        {
            get => _currentLaserAmmo;
            set
            {
                _currentLaserAmmo = value;
                OnLaserChange?.Invoke(value);

            }
        }

        //Max gold and current amount of gold the Ship has and invokes an event for any stat HUDS that needed to be updated do to it's change
        public int maxMoney;
        [SerializeField] private int _currentMoney;
        public int currentMoney
        {
            get => _currentMoney;
            set
            {
                _currentMoney = value;
                OnMoneyChange?.Invoke(value);

            }
        }

        //Speed in combat basic speed for gun loading up. It signify when it's the player's turn
        public float crewSpeed;

        //Base damage for physical attack moves
        public float machinegunfirepower;
        public float rocketfirepower;
        public float laserfirepower;


        //Base damage for magic attack moves
        public float energyPower;

        //Resistance for physical attacks
        public float hullStrength;

        //Resistance for magical attacks
        public float barrierStrength;
        //List of basic attacks and spells
        
        //Dead bool
        public bool deadShip;
        public void CheckHealth()
        {
            if (currentHP <= 0)
            {
                currentHP = 0;
                deadShip = true;
            }
        }
        
    }
}
