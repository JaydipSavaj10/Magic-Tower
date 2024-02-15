using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerConroller : MonoBehaviour
{
    public float healthValue = 100;

    public Image healthBar;

    void Start()
    {
        
    }

    void Update()
    {
        if (healthValue > 0f)
        {
            healthBar.fillAmount = healthValue / 100f;
        }
        else
        {
            healthValue = 0;
            healthBar.fillAmount = healthValue / 100f;
            print("Game Over");
        }
    }
}
