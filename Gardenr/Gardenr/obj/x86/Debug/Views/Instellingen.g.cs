﻿#pragma checksum "C:\Users\cedric\Documents\GitHub\AppDevWindows-Gardnr\Gardenr\Gardenr\Views\Instellingen.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "3D374D96D3C58977A393D1AEF0F213C7"
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
    partial class Instellingen : 
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
                    this.toggleSwitch = (global::Windows.UI.Xaml.Controls.ToggleSwitch)(target);
                    #line 59 "..\..\..\Views\Instellingen.xaml"
                    ((global::Windows.UI.Xaml.Controls.ToggleSwitch)this.toggleSwitch).Toggled += this.toggleSwitch_Toggled;
                    #line default
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.ToggleSwitch element2 = (global::Windows.UI.Xaml.Controls.ToggleSwitch)(target);
                    #line 61 "..\..\..\Views\Instellingen.xaml"
                    ((global::Windows.UI.Xaml.Controls.ToggleSwitch)element2).Toggled += this.ToggleSwitch_Toggled_1;
                    #line default
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.ComboBox element3 = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    #line 63 "..\..\..\Views\Instellingen.xaml"
                    ((global::Windows.UI.Xaml.Controls.ComboBox)element3).SelectionChanged += this.ComboBox_SelectionChanged;
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

