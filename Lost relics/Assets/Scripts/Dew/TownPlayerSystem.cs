using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownPlayerSystem : MonoBehaviour
{

    public Transform PlayerSlot;
    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacterID = GameManager.Instance.selectedCharacterID;
        Debug.Log(selectedCharacterID);
        GameObject characterPrefab = Resources.Load<GameObject>("Prefabs/Town/Character" + selectedCharacterID);
        Debug.Log(characterPrefab);
        GameObject MainCharacter = Instantiate(characterPrefab, PlayerSlot);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
