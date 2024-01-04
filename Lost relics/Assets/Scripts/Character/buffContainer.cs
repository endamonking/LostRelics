using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buffContainer : MonoBehaviour
{
    [SerializeField]
    private GameObject iconPrefab, containBox;

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

    public void updateBuffIconUI(List<buff> allBuff)
    {
        foreach (Transform child in containBox.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (buff activeBuff in allBuff)
        {
            GameObject icon = Instantiate(iconPrefab,containBox.transform);
            Sprite pic = Resources.Load<Sprite>("Buff_Icon/" + activeBuff.buffPicName);
            if (pic != null)
                icon.GetComponent<Image>().sprite = pic;
            else
            {
                pic = Resources.Load<Sprite>("Buff_Icon/none");
                icon.GetComponent<Image>().sprite = pic;
            }

        }

    }

}
