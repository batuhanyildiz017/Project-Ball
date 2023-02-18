using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    [SerializeField]
    private float ballVelocity = 8f;
    bool gameIsStarted;
    bool gameIsFinished;
    bool isTheBallOnThePlatform;
    Rigidbody ballRigidbody;
    private void Awake() //metod oyun ba�lamadan �nce �a��r�l�r.
    {
        ballRigidbody = GetComponent<Rigidbody>(); //topun rigidbodysi ni tan�mlama
        gameIsStarted = false;
        gameIsFinished = false;
        isTheBallOnThePlatform = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !gameIsStarted)  //sol click yap�ld�ysa ve oyun daha ba�lamad�ysa topa x y�n�nde ilk hareketi ver
        {
            ballRigidbody.velocity = new Vector3(ballVelocity, 0, 0); //x yon�nde h�z verme
            gameIsStarted=true; //oyun ba�lad��� i�in true de�er girildi.
        }
        //topun platform �zerinde olup olmad���n� kontrol etme
        isTheBallOnThePlatform = Physics.Raycast(transform.position, Vector3.down); //transform.position topun bulundu�u pozisyon
        if (!isTheBallOnThePlatform)
        {
            //gameIsFinished = true;
            ballRigidbody.velocity = new Vector3(0, ballVelocity * -3, 0); // platform �zerinden ��kt���nda d��mesi
            Camera.main.GetComponent<CameraTracking>().isGameFinished = true; //camera tracking scriptinde oyunun bitip bitmedi�ini anlamak i�in
        }
        if (Input.GetMouseButtonDown(0)&& !gameIsFinished) //oyun bitmediyse ve sol click yap�ld�ysa topun pozisyonunu de�i�tir.
        {
            changeDirection();
        }
    }
    void changeDirection()
    {
        if (ballRigidbody.velocity.x>0)
        {
            ballRigidbody.velocity=new Vector3(0,0,ballVelocity);
        }
        else if (ballRigidbody.velocity.z > 0)
        {
            ballRigidbody.velocity = new Vector3(ballVelocity, 0, 0);
        }
    }
}
