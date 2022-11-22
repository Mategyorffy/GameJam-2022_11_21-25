using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "CrewSpeed", menuName = "CrewSpeed")]
    public class CrewSpeed : Buff
    {
        // Start is called before the first frame update
        public override void AddUpgrade(CharacterStat ship)
        {
            ship.crewSpeed += buff;
            shopPurchaseAmount++;
        }
    }
}
