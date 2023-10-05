using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius = 0.5f;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private InteractionPromptUI _interactionPromptUI;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int _numfoud;

    private IsInteractable _Interactable;

    void Update()
    {
        _numfoud = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders
            , (int)_interactableMask);

        if (_numfoud > 0)
        {
            _Interactable = _colliders[0].GetComponent<IsInteractable>();

            if (_Interactable != null)
            {
                // interactable.Interact(this);
                if (!_interactionPromptUI.IsDisplayed) _interactionPromptUI.SetUp(_Interactable.InteractionPrompt);
                if (Keyboard.current.zKey.wasPressedThisFrame) _Interactable.Interact(this);
            }
            else
            {
                if (_Interactable != null) _Interactable = null;
                if (_interactionPromptUI.IsDisplayed) _interactionPromptUI.Close();
            }

        }
        else
        {
            if (_Interactable != null) _Interactable = null;
            if (_interactionPromptUI.IsDisplayed) _interactionPromptUI.Close();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
