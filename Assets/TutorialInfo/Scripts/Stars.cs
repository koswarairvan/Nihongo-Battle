using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public int starCount;
    public Result resval;

    // Update is called once per frame
    public void SetStar()
    {
        if (resval.result >= 0 && resval.result <=50 )
        {
            star1.SetActive(false);
            star2.SetActive(false);
            star3.SetActive(false);
            starCount=0;
        }
        else if (resval.result >= 51 && resval.result <=70 )
        {
            star1.SetActive(true);
            star2.SetActive(false);
            star3.SetActive(false);
            starCount=1;
        }
        else if (resval.result >= 71 && resval.result <=99 )
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(false);
            starCount=2;
        }
        else if (resval.result == 100 )
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
            starCount=3;
        }
    }
}
