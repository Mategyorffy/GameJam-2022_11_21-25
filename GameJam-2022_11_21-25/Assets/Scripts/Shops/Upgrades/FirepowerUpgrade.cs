using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameJam
{
    [CreateAssetMenu(fileName = "FirepowerUpgrades", menuName = "FirepowerUpgrade")]
    public class FirepowerUpgrade : Buff
    {
        // Start is called before the first frame update
        public override void AddMachineGunUpgrade(CharacterStat ship)
        {
            ship.machinegunfirepower += buff;
            shopPurchaseAmount++;
        }
        public override void AddLaserUpgrade(CharacterStat ship)
        {
            ship.laserfirepower += buff;
            shopPurchaseAmount++;
        }
        public override void AddRocketUpgrade(CharacterStat ship)
        {
            ship.laserfirepower += buff;
            shopPurchaseAmount++;
        }
    }
}
