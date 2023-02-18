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
    private void OnTriggerExit(Collider trigger) // obje alandan d��ar�ya ��kt��� zaman
    {
        if (trigger.gameObject.tag== "ball") //i�eriye giren objenin etiketi ball ise
        {
            StartCoroutine(asagiDusur());
        }
    }
    IEnumerator asagiDusur()  //ge�ikme metodu
    {
        yield return new WaitForSeconds(0.2f);
        GetComponentInChildren<Rigidbody>().isKinematic = false;
        GetComponentInChildren<Rigidbody>().useGravity = true;
        Destroy(gameObject,2f);  //a�a�� d��t�kten 2 saniye sonra yok edilsin.
    }
}
