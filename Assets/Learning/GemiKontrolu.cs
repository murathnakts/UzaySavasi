using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemiKontrolu : MonoBehaviour
{
    const float hareketGucu = 5;

    bool toplama = false;
    GameObject hedef;
    Rigidbody2D myRigidbody2d;
    Toplayici toplayici;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2d = GetComponent<Rigidbody2D>();
        toplayici = Camera.main.GetComponent<Toplayici>();
    }

    void OnMouseDown()
    {
        if (!toplama)
        {
            GitTopla();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == hedef)
        {
            toplayici.YildizYokEt(hedef);
            myRigidbody2d.velocity = Vector2.zero;
            GitTopla();
        }
    }

    void GitTopla()
    {
        hedef = toplayici.HedefYildiz;
        if (hedef != null)
        {
            Vector2 gidilecekYer = new Vector2(hedef.transform.position.x - transform.position.x, 
                hedef.transform.position.y - transform.position.y);
            gidilecekYer.Normalize();
            myRigidbody2d.AddForce(gidilecekYer * hareketGucu,ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 position = transform.position;

        //float yatayInput = Input.GetAxis("Horizontal");
        //float dikeyInput = Input.GetAxis("Vertical");

        //if (yatayInput != 0)
        //{
        //    position.x += yatayInput * hareketGucu * Time.deltaTime;
        //}
        
        //if (dikeyInput != 0)
        //{
        //    position.y += dikeyInput * hareketGucu * Time.deltaTime;
        //}
        //transform.position = position;
    }
}
