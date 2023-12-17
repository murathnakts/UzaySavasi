using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OyunKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject uzayGemisiPrefab;
    GameObject uzayGemisi;
    [SerializeField]
    List<GameObject> asteroidPrefabs = new List<GameObject>();
    List<GameObject> asteroidList = new List<GameObject>();
    UIKontrol uiKontrol;
    [SerializeField]
    int zorluk = 1;
    [SerializeField]
    int carpan = 5;
    void Awake()
    {
        EkranHesaplayici.Init();
    }

    // Start is called before the first frame update
    void Start()
    {
        uiKontrol = GetComponent<UIKontrol>();
    }

    public void OyunuBaslat()
    {
        uzayGemisi = Instantiate(uzayGemisiPrefab);
        uzayGemisi.transform.position = new Vector3(0, EkranHesaplayici.Alt + 1.5f);
        AsteroidUret(carpan);
    }

    void AsteroidUret(int adet)
    {
        Vector3 position = new Vector3();

        for (int i = 0; i < adet; i++) 
        {
            position.z = -Camera.main.transform.position.z;
            position = Camera.main.ScreenToWorldPoint(position);
            position.x = Random.Range(EkranHesaplayici.Sol,EkranHesaplayici.Sag);
            position.y = EkranHesaplayici.Ust - 1;
            
            GameObject asteroid = Instantiate(asteroidPrefabs[Random.RandomRange(0, 3)], position ,Quaternion.identity);  
            asteroidList.Add(asteroid);
        }
    }

    public void AsteroidYokOldu(GameObject asteroid)
    {
        uiKontrol.AsteroidYokOldu(asteroid);
        asteroidList.Remove(asteroid);
        if(asteroidList.Count == 0 )
        {
            zorluk++;
            AsteroidUret(zorluk * carpan);
        }
    }

    public void OyunuBitir()
    {
        foreach (GameObject asteroid in asteroidList)
        {
            asteroid.GetComponent<Asteroid>().AsteroidYokEt();
        }
        asteroidList.Clear();
        zorluk = 1;
        uiKontrol.OyunBitti();
    }
}