using UnityEngine;

// Tạo menu chuột phải để tạo Data mới
[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon System/Weapon Data")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public GameObject weaponPrefab; // Prefab hình ảnh súng để hiển thị quanh nhân vật
    public GameObject projectilePrefab; // Dành cho súng (viên đạn)

    public float baseDamage = 10f;
    public float cooldown = 1f; // 1 giây bắn 1 lần
    public float range = 5f;

    public WeaponTag weaponTag; // Enum hệ vũ khí (Súng, Cận chiến...)
}

public enum WeaponTag { Gun, Melee, Elemental, Heavy }