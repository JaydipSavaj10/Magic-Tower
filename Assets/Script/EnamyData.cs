using UnityEngine;

[CreateAssetMenu(fileName = "EnamyData", menuName = "ScriptableObjects/EnamyData", order = 1)]
public class EnamyData : ScriptableObject
{
    public string enamyName;
    public GameObject enamyPrefab;
    public float enamySpeedValue;
    public float enamyDamageValue;
    public float enamyDamageCooldownValue;
    public float enamyHealthValue;
}
