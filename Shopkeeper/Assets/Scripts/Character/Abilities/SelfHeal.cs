using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
    public class SelfHeal : Ability
    {

        public SelfHeal(string name) : base(name)
        {

        }

        private void Awake()
        {
            this.requirements = new AbilityRequirements();
            this.requirements.intelligence = 99f;
            this.requirements.cooldown = 0.5f;
            this.requirements.energy = 10;
            this.requirements.masteryRequirements = new Dictionary<WeaponMasteryTypes, float>();
        }

        public override IEnumerator Use()
        {
            currentCooldown = requirements.cooldown;
            this.GetComponent<Player.Player>().energy -= 10;
            if (this.GetComponent<Player.Player>().hp + 20 <= this.GetComponent<Player.Player>().status.Health) this.GetComponent<Player.Player>().hp += 20;
            else this.GetComponent<Player.Player>().hp = this.GetComponent<Player.Player>().status.Health;
            yield return new WaitForEndOfFrame();
        }
    }
}