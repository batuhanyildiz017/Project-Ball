using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlatform : MonoBehaviour
{
    float dimensionX;
    float dimensionZ;
    public GameObject platform;
    Vector3 lastPosition;
    // Start is called before the first frame update
    void Start()
    {
        dimensionX= platform.transform.GetChild(0).transform.localScale.x; //x eksenindeki boy uzunluðu;
        dimensionZ= platform.transform.GetChild(0).transform.localScale.z; //z eksenindeki boy uzunluðu GetChild(0).transform.localScale.x;
        lastPosition = platform.transform.position; // platformun son pozisyonu GetChild(0).transform.
        StartCoroutine(createPlatform());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator createPlatform()   // geçikmeli platform oluþturma
    {
        yield return new WaitForSeconds(0.2f);
        int random = Random.Range(0,10);
        if (random<5)
        {
            createXAxis();
        }else
            createZAxis();
        StartCoroutine(createPlatform());
    }
    void createXAxis() //x ekseninde platform oluþturma
    {
        lastPosition.x += dimensionX;
        Instantiate(platform,lastPosition,Quaternion.identity);
    }
    void createZAxis() //z ekseninde platform oluþturma
    {
        lastPosition.z += dimensionZ;
        Instantiate(platform,lastPosition, Quaternion.identity);
    }
}
