using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
	public static BuildManager instance;           //Singleton Pattern, i.e. only one instance of BuildManager must be in the project, other script with same name will give error

	public Text NotEnoughGoldTxt;
	private float timeToAppear = 1f;
	private float timeWhenDisappear = 2f;

	void Awake()
	{
		if (instance != null)
		{
			Debug.LogError("More than one BuildManager in scene!");
			return;
		}
		instance = this;
	}

	void Update()
	{
		if (NotEnoughGoldTxt.enabled && (Time.time >= timeWhenDisappear))
		{
			NotEnoughGoldTxt.enabled = false;
		}
	}

	private TowersBlueprint towerToBuild;

	public bool CanBuild { get { return towerToBuild != null; } }
	public bool HasMoney { get { return PlayerStats.Money >= towerToBuild.cost; } }

	public void BuildTowerOn(Node node)
	{
		if (PlayerStats.Money < towerToBuild.cost)
		{
			EnableText();
			Debug.Log("Not enough gold to build this Tower");
			FindObjectOfType<AudioManager>().Play("ShopError");
			return;
		}

		PlayerStats.Money -= towerToBuild.cost;

		GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
		node.tower = tower;

		Debug.Log("Tower build! Gold Left:" + PlayerStats.Money);
	}

	public void SelectTowerToBuild(TowersBlueprint tower)
	{
		towerToBuild = tower;
	}

	void EnableText()
	{
		NotEnoughGoldTxt.text = "Not enough gold to build this Tower";
		NotEnoughGoldTxt.enabled = true;
		timeWhenDisappear = Time.time + timeToAppear;
	}
}
