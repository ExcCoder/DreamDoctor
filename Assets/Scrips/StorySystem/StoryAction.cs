using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StoryAction
    {
        public string targetName;
        public string actionName;
        public object info;

        public StoryAction(string targetName, string actionName, object info)
        {
            this.targetName = targetName;
            this.actionName = actionName;
            this.info = info;
        }
    }
