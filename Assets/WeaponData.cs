using UnityEngine;

[CreateAssetMenu(fileName = "NewWeapon", menuName = "Weapons/Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public float damageBase;
    public Weapons.DamageType damageType;
    public float range;
    public float attackSpeed;
    public bool isLootable;
    public Weapons.Effect effect;
    public Weapons.Rarity rarity;

    // Spécifique aux armes à distance
    public int ammo;
    public float reloadSpeed;

    // Spécifique aux armes utilisant du mana
    public int manaConsumption;
}
