using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "EnergyPowerUpgrade", menuName = "EnergyPowerUpgrade")]
    public class EnergyPowerUpgrade : Buff
    {
        // Start is called before the first frame update
        public override void AddUpgrade(CharacterStat ship)
        {
            ship.energyPower += buff;
            shopPurchaseAmount++;
        }
    }
}
