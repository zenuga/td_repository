using NUnit.Framework;
using UnityEngine;

public class BuildManeger : MonoBehaviour
{
    public static BuildManeger instance;

    void Awake()
    {
        if(instance != null)
        {
            Debug.Log("more then 1 build maneger in csene");
            return;
        }
        
        instance = this;
    }



    public GameObject standerdTurretPrefab;
    void Start()
    {
        turretToBuild = standerdTurretPrefab;
    }

    private GameObject turretToBuild;
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

}
