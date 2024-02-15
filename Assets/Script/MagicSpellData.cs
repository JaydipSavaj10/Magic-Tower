using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MagicSpellData", menuName = "ScriptableObjects/MagicSpellData", order = 1)]
public class MagicSpellData : ScriptableObject
{
    public string magicSpellName;
    public GameObject magicSpellPrefab;
    public float magicSpellSpeedValue;
    public float magicSpellDamageValue;
    public float magicSpellCooldownValue;
    public GameObject magicSpellImpectEffect;
    public bool isSingle;
}