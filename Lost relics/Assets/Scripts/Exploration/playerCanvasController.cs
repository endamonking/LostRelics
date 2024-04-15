using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCanvasController : MonoBehaviour
{
    private inventoryCanvas ic;
    // Start is called before the first frame update
    void Start()
    {
        if (inventoryCanvas.Instance != null)
            ic = inventoryCanvas.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && !InGameMenu.Instance.Menu.activeSelf)
        {
            showInventoryTab(0);
        }
        if (Input.GetKeyDown(KeyCode.C) && !InGameMenu.Instance.Menu.activeSelf)
        {
            showInventoryTab(1);
        }
        if (Input.GetKeyDown(KeyCode.V) && !InGameMenu.Instance.Menu.activeSelf)
        {
            showInventoryTab(2);
        }
        if (Input.GetKeyDown(KeyCode.J) && !InGameMenu.Instance.Menu.activeSelf)
        {
            showInventoryTab(3);
        }
    }

    private void showInventoryTab(int tabIndex)
    {
        int move = ic.openTab(tabIndex);
        if (move == 0)
            exploration_sceneManager.Instance.isEvent = false;
        else
            exploration_sceneManager.Instance.isEvent = true;
    }
    private void openMenu()
    {
        if (InGameMenu.Instance.gameObject.activeSelf)
            InGameMenu.Instance.closeMenu();
        else
            InGameMenu.Instance.openMenu();
    }

}
