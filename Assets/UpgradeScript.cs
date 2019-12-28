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
    int price = 0;
    int upgradeValue = 0;
    TextMeshProUGUI priceTXT;

    // Start is called before the first frame update
    void Start()
    {
        priceTXT = priceOBJ.GetComponent<TextMeshProUGUI>();
        price = firstPrice;
    }

    // Update is called once per frame
    void Update()
    {
        priceTXT.text = "$" + price + " | " + upgradeValue + "/" + maxUpgradeValue;
    }

    public int GetPrice()
    {
        return price;
    }
}
