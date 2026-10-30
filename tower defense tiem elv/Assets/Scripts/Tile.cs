using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;


public class Tile : MonoBehaviour
{
    public Color hoverColor;
    private GameObject currentTurret;

    private Renderer rend;
    private Color startColor;
   

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    public void IsGetingHit()
    {
        rend.material.color = hoverColor;
    }

    public void ResetColor()
    {
        rend.material.color = startColor;
    }

    public void IsGetingClicked()
    {
        GameObject turretToBuild = BuildManeger.instance.GetTurretToBuild();

        if (turretToBuild == null)
        {
            Debug.LogError("No turret prefab is selected.");
            return;
        }

        if (currentTurret != null)
        {
            Debug.Log("cant build here");
            return;
        }

        Turret turret = turretToBuild.GetComponent<Turret>();
        if (turret == null)
        {
            Debug.LogError("The selected turret prefab has no Turret component.");
            return;
        }

        if (MoneyAndLifesManager.Instance.Money < turret.price)
        {
            Debug.Log("not enough money");
            return;
        }

        currentTurret = Instantiate(turretToBuild, transform.position + Vector3.up * 2f, transform.rotation);
        MoneyAndLifesManager.Instance.ChangeMoney(turret.price);
    }

    
   
}
