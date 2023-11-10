using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buff : MonoBehaviour
{

    public string buffName;
    public int duration = 0; // Turn unit
    public Dictionary<string, int> buffs;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Buff(string name, int duration)
    {
        this.name = name;
        this.duration = duration;
        this.buffs = new Dictionary<string, int>();
    }

}
