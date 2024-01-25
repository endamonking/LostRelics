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
        if (Input.GetKeyDown(KeyCode.B))
        {
            showInventoryTab(0);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            showInventoryTab(1);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            showInventoryTab(2);
        }
        if (Input.GetKeyDown(KeyCode.J))
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
}
