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
    public int upgradeValue = 0;
    TextMeshProUGUI priceTXT;
    Image upgradeImage;
    Button upgradeButton;

    // Start is called before the first frame update
    void Start()
    {
        priceTXT = priceOBJ.GetComponent<TextMeshProUGUI>();
        upgradeImage = GetComponent<Image>();
        upgradeButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        //Se o valor do upgrade for 0 então o preco será o preco inicial
        if(upgradeValue == 0)
        {
            price = firstPrice;
        }

        priceTXT.text = "$" + price + " | " + upgradeValue + "/" + maxUpgradeValue;

        //Se o upgrade não pode mais ser comprado ele fica meio transparente
        if (!canBuy())
        {
            upgradeButton.enabled = false;
            upgradeImage.color = new Color32(255, 255, 255, 20);
        }
    }

    //Funcao para pegar o preco do upgrade
    public int GetPrice()
    {
        return price;
    }

    //Funcao para definir o preco do upgrade
    public void SetPrice(int n, int v)
    {
        price = n;
        upgradeValue = v;
    }

    //Funcao para comprar o upgrade
    public void BuyUpgrade()
    {
        upgradeValue += 1;
        price = price * priceMultiplier;
    }

    //Funcao que indica se o upgrade pode ou não ser comprado
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

    //Funcao para pegar o valor do upgrade amount
    public float GetUpgradeAmount()
    {
        return upgradeAmount;
    }

}
