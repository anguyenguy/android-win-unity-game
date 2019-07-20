using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCollector : MonoBehaviour
{
    [SerializeField]
    private GameObject pipeHolder;


    void Start()
    {
        StartCoroutine(Collector());
    }

    IEnumerator Collector()
    {
        yield return new WaitForSeconds(14);
        Instantiate(pipeHolder, transform.position, Quaternion.identity);
        StartCoroutine(Collector());
    }
}
