using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CompanionSpawner : MonoBehaviour
{
    [Header("UI")]
    public GameObject canvas;
    public TextMeshProUGUI comName;
    public TextMeshProUGUI dialog;

    public int companionNumber;

    private bool isPlayerNear = false;
    private bool isOpen = false;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && isPlayerNear == true)
        {
            openWindow();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerNear = true;
            player = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerNear = false;
            player = null;
        }
    }
    private void openWindow()
    {
        if (isOpen)
            closeRecruit();
        else 
            openRecruit();
    }
    private void openRecruit()
    {
        canvas.SetActive(true);
        isOpen = true;
        printText();
        player.GetComponent<PlayerControl>().stopPlaterMovement();
    }

    public void closeRecruit()
    {
        canvas.SetActive(false);
        player.GetComponent<PlayerControl>().resumePlaterMovement();
        isOpen = false;
    }

    public void spawnCompanion()
    {
        GameManager.Instance.spawnCompanion(companionNumber);
        closeRecruit();
        this.gameObject.SetActive(false);
    }
    //use to show Companion anme and dialog
    private void printText()
    {
        string npcName = "";
        string npcDialog = "";
        switch (companionNumber)
        {
            case 1:
                npcName = "Krist";
                npcDialog = "Test";
                break;
            case 2:
                npcName = "Seraphina";
                npcDialog = "Test";
                break;
            case 3:
                npcName = "Chloe";
                npcDialog = "Test";
                break;
        }
        comName.text = npcName;
        dialog.text = npcDialog;
    }
}
