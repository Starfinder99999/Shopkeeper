using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUI.Worldspace
{
    public class ChoicesPanel : MonoBehaviour
    {
        [SerializeField] public GameObject choiceButton;
        [SerializeField] public GameObject choiceText;
        [SerializeField] public GameObject choiceButtonPanel;
        [SerializeField] public NPCPanel npcPanel;
        [SerializeField] public Choice[] choices; //pairs of: text, number of buttons, buttonFunc, buttontext

        private void Awake()
        {
            this.gameObject.SetActive(false);
        }
        

        public void ShowChoice(int choice)
        {
            int i = 0;
            GameObject button;
            foreach (string buttonName in choices[choice].buttonTexts)
            {
                button = Instantiate(choiceButton, choiceButtonPanel.transform);
                switch (choices[choice].buttonActions[i])
                {
                    case "speech":
                        button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => Speech(choices[choice].actionValues[i]));
                        break;

                    case "leave":
                        button.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(Leave);
                        break;
                }

                button.GetComponentInChildren<UnityEngine.UI.Text>().text = buttonName;
                button.name = buttonName;

                
                i += 1;
            }
        }

        public void Speech(int step)
        {
            npcPanel.speechPanel.SetActive(true);
            npcPanel.speechPanel.GetComponent<SpeechPanel>().ShowStep(step);
            this.gameObject.SetActive(false);
        }

        public void Leave()
        {
            this.npcPanel.ExitInteraction();
        }
    }
}
