using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuagePic : MonoBehaviour
{
    [SerializeField]
    private List<Sprite> imageList = new List<Sprite>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeCharacterImage(string name)
    {
        Image img = GetComponent<Image>();
        switch (name)
        {
            case "Emma":
                img.sprite = imageList[0];
                break;
            case "Avery":
                img.sprite = imageList[1];
                break;
            case "Sylvia":
                img.sprite = imageList[2];
                break;
            case "Krist":
                img.sprite = imageList[3];
                break;
            case "Seraphina":
                img.sprite = imageList[4];
                break;
            case "Chloe":
                img.sprite = imageList[5];
                break;
            case "Slime":
                img.sprite = imageList[6];
                break;
            case "Legged Mugger":
                img.sprite = imageList[7];
                break;
            case "Nike Tiger":
                img.sprite = imageList[8];
                break;
            case "Windy":
                img.sprite = imageList[9];
                break;
            case "Bagky":
                img.sprite = imageList[10];
                break;
            case "Goblin":
                img.sprite = imageList[11];
                break;
            case "Evildoers":
                img.sprite = imageList[12];
                break;
            default:
                break;
        }
    }
}
