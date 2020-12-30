using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas gameOverCnvas;
    // Start is called before the first frame update
    void Start()
    {
        gameOverCnvas.enabled = false;
    }

    public void HandleDeath()
    {
        gameOverCnvas.enabled = true;
        Time.timeScale = 0;
        FindObjectOfType<WeaponSwitcher>().enabled = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
