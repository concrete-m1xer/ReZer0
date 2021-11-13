using UnityEngine;

namespace Gameplay.Hunters
{
    public class InstantAttacker : Attacker
    {
        protected override void Attack()
        {
            print("InstantAttacker - Attack!");
        }
    }
}