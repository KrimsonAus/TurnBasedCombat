using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int attack;

    public bool attackingEnemy;

    public GameObject healthObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthObj.transform.localScale = new Vector3(health/2f, 0.075f, 0.175f);

        if(attackingEnemy && !FindAnyObjectByType<Manager>().playerTurn)
        {
            FindAnyObjectByType<Player>().health -= attack;
            FindAnyObjectByType<Manager>().playerTurn = true;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
