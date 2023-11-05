using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IsInteractable  
{   
    
    public string InteractionPrompt { get;    }
    public bool Interact(Interactor interactor);



}
