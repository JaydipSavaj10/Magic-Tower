using UnityEngine;

public class LifeScript : MonoBehaviour
{
    public float lifespan = 1f;

    void Start()
    {
        Destroy(gameObject, lifespan);
    }
}
