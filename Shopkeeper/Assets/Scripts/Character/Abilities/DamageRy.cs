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
        }

        public override IEnumerator Use()
        {
            currentCooldown = requirements.cooldown;
            RaycastHit2D hit = Physics2D.Raycast(GetComponent<Rigidbody2D>().position, Input.mousePosition, 10f);
            if (hit.collider != null)
            {
                Debug.DrawRay(GetComponent<Rigidbody2D>().position, hit.point, new Color(50f, 200f, 0f));
            }
            else Debug.DrawRay(GetComponent<Rigidbody2D>().position, Input.mousePosition, new Color(50f, 200f, 0f));
            yield return new WaitForEndOfFrame();
        }

    }
}