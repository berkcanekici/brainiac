﻿#pragma checksum "..\..\Test5.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "12EA0AAB378544D71B1AA48E993CDC700E04B8DA18F7EC648FD2D0F5E2F0B7F1"
//------------------------------------------------------------------------------
// <auto-generated>
//     Bu kod araç tarafından oluşturuldu.
//     Çalışma Zamanı Sürümü:4.0.30319.42000
//
//     Bu dosyada yapılacak değişiklikler yanlış davranışa neden olabilir ve
//     kod yeniden oluşturulursa kaybolur.
// </auto-generated>
//------------------------------------------------------------------------------

using BrainiacApp;
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


namespace BrainiacApp {
    
    
    /// <summary>
    /// Test5
    /// </summary>
    public partial class Test5 : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\Test5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel Introduction;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Test5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock T5Info1;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Test5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock T5Info2;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Test5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock T5Info3;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\Test5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel QuestionPanel;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\Test5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GoButton_;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\Test5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NoGoButton_;
        
        #line default
        #line hidden
        
        
        #line 120 "..\..\Test5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock QuestionText;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\Test5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock Rest;
        
        #line default
        #line hidden
        
        
        #line 135 "..\..\Test5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GoText;
        
        #line default
        #line hidden
        
        
        #line 136 "..\..\Test5.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock NoGoText;
        
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
            System.Uri resourceLocater = new System.Uri("/BrainiacApp;component/test5.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Test5.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
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
            this.Introduction = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 2:
            this.T5Info1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.T5Info2 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.T5Info3 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            
            #line 49 "..\..\Test5.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.StartTest5);
            
            #line default
            #line hidden
            return;
            case 6:
            this.QuestionPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 7:
            this.GoButton_ = ((System.Windows.Controls.Button)(target));
            
            #line 76 "..\..\Test5.xaml"
            this.GoButton_.Click += new System.Windows.RoutedEventHandler(this.GoButton);
            
            #line default
            #line hidden
            return;
            case 8:
            this.NoGoButton_ = ((System.Windows.Controls.Button)(target));
            
            #line 96 "..\..\Test5.xaml"
            this.NoGoButton_.Click += new System.Windows.RoutedEventHandler(this.NoGoButton);
            
            #line default
            #line hidden
            return;
            case 9:
            this.QuestionText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.Rest = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.GoText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.NoGoText = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

