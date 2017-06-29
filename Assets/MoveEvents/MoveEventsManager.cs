using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.MoveEvents
{
    public static class MoveEventsManager
    {
        private static Dictionary<string, MoveEvent> MoveEvents = new Dictionary<string, MoveEvent>();
        private static bool isInit = false;

        private static void Init()
        {
            if (isInit)
                return;
            MoveEvents.Add("move-left", new MoveLeft());
            MoveEvents.Add("move-right", new MoveRight());
            MoveEvents.Add("move-forward", new MoveForward());
            MoveEvents.Add("move-backward", new MoveBackward());
            MoveEvents.Add("click", new Enter());
            MoveEvents.Add("return", new Escape());
            isInit = true;
        }

        public static MoveEvent GetMoveEvent(string event_name)
        {
            Init();
            if (MoveEvents.ContainsKey(event_name))
            {
                return MoveEvents[event_name];
            }
            return null;
        }
    }
}
