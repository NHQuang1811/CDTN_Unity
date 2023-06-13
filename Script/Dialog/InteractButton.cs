using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractButton : MonoBehaviour
{
    public DialogTrigger dialogTrigger;
    public void OnClick()
    {
        if (dialogTrigger != null)
        {
            dialogTrigger.StartDialog();
        }
    }
}
