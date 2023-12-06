﻿#pragma checksum "..\..\..\..\..\Windows\Reservations\Reservations.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E8A8D770C0783EA99610C3DEBE12BE8639BBE077"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HotelReservations.Windows;
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


namespace HotelReservations.Windows {
    
    
    /// <summary>
    /// Reservations
    /// </summary>
    public partial class Reservations : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox RoomNumberSearchTextBox;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox StartDateSearchTextBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox EndDateSearchTextBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddReservationButton;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditReservationButton;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteReservationButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button FinishReservationButton;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ActiveReservationButton;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ReservationsDataGrid;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.12.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HotelReservations;component/windows/reservations/reservations.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.12.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.RoomNumberSearchTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
            this.RoomNumberSearchTextBox.PreviewKeyUp += new System.Windows.Input.KeyEventHandler(this.SearchTB_PreviewKeyUp);
            
            #line default
            #line hidden
            return;
            case 2:
            this.StartDateSearchTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
            this.StartDateSearchTextBox.PreviewKeyUp += new System.Windows.Input.KeyEventHandler(this.SearchTB_PreviewKeyUp);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EndDateSearchTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
            this.EndDateSearchTextBox.PreviewKeyUp += new System.Windows.Input.KeyEventHandler(this.SearchTB_PreviewKeyUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AddReservationButton = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
            this.AddReservationButton.Click += new System.Windows.RoutedEventHandler(this.AddReservationButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.EditReservationButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
            this.EditReservationButton.Click += new System.Windows.RoutedEventHandler(this.EditReservationButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.DeleteReservationButton = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
            this.DeleteReservationButton.Click += new System.Windows.RoutedEventHandler(this.DeleteReservationButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.FinishReservationButton = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
            this.FinishReservationButton.Click += new System.Windows.RoutedEventHandler(this.FinishReservationButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ActiveReservationButton = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
            this.ActiveReservationButton.Click += new System.Windows.RoutedEventHandler(this.CheckActiveReservationButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ReservationsDataGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 35 "..\..\..\..\..\Windows\Reservations\Reservations.xaml"
            this.ReservationsDataGrid.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.ReservationsDataGrid_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

