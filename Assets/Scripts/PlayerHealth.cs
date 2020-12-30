using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float playerHelath = 100f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandlePlayerGettingHit(float damage)
    {
        playerHelath -= damage;
        if(playerHelath <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath(); ;
        }
    }
}
