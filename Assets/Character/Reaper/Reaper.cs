using UnityEngine;

class Reaper : CharacterClass {
    public WeaponData MyWeapon;
    Reaper() {
        Name = "Reaper";
        MaxHealth = 100;
        ActHealth = MaxHealth;
        Armor = 10;
        DamageBase = 10;
        Level = 0;
        Mana = null;
        Description = "De sont vrai nom Valcap et ayant reçus une malédiction. Il a obtenu le pouvoir d'attirer ses ennemies afin de les provoquer pour ensuite les annihiler avec c'est pouvoir bien mystérieux";
    }
}