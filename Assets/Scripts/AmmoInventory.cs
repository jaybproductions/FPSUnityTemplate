using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoInventory : MonoBehaviour
{
   


[System.Serializable]
public struct AmmoEntry
    {
#if UNITY_EDITOR
        [HideInInspector]
        public string name;

#endif
        public int maxCapacity;
        public int stock;



    }


    // Keep a list of ammo stock

    [SerializeField]
    List<AmmoEntry> _inventory = new List<AmmoEntry>();


    // Since enum is int, can use it
    // as an index 

    public int GetStock(AmmoType type)
    {
        return _inventory[(int)type].stock;

    }


    //Returns amount collected so you can choose not to consume
    // pickups if youre already full ie. return value is 0


    public int Collect(AmmoType type, int amount)
    {

        AmmoEntry held = _inventory[(int)type];
        int collect = Mathf.Min(amount, held.maxCapacity - held.stock);
        held.stock += collect;
        _inventory[(int)type] = held;
        return collect;


    }





    // returns the amount spent, in case of firing a full round
    // would drop us below 0 ammo, you can scale down the last shot
    // you could also implement TrySpend thay aborts for no ammo


    public int Spend(AmmoType type, int amount)
    {
        AmmoEntry held = _inventory[(int)type];
        int spend = Mathf.Min(amount, held.stock);
        held.stock -= spend;
        _inventory[(int)type] = held;
        return spend;



    }



   

    // Ensure our inventory lsit always matches the enum
    // you could also use a custom editor to maintain this


#if UNITY_EDITOR

    void Reset()
    {

        OnValidate();


    }

     void OnValidate()
    {
        var ammoNames = System.Enum.GetNames(typeof(AmmoType));
        var inventory = new List<AmmoEntry>(ammoNames.Length);

        for(int i = 0; i < ammoNames.Length; i++)
        {
            var existing = _inventory.Find((entry) => { return entry.name == ammoNames[i]; });
            existing.name = ammoNames[i];
            existing.stock = Mathf.Min(existing.stock, existing.maxCapacity);
            inventory.Add(existing);


        }

        _inventory = inventory;


    }

#endif

}
