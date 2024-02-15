using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnamyController : MonoBehaviour
{
    public EnamyData enamy_data;

    public float enamyHealth;

    public int num = 0;

    public bool isOccupied = false;
    public bool isVisible = false;
    MeshRenderer m_renderer;
    Camera m_camera;

    float temp_cooldown = 0;

    void Start()
    {
        enamyHealth = enamy_data.enamyHealthValue;
        temp_cooldown = enamy_data.enamyDamageCooldownValue;

        m_renderer = transform.GetChild(0).GetComponent<MeshRenderer>();
        m_camera = FindObjectOfType<Camera>();
    }


    public void CheckVisibility()
    {
        var screenPos = m_camera.WorldToScreenPoint(transform.position);
        var onScreen = screenPos.x > 0f && screenPos.x < Screen.width && screenPos.y > 0f && screenPos.y < Screen.height;

        if (onScreen && m_renderer.isVisible)
        {
            isVisible = true;
        }
        else
        {
            isVisible = false;
        }
    }

    void Update()
    {
        CheckVisibility();

        if (Vector3.Distance(GameManager.Inst.player.transform.position,transform.position) > 1f)
        {
            transform.Translate(Vector3.forward * enamy_data.enamySpeedValue * Time.deltaTime);
        }
        else
        {
            temp_cooldown -= Time.deltaTime;

            if (temp_cooldown < 0)
            {
                StartAttack();
                temp_cooldown = enamy_data.enamyDamageCooldownValue;
            }
        }

        if (enamyHealth <= 0)
        {
            GameManager.Inst.enamyList.Remove(gameObject);
            Destroy(gameObject);
        }
    }

    void StartAttack()
    {
        GameManager.Inst.player.GetComponent<PlayerConroller>().healthValue -= enamy_data.enamyDamageValue;
    }

    public void GetDamage(float val)
    {
        isOccupied = false;
        enamyHealth -= val;
    }
}
