using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeriSayimSayaci : MonoBehaviour
{
    float toplamSure = 0;
    float gecenSure = 0;

    bool calisiyor = false;
    bool basladi = false;

    /// <summary>
    /// Geri Say�m Sayac�n�n Toplam S�resini Ayarlar.
    /// </summary>
    public float ToplamSure
    {
        set
        {
            if(!calisiyor)
            {
                toplamSure = value;
            }
        }
    }

    /// <summary>
    /// Geri Say�m�n Bitip Bitmedi�ini S�yler.
    /// </summary>
    public bool Bitti
    {
        get
        {
            return basladi && !calisiyor;
        }
    }

    /// <summary>
    /// Sayac� �al��t�r�r. 
    /// </summary>
    public void Calistir()
    {
        if (toplamSure > 0)
        {
            calisiyor = true;
            basladi = true;
            gecenSure = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (calisiyor)
        {
            gecenSure += Time.deltaTime;
            if (gecenSure >= toplamSure)
            {
                calisiyor = false;
            }
        }
    }
}
