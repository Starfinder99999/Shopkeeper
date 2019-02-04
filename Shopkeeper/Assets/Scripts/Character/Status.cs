﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character { //TODO finish status class
    public class Status : MonoBehaviour {

        public float Strength {
            get { return Strength; }
            set { CalcHealth(); Strength = value; } }

        public float Charisma { get; private set; }
        public float Perception { get; private set; }
        public float Luck { get; private set; }
        public float Endurance { get; private set; }

        public float Vitality {
            get { return Vitality; }
            set { CalcHealth(); Vitality = value; } }

        public float Agility { get; private set; }
        public float Intelligence { get; private set; }
        public float Wisdom { get; private set; }
        public float MagicAffinity { get; private set; }
        public int Health { get; private set; }
        public int Energy { get; private set; }
        public float Age { get; private set; }

        void CalcHealth()
        {
            this.Health = (int) (100 + Strength + Vitality);
        }

    }
}