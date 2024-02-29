using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.Heat;

public class CharacterPicker : MonoBehaviour
{
    public HorizontalSelector selector;

    public void PickCharactor()
    {
        selector.items[selector.index].onItemSelect.Invoke();
    }
}
