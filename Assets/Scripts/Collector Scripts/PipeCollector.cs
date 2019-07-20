using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeCollector : MonoBehaviour
{
    [SerializeField]
    private GameObject pipeHolder;


    void Start()
    {
        StartCoroutine(Collector()); 
    }

    IEnumerator Collector()
    {
        yield return new WaitForSeconds(2);
        Vector3 temp = pipeHolder.transform.position;
        temp.y = Random.Range(-1.5f, 2.5f);

        Instantiate(pipeHolder, temp, Quaternion.identity);
        StartCoroutine(Collector());
    }
}
