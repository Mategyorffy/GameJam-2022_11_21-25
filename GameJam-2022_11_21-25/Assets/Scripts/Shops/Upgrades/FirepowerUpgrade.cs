using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "FirepowerUpgrade", menuName = "FirepowerUpgrade")]
    public class FirepowerUpgrade : Buff
    {
        // Start is called before the first frame update
        public override void AddUpgrade(CharacterStat ship)
        {
            ship.firepower += buff;
            shopPurchaseAmount++;
        }
    }
}
