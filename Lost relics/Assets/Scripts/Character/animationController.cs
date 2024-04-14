using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{
    /*[Header("Animation numbers")]
    public int attackAnims = 2;*/

    public GameObject hitEffectSpritePrefab;
    [Header("Particle")]
    [SerializeField]
    private GameObject healParticleEffect;
    [SerializeField]
    private GameObject buffParticleEffect, debuffParticleEffect;
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
    public void playMeleeAttackAnim(Transform targetTransform, Vector3 originalPosition)
    {
        Transform character = this.transform.parent.gameObject.transform;
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
        StartCoroutine(delayReturn(character, originalPosition));
    }
    IEnumerator delayReturn(Transform character, Vector3 original)
    {
        yield return new WaitForSeconds(0.7f);
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

    public void startHealParticleEff(Transform character)
    {
        GameObject healparticle = Instantiate(healParticleEffect, character);
    }
    public void startBuffParticleEff(Transform character)
    {
        Debug.Log(character.gameObject.name);
        GameObject buffparticle = Instantiate(buffParticleEffect, character);
    }
    public void startDebuffParticleEff(Transform character)
    {
        Debug.Log(character.gameObject.name);
        GameObject debuffparticle = Instantiate(debuffParticleEffect, character);
    }
}
