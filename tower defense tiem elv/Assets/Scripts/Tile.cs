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
        if (currentTurret != null)
        {
            Debug.Log("cant build here");
            return;
        }

        GameObject turretToBuild = BuildManeger.instance.GetTurretToBuild();
        currentTurret = (GameObject) Instantiate(turretToBuild, transform.position, transform. rotation);
        
    }

    
   
}
