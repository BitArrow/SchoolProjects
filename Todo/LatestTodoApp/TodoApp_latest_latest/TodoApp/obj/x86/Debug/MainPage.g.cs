﻿#pragma checksum "C:\Users\Mait\Desktop\LatestTodoApp\TodoApp\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A393E5AD7AC02CBDBE022A3F1BE41344"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TodoApp
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    global::Windows.UI.Xaml.Controls.Button element1 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 21 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element1).Click += this.btnMenu_Click;
                    #line default
                }
                break;
            case 2:
                {
                    this.TodoAppNavigation = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.ListView element3 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 65 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)element3).ItemClick += this.lvTodos_ItemClick;
                    #line 65 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)element3).SelectionChanged += this.lvTodos_SelectionChanged;
                    #line default
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.Button element4 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 51 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element4).Click += this.btnReset_Click;
                    #line default
                }
                break;
            case 5:
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 43 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.btnCategoryNavigation_Click;
                    #line default
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

