﻿#pragma checksum "C:\Users\wouter\Desktop\AppDevWindows-Gardnr\Gardenr\Gardenr\Views\Home.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "22321A40441D16711D08DE2522053C6C"
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
    partial class Home : 
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
                    global::Windows.UI.Xaml.Controls.TextBlock element1 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    #line 74 "..\..\..\Views\Home.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element1).Tapped += this.TextBlock_Tapped;
                    #line default
                }
                break;
            case 2:
                {
                    this.ListItems = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    #line 75 "..\..\..\Views\Home.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.ListItems).Tapped += this.ListItems_Tapped;
                    #line default
                }
                break;
            case 3:
                {
                    this.NiewsItems = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    #line 103 "..\..\..\Views\Home.xaml"
                    ((global::Windows.UI.Xaml.Controls.GridView)this.NiewsItems).Tapped += this.NiewsItems_Tapped;
                    #line default
                }
                break;
            case 4:
                {
                    this.LocationDisabledMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
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

