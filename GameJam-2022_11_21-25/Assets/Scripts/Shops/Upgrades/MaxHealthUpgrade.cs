using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "MaxHealthUpgrade", menuName = "MaxHealthUpgrade")]
    public class MaxHealthUpgrade : Buff
    {
        // Start is called before the first frame update
        public override void AddGenericUpgrade(CharacterStat ship)
        {
            ship.maxHP += buff;
            ship.currentHP = ship.maxHP;
            shopPurchaseAmount++;
        }
    }
}
