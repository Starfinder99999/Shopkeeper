using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
    public class DamageRy : Ability
    {
        private Camera cam;

        public DamageRy(string name) : base(name)
        {

        }



        private void Awake()
        {
            
            this.requirements = new AbilityRequirements();
            this.requirements.intelligence = 99f;
            this.requirements.masteryRequirements = new Dictionary<WeaponMasteryTypes, float>();
            cam = Camera.main;
        }

        public override IEnumerator Use()
        {
            LayerMask mask = LayerMask.GetMask("Default");
            currentCooldown = requirements.cooldown;
            RaycastHit2D hit = Physics2D.Raycast(GetComponent<Rigidbody2D>().position,
                cam.ScreenToWorldPoint(Input.mousePosition) - new Vector3(GetComponent<Rigidbody2D>().position.x, GetComponent<Rigidbody2D>().position.y), 
                6, mask.value);
            if (hit.collider != null)
            {
                Debug.DrawLine(GetComponent<Rigidbody2D>().position,  hit.point, new Color(0f, 200f, 0f), 0.4f, false);
                if (hit.rigidbody.GetComponent<Character>())
                {
                    hit.rigidbody.GetComponent<Character>().TakeDamage(20, "");
                }
            }
            else Debug.DrawRay(GetComponent<Rigidbody2D>().position, cam.ScreenToWorldPoint(Input.mousePosition) - new Vector3(GetComponent<Rigidbody2D>().position.x, GetComponent<Rigidbody2D>().position.y), new Color(0f, 200f, 0f), 0.4f, false);
            yield return new WaitForEndOfFrame();
        }

    }
}