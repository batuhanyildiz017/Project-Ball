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
    private void Awake() //metod oyun baþlamadan önce çaðýrýlýr.
    {
        ballRigidbody = GetComponent<Rigidbody>(); //topun rigidbodysi ni tanýmlama
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
        if (Input.GetMouseButtonDown(0) && !gameIsStarted)  //sol click yapýldýysa ve oyun daha baþlamadýysa topa x yönünde ilk hareketi ver
        {
            ballRigidbody.velocity = new Vector3(ballVelocity, 0, 0); //x yonünde hýz verme
            gameIsStarted=true; //oyun baþladýðý için true deðer girildi.
        }
        //topun platform üzerinde olup olmadýðýný kontrol etme
        isTheBallOnThePlatform = Physics.Raycast(transform.position, Vector3.down); //transform.position topun bulunduðu pozisyon
        if (!isTheBallOnThePlatform)
        {
            //gameIsFinished = true;
            ballRigidbody.velocity = new Vector3(0, ballVelocity * -3, 0); // platform üzerinden çýktýðýnda düþmesi
            Camera.main.GetComponent<CameraTracking>().isGameFinished = true; //camera tracking scriptinde oyunun bitip bitmediðini anlamak için
        }
        if (Input.GetMouseButtonDown(0)&& !gameIsFinished) //oyun bitmediyse ve sol click yapýldýysa topun pozisyonunu deðiþtir.
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
