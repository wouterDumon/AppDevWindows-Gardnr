﻿#pragma checksum "C:\Users\cedric\Documents\GitHub\AppDevWindows-Gardnr\Gardenr\Gardenr\Views\Profiel_Favorieten.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9D9314AC71100C798FA6B9C75F9FB2B7"
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
    partial class Profiel_Favorieten : 
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
                    this.fa = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 3:
                {
                    this.ListItems = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    #line 63 "..\..\..\Views\Profiel_Favorieten.xaml"
                    ((global::Windows.UI.Xaml.Controls.GridView)this.ListItems).SizeChanged += this.ListItems_SizeChanged;
                    #line 63 "..\..\..\Views\Profiel_Favorieten.xaml"
                    ((global::Windows.UI.Xaml.Controls.GridView)this.ListItems).Tapped += this.ListItems_Tapped;
                    #line default
                }
                break;
            case 4:
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element4 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    #line 67 "..\..\..\Views\Profiel_Favorieten.xaml"
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element4).Loaded += this.StackPanel_Loaded;
                    #line default
                }
                break;
            case 5:
                {
                    global::Windows.UI.Xaml.Shapes.Ellipse element5 = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                    #line 69 "..\..\..\Views\Profiel_Favorieten.xaml"
                    ((global::Windows.UI.Xaml.Shapes.Ellipse)element5).Loaded += this.Ellipse_Loaded;
                    #line default
                }
                break;
            case 6:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element6 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 92 "..\..\..\Views\Profiel_Favorieten.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element6).Tapped += this.Position_Tapped;
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

