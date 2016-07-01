using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gradebook.ViewModel.Service
{
    public static class StateManager
    {
        private static bool isDirty = false;
        public static bool IsDirty
        {
            get
            {
                return isDirty;
            }
        }

        public static bool IsClean
        {
            get
            {
                return !isDirty;
            }
        }

        public static void MarkDirty()
        {
            isDirty = true;
        }

        public static void Clean()
        {
            isDirty = false;
        }

    }
}
