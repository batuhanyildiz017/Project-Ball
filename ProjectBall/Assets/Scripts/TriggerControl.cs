using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class TriggerControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider trigger) // obje alandan dýþarýya çýktýðý zaman
    {
        if (trigger.gameObject.tag== "ball") //içeriye giren objenin etiketi ball ise
        {
            StartCoroutine(asagiDusur());
        }
    }
    IEnumerator asagiDusur()  //geçikme metodu
    {
        yield return new WaitForSeconds(0.2f);
        GetComponentInChildren<Rigidbody>().isKinematic = false;
        GetComponentInChildren<Rigidbody>().useGravity = true;
        Destroy(gameObject,2f);  //aþaðý düþtükten 2 saniye sonra yok edilsin.
    }
}
