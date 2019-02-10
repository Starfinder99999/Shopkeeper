using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character.Actions
{
    public struct AbilityRequirements
    {
        [SerializeField] public float intelligence;
        [SerializeField] public float wisdom;
        [SerializeField] public float energy;
        [SerializeField] public float health;
        [SerializeField] public float cooldown;
        [SerializeField] public Dictionary<WeaponMasteryTypes, float> masteryRequirements;
    }


    public class Ability : MonoBehaviour
    {
        public float currentCooldown { get; set; }
        public string Name { get; set; }

        [SerializeField] public AbilityRequirements requirements;


        private void Update()
        {
            if (currentCooldown > 0) currentCooldown -= Time.deltaTime;
        }

        public Ability(string name)
        {
            this.Name = name;
        }

        virtual public IEnumerator Use()
        {
            currentCooldown = requirements.cooldown;
            yield return new WaitForEndOfFrame();
        }
    }
}