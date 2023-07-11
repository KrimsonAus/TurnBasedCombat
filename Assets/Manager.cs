using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public float globalTimer;
    public bool pause;
    public bool playerTurn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!pause)
        {
            globalTimer = Time.deltaTime;
        }
        else
        {
            globalTimer = 0;
        }
    }
}
