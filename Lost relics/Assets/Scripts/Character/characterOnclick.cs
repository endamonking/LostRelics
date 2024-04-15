using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class characterOnclick : MonoBehaviour
{
    private CapsuleCollider characterCollider;
    // Start is called before the first frame update
    void Start()
    {
        characterCollider = GetComponent<CapsuleCollider>();
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
    //Some how it need to re enable to make the third character can click (need to remain last)
    public void reActivateCollider()
    {
        StartCoroutine(delayEnable());

    }

    IEnumerator delayEnable()
    {
        characterCollider.enabled = false;
        yield return new WaitForSeconds(0.2f);
        characterCollider.enabled = true;
    }
}
