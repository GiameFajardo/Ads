﻿#pragma checksum "..\..\..\Pages\ConfigurationPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9FA74F4BEBF1DDD4D2D91FF17ABEA86EAFB32368D778794E57ED47983A3FF5FC"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using SlideShow.Pages;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace SlideShow.Pages {
    
    
    /// <summary>
    /// ConfigurationPage
    /// </summary>
    public partial class ConfigurationPage : SlideShow.Pages.BasePage, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\Pages\ConfigurationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPath;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Pages\ConfigurationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGetNewPath;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Pages\ConfigurationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnReload;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\ConfigurationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtDuration;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Pages\ConfigurationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPrice;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/SlideShow;component/pages/configurationpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\ConfigurationPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.txtPath = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            
            #line 18 "..\..\..\Pages\ConfigurationPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnGetNewPath = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\Pages\ConfigurationPage.xaml"
            this.btnGetNewPath.Click += new System.Windows.RoutedEventHandler(this.btnGetNewPath_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnReload = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Pages\ConfigurationPage.xaml"
            this.btnReload.Click += new System.Windows.RoutedEventHandler(this.btnReload_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtDuration = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\..\Pages\ConfigurationPage.xaml"
            this.txtDuration.KeyDown += new System.Windows.Input.KeyEventHandler(this.TxtDuration_KeyDown);
            
            #line default
            #line hidden
            
            #line 24 "..\..\..\Pages\ConfigurationPage.xaml"
            this.txtDuration.KeyUp += new System.Windows.Input.KeyEventHandler(this.TxtDuration_KeyUp);
            
            #line default
            #line hidden
            
            #line 25 "..\..\..\Pages\ConfigurationPage.xaml"
            this.txtDuration.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberValidationTextBox);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnPrice = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Pages\ConfigurationPage.xaml"
            this.btnPrice.Click += new System.Windows.RoutedEventHandler(this.BtnPrice_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

