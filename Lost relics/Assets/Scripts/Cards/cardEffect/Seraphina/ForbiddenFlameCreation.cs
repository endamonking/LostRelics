using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForbiddenFlameCreation : cardEffect
{
    [SerializeField]
    private int damage = 15;
    public Card tokenCard;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override bool applyEffect(Character target, Character user)
    {
        //Check ally
        //Other aproach is to check tag
        List<GameObject> enemies = new List<GameObject>();
        enemies.AddRange(combatManager.Instance.getAllEnemies());
        foreach (GameObject enemy in enemies)
        {
            if (enemy == target.gameObject)
                return false;
        }
        //Deal dmg
        target.takeTrueDamageIgnoreOnHit(damage);
        //play animation and sound
        user.doCharacterAnimationAndSound(target.gameObject);
        //Create card
        cardHandler playerCardHand = user.gameObject.GetComponent<cardHandler>();
        playerCardHand.createCardToHand(tokenCard);


        return true;
    }
}
