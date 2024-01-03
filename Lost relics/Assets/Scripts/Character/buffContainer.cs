using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buffContainer : MonoBehaviour
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
        Sprite pic = this.transform.parent.parent.GetComponentInChildren<SpriteRenderer>().sprite;
        combatManager.Instance.showCharacterWindow(this.transform.parent.parent.gameObject.GetComponent<Character>(), pic);
    }
}
