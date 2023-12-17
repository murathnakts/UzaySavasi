using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yokedici : MonoBehaviour
{
    [SerializeField]
    GameObject patlamaPrefab;

    GeriSayimSayaci geriSayimSayaci;

    // Start is called before the first frame update
    void Start()
    {
        geriSayimSayaci = gameObject.AddComponent<GeriSayimSayaci>();
        //geriSayimSayaci.ToplamSure = Random.Range(1,20);
        //geriSayimSayaci.Calistir();

    }

    // Update is called once per frame
    void Update()
    {
        if (geriSayimSayaci.Bitti)
        {
            Instantiate(patlamaPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void AsteroidYokedici(int sure)
    {
        geriSayimSayaci.ToplamSure = sure;
        geriSayimSayaci.Calistir();
    }
}
