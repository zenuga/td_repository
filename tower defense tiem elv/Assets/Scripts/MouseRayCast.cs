using UnityEngine;

public class MouseRayCast : MonoBehaviour
{
    private Tile lastTile;
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red);

        if (Physics.Raycast(ray, out hit))
        {
            Tile obj = hit.collider.GetComponentInParent<Tile>();

            if (obj != null)
            {
                if (lastTile != obj && lastTile != null)
                {
                    lastTile.ResetColor();
                }

                obj.IsGetingHit();
                lastTile = obj;
                return;
            }
        }

        if (lastTile != null)
        {
            lastTile.ResetColor();
            lastTile = null;
        }
    }
}
