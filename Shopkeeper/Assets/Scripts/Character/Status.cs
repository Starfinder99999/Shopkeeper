namespace Character { //TODO finish status class
    public class Status {

        private float strength;
        public float Strength {
            get { return strength; }
            set { strength = value; CalcHealth(); } }

        private float vitality;
        public float Vitality {
            get { return vitality; }
            set { vitality = value; CalcHealth(); CalcEnergy(); }
        }

        private float intelligence;
        public float Intelligence {
            get { return intelligence; }
            set { intelligence = value; CalcMagicAffinity(); } }

        private float wisdom;
        public float Wisdom {
            get { return wisdom; }
            set { wisdom = value; CalcMagicAffinity(); } }

        private float baseMagicAffinity;
        public float BaseMagicAffinity {
            get { return baseMagicAffinity; }
            set { baseMagicAffinity = value; CalcMagicAffinity(); }
        }

        private float baseEnergy;
        public float BaseEnergy {
            get { return baseEnergy; }
            set { baseEnergy = value; CalcEnergy(); } }

        public float Charisma { get; set; }
        public float Agility { get; set; }
        public float Perception { get; set; }
        public float Luck { get; set; }
        public float Endurance { get; set; }
        public float MagicAffinity { get; private set; }
        public int Health { get; private set; }
        public int Energy { get; private set; }
        public float Age { get; set; }

        public Status(float strength = 0f, float charisma = 0f, float perception = 0f, float luck = 0f, float endurance = 0f,
            float vitality = 0f, float agility = 0f, float intelligence = 0f, float wisdom = 0f, float baseMagicAffinity = 0f, 
            float baseEnergy = 0f, float Age = 0f)
        {
            this.Strength = strength;
            this.Charisma = charisma;
            this.Perception = perception;
            this.Luck = luck;
            this.Endurance = endurance;
            this.Vitality = vitality;
            this.Agility = agility;
            this.Intelligence = intelligence;
            this.Wisdom = wisdom;
            this.BaseMagicAffinity = baseMagicAffinity;
            this.BaseEnergy = baseEnergy;

        }

        void CalcHealth()
        {
            this.Health = (int) (100 + strength + vitality);
        }

        void CalcEnergy()
        {
            this.Energy = (int) (this.baseEnergy + this.vitality);
        }

        void CalcMagicAffinity()
        {
            this.MagicAffinity = this.wisdom + this.intelligence + this.baseMagicAffinity;
        }

    }
}