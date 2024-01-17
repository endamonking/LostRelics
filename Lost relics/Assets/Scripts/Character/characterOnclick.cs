using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class characterOnclick : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Scene thisScene = SceneManager.GetActiveScene();

        if (thisScene.name != "Exploration")
            return;

        if (combatManager.Instance.state != BattleState.PLAYER || combatManager.Instance.isShowDiscard == true)
            return;

        Debug.Log(this.gameObject.name + "Clicked");
        combatManager.Instance.selectedTarget(this.transform.parent.gameObject);
    }
}
