using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public GameObject combatPanel;
    public GameObject attackPanel;

    Manager manager;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<Manager>();
        player = FindFirstObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.inCombat && manager.playerTurn)
        {
            combatPanel .SetActive(true);
        }
        else
        {
            combatPanel .SetActive(false);
            attackPanel .SetActive(false);
        }
    }

    public void Attack()
    {
        attackPanel .SetActive(!attackPanel.activeSelf);
    }
}
