using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class PlayerAbillity : MonoBehaviour
{
    public event EventHandler<OnAbillityUlockedEventArgs> OnAbillityUnlocked;

    public class OnAbillityUlockedEventArgs : EventArgs
    {
        public AbillityType AbillityType;
    }

    public enum AbillityType
    {
        None,
        EasyStep,
        SecondWind,
        BattleHungry,
        FuriousBlow,
        InnerPeace,
        ShockWave,
        Thunderbolt,
        Thunderclap, //юзабельный
        PowerOfHeaven,
        Novice
    }

    private List<AbillityType> unblockedAbilities;

    public PlayerAbillity()
    {
        unblockedAbilities = new List<AbillityType>();
    }

    private void UnlockAbillity(AbillityType abillity)
    {
        if (!IsAbillityUnlocked(abillity))
        {
            unblockedAbilities.Add(abillity);
            OnAbillityUnlocked?.Invoke(this, new OnAbillityUlockedEventArgs { AbillityType = abillity }); //???
        }
    }

    public bool IsAbillityUnlocked(AbillityType abillity)
    {
        return unblockedAbilities.Contains(abillity);
    }

    public AbillityType GetAbillityType(AbillityType abillity)
    {
        switch (abillity)
        {
            case AbillityType.SecondWind: return AbillityType.EasyStep;
        }

        return AbillityType.None;
    }

    public bool TryUnlockSkill(AbillityType abillity)
    {
        AbillityType abillityRequirement = GetAbillityType(abillity);

        if(abillityRequirement != AbillityType.None)
        {
            if (IsAbillityUnlocked(abillityRequirement))
            {
                UnlockAbillity(abillityRequirement);
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            UnlockAbillity(abillity);
            return true;
        }
    }
}
