﻿#pragma checksum "..\..\..\..\..\ViewPatient\ViewSecretary\PatientViewSecretary.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B362E9612F21B5F9F16F80F6F9414FCE5782DBB5"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Hospital.ViewSecretary;
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


namespace Hospital.ViewSecretary {
    
    
    /// <summary>
    /// PatientViewSecretary
    /// </summary>
    public partial class PatientViewSecretary : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\..\ViewPatient\ViewSecretary\PatientViewSecretary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button MenuButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\ViewPatient\ViewSecretary\PatientViewSecretary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ProfileButton;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\ViewPatient\ViewSecretary\PatientViewSecretary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image addImageButton;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\..\ViewPatient\ViewSecretary\PatientViewSecretary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackToPatients;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\..\..\..\ViewPatient\ViewSecretary\PatientViewSecretary.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChangePatientsProfile;
        
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
            System.Uri resourceLocater = new System.Uri("/Hospital;component/viewpatient/viewsecretary/patientviewsecretary.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\ViewPatient\ViewSecretary\PatientViewSecretary.xaml"
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
            this.MenuButton = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\..\..\ViewPatient\ViewSecretary\PatientViewSecretary.xaml"
            this.MenuButton.Click += new System.Windows.RoutedEventHandler(this.MenuButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.ProfileButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\..\ViewPatient\ViewSecretary\PatientViewSecretary.xaml"
            this.ProfileButton.Click += new System.Windows.RoutedEventHandler(this.ProfileButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.addImageButton = ((System.Windows.Controls.Image)(target));
            return;
            case 4:
            this.BackToPatients = ((System.Windows.Controls.Button)(target));
            
            #line 59 "..\..\..\..\..\ViewPatient\ViewSecretary\PatientViewSecretary.xaml"
            this.BackToPatients.Click += new System.Windows.RoutedEventHandler(this.BackToPatients_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ChangePatientsProfile = ((System.Windows.Controls.Button)(target));
            
            #line 62 "..\..\..\..\..\ViewPatient\ViewSecretary\PatientViewSecretary.xaml"
            this.ChangePatientsProfile.Click += new System.Windows.RoutedEventHandler(this.ChangePatientsProfile_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

