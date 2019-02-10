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

        public float Wisdom {
            get { return Wisdom; }
            set { Wisdom = value; CalcMagicAffinity(); } }

        public float BaseMagicAffinity {
            get { return BaseMagicAffinity; }
            set { BaseMagicAffinity = value; CalcMagicAffinity(); }
        }

        public float BaseEnergy {
            get { return BaseEnergy; }
            set { BaseEnergy = value; CalcEnergy(); } }

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
            this.Health = (int) (100 + Strength + Vitality);
        }

        void CalcEnergy()
        {
            this.Energy = (int) (this.BaseEnergy + this.Vitality);
        }

        void CalcMagicAffinity()
        {
            this.MagicAffinity = this.Wisdom + this.Intelligence + this.BaseMagicAffinity;
        }

    }
}