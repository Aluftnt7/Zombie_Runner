using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    public void TakeDamage(float damage)
    {
        BroadcastMessage("OnDamageTaken"); // can activate function called "ondamagetaken" whatever it is (on the same game object or his children)
        hitPoints -= damage;
        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
