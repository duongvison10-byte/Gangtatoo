using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public List<WeaponData> startingWeapons; 
    public Transform[] weaponSlots;

    private List<GameObject> activeWeapons = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < startingWeapons.Count; i++)
        {
            EquipWeapon(startingWeapons[i], i);
        }
    }

    public void EquipWeapon(WeaponData newWeaponData, int slotIndex)
    {
        if (slotIndex >= weaponSlots.Length) return;

     
        GameObject weaponObj = Instantiate(newWeaponData.weaponPrefab, weaponSlots[slotIndex]);

        
        WeaponController controller = weaponObj.GetComponent<WeaponController>();
        if (controller != null)
        {
            controller.data = newWeaponData;
        }

        activeWeapons.Add(weaponObj);
    }

}