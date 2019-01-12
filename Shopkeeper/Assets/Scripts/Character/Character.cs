using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public class Character : MonoBehaviour
    {

        [SerializeField] string name;
        [SerializeField] int level;
        [SerializeField] string description;
        [SerializeField] Sprite sprite;

        [SerializeField] int[] inventory; //TODO make inventory obj
        [SerializeField] int[] stats; //TODO make stat obj

        public int hp;

        // Use this for initialization
        void Start()
        {

        }

        void TakeDamage(int damage, string damageType) //TODO make damagetype enum
        {
            this.hp -= damage;
            if (hp <= 0)
            {
                this.Die();
            }
        }

        void Die()
        {
            Debug.Log(this.gameObject + " died!");
            Destroy(this.gameObject);
        }
    }
}