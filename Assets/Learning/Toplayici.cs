using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toplayici : MonoBehaviour
{
    
    [SerializeField]
    GameObject yildizPrefab;

    List<GameObject> yildizList = new List<GameObject>();

    /// <summary>
    /// Hedefteki Y�ld�z� S�yler.
    /// </summary>
    public GameObject HedefYildiz
    {
        get
        {
            if (yildizList.Count > 0)
            {
                return yildizList[0];
            } else
            {
                return null;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) 
        {
            Vector3 pos = Input.mousePosition;
            pos.z = -Camera.main.transform.position.z;
            Vector3 posOyun = Camera.main.ScreenToWorldPoint(pos);
            yildizList.Add(Instantiate(yildizPrefab,posOyun,Quaternion.identity));
        }
    }

    /// <summary>
    /// Parametre Olarak G�nderilen Y�ld�z� Yok Eder.
    /// </summary>
    /// <param name="yokEdilen"></param>
    public void YildizYokEt(GameObject yokEdilen)
    {
        yildizList.Remove(yokEdilen);
        Destroy(yokEdilen);
    }
}
