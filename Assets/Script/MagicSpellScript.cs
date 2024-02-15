using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSpellScript : MonoBehaviour
{
    [HideInInspector] public GameObject targetEnamy;

    [HideInInspector] public MagicSpellData magicSpellData;

    void Start()
    {
    }

    void Update()
    {
        if (Vector3.Distance(targetEnamy.transform.position, transform.position) > .5f)
        {
            transform.Translate(Vector3.forward * magicSpellData.magicSpellSpeedValue * Time.deltaTime);
        }
        else
        {
            if (!magicSpellData.isSingle)
            {

                Collider[] nearbyEnamy = Physics.OverlapSphere(transform.position, 3f);

                for (int i = 0; i < nearbyEnamy.Length; i++)
                {
                    if (nearbyEnamy[i].name != "Floor")
                    {
                        print(nearbyEnamy[i].name);
                        if (nearbyEnamy[i].GetComponent<EnamyController>() != null)
                        {
                            nearbyEnamy[i].GetComponent<EnamyController>().GetDamage(magicSpellData.magicSpellDamageValue);
                        }
                    }
                }
            }
            else
            {
                targetEnamy.GetComponent<EnamyController>().GetDamage(magicSpellData.magicSpellDamageValue);
            }

            Instantiate(magicSpellData.magicSpellImpectEffect, transform.position,Quaternion.identity);

            Destroy(gameObject);
        }
    }
}
