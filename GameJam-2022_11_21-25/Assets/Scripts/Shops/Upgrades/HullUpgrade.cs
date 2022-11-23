using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "HullUpgrade", menuName = "HullUpgrade")]
    public class HullUpgrade : Buff
    {
        // Start is called before the first frame update
        public override void AddGenericUpgrade(CharacterStat ship)
        {
            ship.hullStrength += buff;
            shopPurchaseAmount++;
        }
    }
}
