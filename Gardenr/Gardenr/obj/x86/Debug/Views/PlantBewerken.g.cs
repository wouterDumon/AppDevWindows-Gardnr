﻿#pragma checksum "C:\Users\cedric\Documents\GitHub\AppDevWindows-Gardnr\Gardenr\Gardenr\Views\PlantBewerken.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A004E3997C6C8F8617B9E037CB057575"
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
    partial class PlantBewerken : 
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
                    this.add = (global::Microsoft.Advertising.WinRT.UI.AdControl)(target);
                }
                break;
            case 2:
                {
                    this.image = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 3:
                {
                    this.ListItems = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    #line 90 "..\..\..\Views\PlantBewerken.xaml"
                    ((global::Windows.UI.Xaml.Controls.GridView)this.ListItems).Tapped += this.ListItems_Tapped;
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

