using System;
using System.Windows.Forms;
using MoonSharp.Interpreter;

namespace rMOD.Functions
{
    // TODO: Merge both print into single which switches based on type of object ex 
    public class LuaException
    {
        public static void Print(string decoratedMessage, string structureName)
        {
            string[] exChunks = decoratedMessage.Split(new char[] { ':' }, 3);
            string[] lineVals = exChunks[1].Split(new char[] { ',' }, 2);
            string message = exChunks[2];
            string outputMessage = string.Format("A Runtime exception has occured while loading {0}!\n\nDetails:\n\tMessage: {1}\n\tLine: {2}\n\tOffset: {3}",
                structureName,
                message,
                lineVals[0].Remove(0, 1),
                lineVals[1].Remove(lineVals[1].Length - 1)
                );

            MessageBox.Show(outputMessage, "LUA Runtime Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
