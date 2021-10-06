using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class Scheduler : MonoBehaviour
    {
        IAction currentAtion;
        public void StartAction(IAction action)
        {
            if (currentAtion == action) return;
            if(currentAtion != null)
            {
                currentAtion.Cancel();
            }            
            currentAtion = action;
        }
    }
}
