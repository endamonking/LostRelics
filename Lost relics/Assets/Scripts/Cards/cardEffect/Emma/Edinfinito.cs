using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edinfinito : cardEffect, IBeforeUseCard
{
    [SerializeField]
    private int baseSkillMultiplier = 20;
    public Card drawedCard;
    private Character thisUser;
    private buff currentBuff;
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
        thisUser = user;
        useEffect();
        return true;
    }
    public void onBeforeUseCard(Card usingCard)
    {
        if (usingCard == drawedCard)
        {
            
            useEffect();
        }
    }

    private void useEffect()
    {
        //draw
        cardHandler cardUser = combatManager.Instance.currentObjTurn.GetComponent<cardHandler>();
        drawedCard = cardUser.drawCardWithReturnDrawCard();
        //Buff
        buff newBuff = new buff("Ed infinito", 1, "Before_Use_Card", this.gameObject.GetComponent<IBeforeUseCard>());
        if (!thisUser.findBuffContainByName(newBuff.buffName))
        {
            thisUser.applyActiveDeBuff(newBuff,true);
            currentBuff = newBuff;
        }

        //Do damage
        int userDamage = thisUser.inComATK;
        int userAP = thisUser.inComArmorPen;
        int userDMGBonus = thisUser.inComDMGBonus;
        int userCritRate = thisUser.inComCritRate;
        int userCritDMG = thisUser.inComCritDMG;
        GameObject enemy = combatManager.Instance.getRandomEnemy();
        Character target = enemy.GetComponent<Character>();
        float skillMulti = baseSkillMultiplier / 100.0f;
        target.takeDamage(userDamage, userAP, userDMGBonus, skillMulti, userCritRate, userCritDMG);

    }
    
}