﻿#pragma checksum "C:\Users\wouter\Desktop\AppDevWindows-Gardnr\Gardenr\Gardenr\Views\Profiel_Huidig.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CEC83F5838928A8640730EC503268BB1"
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
                    this.SplitModeWide = (global::Windows.UI.Xaml.VisualStateGroup)(target);
                }
                break;
            case 2:
                {
                    this.TabletState = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 3:
                {
                    this.SplitModeNarrow = (global::Windows.UI.Xaml.VisualState)(target);
                }
                break;
            case 4:
                {
                    this.Desktop = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 5:
                {
                    this.Mobile = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 6:
                {
                    this.fa = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 7:
                {
                    this.ListItems = (global::Windows.UI.Xaml.Controls.GridView)(target);
                    #line 264 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Controls.GridView)this.ListItems).SizeChanged += this.ListItems_SizeChanged;
                    #line 264 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Controls.GridView)this.ListItems).Tapped += this.ListItems_Tapped;
                    #line default
                }
                break;
            case 8:
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element8 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    #line 269 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element8).Loaded += this.StackPanel_Loaded;
                    #line default
                }
                break;
            case 9:
                {
                    global::Windows.UI.Xaml.Shapes.Ellipse element9 = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                    #line 270 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Shapes.Ellipse)element9).Loaded += this.Ellipse_Loaded;
                    #line default
                }
                break;
            case 10:
                {
                    this.Huidig = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 11:
                {
                    this.Historiek = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 12:
                {
                    this.Favorieten = (global::Windows.UI.Xaml.Controls.Grid)(target);
                }
                break;
            case 13:
                {
                    this.ListItemsDESK = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 191 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ListItemsDESK).SizeChanged += this.ListItemsDESK_SizeChanged;
                    #line 191 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ListItemsDESK).Tapped += this.ListItemsDESK_Tapped;
                    #line default
                }
                break;
            case 14:
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element14 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    #line 199 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element14).Loaded += this.StackPanel_Loaded_1;
                    #line default
                }
                break;
            case 15:
                {
                    global::Windows.UI.Xaml.Shapes.Ellipse element15 = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                    #line 201 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Shapes.Ellipse)element15).Loaded += this.Ellipse_Loaded_1;
                    #line default
                }
                break;
            case 16:
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element16 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    #line 225 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element16).Tapped += this.Position_Tapped;
                    #line default
                }
                break;
            case 17:
                {
                    this.ListItemsHIST = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 146 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ListItemsHIST).SizeChanged += this.ListItemsHIST_SizeChanged;
                    #line 146 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ListItemsHIST).Tapped += this.ListItemsHIST_Tapped;
                    #line default
                }
                break;
            case 18:
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element18 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    #line 154 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element18).Loaded += this.StackPanel_Loaded_2;
                    #line default
                }
                break;
            case 19:
                {
                    global::Windows.UI.Xaml.Shapes.Ellipse element19 = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                    #line 156 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Shapes.Ellipse)element19).Loaded += this.Ellipse_Loaded_2;
                    #line default
                }
                break;
            case 20:
                {
                    this.ListItemsHUID = (global::Windows.UI.Xaml.Controls.ListView)(target);
                    #line 101 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ListItemsHUID).SizeChanged += this.ListItemsHUID_SizeChanged;
                    #line 101 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Controls.ListView)this.ListItemsHUID).Tapped += this.ListItemsHUID_Tapped;
                    #line default
                }
                break;
            case 21:
                {
                    global::Windows.UI.Xaml.Controls.StackPanel element21 = (global::Windows.UI.Xaml.Controls.StackPanel)(target);
                    #line 109 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Controls.StackPanel)element21).Loaded += this.StackPanel_Loaded_3;
                    #line default
                }
                break;
            case 22:
                {
                    global::Windows.UI.Xaml.Shapes.Ellipse element22 = (global::Windows.UI.Xaml.Shapes.Ellipse)(target);
                    #line 110 "..\..\..\Views\Profiel_Huidig.xaml"
                    ((global::Windows.UI.Xaml.Shapes.Ellipse)element22).Loaded += this.Ellipse_Loaded_3;
                    #line default
                }
                break;
            case 23:
                {
                    this.MOBILEHELP = (global::Windows.UI.Xaml.Controls.CommandBar)(target);
                }
                break;
            case 24:
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

