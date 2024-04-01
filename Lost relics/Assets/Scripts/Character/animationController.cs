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
        animator.SetTrigger(animName);
        GameObject effectSprite;
        if (hitEffectSpritePrefab != null)
            effectSprite = Instantiate(hitEffectSpritePrefab, targetTransform.position, Quaternion.identity);
    }
    public void playMeleeAttackAnim(Transform targetTransform)
    {
        Transform character = this.transform.parent.gameObject.transform;
        Vector3 original = this.transform.parent.gameObject.transform.position;
        //Target position
        if (gameObject.transform.parent.tag == "Player")
            character.position = targetTransform.position + new Vector3 (-1,0,0);
        else
            character.position = targetTransform.position + new Vector3(1, 0, 0);
        string animName = "Atk";
        animator.SetTrigger(animName);
        GameObject effectSprite;
        if (hitEffectSpritePrefab != null)
            effectSprite = Instantiate(hitEffectSpritePrefab, targetTransform.position, Quaternion.identity);
        StartCoroutine(delayReturn(character, original));
    }
    IEnumerator delayReturn(Transform character, Vector3 original)
    {
        yield return new WaitForSeconds(1.0f);
        character.position = original;
    }
    public void playAttackAnim()
    {
        /*int randomNum = Random.Range(0, attackAnims);
        randomNum++;*/
        string animName = "Atk";
        animator.SetTrigger(animName);
    }
    public void spawnHitEffect(Transform targetTransform)
    {
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
