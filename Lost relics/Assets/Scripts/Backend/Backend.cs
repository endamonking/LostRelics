using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterJSON
{
    public string characterName;
    public List<string> characterDeck;

    public CharacterJSON(string name, List<Card> deck)
    {
        this.characterName = name;
        this.characterDeck = addCardName(deck);
    }

    private List<string> addCardName(List<Card> deck)
    {
        List<string> cardNameList = new List<string>();
        foreach (Card card in deck)
        {
            string cardName = card.cardName;
            cardNameList.Add(cardName);
        }

        return cardNameList;
    }

}

public class Backend : MonoBehaviour
{
    public static Backend instance;
    public web web;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        web = GetComponent<web>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void createJson(GameObject player)
    {
        Character character = player.GetComponent<Character>();
        cardHandler CH = player.GetComponent<cardHandler>();
        CharacterJSON result = new CharacterJSON(character.characterName, CH.playerDeck);
        string content = JsonUtility.ToJson(result);
        Debug.Log(content);
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);
        StartCoroutine(web.sendJson(content));
    }
    public void createJson(GameObject player, GameObject companion)
    {
        Character character = player.GetComponent<Character>();
        cardHandler CH = player.GetComponent<cardHandler>();
        CharacterJSON result = new CharacterJSON(character.characterName, CH.playerDeck);
        string content = JsonUtility.ToJson(result);
        // Compa
        Character character2 = companion.GetComponent<Character>();
        cardHandler CH2 = companion.GetComponent<cardHandler>();
        CharacterJSON result2 = new CharacterJSON(character2.characterName, CH2.playerDeck);
        string content2 = JsonUtility.ToJson(result2);
        Debug.Log(content);
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);
        StartCoroutine(web.sendJson(content, content2));
    }
    public void sendCharacter(string characterName)
    {
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);

        StartCoroutine(web.sendCharacter(characterName));
    }
}
