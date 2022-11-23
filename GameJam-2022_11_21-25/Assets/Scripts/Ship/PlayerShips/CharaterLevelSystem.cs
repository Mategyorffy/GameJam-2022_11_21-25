using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


namespace GameJam
{
    public class CharaterLevelSystem : MonoBehaviour
    {
        [SerializeField] private CharacterStat shipStart;
        [SerializeField] private CharacterStat shipCurrent;

        //The small amount that stats would increase due to level up
        [SerializeField] private int basicLevelUpAmount;

        //Reseting the ship to it's basic model
        public void ResetShip()
        {
            shipCurrent.maxHP = shipStart.maxHP;
            shipCurrent.currentHP = shipCurrent.maxHP;
            shipCurrent.maxFuel = shipStart.maxFuel;
            shipCurrent.currentFuel = shipCurrent.maxFuel;
            shipCurrent.maxRocketAmmo = shipStart.maxRocketAmmo;
            shipCurrent.currentRocketAmmo = shipStart.maxRocketAmmo;
            shipCurrent.maxLaserAmmo = shipStart.maxLaserAmmo;
            shipCurrent.currentLaserAmmo = shipStart.maxLaserAmmo;
            shipCurrent.crewSpeed = shipStart.crewSpeed;
            shipCurrent.machinegunfirepower = shipStart.machinegunfirepower;
            shipCurrent.laserfirepower = shipStart.laserfirepower;
            shipCurrent.rocketfirepower = shipStart.rocketfirepower;
            shipCurrent.energyPower = shipStart.energyPower;
            shipCurrent.hullStrength = shipStart.hullStrength;
            shipCurrent.barrierStrength = shipStart.barrierStrength;
            shipCurrent.deadShip = false;
            Debug.Log("Reset complete!");
        }

        //Leveling the ship's stats due to a level up
        public void LevelUpShip()
        {
            Debug.Log("Begin leveling process on the ship");
            shipCurrent.maxHP += basicLevelUpAmount;
            shipCurrent.crewSpeed += basicLevelUpAmount;
            shipCurrent.machinegunfirepower += basicLevelUpAmount;
            shipCurrent.laserfirepower += basicLevelUpAmount;
            shipCurrent.rocketfirepower += basicLevelUpAmount;
            shipCurrent.energyPower += basicLevelUpAmount;
            shipCurrent.hullStrength += basicLevelUpAmount;
            shipCurrent.barrierStrength += basicLevelUpAmount;
            shipCurrent.deadShip = false;
            Debug.Log("Reset complete!");

        }
    }
}