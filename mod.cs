using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ScamLineMenu
{
    public class Mod : MonoBehaviour
    {
    // some things for menu visibilty if you want you can change window size or stuff like that
        private bool menushow = true;
        private int selectedTab = 0;
        private Rect windowRect = new Rect(Screen.width / 2 - 300f, Screen.height / 2 - 175f, 600f, 350f);
        private int mainWID = 1024;
        private bool isDragging1 = true;
        private Vector2 offset1 = Vector2.zero;
        private Color selectedColor = Color.white;

        void KeyBoardStuff()
        {
            if (Input.GetKeyDown(KeyCode.PageUp)) // you can change that too like making the whatever button you want to open menu
            {
                menushow = !menushow;
            }
            if (Input.GetKeyDown(KeyCode.End)) //and this one is for unloading the menu in game
            {
                Loader.Unload();
            }
        }
        void Update() // you can add your loops that needs constant refresh voids like godmod
        {

        }

        void OnGUI() // its on screen void
        {
            if (!menushow)
                return;

            switch (selectedTab)
            {
                case 0:
                    windowRect = GUI.Window(0, windowRect, menu, "Simple Menu");
                    break;

                case 1:
                    windowRect = GUI.Window(0, windowRect, menu2, "Simple Menu");
                    break;
                default:
                    Debug.LogError("Invalid tab index!");
                    break;
            }

         HandleDragging(ref windowRect, ref isDragging1, ref offset1);
        }

        private void menu(int id)
        {

        }

        private void menu2(int id)
        {

        }

        void HandleDragging(ref Rect window, ref bool isDragging, ref Vector2 offset) // this for dragging function in menu i recommend to not change if you dont know what you doing
        {
            if (Event.current.type == EventType.MouseDown &&
                Event.current.button == 0 &&
                window.Contains(Event.current.mousePosition))
            {
                isDragging = true;
                offset = Event.current.mousePosition - new Vector2(window.x, window.y);
            }

            if (isDragging && Event.current.type == EventType.MouseDrag)
            {
                window.position = Event.current.mousePosition - offset;
            }

            if (Event.current.type == EventType.MouseUp)
            {
                isDragging = false;
            }
        }
    }
}
