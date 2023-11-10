using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class cardEffect : MonoBehaviour
{
    public stance intoStance;

    void Start()
    {

    }

    public abstract void applyEffect(Character target, Character user);

}
