﻿#pragma checksum "..\..\..\SHA2.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D909D6D8801F9DA36540870B6725166DB4C4A876"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using practic;


namespace practic {
    
    
    /// <summary>
    /// SHA2
    /// </summary>
    public partial class SHA2 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\SHA2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Text;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\SHA2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Encrypt;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\SHA2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\SHA2.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/practic;component/sha2.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\SHA2.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 10 "..\..\..\SHA2.xaml"
            ((practic.SHA2)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.Encrypt = ((System.Windows.Controls.Button)(target));
            
            #line 42 "..\..\..\SHA2.xaml"
            this.Encrypt.Click += new System.Windows.RoutedEventHandler(this.Encrypt_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Save = ((System.Windows.Controls.Button)(target));
            
            #line 43 "..\..\..\SHA2.xaml"
            this.Save.Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\SHA2.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

