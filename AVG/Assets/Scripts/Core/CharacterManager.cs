using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class CharacterManager : MonoBehaviour
{
    public static CharacterManager instance;
    public RectTransform characterPanel;
    public List<Character> characters = new List<Character>();
    public Dictionary<string, int> characterDictionary = new Dictionary<string, int>();
    private void Awake()
    {
        instance = this;
    }
    
    public Character GetCharacter(string characterName, bool createCharacterIfDoesNotExit = true, bool enableCreateCharacterOnStart = true)
    {
        int index = -1;
        if (characterDictionary.TryGetValue(characterName, out index))
        {
            return characters[index];
        }
        else if(createCharacterIfDoesNotExit)
        {
            return CreateCharacter(characterName, enableCreateCharacterOnStart);
        }
        return null;
    }

    public Character CreateCharacter(string characterName, bool enableOnStart = true) 
    {
        Character newCharacter = new Character (characterName, enableOnStart);

        characterDictionary.Add(characterName, characters.Count);

        characters.Add(newCharacter);

        return newCharacter;
    }

    public class CharacterPosition
    {
        public Vector2 right = new Vector2(0.479625f, 0);
        public Vector2 left = new Vector2(0.1274375f,0);
        public Vector2 middle = new Vector2(0.4346738f, 0);
    
    }

    public class CharacterExpressions
    {
        public int normal = 0;
        public int alternative = 1;
    }

    public static CharacterExpressions characterExpressions = new CharacterExpressions();

}
