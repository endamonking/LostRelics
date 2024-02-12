using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCSpawner : MonoBehaviour
{
    public Transform mcLocation;
    [Header("Camera")]
    public PlayerCamera pCam;
    private GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameManager.Instance;
        GM.spawnMC(mcLocation, pCam);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
