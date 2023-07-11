using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public GameObject player;
    public Player playerC;
    // Start is called before the first frame update
    void Start()
    {
        playerC = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerC.inCombat)
        {
            transform.position = player.transform.position;
            transform.rotation = player.transform.rotation;
        }
        else
        {
            transform.position = (player.transform.position + playerC.enemy.transform.position) / 2;

            transform.Rotate(0, -Time.deltaTime * 5, 0);
        }
    }

}
