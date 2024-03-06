using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class popUpDMG : MonoBehaviour
{
    public float lifeTime = 3.0f;
    [SerializeField]
    private float maxPower = 10.0f, minPower = 5.0f,upPower = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void popUpDamage(int damage)
    {
        TextMeshPro tmp = GetComponent<TextMeshPro>();
        if (damage > 0)
            tmp.text = damage.ToString();
        else
        {
            tmp.text = "MISS";
            Color whiteColour = new Color(255, 0, 0);
            tmp.color = whiteColour;
        }

        addForce();
    }
    public void popUpTrueDamage(int damage)
    {
        TextMeshPro tmp = GetComponent<TextMeshPro>();
        tmp.text = damage.ToString();
        Color whiteColour = new Color(255, 255, 255);
        tmp.color = whiteColour;
        addForce();
    }

    private void addForce()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        Vector3 forceDirection = new Vector3(Random.Range(-1f, 1f), 1f, 0).normalized;
        float forcePower = Random.Range(minPower, maxPower);
        rb.AddForce(forceDirection * forcePower, ForceMode.Impulse);
        rb.AddForce(Vector3.up * upPower, ForceMode.Impulse); 
    }
}

