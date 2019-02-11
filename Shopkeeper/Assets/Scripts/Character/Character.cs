﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//test
//Commentary
namespace Character
{
    public class Character : MonoBehaviour
    {

        [SerializeField] string characterName;
        [SerializeField] int level;
        [SerializeField] string description;
        [SerializeField] Sprite sprite;

        [SerializeField] Generic.Inventory inventory;
        public Status status { get; private set; }
        public AbilityManager abilityManager;

        public int hp;

        // Use this for initialization
        public void Awake()
        {
            InitializeStatus();
            this.abilityManager = GetComponent<AbilityManager>();
        }

        private void InitializeStatus()
        {
            this.status = new Status(
                100f, //Strength
                100f, //Charisma
                100f, //Perception
                10f, //Luck
                100f, //Endurance
                100f, //Vitality
                100f, //Agility
                100f, //Intelligence
                100f, //Wisdom
                100f, //BaseMagicAffinity
                100f, //BaseEnergy
                30f); //Age
        }

        public void TakeDamage(int damage, string damageType) //TODO make damagetype enum
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