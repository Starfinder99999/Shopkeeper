using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
    public class DamageRy : Ability
    {
        public DamageRy(string name) : base(name)
        {

        }

        private void Awake()
        {
            this.requirements.intelligence = 1f;
            this.requirements = new AbilityRequirements();
            this.requirements.masteryRequirements = new Dictionary<WeaponMasteryTypes, float>();
        }

        public override IEnumerator Use()
        {
            Debug.Log("DamageRay");
            currentCooldown = requirements.cooldown;
            RaycastHit2D hit = Physics2D.Raycast(GetComponent<Rigidbody2D>().position, Input.mousePosition, 10000000000, 1);
            if (hit.collider != null)
            {
                Debug.DrawRay(GetComponent<Rigidbody2D>().position, hit.point, new Color(0f, 200f, 0f), 30, false);
                Debug.Log(hit.rigidbody.gameObject);
            }
            else Debug.DrawRay(GetComponent<Rigidbody2D>().position, Input.mousePosition * 10, new Color(0f, 200f, 0f), 30, false);
            yield return new WaitForEndOfFrame();
        }

    }
}