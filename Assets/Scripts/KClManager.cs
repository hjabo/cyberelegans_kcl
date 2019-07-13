using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KClManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mKcl;
    void Start()
    {
        for (int i = 0; i < 1500; i++)
        {
            GameObject n = Instantiate(mKcl, new Vector3(Random.Range(0, 200.0f), -7.5f, Random.Range(-200.0f, 200.0f)), transform.rotation);
            n.transform.SetParent(this.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
