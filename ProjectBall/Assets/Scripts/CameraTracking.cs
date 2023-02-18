using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    public GameObject ball; // top objesi
    Vector3 distance; // mesafe
    Vector3 aimPosition; //hedeflenen mesafe
    Vector3 cameraPosition; // kamera pozisyonu
    public bool isGameFinished;
    // Start is called before the first frame update
    void Start()
    {
        distance = ball.transform.position - transform.position;
        isGameFinished = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isGameFinished)
        kameraMesafeAyarla();
    }
    void kameraMesafeAyarla()
    {
       // transform.position = ball.transform.position - distance; //topun pozisyonundan mesafeyi çýkararak kameranýn pozisyonunu günceller.
        aimPosition = ball.transform.position-distance;
        cameraPosition = transform.position;
        cameraPosition = Vector3.Lerp(cameraPosition, aimPosition, 3*Time.deltaTime); // Vector3.Lerp() metodu unitynin kamera takip için metodu
        transform.position = cameraPosition; // cameraPosition deðiþkenini kameranýn pozisyonuna eþitledik.

    }
}
