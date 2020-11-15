using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TileVania2D.Abstracts.Inputs
{
    public interface IBaseInput
    {
        float Horizontal { get; }
        float Veritical { get; }
        bool IsJump { get; }
    }
}

