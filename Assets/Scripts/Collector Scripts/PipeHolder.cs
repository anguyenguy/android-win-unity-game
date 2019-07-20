using System.Collections;
using UnityEngine;

public class PipeHolder : MonoBehaviour
{
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(BirdScripts.instance != null)
        {
            if (BirdScripts.instance.flag == 1)
            {
                Destroy(GetComponent<PipeHolder>());
            }
        }
        PipeMovement();
    }

    void PipeMovement()
    {
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime;
        transform.position = temp;
    }


    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Destroy")
        {
            Destroy(gameObject);
        }
    }
}
