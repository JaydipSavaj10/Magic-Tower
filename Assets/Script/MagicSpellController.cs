using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicSpellController : MonoBehaviour
{
    public MagicSpellData magicSpellData;

    public bool isFireEnable = true;

    public Image cooldownBar;
    float temp_cooldown = 0;

    void Update()
    {
        if (!isFireEnable)
        {
            cooldownBar.fillAmount = temp_cooldown;

            temp_cooldown -= Time.deltaTime * magicSpellData.magicSpellCooldownValue;

            if (temp_cooldown < 0)
            {
                isFireEnable = true;
            }
        }
    }

    public void FireButtonPress()
    {
        if (magicSpellData.magicSpellName == "FireballSpell")
        {
            if (GameManager.Inst.enamyList.Count != 0)
            {
                int count = 0;

                for (int i = 0; i < GameManager.Inst.enamyList.Count; i++)
                {
                    if (GameManager.Inst.enamyList[i].GetComponent<EnamyController>().isVisible)
                    {
                        count++;
                        if (GameManager.Inst.enamyList[i].GetComponent<EnamyController>().isOccupied)
                        {
                            count--;
                        }
                    }
                }

                if (isFireEnable && count != 0)
                {
                    isFireEnable = false;
                    temp_cooldown = 1f;

                    next:
                    int enamyNum = Random.Range(0, GameManager.Inst.enamyList.Count);

                    if (GameManager.Inst.enamyList[enamyNum] == null)
                        goto next;
                    if (!GameManager.Inst.enamyList[enamyNum].GetComponent<EnamyController>().isVisible)
                        goto next;
                    if (GameManager.Inst.enamyList[enamyNum].GetComponent<EnamyController>().isOccupied)
                        goto next;

                    GameManager.Inst.enamyList[enamyNum].GetComponent<EnamyController>().isOccupied = true;

                    GameObject temp_magicSpell = Instantiate(magicSpellData.magicSpellPrefab);

                    Vector3 random_pos = GameManager.Inst.player.transform.position;

                    temp_magicSpell.transform.position = random_pos + new Vector3(0, 1.5f, 0);
                    temp_magicSpell.transform.LookAt(GameManager.Inst.enamyList[enamyNum].transform);

                    temp_magicSpell.GetComponent<MagicSpellScript>().targetEnamy = GameManager.Inst.enamyList[enamyNum];
                    temp_magicSpell.GetComponent<MagicSpellScript>().magicSpellData = magicSpellData;

                    temp_magicSpell.transform.SetParent(GameManager.Inst.magicSpellParent);
                }
            }
        }
        else if (magicSpellData.magicSpellName == "BarrageSpell")
        {
            if (GameManager.Inst.enamyList.Count != 0)
            {
                List<GameObject> enamyList = new List<GameObject>();

                for (int i = 0; i < GameManager.Inst.enamyList.Count; i++)
                {
                    if (GameManager.Inst.enamyList[i].GetComponent<EnamyController>().isVisible)
                    {
                        enamyList.Add(GameManager.Inst.enamyList[i]);
                    }
                }

                if (isFireEnable && enamyList.Count != 0)
                {
                    isFireEnable = false;
                    temp_cooldown = 1f;

                    for (int i = 0; i < enamyList.Count; i++)
                    {
                        GameObject temp_magicSpell = Instantiate(magicSpellData.magicSpellPrefab);

                        Vector3 random_pos = GameManager.Inst.player.transform.position;

                        temp_magicSpell.transform.position = random_pos + new Vector3(0, 1.5f, 0);
                        temp_magicSpell.transform.LookAt(enamyList[i].transform);

                        temp_magicSpell.GetComponent<MagicSpellScript>().targetEnamy = enamyList[i];
                        temp_magicSpell.GetComponent<MagicSpellScript>().magicSpellData = magicSpellData;

                        temp_magicSpell.transform.SetParent(GameManager.Inst.magicSpellParent);
                    }
                }
            }
        }
    }
}
