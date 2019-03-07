using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.Actions
{
    public class DamageRy : Ability
    {
        private Camera cam;
        private ContactFilter2D filter;
        public RaycastHit2D[] hits;

        public DamageRy(string name) : base(name)
        {

        }



        private void Awake()
        {
            
            this.requirements = new AbilityRequirements();
            this.requirements.intelligence = 99f;
            this.requirements.cooldown = 0.5f;
            this.requirements.masteryRequirements = new Dictionary<WeaponMasteryTypes, float>();
            cam = Camera.main;
            LayerMask mask = LayerMask.GetMask("Default");
            filter = new ContactFilter2D();
            filter.useTriggers = false;
            filter.useLayerMask = true;
            filter.layerMask = mask;
        }

        public override IEnumerator Use()
        {

            hits = new RaycastHit2D[10];
            currentCooldown = requirements.cooldown;
            
            Physics2D.Raycast(GetComponent<Rigidbody2D>().position,
                cam.ScreenToWorldPoint(Input.mousePosition) - new Vector3(GetComponent<Rigidbody2D>().position.x, GetComponent<Rigidbody2D>().position.y), filter, hits, 5);
            if (hits[0])
            {
                if (hits[0].collider != null)
                {
                    Debug.DrawLine(GetComponent<Rigidbody2D>().position, hits[0].point, new Color(0f, 200f, 0f), 0.4f, false);
                    if (hits[0].rigidbody.GetComponent<Character>())
                    {
                        hits[0].rigidbody.GetComponent<Character>().TakeDamage(20, "");
                    }
                }
            }
            else Debug.DrawRay(GetComponent<Rigidbody2D>().position, cam.ScreenToWorldPoint(Input.mousePosition) - new Vector3(GetComponent<Rigidbody2D>().position.x, GetComponent<Rigidbody2D>().position.y), new Color(0f, 200f, 0f), 0.4f, false);
            yield return new WaitForEndOfFrame();
        }

    }
}