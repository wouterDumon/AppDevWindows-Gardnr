﻿#pragma checksum "C:\Users\wouter\Desktop\AppDevWindows-Gardnr\Gardenr\Gardenr\Views\Profiel_Huidig.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "7A030C655CC7CB83E619DAC1B9242D9A"
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
    partial class Profiel : 
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
                    this.fa = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 2:
                {
                    this.ListItems = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    #line 63 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Controls.GridView)this.ListItems).SizeChanged += this.ListItems_SizeChanged;
                    #line 63 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Controls.GridView)this.ListItems).Tapped += this.ListItems_Tapped;
                    #line default
                }
                break;
            case 3:
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element3 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    #line 68 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element3).Loaded += this.StackPanel_Loaded;
                    #line default
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Shapes.Ellipse element4 = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                    #line 69 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Shapes.Ellipse)element4).Loaded += this.Ellipse_Loaded;
                    #line default
                }
                break;
            case 5:
                {
                    this.AddItemAppBarBtn = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
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

