using System;
using System.Collections.Generic;

namespace Chapter04.Examples
{
    class UndoStack
    {
        private readonly Stack<Action> _undoStack = new Stack<Action>();

        public void Do(Action action)
        {
            _undoStack.Push(action);
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                var undo = _undoStack.Pop();
                undo?.Invoke();
            }
        }
    }

    class TextEditor
    {
        private readonly UndoStack _undoStack;

        public TextEditor(UndoStack undoStack)
        {
            _undoStack = undoStack;
        }

        public string Text {get; private set; }

        public void EditText(string newText)
        {
            var previousText = Text;

            _undoStack.Do( () =>
            {
                Text = previousText;
                Console.Write($"Undo:'{newText}'".PadRight(40));
                Console.WriteLine($"Text='{Text}'");
            });

            Text += newText;
            Console.Write($"Edit:'{newText}'".PadRight(40));
            Console.WriteLine($"Text='{Text}'");
        }
    }

    class StackExamples
    {
        
        public static void Main()
        {
            var undoStack = new UndoStack();
            var editor = new TextEditor(undoStack);

            editor.EditText("One day, ");
            editor.EditText("in a ");
            editor.EditText("city ");
            editor.EditText("near by ");

            undoStack.Undo(); // remove 'near by'
            undoStack.Undo(); // remove 'city'

            editor.EditText("land ");
            editor.EditText("far far away ");

            Console.ReadLine();
        }
    }
    
}