using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ShopManager : MonoBehaviour {

    //Show Bird on selection
    public GameObject showSelectedbird;

    //Popups
    public GameObject textCongo, textOOPs;

    //For Updating Sprites
    public Sprite spriteSelect;
    public Sprite spriteSelected;
    public Sprite[] spriteBird;

    //Bird Selection System
    public static int selectedbird=1;

    //Products
    public GameObject[] selectButtons;
    int product2, product3, product4, product5, product6, product7, product8, product9;

    //bird sequence if it is purchased or not
    void Start()
    {
        //PlayerPrefs.DeleteAll();
        //GameOverManager.totalScore = 3000;
        GameOverManager.totalScore = PlayerPrefs.GetInt("totalScore");
        product2 = PlayerPrefs.GetInt("purchase2");
        product3 = PlayerPrefs.GetInt("purchase3");
        product4 = PlayerPrefs.GetInt("purchase4");
        product5 = PlayerPrefs.GetInt("purchase5");
        product6 = PlayerPrefs.GetInt("purchase6");
        product7 = PlayerPrefs.GetInt("purchase7");
        product8 = PlayerPrefs.GetInt("purchase8");
        product9 = PlayerPrefs.GetInt("purchase9");

        if (product2 == 1) { selectButtons[2].GetComponent<Image>().sprite = spriteSelect; selectButtons[2].transform.GetChild(0).gameObject.SetActive(false); }
        if (product3 == 1) { selectButtons[3].GetComponent<Image>().sprite = spriteSelect; selectButtons[3].transform.GetChild(0).gameObject.SetActive(false); }
        if (product4 == 1) { selectButtons[4].GetComponent<Image>().sprite = spriteSelect; selectButtons[4].transform.GetChild(0).gameObject.SetActive(false); }
        if (product5 == 1) { selectButtons[5].GetComponent<Image>().sprite = spriteSelect; selectButtons[5].transform.GetChild(0).gameObject.SetActive(false); }
        if (product6 == 1) { selectButtons[6].GetComponent<Image>().sprite = spriteSelect; selectButtons[6].transform.GetChild(0).gameObject.SetActive(false); }
        if (product7 == 1) { selectButtons[7].GetComponent<Image>().sprite = spriteSelect; selectButtons[7].transform.GetChild(0).gameObject.SetActive(false); }
        if (product8 == 1) { selectButtons[8].GetComponent<Image>().sprite = spriteSelect; selectButtons[8].transform.GetChild(0).gameObject.SetActive(false); }
        if (product9 == 1) { selectButtons[9].GetComponent<Image>().sprite = spriteSelect; selectButtons[9].transform.GetChild(0).gameObject.SetActive(false); }

    }

    public void OnClickproduct1()
    {
        selectButtons[1].GetComponent<Image>().sprite = spriteSelected;


        if (product2 == 1)
            selectButtons[2].GetComponent<Image>().sprite = spriteSelect;
        if (product3 == 1)
            selectButtons[3].GetComponent<Image>().sprite = spriteSelect;
        if (product4 == 1)
            selectButtons[4].GetComponent<Image>().sprite = spriteSelect;
        if (product5 == 1)
            selectButtons[5].GetComponent<Image>().sprite = spriteSelect;
        if (product6 == 1)
            selectButtons[6].GetComponent<Image>().sprite = spriteSelect;
        if (product7 == 1)
            selectButtons[7].GetComponent<Image>().sprite = spriteSelect;
        if (product8 == 1)
            selectButtons[8].GetComponent<Image>().sprite = spriteSelect;
        if (product9 == 1)
            selectButtons[9].GetComponent<Image>().sprite = spriteSelect;

        showSelectedbird.GetComponent<Image>().sprite = spriteBird[0];
        selectedbird = 1;

    }

    public void OnClickProduct2()
    {
        if(product2 == 0) {

            if (GameOverManager.totalScore >= 300)
            {
                textCongo.SetActive(true);
                selectButtons[2].GetComponent<Image>().sprite = spriteSelect;
                selectButtons[2].transform.GetChild(0).gameObject.SetActive(false);
                GameOverManager.totalScore -= 300;
                PlayerPrefs.SetInt("totalScore", GameOverManager.totalScore);
                PlayerPrefs.SetInt("purchase2", 1);
                PlayerPrefs.Save();
                product2 = 1;
            }
            else
            {
                textOOPs.SetActive(true);
                Invoke("OnClickBuyCoins", 1.3f);
            }
        }
        else
        {
            selectButtons[2].GetComponent<Image>().sprite = spriteSelected;

           
            selectButtons[1].GetComponent<Image>().sprite = spriteSelect;
            if (product3 == 1)
                selectButtons[3].GetComponent<Image>().sprite = spriteSelect;
            if (product4== 1)
                selectButtons[4].GetComponent<Image>().sprite = spriteSelect;
            if (product5 == 1)
                selectButtons[5].GetComponent<Image>().sprite = spriteSelect;
            if (product6 == 1)
                selectButtons[6].GetComponent<Image>().sprite = spriteSelect;
            if (product7 == 1)
                selectButtons[7].GetComponent<Image>().sprite = spriteSelect;
            if (product8 == 1)
                selectButtons[8].GetComponent<Image>().sprite = spriteSelect;
            if (product9 == 1)
                selectButtons[9].GetComponent<Image>().sprite = spriteSelect;

            selectedbird = 2;
            showSelectedbird.GetComponent<Image>().sprite = spriteBird[1];
        }
    }

    public void OnClickProduct3()
    {
        if (product3 == 0)
        {

            if (GameOverManager.totalScore >= 500)
            {
                textCongo.SetActive(true);
                selectButtons[3].GetComponent<Image>().sprite = spriteSelect;
                selectButtons[3].transform.GetChild(0).gameObject.SetActive(false);
                GameOverManager.totalScore -= 500;
                PlayerPrefs.SetInt("totalScore", GameOverManager.totalScore);
                PlayerPrefs.SetInt("purchase3", 1);
                PlayerPrefs.Save();
                product3 = 1;
            }
            else
            {
                textOOPs.SetActive(true);
                Invoke("OnClickBuyCoins", 1.3f);
            }
        }
        else
        {
            selectButtons[3].GetComponent<Image>().sprite = spriteSelected;
            selectButtons[1].GetComponent<Image>().sprite = spriteSelect;
            if (product2 == 1)
                selectButtons[2].GetComponent<Image>().sprite = spriteSelect;
            if (product4 == 1)
                selectButtons[4].GetComponent<Image>().sprite = spriteSelect;
            if (product5 == 1)
                selectButtons[5].GetComponent<Image>().sprite = spriteSelect;
            if (product6 == 1)
                selectButtons[6].GetComponent<Image>().sprite = spriteSelect;
            if (product7 == 1)
                selectButtons[7].GetComponent<Image>().sprite = spriteSelect;
            if (product8 == 1)
                selectButtons[8].GetComponent<Image>().sprite = spriteSelect;
            if (product9 == 1)
                selectButtons[9].GetComponent<Image>().sprite = spriteSelect;
            selectedbird = 3;
            showSelectedbird.GetComponent<Image>().sprite = spriteBird[2];
        }
    }

    public void OnClickProduct4()
    {
        if (product4 == 0)
        {

            if (GameOverManager.totalScore >= 700)
            {
                textCongo.SetActive(true);
                selectButtons[4].GetComponent<Image>().sprite = spriteSelect;
                selectButtons[4].transform.GetChild(0).gameObject.SetActive(false);
               // selectButtons[4].GetComponentInChildren<Text>().enabled = false;
                GameOverManager.totalScore -= 700;
                PlayerPrefs.SetInt("totalScore", GameOverManager.totalScore);
                PlayerPrefs.SetInt("purchase4", 1);
                PlayerPrefs.Save();
                product4 = 1;
            }
            else
            {
                textOOPs.SetActive(true);
                Invoke("OnClickBuyCoins", 1.3f);
            }
        }
        else
        {
            showSelectedbird.GetComponent<Image>().sprite = spriteBird[3];

            selectedbird = 4;
            selectButtons[4].GetComponent<Image>().sprite = spriteSelected;
            selectButtons[1].GetComponent<Image>().sprite = spriteSelect;
            if (product3 == 1)
                selectButtons[3].GetComponent<Image>().sprite = spriteSelect;
            if (product2 == 1)
                selectButtons[2].GetComponent<Image>().sprite = spriteSelect;
            if (product5 == 1)
                selectButtons[5].GetComponent<Image>().sprite = spriteSelect;
            if (product6 == 1)
                selectButtons[6].GetComponent<Image>().sprite = spriteSelect;
            if (product7 == 1)
                selectButtons[7].GetComponent<Image>().sprite = spriteSelect;
            if (product8 == 1)
                selectButtons[8].GetComponent<Image>().sprite = spriteSelect;
            if (product9 == 1)
                selectButtons[9].GetComponent<Image>().sprite = spriteSelect;
        }
    }


    public void OnClickProduct5()
    {
        if (product5 == 0)
        {

            if (GameOverManager.totalScore >= 900)
            {
                textCongo.SetActive(true);
                selectButtons[5].GetComponent<Image>().sprite = spriteSelect;
                
                selectButtons[5].transform.GetChild(0).gameObject.SetActive(false);
                GameOverManager.totalScore -= 900;
                PlayerPrefs.SetInt("totalScore", GameOverManager.totalScore);
                PlayerPrefs.SetInt("purchase5", 1);
                PlayerPrefs.Save();
                product5 = 1;

            }
            else
            {
                textOOPs.SetActive(true);
                Invoke("OnClickBuyCoins", 1.3f);
            }
        }
        else
        {
            showSelectedbird.GetComponent<Image>().sprite = spriteBird[4];
            selectedbird = 5;
            selectButtons[5].GetComponent<Image>().sprite = spriteSelected;
            selectButtons[1].GetComponent<Image>().sprite = spriteSelect;
            if (product3 == 1)
                selectButtons[3].GetComponent<Image>().sprite = spriteSelect;
            if (product4 == 1)
                selectButtons[4].GetComponent<Image>().sprite = spriteSelect;
            if (product2 == 1)
                selectButtons[2].GetComponent<Image>().sprite = spriteSelect;
            if (product6 == 1)
                selectButtons[6].GetComponent<Image>().sprite = spriteSelect;
            if (product7 == 1)
                selectButtons[7].GetComponent<Image>().sprite = spriteSelect;
            if (product8 == 1)
                selectButtons[8].GetComponent<Image>().sprite = spriteSelect;
            if (product9 == 1)
                selectButtons[9].GetComponent<Image>().sprite = spriteSelect;
        }
    }

    public void OnClickProduct6()
    {
        if (product6 == 0)
        {

            if (GameOverManager.totalScore >= 1300)
            {
                
                textCongo.SetActive(true);
                selectButtons[6].GetComponent<Image>().sprite = spriteSelect;
                selectButtons[6].transform.GetChild(0).gameObject.SetActive(false);
                GameOverManager.totalScore -= 1300;
                PlayerPrefs.SetInt("totalScore", GameOverManager.totalScore);
                PlayerPrefs.SetInt("purchase6", 1);
                PlayerPrefs.Save();
                product6 = 1;
            }
            else
            {
                textOOPs.SetActive(true);
                Invoke("OnClickBuyCoins", 1.3f);
            }
        }
        else
        {
            showSelectedbird.GetComponent<Image>().sprite = spriteBird[5];
            selectedbird = 6;
            selectButtons[6].GetComponent<Image>().sprite = spriteSelected;
            selectButtons[1].GetComponent<Image>().sprite = spriteSelect;
            if (product3 == 1)
                selectButtons[3].GetComponent<Image>().sprite = spriteSelect;
            if (product4 == 1)
                selectButtons[4].GetComponent<Image>().sprite = spriteSelect;
            if (product5 == 1)
                selectButtons[5].GetComponent<Image>().sprite = spriteSelect;
            if (product2 == 1)
                selectButtons[2].GetComponent<Image>().sprite = spriteSelect;
            if (product7 == 1)
                selectButtons[7].GetComponent<Image>().sprite = spriteSelect;
            if (product8 == 1)
                selectButtons[8].GetComponent<Image>().sprite = spriteSelect;
            if (product9 == 1)
                selectButtons[9].GetComponent<Image>().sprite = spriteSelect;
        }
    }

    public void OnClickProduct7()
    {
        if (product7 == 0)
        {

            if (GameOverManager.totalScore >= 1500)
            {
                textCongo.SetActive(true);
                selectButtons[7].GetComponent<Image>().sprite = spriteSelect;
                selectButtons[7].transform.GetChild(0).gameObject.SetActive(false);
                GameOverManager.totalScore -= 1500;
                PlayerPrefs.SetInt("totalScore", GameOverManager.totalScore);
                PlayerPrefs.SetInt("purchase7", 1);
                PlayerPrefs.Save();
                product7 = 1;
            }
            else
            {
                textOOPs.SetActive(true);
                Invoke("OnClickBuyCoins", 1.3f);
            }

        }
        else
        {
            showSelectedbird.GetComponent<Image>().sprite = spriteBird[6];
            selectedbird = 7;
            selectButtons[1].GetComponent<Image>().sprite = spriteSelect;
            if (product3 == 1)
                selectButtons[3].GetComponent<Image>().sprite = spriteSelect;
            if (product4 == 1)
                selectButtons[4].GetComponent<Image>().sprite = spriteSelect;
            if (product5 == 1)
                selectButtons[5].GetComponent<Image>().sprite = spriteSelect;
            if (product6 == 1)
                selectButtons[6].GetComponent<Image>().sprite = spriteSelect;
            if (product2 == 1)
                selectButtons[2].GetComponent<Image>().sprite = spriteSelect;
            if (product8 == 1)
                selectButtons[8].GetComponent<Image>().sprite = spriteSelect;
            if (product9 == 1)
                selectButtons[9].GetComponent<Image>().sprite = spriteSelect;
            selectButtons[7].GetComponent<Image>().sprite = spriteSelected;
        }
    }

    public void OnClickProduct8()
    {
        if (product8 == 0)
        {

            if (GameOverManager.totalScore >= 1500)
            {
                textCongo.SetActive(true);
                selectButtons[8].GetComponent<Image>().sprite = spriteSelect;
                selectButtons[8].transform.GetChild(0).gameObject.SetActive(false);
                GameOverManager.totalScore -= 1500;
                PlayerPrefs.SetInt("totalScore", GameOverManager.totalScore);
                PlayerPrefs.SetInt("purchase8", 1);
                PlayerPrefs.Save();
                product8 = 1;
            }
            else
            {
                textOOPs.SetActive(true);
                Invoke("OnClickBuyCoins", 1.3f);
            }


        }
        else
        {
            selectedbird = 8;
            showSelectedbird.GetComponent<Image>().sprite = spriteBird[7];
            selectButtons[1].GetComponent<Image>().sprite = spriteSelect;
            if (product3 == 1)
                selectButtons[3].GetComponent<Image>().sprite = spriteSelect;
            if (product4 == 1)
                selectButtons[4].GetComponent<Image>().sprite = spriteSelect;
            if (product5 == 1)
                selectButtons[5].GetComponent<Image>().sprite = spriteSelect;
            if (product6 == 1)
                selectButtons[6].GetComponent<Image>().sprite = spriteSelect;
            if (product7 == 1)
                selectButtons[7].GetComponent<Image>().sprite = spriteSelect;
            if (product2 == 1)
                selectButtons[2].GetComponent<Image>().sprite = spriteSelect;
            if (product9 == 1)
                selectButtons[9].GetComponent<Image>().sprite = spriteSelect;
            selectButtons[8].GetComponent<Image>().sprite = spriteSelected;
        }
    }

    public void OnClickProduct9()
    {
        if (product9 == 0)
        {

            if (GameOverManager.totalScore >= 1700)
            {
                textCongo.SetActive(true);
                selectButtons[9].GetComponent<Image>().sprite = spriteSelect;
                selectButtons[9].transform.GetChild(0).gameObject.SetActive(false);
                GameOverManager.totalScore -= 1700;
                PlayerPrefs.SetInt("totalScore", GameOverManager.totalScore);
                PlayerPrefs.SetInt("purchase9", 1);
                PlayerPrefs.Save();
                product9 = 1;
            }
            else
            {
                textOOPs.SetActive(true);
                Invoke("OnClickBuyCoins",1.3f);
            }
               
        }
        else
        {
            showSelectedbird.GetComponent<Image>().sprite = spriteBird[8];
            selectedbird = 9;
            selectButtons[1].GetComponent<Image>().sprite = spriteSelect;
            if (product3 == 1)
                selectButtons[3].GetComponent<Image>().sprite = spriteSelect;
            if (product4 == 1)
                selectButtons[4].GetComponent<Image>().sprite = spriteSelect;
            if (product5 == 1)
                selectButtons[5].GetComponent<Image>().sprite = spriteSelect;
            if (product6 == 1)
                selectButtons[6].GetComponent<Image>().sprite = spriteSelect;
            if (product7 == 1)
                selectButtons[7].GetComponent<Image>().sprite = spriteSelect;
            if (product8 == 1)
                selectButtons[8].GetComponent<Image>().sprite = spriteSelect;
            if (product2 == 1)
                selectButtons[2].GetComponent<Image>().sprite = spriteSelect;
            selectButtons[9].GetComponent<Image>().sprite = spriteSelected;
        }
    }



    // Store Purchases
    public GameObject BuyPanel;
    public void OnClickBuyCoins()
    {
        BuyPanel.SetActive(true);
    }

    public void OnClickCloseBuyPanel()
    {
        BuyPanel.SetActive(false);
    }

    
    public static bool coinsAdsbool=false;
    // Advertisement Coins Free
    public void OnClickWatchtoAddCoins()
    {
        ShopManager.coinsAdsbool = true;
        Debug.Log("state"+ ShopManager.coinsAdsbool);
        UnityAdsManager.Instance.ShowRewardedVideoAd();
    }


}
