using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] createObject;
    public Vector3 minPosition;
    public Vector3 maxPosition;
    Rigidbody rb;
    void Start()
    {
       
        for (int i = 0; i < 15; i++)
        {

            InvokeRepeating("CreateRandomObject", 0, 1);
          
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void CreateRandomObject()
    {
        Vector3 randomPosition = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y),
            Random.Range(minPosition.z, maxPosition.z)
        );

        int rndm = Random.Range(0,14);
        GameObject newObje = Instantiate(createObject[rndm], randomPosition, Quaternion.identity);
        

        Destroy(newObje,4f);
    }
  
}
