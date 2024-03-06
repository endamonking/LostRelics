using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{
    /*[Header("Animation numbers")]
    public int attackAnims = 2;*/
    public GameObject hitEffectSpritePrefab;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playAnimation(string aniName)
    {
        animator.Play(aniName);
    }

    public void playAttackAnim(Transform targetTransform)
    {
        /*int randomNum = Random.Range(0, attackAnims);
        randomNum++;*/
        string animName = "Atk";
        Debug.Log(animName);
        animator.SetTrigger(animName);
        GameObject effectSprite;
        if (hitEffectSpritePrefab != null)
            effectSprite = Instantiate(hitEffectSpritePrefab, targetTransform.position, Quaternion.identity);
    }

    public void playHurtAnim()
    {
        animator.SetTrigger("Hurt");
    }
    public void playEvadeAnim()
    {
        animator.SetTrigger("Evade");
    }
}
