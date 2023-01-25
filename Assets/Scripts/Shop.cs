using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TowersBlueprint fireTower;
    public TowersBlueprint iceTower;
    public TowersBlueprint wizardTower;

    BuildManager buildManager;

    void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectFireTower()
    {
        Debug.Log("Fire Tower Selected");
        buildManager.SelectTowerToBuild(fireTower);
        FindObjectOfType<AudioManager>().Play("ShopButton");
    }

    public void SelectIceTower()
    {
        Debug.Log("Ice Tower Selected");
        buildManager.SelectTowerToBuild(iceTower);
        FindObjectOfType<AudioManager>().Play("ShopButton");
    }

    public void SelectWizardTower()
    {
        Debug.Log("Wizard Tower Selected");
        buildManager.SelectTowerToBuild(wizardTower);
        FindObjectOfType<AudioManager>().Play("ShopButton");
    }

}
