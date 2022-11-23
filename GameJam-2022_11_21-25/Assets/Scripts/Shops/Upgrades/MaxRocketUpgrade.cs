using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "MaxRocketUpgrade", menuName = "MaxRocketUpgrade")]
    public class MaxRocketUpgrade : Buff
    {
        // Start is called before the first frame update
        public override void AddGenericUpgrade(CharacterStat ship)
        {
            ship.maxRocketAmmo += buff;
            shopPurchaseAmount++;
        }
    }
}
