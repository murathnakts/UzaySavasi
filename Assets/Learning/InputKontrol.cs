using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject asteroidPrefab;

    List<GameObject> asteroidList = new List<GameObject>();
    //GameObject[] asteroidler = new GameObject[4];   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(Input.mousePosition);

            Vector3 position = Input.mousePosition;
            //Z Deðerini Negatif Yaparak Oyuna Adapte Etme
            position.z = -Camera.main.transform.position.z;
            //Kordinatlarý Oyun Dünyasýna Göre Çevirme
            position = Camera.main.ScreenToWorldPoint(position);

            //asteroidler[0] = Instantiate(asteroidPrefab, position, Quaternion.identity);
            //asteroidler[1] = Instantiate(asteroidPrefab, position, Quaternion.identity);
            //asteroidler[2] = Instantiate(asteroidPrefab, position, Quaternion.identity);
            //asteroidler[3] = Instantiate(asteroidPrefab, position, Quaternion.identity);

            for (int i = 0; i < 20; i++)
            {
                asteroidList.Add(Instantiate(asteroidPrefab, position, Quaternion.identity));
            }
        }

        if (Input.GetButtonDown("Fire2"))
        {
            //for (int i = 0; i < asteroidler.Length; i++)
            //{
            //    Destroy(asteroidler[i]);
            //}

            //for (int i = 0;i < asteroidList.Count; i++) 
            //{
            //    Destroy(asteroidList[i]);
            //}

            foreach (GameObject asteroid in asteroidList) 
            {
                Destroy(asteroid);
            }
            asteroidList.Clear();
        }
    }
}
