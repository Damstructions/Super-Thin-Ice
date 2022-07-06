using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Begone(3));
    }

    public IEnumerator Begone(float t)
    {
        yield return new WaitForSeconds(t);
        Destroy(this.gameObject);
    }
}
