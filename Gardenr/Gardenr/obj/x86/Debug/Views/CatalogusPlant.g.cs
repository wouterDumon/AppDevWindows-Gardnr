﻿#pragma checksum "C:\Users\cedric\Documents\GitHub\AppDevWindows-Gardnr\Gardenr\Gardenr\Views\CatalogusPlant.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "2C5EF4F667E4C67D5F94DB2B9C9F86C1"
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
    partial class CatalogusPlant : 
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
                    #line 66 "..\..\..\Views\CatalogusPlant.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element1).Tapped += this.TextBlock_Tapped_1;
                    #line default
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.TextBlock element2 = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                    #line 67 "..\..\..\Views\CatalogusPlant.xaml"
                    ((global::Windows.UI.Xaml.Controls.TextBlock)element2).Tapped += this.TextBlock_Tapped;
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

