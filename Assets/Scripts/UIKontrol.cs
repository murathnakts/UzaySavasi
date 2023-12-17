using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKontrol : MonoBehaviour
{
    [SerializeField]
    GameObject oyunAdiText;
    [SerializeField]
    GameObject oyunBittiText;
    [SerializeField]
    Text puanText;
    [SerializeField]
    GameObject oynaButton;

    int puan;

    // Start is called before the first frame update
    void Start()
    {
        oyunBittiText.gameObject.SetActive(false);
        puanText.gameObject.SetActive(false);
    }

    public void OyunBasladi()
    {
        puan = 0;
        oyunAdiText.gameObject.SetActive(false);
        oynaButton.gameObject.SetActive(false);
        oyunBittiText.gameObject.SetActive(false);   
        puanText.gameObject.SetActive(true);
        PuaniGuncelle();
    }

    public void OyunBitti()
    {
        oyunBittiText.gameObject.SetActive(true);
        oynaButton.gameObject.SetActive(true);
    }

    void PuaniGuncelle()
    {
        puanText.text = "Puan: " + puan;
    }

    public void AsteroidYokOldu(GameObject asteroid)
    {
       switch (asteroid.gameObject.name[8]) 
        {
            case '1':
                puan += 5;
                PuaniGuncelle();
                break;
            case '2':
                puan += 10;
                PuaniGuncelle();
                break;
            case '3':
                puan += 15;
                PuaniGuncelle();
                break;
            default:
                break;
        }
        
    }
}
