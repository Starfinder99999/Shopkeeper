using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI.Worldspace
{
    public class SpeechPanel : MonoBehaviour
    {
        [SerializeField] public NPCPanel npcPanel;
        [SerializeField] public UnityEngine.UI.Text text;
        [SerializeField] public string[] monologue; //pairs of text and action


        private bool initialized = false;
        private int step = 0;

        private void Awake()
        {
            this.gameObject.SetActive(false);
        }

        private void OnEnable()
        {
            if (!initialized)
            {
                initialized = true;
                NextStep();
            }
        }

        void DisplayText(string text)
        {
            this.text.text = text;
        }

        void Choice(string options)
        {
            npcPanel.choicePanel.SetActive(true);
            npcPanel.choicePanel.GetComponent<ChoicesPanel>().ShowChoice(0);
            this.gameObject.SetActive(false);

        }

        public void Reset()
        {
            this.initialized = false;
            this.step = 0;
        }

        public void NextStep()
        {
            switch (monologue[(step * 2)])
            {
                case "text":
                    DisplayText(monologue[(step * 2) + 1]);
                    break;

                case "choice":
                    Choice(monologue[(step * 2) + 1]);
                    break;
            }
            step += 1;
        }

        public void ShowStep(int step)
        {

        }

        public void Leave()
        {
            npcPanel.ExitInteraction();
        }
    }
}