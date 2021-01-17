﻿using UnityEngine;

namespace _Code.MainCode
{
    public interface IMovePointBehavior
    {
        Transform MovePoint {get;}
        void StepTowards(Vector3 dir);
        void SetPosition(Vector3 pos);
    }
}