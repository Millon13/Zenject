using UnityEngine;
using System.Collections.Generic;
using Zenject;


namespace Modules
{
    [CreateAssetMenu(fileName = "NewInputDictionary", menuName = "Input/Input Dictionary")]
    public class InputButtonSystem : ScriptableObject
    {
        [System.Serializable]
        public class InputButton
        {
            public string buttonName;
            public KeyCode buttonKey;
        }

        [SerializeField] private List<InputButton> buttonsList = new List<InputButton>();
        private Dictionary<string, InputButton> buttonsDictionary;

        private void InitializeDictionary()
        {
            if (buttonsDictionary != null)
                return;
            buttonsDictionary = new Dictionary<string, InputButton>();

            for (int i = 0; i < buttonsList.Count; i++)
            {
                InputButton inputButton = buttonsList[i];

                if (!buttonsDictionary.ContainsKey(inputButton.buttonName))
                {
                    buttonsDictionary.Add(inputButton.buttonName, inputButton);
                }
                else
                {
                    Debug.Log($"������ {inputButton.buttonName} �� ���������� ");
                }
            }
        }

        private void OnEnable()
        {
            InitializeDictionary();
        }

        public KeyCode GetPrimaryKey(string actionName)
        {
            InitializeDictionary();

            if (buttonsDictionary.TryGetValue(actionName, out InputButton inputButton))
            {
                return inputButton.buttonKey;
            }

            return KeyCode.None;
        }

        public bool IsKeyDown(string actionName)
        {
            InitializeDictionary();

            if (buttonsDictionary.TryGetValue(actionName, out InputButton inputButton))
            {
                if (Input.GetKeyDown(inputButton.buttonKey))
                    return true;
            }

            return false;
        }
    }
}