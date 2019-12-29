using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UpgradeScript : MonoBehaviour
{
    public GameObject priceOBJ;
    public int firstPrice;
    public int priceMultiplier;
    public int maxUpgradeValue;
    public float upgradeAmount;
    int price = 0;
    int upgradeValue = 0;
    TextMeshProUGUI priceTXT;
    Image upgradeImage;
    Button upgradeButton;

    // Start is called before the first frame update
    void Start()
    {
        priceTXT = priceOBJ.GetComponent<TextMeshProUGUI>();
        price = firstPrice;
        upgradeImage = GetComponent<Image>();
        upgradeButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        priceTXT.text = "$" + price + " | " + upgradeValue + "/" + maxUpgradeValue;
        if (!canBuy())
        {
            upgradeButton.enabled = false;
            upgradeImage.color = new Color32(255, 255, 255, 20);
        }
    }

    public int GetPrice()
    {
        return price;
    }

    public void BuyUpgrade()
    {
        upgradeValue += 1;
        price = price * priceMultiplier;
    }

    public bool canBuy()
    {
        if (upgradeValue < maxUpgradeValue)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public float GetUpgradeAmount()
    {
        return upgradeAmount;
    }

}
