﻿
#Region " Option Statements "

Option Strict On
Option Explicit On
Option Infer Off

#End Region

#Region " Imports "


#End Region

#Region " TaskbarList "

Namespace SmartBotKit.Interop.Win32

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Provides internal access to the functions provided by the ITaskbarList4 interface, 
    ''' without being forced to refer to it through another singleton.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    Public NotInheritable Class TaskbarList

        Private Shared ReadOnly lock As New Object()
        Private Shared taskbarList As ITaskbarList4

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Prevents a default instance of the <see cref="TaskbarList"/> class from being created.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Private Sub New()
        End Sub

        Public Shared ReadOnly Property Instance() As ITaskbarList4
            Get
                If (taskbarList Is Nothing) Then
                    SyncLock lock
                        If (taskbarList Is Nothing) Then
                            taskbarList = DirectCast(New CTaskbarList(), ITaskbarList4)
                            taskbarList.HrInit()
                        End If
                    End SyncLock
                End If

                Return taskbarList
            End Get
        End Property

    End Class

End Namespace

#End Region
