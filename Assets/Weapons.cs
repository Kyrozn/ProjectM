using UnityEngine;
public class Weapons : MonoBehaviour
{
    public WeaponData weaponData; // Référence au ScriptableObject

    public virtual void Attack()
    {
        Debug.Log($"{weaponData.weaponName} attacks, dealing {weaponData.damageBase} damage of type {weaponData.damageType}!");
    }

    public void ApplyEffect()
    {
        if (weaponData.effect != Effect.None)
        {
            Debug.Log($"{weaponData.weaponName} applies {weaponData.effect} effect!");
        }
    }

    public enum DamageType
    {
        Physical,
        Magical,
        Hybride
    }

    public enum Effect
    {
        None,
        Burning,
        Freezing,
        Poisoning
    }

    public enum Rarity
    {
        Common,
        Rare,
        Epic,
        Legendary,
        Unique
    }
}

public class RangeWeapon : Weapons
{
    public override void Attack()
    {
        if (weaponData.ammo > 0)
        {
            weaponData.ammo--;
            Debug.Log($"{weaponData.weaponName} shoots, dealing {weaponData.damageBase} damage. Remaining ammo: {weaponData.ammo}.");
        }
        else
        {
            Debug.Log($"{weaponData.weaponName} is out of ammo!");
        }
    }

    public void Reload()
    {
        Debug.Log($"{weaponData.weaponName} is reloading... Time: {weaponData.reloadSpeed} seconds.");
        weaponData.ammo = 10;
    }
}

public class ManaWeapon : Weapons
{
    public override void Attack()
    {
        Debug.Log($"{weaponData.weaponName} casts a spell, consuming {weaponData.manaConsumption} mana and dealing {weaponData.damageBase} damage.");
    }
}
