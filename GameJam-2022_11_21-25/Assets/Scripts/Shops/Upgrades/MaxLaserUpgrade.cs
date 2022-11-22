using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "MaxLaserUpgrade", menuName = "MaxLaserUpgrade")]
    public class MaxLaserUpgrade : Buff
    {
        // Start is called before the first frame update
        public override void AddUpgrade(CharacterStat ship)
        {
            ship.maxLaserAmmo += buff;
            shopPurchaseAmount++;
        }
    }
}
