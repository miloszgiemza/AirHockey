using UnityEngine;

namespace GameHardwareAndInputClasses
{
    public class SwipeController
    {
        public enum State
        {
            NotSwiping,
            Swiping
        }

        public Vector2 PreviousCursorPos => previousCursorPos;
        public Vector2 CurrentCursorPos => currentCursorPos;

        private State currentState = State.NotSwiping;

        private Vector2 previousCursorPos;
        private Vector2 currentCursorPos;

        public Vector2 RunUpdate(bool inputPressed, Vector2 inputPosition)
        {
            Vector2 swipeValue = new Vector2();

            if (inputPressed)
            {
                switch (currentState)
                {
                    case State.Swiping:

                        currentCursorPos = inputPosition;

                        swipeValue = new Vector2(Mathf.Abs(currentCursorPos.x - previousCursorPos.x), Mathf.Abs(currentCursorPos.y - previousCursorPos.y));
                        if (currentCursorPos.x > previousCursorPos.x) swipeValue = new Vector2(-swipeValue.x, swipeValue.y);
                        if (currentCursorPos.y > previousCursorPos.y) swipeValue = new Vector2(swipeValue.x, -swipeValue.y);

                        if (previousCursorPos == currentCursorPos)
                        {
                            swipeValue = new Vector2();
                        }

                        previousCursorPos = currentCursorPos;

                        if (!inputPressed)
                        {
                            swipeValue = new Vector2();
                            currentState = State.NotSwiping; ;
                        }

                        break;

                    case State.NotSwiping:

                        if (inputPressed)
                        {
                            previousCursorPos = inputPosition;
                            currentState = State.Swiping;
                        }

                        break;
                }
            }

            //swipeValue = new Vector2(swipeValue.x, swipeValue.y);

            return swipeValue;
        }
    }
}

