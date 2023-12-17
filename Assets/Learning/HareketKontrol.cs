using System;
using UnityEngine;

public class HareketKontrol : MonoBehaviour
{
    float colliderBoyYarim;
    float colliderEnYarim;

    // Start is called before the first frame update
    void Start()
    {
        //Objeyi Belirli Bir Y�nde Hareket Ettirme
        Rigidbody2D myrb2d = GetComponent<Rigidbody2D>();
        myrb2d.AddForce(new Vector2(UnityEngine.Random.Range(-5,5), UnityEngine.Random.Range(-5, 5)),ForceMode2D.Impulse);

        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        colliderBoyYarim = collider.size.y / 2;
        colliderEnYarim = collider.size.x / 2;
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("�arp��ma");
    }

    // Update is called once per frame
    void Update()
    {
        //Objenin Mouse �mlecini Takip Etmesini Sa�lama
        //Vector3 position = Input.mousePosition;
        //position.z = -Camera.main.transform.position.z;
        //position = Camera.main.ScreenToWorldPoint(position);
        //transform.position = position;
        //EkrandaKal();
    }

    void EkrandaKal()
    {  
        // Collider�n Orta Noktas�n� Hesaplayarak Ona G�re ��lem Yapma
        Vector3 position = transform.position;
        if(position.x - colliderEnYarim < EkranHesaplayici.Sol)
        {
            position.x = EkranHesaplayici.Sol + colliderEnYarim;
            
        } else if(position.x + colliderEnYarim > EkranHesaplayici.Sag)
        {
            position.x = EkranHesaplayici.Sag - colliderEnYarim;
        }
        if (position.y + colliderBoyYarim > EkranHesaplayici.Ust)
        {
            position.y = EkranHesaplayici.Ust - colliderBoyYarim;
        }
        else if (position.y - colliderBoyYarim < EkranHesaplayici.Alt)
        {
            position.y = EkranHesaplayici.Alt + colliderBoyYarim;
        }
        transform.position = position;
    }
}
