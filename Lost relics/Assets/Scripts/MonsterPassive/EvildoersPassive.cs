using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvildoersPassive : uniquePassSkill, IStartturnEffect
{
    [SerializeField]
    private GameObject windyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onStartTurn()
    {
        List<GameObject> allies = new List<GameObject>();
        allies.AddRange(combatManager.Instance.getAllEnemies());

        if (allies.Count < 3)
        {
            combatManager.Instance.initMoreEnemy(windyPrefab, this.gameObject.transform.parent);
            //Play animation
            Character chara = characterGO.GetComponent<Character>();
            chara.doCharacterAnimationAndSound();
        }
    }
}
