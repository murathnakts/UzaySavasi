using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GemiKontrol : MonoBehaviour
{
    const float hareketGucu = 5;

    [SerializeField]
    GameObject kursunPrefab;
    [SerializeField]
    GameObject patlamaPrefab;

    OyunKontrol oyunKontrol;

    // Start is called before the first frame update
    void Start()
    {
        oyunKontrol = Camera.main.GetComponent<OyunKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        float yatayInput = Input.GetAxis("Horizontal");
        float dikeyInput = Input.GetAxis("Vertical");

        if (yatayInput != 0)
        {
            position.x += yatayInput * hareketGucu * Time.deltaTime;
        }
        if (dikeyInput != 0)
        {
            position.y += dikeyInput * hareketGucu * Time.deltaTime;
        }
        transform.position = position;

        if(Input.GetButtonDown("Jump")) 
        {
            FindObjectOfType<SesKontrol>().Fire();
            Vector3 kursunPosition = gameObject.transform.position;
            kursunPosition.y += 1;
            Instantiate(kursunPrefab,kursunPosition,Quaternion.identity);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)  //collision metodunda trigger açýlmaz ve temas sonrasý itme uygulanýr. 
    {
        if(collision.gameObject.tag == "Asteroid") 
        {
            FindObjectOfType<SesKontrol2>().Boom();
            oyunKontrol.OyunuBitir();
            Instantiate(patlamaPrefab,gameObject.transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
} 
