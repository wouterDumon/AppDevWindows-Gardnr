﻿#pragma checksum "C:\Users\cedric\Documents\GitHub\AppDevWindows-Gardnr\Gardenr\Gardenr\Views\Shell.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "303231570E72A06A89BD40EA2B7A05AB"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gardenr.Views
{
    partial class Shell : 
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
                    this.MySplitView = (global::Windows.UI.Xaml.Controls.SplitView)(target);
                }
                break;
            case 2:
                {
                    this.HamburgerButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 109 "..\..\..\Views\Shell.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.HamburgerButton).Click += this.HamburgerButton_Click;
                    #line default
                }
                break;
            case 3:
                {
                    this.SplitViewPane = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 27 "..\..\..\Views\Shell.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)this.SplitViewPane).ManipulationCompleted += this.SplitViewPane_ManipulationCompleted;
                    #line default
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.ListView element4 = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 30 "..\..\..\Views\Shell.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)element4).SelectionChanged += this.Menu_SelectionChanged;
                    #line default
                }
                break;
            case 5:
                {
                    this.SplitViewFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 6:
                {
                    global::Windows.UI.Xaml.Controls.Grid element6 = (global::Windows.UI.Xaml.Controls.Grid)(target);
                    #line 72 "..\..\..\Views\Shell.xaml"
                    ((global::Windows.UI.Xaml.Controls.Grid)element6).ManipulationCompleted += this.SplitViewOpener_ManipulationCompleted;
                    #line default
                }
                break;
            case 7:
                {
                    this.ScenarioFrame = (global::Windows.UI.Xaml.Controls.Frame)(target);
                }
                break;
            case 8:
                {
                    this.StatusPanel = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 9:
                {
                    this.StatusBorder = (global::Windows.UI.Xaml.Controls.Border)(target);
                }
                break;
            case 10:
                {
                    this.LoadingBaaar = (global::Windows.UI.Xaml.Controls.ProgressRing)(target);
                }
                break;
            case 11:
                {
                    this.StatusBlock = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

