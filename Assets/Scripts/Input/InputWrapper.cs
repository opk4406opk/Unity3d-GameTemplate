using UnityEngine;
using UnityEngine.Assertions;

namespace InputWrapper
{
    public static class Input
    {
        static bool IsTouchSupported => UnityEngine.Input.touchSupported;
        static Touch? FakeTouch => SimulateTouchWithMouse.Instance.FakeTouch;

        public static bool GetButton(string buttonName)
        {
            return UnityEngine.Input.GetButton(buttonName);
        }

        public static bool GetButtonDown(string buttonName)
        {
            return UnityEngine.Input.GetButtonDown(buttonName);
        }

        public static bool GetButtonUp(string buttonName)
        {
            return UnityEngine.Input.GetButtonUp(buttonName);
        }

        public static bool GetMouseButton(int button)
        {
            return UnityEngine.Input.GetMouseButton(button);
        }

        public static bool GetMouseButtonDown(int button)
        {
            return UnityEngine.Input.GetMouseButtonDown(button);
        }

        public static bool GetMouseButtonUp(int button)
        {
            return UnityEngine.Input.GetMouseButtonUp(button);
        }

        public static int TouchCount
        {
            get
            {
                if (IsTouchSupported)
                {
                    return UnityEngine.Input.touchCount;
                }
                else
                {
                    return FakeTouch.HasValue ? 1 : 0;
                }
            }
        }

        public static Touch GetTouch(int index)
        {
            if (IsTouchSupported)
            {
                return UnityEngine.Input.GetTouch(index);
            }
            else
            {
                Assert.IsTrue(FakeTouch.HasValue && index == 0);
                return FakeTouch.Value;
            }
        }

        public static Touch[] Touches
        {
            get
            {
                if (IsTouchSupported)
                {
                    return UnityEngine.Input.touches;
                }
                else
                {
                    return FakeTouch.HasValue ? new[] { FakeTouch.Value } : new Touch[0];
                }
            }
        }
    }

    internal class SimulateTouchWithMouse
    {
        private static SimulateTouchWithMouse _Instance;
        private float LastUpdateTime;
        private Vector3 PrevMousePos;
        private Touch? _FakeTouch;
        public static SimulateTouchWithMouse Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SimulateTouchWithMouse();
                }

                return _Instance;
            }
        }

        public Touch? FakeTouch
        {
            get
            {
                Update();
                return _FakeTouch;
            }
        }

        void Update()
        {
            if (Time.time != LastUpdateTime)
            {
                LastUpdateTime = Time.time;

                var curMousePos = UnityEngine.Input.mousePosition;
                var delta = curMousePos - PrevMousePos;
                PrevMousePos = curMousePos;

                _FakeTouch = CreateTouch(GetPhase(delta), delta);
            }
        }

        static TouchPhase? GetPhase(Vector3 delta)
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                return TouchPhase.Began;
            }
            else if (UnityEngine.Input.GetMouseButton(0))
            {
                return delta.sqrMagnitude < 0.01f ? TouchPhase.Stationary : TouchPhase.Moved;
            }
            else if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                return TouchPhase.Ended;
            }
            else
            {
                return null;
            }
        }

        static Touch? CreateTouch(TouchPhase? phase, Vector3 delta)
        {
            if (!phase.HasValue)
            {
                return null;
            }

            var curMousePos = UnityEngine.Input.mousePosition;
            return new Touch
            {
                phase = phase.Value,
                type = TouchType.Indirect,
                position = curMousePos,
                rawPosition = curMousePos,
                fingerId = 0,
                tapCount = 1,
                deltaTime = Time.deltaTime,
                deltaPosition = delta
            };
        }
    }
}