using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "MaxFuelUpgrade", menuName = "MaxFuelUpgrade")]
    public class MaxFuelUpgrade : Buff
    {
        // Start is called before the first frame update
        public override void AddUpgrade(CharacterStat ship)
        {
            ship.maxFuel += buff;
            ship.currentFuel = ship.maxFuel;
            shopPurchaseAmount++;
        }
    }
}
