using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Strategy
{
    public abstract class Interactable : MonoBehaviour
    {
        public string InteractText;
        public void BaseInteract()
        {
            Interact();
        }
        protected virtual void Interact() { }
    }
}
