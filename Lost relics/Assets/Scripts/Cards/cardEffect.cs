using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class cardEffect : MonoBehaviour
{
    [SerializeField]
    private stance intoStance;

    void Start()
    {

    }

    public abstract void applyEffect(Character character);

}
