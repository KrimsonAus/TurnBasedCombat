using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngineInternal;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public float mouseSpeed;
    bool canJump;
    Manager manager;
    float gTimer;

    public bool inCombat;
    public GameObject enemy;
    Enemy enemyS;
    UiManager uiManager;

    [Header("Stats")]
    public int health;
    public int maxHealth;
    public int attack;
    public int defence;
    // Start is called before the first frame update
    void Start()
    {
        canJump = true;
        Application.targetFrameRate = 120;
        rb = GetComponent<Rigidbody>();
        manager = FindAnyObjectByType<Manager>();
        uiManager = FindAnyObjectByType<UiManager>();
    }

    // Update is called once per frame
    void Update()
    {
        gTimer = manager.globalTimer;
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        rb.velocity += transform.forward * Input.GetAxis("Vertical") * speed * gTimer + transform.right * Input.GetAxis("Horizontal") * speed * gTimer;

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.velocity += transform.up * 400 * gTimer;

            canJump = false;
        }

        if (Input.GetMouseButton(1))
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * mouseSpeed * gTimer, 0);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        canJump = true;
        if(other.tag == "Enemy")
        {
            print("Enemy");
            manager.pause = true;

            inCombat = true;

            enemy = other.gameObject;
            enemyS = enemy.GetComponent<Enemy>();
            enemyS.attackingEnemy = true;
            manager.playerTurn = true;
        }
    }

    public void PrimaryAttack()
    {
        enemyS.health -= attack;

        manager.playerTurn = false;
    }
}
