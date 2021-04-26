﻿using System.Collections;
using System.Collections.Generic;
using _Code.Toolbox.SimpleValues;
using UnityEngine;

[CreateAssetMenu(fileName = "IncrBasedOnDifficulty", menuName = "CustomScriptables/StructValue/IncrBasedOnDifficulty")]
public class TimeIncrementBasedOnDifficulty : ScriptableObject
{
    [SerializeField] private DifficultyHolder _difficultyHolder;
    [SerializeField] private FloatValue _remainingTimeScriptable;

    public void AddTimeBasedOnDifficulty()
    {
        _remainingTimeScriptable.AddToValue(_difficultyHolder.GetDifficulty().Increment);
    }
}
