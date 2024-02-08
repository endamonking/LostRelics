using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{
    [Header("Animation numbers")]
    public int attackAnims = 2;

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

    public void playAttackAnim()
    {
        int randomNum = Random.Range(0, attackAnims);
        randomNum++;
        string animName = "Atk" + randomNum;
        Debug.Log(animName);
        animator.SetTrigger(animName);
    }

    public void playHurtAnim()
    {
        animator.SetTrigger("Hurt");
    }
}
