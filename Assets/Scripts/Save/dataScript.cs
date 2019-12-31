using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class dataScript{

    public int level;

    public int money;

    public int damageUpgrade;

    public int velocityUpgrade;

    public int fireRateUpgrade;

    public bool automaticUpgrade;


    //Construtor da classe, recebendo um info como referencia para os seus dados
    public dataScript(info inf)
    {
        level = inf.level;

        money = inf.money;

        damageUpgrade = inf.damageUpgrade;

        velocityUpgrade = inf.velocityUpgrade;

        fireRateUpgrade = inf.fireRateUpgrade;

        automaticUpgrade = inf.automaticUpgrade;

    }

}
