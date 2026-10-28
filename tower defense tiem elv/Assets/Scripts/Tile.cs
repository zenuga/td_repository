using UnityEngine;
using UnityEngine.EventSystems;


public class Tile : MonoBehaviour
{
    public Color hoverColor;
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

    
   
}
