using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.Rendering.HighDefinition.ProbeSettings.Frustum;

namespace ScamLineMenu
{
    public class Mod : MonoBehaviour
    {
        private bool menushow = true;
        private bool loop1 = false;
        private bool loop2 = false;
        private bool loop3 = false;
        private int selectedTab = 0;
        private Rect windowRect = new Rect(Screen.width / 2 - 300f, Screen.height / 2 - 175f, 600f, 350f);
        private int mainWID = 1024;
        private bool isDragging1 = true;
        private Vector2 offset1 = Vector2.zero;
        private Color selectedColor = Color.white;

        void KeyBoardStuff()
        {
            if (Input.GetKeyDown(KeyCode.PageUp))
            {
                menushow = !menushow;
            }
            if (Input.GetKeyDown(KeyCode.End))
            {
                Loader.Unload();
            }
        }
        void Update()
        {
            if (loop1) // if loop 1 checked the code gonna work all the time
            {
                //loop code
            }
        }

        void OnGUI()
        {
            if (!menushow)
                return;

            switch (selectedTab)
            {
                case 0:
                    windowRect = GUI.Window(0, windowRect, menu, "YAPYAP Menu V 1.0");
                    break;

                case 1:
                    windowRect = GUI.Window(0, windowRect, menu2, "YAPYAP Menu V 1.0");
                    break;
                default:
                    Debug.LogError("Invalid tab index!");
                    break;
            }

         HandleDragging(ref windowRect, ref isDragging1, ref offset1);
        }

        private void menu(int id)
        {
            windowRect.width = 480f;
            windowRect.height = 430f;
            GUIStyle windowStyle = new GUIStyle(GUI.skin.window);
            Color hoverColor = new Color(0f, 51f / 255f, 102f / 255f);
            Texture2D hoverTexture = new Texture2D(1, 1);
            hoverTexture.SetPixel(0, 0, hoverColor);
            hoverTexture.Apply();
            windowStyle.normal.background = hoverTexture;
            windowStyle.onNormal.background = hoverTexture;
            windowStyle.onHover.background = hoverTexture;
            GUI.skin.window = windowStyle;
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Menu 1", GUILayout.Width(200f)))
                selectedTab = 0;

            GUILayout.Space(56);

            if (GUILayout.Button("Menu 2", GUILayout.Width(200f)))
                selectedTab = 1;
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            // add whatever you want this is the main area of the menu for example 3 buttons : 
            if (GUILayout.Button("Button 1", GUILayout.Width(145), GUILayout.Height(52)))
            {
                //the function you want to add and dont forget its gonna work only one time if you want loop you need to use checkbox
            }
            if (GUILayout.Button("Button 2", GUILayout.Width(145), GUILayout.Height(52)))
            {
                //the function you want to add and dont forget its gonna work only one time if you want loop you need to use checkbox
            }
            if (GUILayout.Button("Button 3", GUILayout.Width(155), GUILayout.Height(52)))
            {
                //the function you want to add and dont forget its gonna work only one time if you want loop you need to use checkbox
            }
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            loop1 = GUILayout.Toggle(loop1, "Loop 1", GUILayout.Width(145), GUILayout.Height(22));
            loop2 = GUILayout.Toggle(loop2, "Loop 2", GUILayout.Width(145), GUILayout.Height(22));
            loop3 = GUILayout.Toggle(loop3, "Loop 3", GUILayout.Width(145), GUILayout.Height(22));
            GUILayout.EndHorizontal();
            GUI.DragWindow();
        }

        private void menu2(int id)
        {
            windowRect.width = 480f;
            windowRect.height = 430f;
            GUIStyle windowStyle = new GUIStyle(GUI.skin.window);
            Color hoverColor = new Color(0f, 51f / 255f, 102f / 255f);
            Texture2D hoverTexture = new Texture2D(1, 1);
            hoverTexture.SetPixel(0, 0, hoverColor);
            hoverTexture.Apply();
            windowStyle.normal.background = hoverTexture;
            windowStyle.onNormal.background = hoverTexture;
            windowStyle.onHover.background = hoverTexture;
            GUI.skin.window = windowStyle;
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Menu 1", GUILayout.Width(200f)))
                selectedTab = 0;

            GUILayout.Space(56);

            if (GUILayout.Button("Menu 2", GUILayout.Width(200f)))
                selectedTab = 1;
            GUILayout.EndHorizontal();
            GUILayout.BeginHorizontal();
            // add whatever you want this is the main area of the menu
            GUILayout.EndHorizontal();
            GUI.DragWindow();
        }

        void HandleDragging(ref Rect window, ref bool isDragging, ref Vector2 offset)
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
