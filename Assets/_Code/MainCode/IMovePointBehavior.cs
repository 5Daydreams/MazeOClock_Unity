﻿using UnityEngine;

namespace _Code.MainCode
{
    public interface IMovePointBehavior
    {
        Transform MovePoint {get;}
        void StepTowards(Vector2 dir);
    }
}