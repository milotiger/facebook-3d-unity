using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using WindowsInput;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using Debug = UnityEngine.Debug;

namespace Assets.MoveEvents
{
    public abstract class MoveEvent
    {
        public abstract void Exec(float value);

        protected void HoldAndRelease(VirtualKeyCode Code, float Duration)
        {
            InputSimulator.SimulateKeyDown(Code);
            Wait(Duration);
            InputSimulator.SimulateKeyUp(Code);
        }

        protected void Press(VirtualKeyCode Code)
        {
            InputSimulator.SimulateKeyPress(Code);
        }

        private void Wait(float s)
        {
            Stopwatch sw = Stopwatch.StartNew();
            float tick = s * Stopwatch.Frequency;
            while (sw.ElapsedTicks < tick)
            { }
        }
    }

    public class MoveLeft : MoveEvent
    {
        public override void Exec(float value)
        {
            Debug.Log("Move left......");
            HoldAndRelease(VirtualKeyCode.VK_A, value);
        }
    }

    public class MoveRight : MoveEvent
    {
        public override void Exec(float value)
        {
            Debug.Log("Move right......");
            HoldAndRelease(VirtualKeyCode.VK_D, value);
        }
    }

    public class MoveForward : MoveEvent
    {
        public override void Exec(float value)
        {
            Debug.Log("Move forward......");
            HoldAndRelease(VirtualKeyCode.VK_W, value);
        }
    }

    public class MoveBackward : MoveEvent
    {
        public override void Exec(float value)
        {
            Debug.Log("Move backward......");
            HoldAndRelease(VirtualKeyCode.VK_S, value);
        }
    }

    public class Enter : MoveEvent
    {
        public override void Exec(float value)
        {
            Debug.Log("Press Enter......");
            Press(VirtualKeyCode.RETURN);
        }
    }

    public class Escape : MoveEvent
    {
        public override void Exec(float value)
        {
            Debug.Log("Press Escape......");
            Press(VirtualKeyCode.ESCAPE);
        }
    }
}
