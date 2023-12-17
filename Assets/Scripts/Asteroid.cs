using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    GameObject patlamaPrefab;
    OyunKontrol oyunKontrol;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        oyunKontrol = Camera.main.GetComponent<OyunKontrol>();

        float yon = Random.Range(0f, 1.0f);
        if (yon < 0.5)
        {
            rigidbody2D.AddForce(new Vector2(Random.Range(-2.5f, -1.0f), Random.Range(-2.5f, -1.0f)), ForceMode2D.Impulse);
            rigidbody2D.AddTorque(yon * 10.0f);
        }
        else
        {
            rigidbody2D.AddForce(new Vector2(Random.Range(1.0f, 2.5f), Random.Range(-2.5f, -1.0f)), ForceMode2D.Impulse);
            rigidbody2D.AddTorque(-yon * 10.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)  //collider metodunda trigger açýlýr ve çarpma sonrasý itme uygulanmaz.
    {
        if (collider.gameObject.tag == "Kursun") 
        {
            FindObjectOfType<SesKontrol2>().Boom();    
            oyunKontrol.AsteroidYokOldu(gameObject);
            AsteroidYokEt();
        }
    }

    public void AsteroidYokEt()
    {
        Instantiate(patlamaPrefab, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
