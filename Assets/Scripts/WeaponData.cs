using UnityEngine;


[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon System/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public GameObject weaponPrefab;
    public GameObject projectilePrefab; 

    public float baseDamage = 10f;
    public float cooldown = 1f; 
    public float range = 5f;

    public WeaponTag weaponTag; 
}

public enum WeaponTag { Gun, Melee, Elemental, Heavy }