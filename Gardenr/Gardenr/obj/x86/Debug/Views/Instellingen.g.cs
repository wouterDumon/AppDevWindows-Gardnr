﻿#pragma checksum "C:\Users\wouter\Desktop\AppDevWindows-Gardnr\Gardenr\Gardenr\Views\Instellingen.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E290CCA4F0F0BAE730DA4F289E2883C8"
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
                    this.add = (global::Microsoft.Advertising.WinRT.UI.AdControl)(target);
                }
                break;
            case 2:
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element2 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 66 "..\..\..\Views\Instellingen.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element2).Checked += this.RadioButton_Checked;
                    #line default
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element3 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    #line 67 "..\..\..\Views\Instellingen.xaml"
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element3).Checked += this.RadioButton_Checked;
                    #line default
                }
                break;
            case 4:
                {
                    this.WAARBENIK = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5:
                {
                    global::Windows.UI.Xaml.Controls.Button element5 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 71 "..\..\..\Views\Instellingen.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)element5).Click += this.Button_Click;
                    #line default
                }
                break;
            case 6:
                {
                    this.ophalen = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                }
                break;
            case 7:
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

