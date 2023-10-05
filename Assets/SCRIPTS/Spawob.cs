using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawob : MonoBehaviour
{
    [SerializeField] private GameObject crystal;
    [SerializeField] float radius = 1500;
    float timer = 0;
    float cooldown = 2;
    void Start()
    {
        GameObject buf = Instantiate(crystal);
        float x = Random.Range(-radius, radius);
        float z = Random.Range(-radius, radius);
        buf.transform.position = transform.position + new Vector3(x, 1, z);
    }


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > cooldown)
        {
            timer = 0;
            GameObject buf = Instantiate(crystal);
            float x = Random.Range(-radius, radius);
            float z = Random.Range(-radius, radius);
            buf.transform.position = transform.position + new Vector3(x, 1, z);

        }
        if (Input.GetKey(KeyCode.X))
        {
            GameObject buf = Instantiate(crystal);
            float x=Random.Range(-radius, radius);
            float z = Random.Range(-radius, radius);
            buf.transform.position = transform.position + new Vector3(x, 1, z);
        
        }
    }
}
