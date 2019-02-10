using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public enum AbilityReturnValue
    {
        Success,
        NotEnoughEnergy,
        CooldownInProgress,
        NotEnoughHealth,
        NotEnoughIntelligence,
        NotEnoughWisdom,
        AbilityNotLearnt,
        WeaponMasteryNotMet
    }

    public class AbilityManager : MonoBehaviour
    { 
        [SerializeField] private Generic.CoroutineTracker coroutineTracker;
        [SerializeField] private List<Actions.Ability> learntAbilities = new List<Actions.Ability>();

        private void Awake()
        {
            this.coroutineTracker = this.gameObject.AddComponent<Generic.CoroutineTracker>();
        }


        public AbilityReturnValue UseAbility(Actions.Ability ability)
        {
            if (!learntAbilities.Contains(ability)) return AbilityReturnValue.AbilityNotLearnt;
            int abilityIndex = learntAbilities.IndexOf(ability);
            if (learntAbilities[abilityIndex].currentCooldown > 0) { return AbilityReturnValue.CooldownInProgress; }
            else
            {

                if (this.GetComponent<Player.Player>())
                {
                    Player.Player player = this.GetComponent<Player.Player>();
                    if (player.status.Energy < learntAbilities[abilityIndex].requirements.energy) return AbilityReturnValue.NotEnoughEnergy;
                    else if (player.status.Health < learntAbilities[abilityIndex].requirements.health) return AbilityReturnValue.NotEnoughHealth;
                    else if (player.status.Intelligence < learntAbilities[abilityIndex].requirements.intelligence) return AbilityReturnValue.NotEnoughIntelligence;
                    else if (player.status.Wisdom < learntAbilities[abilityIndex].requirements.wisdom) return AbilityReturnValue.NotEnoughWisdom;
                    else
                    {
                        foreach (WeaponMasteryTypes key in learntAbilities[abilityIndex].requirements.masteryRequirements.Keys)
                        {
                            if (player.weaponMastery.WeaponMasteryLevels[key] < learntAbilities[abilityIndex].requirements.masteryRequirements[key])
                            {
                                return AbilityReturnValue.WeaponMasteryNotMet;
                            }
                        }
                    }
                }

            }
            coroutineTracker.StartTrackedCoroutine(learntAbilities[abilityIndex].Use());
            return AbilityReturnValue.Success;
        }

        public AbilityReturnValue UseAbility(System.Type abilityType)
        {
            Actions.Ability abilityToUse = null;
            foreach (Actions.Ability ability in learntAbilities)
            {
                if (ability.GetType() == abilityType) { abilityToUse = ability; break; }
            }
            if (abilityToUse == null) return AbilityReturnValue.AbilityNotLearnt;
            else
            {

                if (this.GetComponent<Player.Player>())
                {
                    Player.Player player = this.GetComponent<Player.Player>();
                    if (player.status.Energy < abilityToUse.requirements.energy) return AbilityReturnValue.NotEnoughEnergy;
                    else if (player.status.Health < abilityToUse.requirements.health) return AbilityReturnValue.NotEnoughHealth;
                    else if (player.status.Intelligence < abilityToUse.requirements.intelligence) return AbilityReturnValue.NotEnoughIntelligence;
                    else if (player.status.Wisdom < abilityToUse.requirements.wisdom) return AbilityReturnValue.NotEnoughWisdom;
                    else
                    {
                        foreach (WeaponMasteryTypes key in abilityToUse.requirements.masteryRequirements.Keys)
                        {
                            if (player.weaponMastery.WeaponMasteryLevels[key] < abilityToUse.requirements.masteryRequirements[key])
                            {
                                return AbilityReturnValue.WeaponMasteryNotMet;
                            }
                        }
                    }
                }

            }
            coroutineTracker.StartTrackedCoroutine(abilityToUse.Use());
            return AbilityReturnValue.Success;
        }
    }
}