using UnityEngine;

namespace Gameplay.Hunters
{
    [CreateAssetMenu(fileName = "new Hunter", menuName = "Hunter", order = 51)]
    public class HunterStats : ScriptableObject
    {
        public string Name = "Bogdan";
        public int Health = 1000;
        public int Damage = 300;
        public float MovementSpeed = 8;
        public float AttackCooldown = 0.5f;
        public float ReloadTime = 5f;
        public int AttackCount = 5;
    }
}