using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;

    public GameObject player;

    public float genrateSpeed = 2f;

    [Space(10)]
    [Header("Enamy")]
    public Transform enamyParent;
    public List<EnamyData> enamyType = new List<EnamyData>();
    public List<GameObject> enamyList = new List<GameObject>();

    [Space(10)]
    [Header("Magic Spell")]
    public Transform magicSpellParent;


    private void Awake()
    {
        Inst = this;
    }

    void Start()
    {
        StartCoroutine(EnamyGenerate());
    }

    public IEnumerator EnamyGenerate()
    {
        yield return new WaitForSeconds(genrateSpeed);

        int e_type = Random.Range(0, 100);
        int num = e_type < 81 ? 0 : e_type < 96 ? 1 : 2;

        GameObject temp_enamy = Instantiate(enamyType[num].enamyPrefab);

        Vector3 random_pos = new Vector3(Random.Range(0, 100) < 50 ? Random.Range(-15, -10) : Random.Range(10, 15), 0, Random.Range(0, 100) < 50 ? Random.Range(-15, -10) : Random.Range(10, 15));

        temp_enamy.transform.position = random_pos;
        temp_enamy.transform.LookAt(player.transform);

        temp_enamy.transform.SetParent(enamyParent);
        enamyList.Add(temp_enamy);

        genrateSpeed -= Time.deltaTime;
        StartCoroutine(EnamyGenerate());
    }

    public void RemoveNullEnamy()
    {
        for (int i = enamyList.Count - 1; i > -1; i--)
        {
            if (enamyList[i] == null)
            {
                enamyList.RemoveAt(i);
            }
        }
    }
}
