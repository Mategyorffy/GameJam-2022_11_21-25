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
        public int shopYesVariable;
        public int goldCost;
        public string shopInfoText;


        public virtual void AddGenericUpgrade(CharacterStat character)
        {
            Debug.Log("Made it to generic spot");
        }
        public virtual void AddMachineGunUpgrade(CharacterStat character)
        {
            Debug.Log("Made it to generic spot");
        }
        public virtual void AddRocketUpgrade(CharacterStat character)
        {
            Debug.Log("Made it to generic spot");
        }
        public virtual void AddLaserUpgrade(CharacterStat character)
        {
            Debug.Log("Made it to generic spot");
        }
    }


}
