using System.Collections;
using System.Collections.Generic;
using TileVania2D.Abstracts.Inputs;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace TileVania2D.Inputs
{
    public class InputCrossPlatform : MonoBehaviour,IBaseInput
    {
        public float Horizontal => CrossPlatformInputManager.GetAxisRaw("Horizontal");
        public float Veritical => CrossPlatformInputManager.GetAxisRaw("Vertical");
        public bool IsJump => CrossPlatformInputManager.GetButton("Jump");
    }
}

