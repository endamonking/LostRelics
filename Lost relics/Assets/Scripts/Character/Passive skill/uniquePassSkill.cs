using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class uniquePassSkill : MonoBehaviour
{
    public GameObject characterGO;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public  void initPassive(GameObject attachedGO)
    {
        characterGO = attachedGO;
    }
}
