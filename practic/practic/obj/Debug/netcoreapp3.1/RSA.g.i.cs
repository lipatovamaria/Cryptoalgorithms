﻿#pragma checksum "..\..\..\RSA.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2C3EBAA43D946DEF0FEEDA169A71B3FA39DC532E"
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
    /// RSA
    /// </summary>
    public partial class RSA : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\RSA.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox publicKey_TextBox;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\RSA.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox secretKey_TextBox;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\RSA.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox sessionKey_TextBox;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\RSA.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Text;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\RSA.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Encrypt;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\RSA.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Decrypt;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\RSA.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GenerateKeys;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\RSA.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Save;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\RSA.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveKeys;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\..\RSA.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoadKeys;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\RSA.xaml"
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
            System.Uri resourceLocater = new System.Uri("/practic;component/rsa.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\RSA.xaml"
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
            
            #line 10 "..\..\..\RSA.xaml"
            ((practic.RSA)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.publicKey_TextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 41 "..\..\..\RSA.xaml"
            this.publicKey_TextBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.TextBox_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 3:
            this.secretKey_TextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 43 "..\..\..\RSA.xaml"
            this.secretKey_TextBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.TextBox_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 4:
            this.sessionKey_TextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 45 "..\..\..\RSA.xaml"
            this.sessionKey_TextBox.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.TextBox_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Text = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.Encrypt = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\RSA.xaml"
            this.Encrypt.Click += new System.Windows.RoutedEventHandler(this.Encrypt_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Decrypt = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\RSA.xaml"
            this.Decrypt.Click += new System.Windows.RoutedEventHandler(this.Decrypt_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.GenerateKeys = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\RSA.xaml"
            this.GenerateKeys.Click += new System.Windows.RoutedEventHandler(this.GenerateKeys_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.Save = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\RSA.xaml"
            this.Save.Click += new System.Windows.RoutedEventHandler(this.Save_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.SaveKeys = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\RSA.xaml"
            this.SaveKeys.Click += new System.Windows.RoutedEventHandler(this.SaveKeys_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.LoadKeys = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\..\RSA.xaml"
            this.LoadKeys.Click += new System.Windows.RoutedEventHandler(this.LoadKeys_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 64 "..\..\..\RSA.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

