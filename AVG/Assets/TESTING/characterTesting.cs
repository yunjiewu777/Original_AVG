using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterTesting : MonoBehaviour    
{

    public Character C;
    public int body=0;
    public int expression=0;

    // Start is called before the first frame update
    void Start()
    {
        C = CharacterManager.instance.GetCharacter("C", enableCreateCharacterOnStart:false);
    }

    public string[] speech;
    public int i = 0;

    public Vector2 moveTarget;
    public float moveSpeed=2;
    public bool smooth=true;

    public float speed = 1f;
    public bool smoothtransitions = true;

    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (i < speech.Length)
            {
                C.Say(speech[i]);
            }
            else 
            {
                DialogueSystem.instance.Close();
            }
            i++;    
        }

        if (Input.GetKey(KeyCode.M))
        {
            C.MoveTo(moveTarget, moveSpeed, smooth);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            C.StopMoving(true);
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (Input.GetKey(KeyCode.T))
                C.TransitionBody(C.GetBodySprite(body), speed, smoothtransitions);
            else
                C.SetBody(body);
        }

        if (Input.GetKey(KeyCode.E))
        {
            if (Input.GetKey(KeyCode.T))
                C.TransitionExpression(C.GetExpressionSprite(expression), speed, smoothtransitions);
            else
                C.SetExpression(expression);
        }

    }

    
}
