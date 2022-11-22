using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "New Buff", menuName = "ShopBuff")]
    public class Buff : ScriptableObject
    {
        public int buff;
        public int shopPurchaseAmount;
        public int goldCost;

        public virtual void AddUpgrade(CharacterStat character)
        {
            Debug.Log("Made it to generic spot");
        }
    }


}
