using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class cardEffect : MonoBehaviour
{
    public stance intoStance;

    void Start()
    {

    }

    //return true if do succes
    public abstract bool applyEffect(Character target, Character user);

}
