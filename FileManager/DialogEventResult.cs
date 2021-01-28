using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    public enum DialogButtonType
    {
        No,
        Yes
    }

    public class DialogEventResult : EventArgs
    {
        public DialogButtonType ButtonResult { get; set; }
    }
}
