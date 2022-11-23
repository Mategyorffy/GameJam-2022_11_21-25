using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "BarrierUpgrade", menuName = "BarrierUpgrade")]
    public class BarrierUpgrade : Buff
    {
        // Start is called before the first frame update
        public override void AddGenericUpgrade(CharacterStat ship)
        {
            ship.barrierStrength += buff;
            shopPurchaseAmount++;
        }
    }
}