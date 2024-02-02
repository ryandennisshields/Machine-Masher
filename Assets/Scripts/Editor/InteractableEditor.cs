using UnityEditor;

[CustomEditor(typeof(Interactable),true)] // Creates a custom editor for Interactable
public class InteractableEditor : Editor
{
    // Function that creates a custom inspector
    // Override is used here so it can be replaced by the "else" code
    public override void OnInspectorGUI()
    {
        Interactable interactable = (Interactable)target; // Grabs the interactable target from the Interactable code, with the target set by Player Interact
        // This code is used when Event Only Interactable is added, a script that can make an interactable object use Unity Events exclusively. Good for things like a simple parameter change
        if (target.GetType() == typeof(EventOnlyInteractable))
        { // If the target is an interactable object using the Event Only Interactable script,
            interactable.promptMessage = EditorGUILayout.TextField("Prompt Message", interactable.promptMessage); // Set the interactable object's prompt message to the contents of a text field created on the editor
            EditorGUILayout.HelpBox("EventOnlyInteract only uses UnityEvents", MessageType.Info); // Creates a help text box notifying that anything using Event Only Interact only uses Unity Events
            if (interactable.GetComponent<InteractionEvent>() == null)
            { // If the interactable has no Interaction Event code,
                interactable.useEvents = true; // Set the code to use events
                interactable.gameObject.AddComponent<InteractionEvent>(); // Add the Interaction Event code to the interactable
            }
        }
        else
        { // This code is used when an object has it's own interactable object script (overriding Interactable), creating a check box for using Unity Events or not. Good for when an interactable object may want to use Unity Events but also something with code
            // If the target isn't an interactable object that uses the Event Only Interactable Script,
            base.OnInspectorGUI(); // Derive from the base of On Inspector GUI to create a new editor
            if (interactable.useEvents)
            { // If the interactble object is using events,
                if (interactable.GetComponent<InteractionEvent>() == null)
                { // If the interactable object has no Interaction Event code,
                    interactable.gameObject.AddComponent<InteractionEvent>(); // Add the Interaction Event code to the interactable
                }
            }
            else
            { // If the interactable is not using events,
                if (interactable.GetComponent<InteractionEvent>() != null)
                { // If the interactable object does have the Interaction Event code,
                    DestroyImmediate(interactable.GetComponent<InteractionEvent>()); // Remove the Interaction Event script from the editor
                }
            }
        }
    }
}
