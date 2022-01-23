using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    DialogueSystem dialogue;
    // Start is called before the first frame update
    void Start()
    {
        dialogue = DialogueSystem.instance;
    }

    // Update is called once per frame

    public string[] s = new string[]
    {
        "Hi, how are you? :Ruby Wu",
        "It's lovely weather today.",
        "To be honest, I'm glad its not snowing any more!",
        "I'm fine... :C",
        "What are you going to do though?"

    };
    int index = 0;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!dialogue.isSpeaking || dialogue.isWaitingForUserInput)
            {
                if (index >= s.Length) 
                {
                    return;
                }
                Say(s[index]);
                index++;
            }
        
        }

        void Say(string s)
        {
            string[] parts = s.Split(':');
            string speech = parts[0];
            string speaker = (parts.Length >= 2) ? parts[1] : "";

            dialogue.Say(speech,speaker);
        }
        
    }
}
