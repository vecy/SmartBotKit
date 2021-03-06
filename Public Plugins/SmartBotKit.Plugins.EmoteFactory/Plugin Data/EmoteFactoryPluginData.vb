﻿
#Region " Option Statements "

Option Strict On
Option Explicit On
Option Infer Off

#End Region

#Region " Imports "

Imports Microsoft.VisualBasic.ApplicationServices

Imports System.ComponentModel
Imports System.Diagnostics
Imports System.IO
Imports System.Reflection

Imports SmartBot.Plugins
Imports SmartBot.Plugins.API

#End Region

#Region " EmoteFactoryPluginData "

Namespace EmoteFactory

    ''' ----------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Plugin data for <see cref="EmoteFactoryPlugin"/> plugin class.
    ''' </summary>
    ''' ----------------------------------------------------------------------------------------------------
    ''' <seealso cref="PluginDataContainer"/>
    ''' ----------------------------------------------------------------------------------------------------
    <Serializable>
    <DebuggerNonUserCode>
    Public NotInheritable Class EmoteFactoryPluginData : Inherits PluginDataContainer

#Region " Properties "

#Region " Plugin "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the <see cref="ApplicationServices.AssemblyInfo"/> for this assembly.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Friend ReadOnly Property AssemblyInfo As AssemblyInfo
            Get
                Return New AssemblyInfo(Assembly.GetExecutingAssembly())
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the assembly name.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Plugin")>
        <DisplayName("Assembly Name")>
        Public ReadOnly Property AssemblyName As String
            Get
                Return Path.ChangeExtension(Me.AssemblyInfo.AssemblyName, "dll")
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets the plugin description.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Plugin")>
        <DisplayName("Description")>
        Public ReadOnly Property Description As String
            Get
                Return "Builds configurable rule conditions" & ControlChars.NewLine &
                       "to send or answer to opponent emotes."
            End Get
        End Property

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets a value that determine whether the plugin should delete log files.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Plugin")>
        <DisplayName("Version")>
        Public ReadOnly Property Version As String
            Get
                Return Me.AssemblyInfo.Version.ToString()
            End Get
        End Property

        <Browsable(False)>
        Public Shadows Property Name As String

#End Region

#Region " Reply to Enemy Emotes "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets the percentage chance to reply an emote.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' A value between 1% and 100%.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Reply To Enemy Emotes")>
        <DisplayName("The percentage chance to reply an emote")>
        <Browsable(True)>
        Public Property ReplyEmotePercent() As Integer
            Get
                Return Me.replyEmotePercentB
            End Get
            Set(ByVal value As Integer)
                If value < 1 Then
                    Me.replyEmotePercentB = 1
                ElseIf value > 100 Then
                    Me.replyEmotePercentB = 100
                Else
                    Me.replyEmotePercentB = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' ( Backing Field )
        ''' <para></para>
        ''' The percentage chance to reply an emote.
        ''' </summary>
        Private replyEmotePercentB As Integer

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets the amount of maximum emote replies per game.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' A value between 1 and 20.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Reply To Enemy Emotes")>
        <DisplayName("The amount of maximum emote replies per game")>
        <Browsable(True)>
        Public Property MaxReplies() As Integer
            Get
                Return Me.maxRepliesB
            End Get
            Set(ByVal value As Integer)
                If (value < 1) Then
                    Me.maxRepliesB = 1
                ElseIf (value > 20) Then
                    Me.maxRepliesB = 20
                Else
                    Me.maxRepliesB = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' ( Backing Field )
        ''' <para></para>
        ''' The amount of maximum emote replies per game.
        ''' </summary>
        Private maxRepliesB As Integer

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that determine the emote that will be sent 
        ''' when <see cref="Bot.EmoteType.Greetings"/> is sent by the enemy.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Reply To Enemy Emotes")>
        <DisplayName("Reply to emote: 'Grettings' with:")>
        <Browsable(True)>
        Public Property EmoteToReplyGrettings() As Bot.EmoteType

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that determine the emote that will be sent 
        ''' when <see cref="Bot.EmoteType.Oops"/> is sent by the enemy.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Reply To Enemy Emotes")>
        <DisplayName("Reply to emote: 'Oops' with:")>
        <Browsable(True)>
        Public Property EmoteToReplyOops() As Bot.EmoteType

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that determine the emote that will be sent 
        ''' when <see cref="Bot.EmoteType.Thanks"/> is sent by the enemy.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Reply To Enemy Emotes")>
        <DisplayName("Reply to emote: 'Thanks' with:")>
        <Browsable(True)>
        Public Property EmoteToReplyThanks() As Bot.EmoteType

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that determine the emote that will be sent 
        ''' when <see cref="Bot.EmoteType.Threaten"/> is sent by the enemy.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Reply To Enemy Emotes")>
        <DisplayName("Reply to emote: 'Threaten' with:")>
        <Browsable(True)>
        Public Property EmoteToReplyThreaten() As Bot.EmoteType

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that determine the emote that will be sent 
        ''' when <see cref="Bot.EmoteType.WellPlayed"/> is sent by the enemy.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Reply To Enemy Emotes")>
        <DisplayName("Reply to emote: 'Well Played' with:")>
        <Browsable(True)>
        Public Property EmoteToReplyWellPlayed() As Bot.EmoteType

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that determine the emote that will be sent 
        ''' when <see cref="Bot.EmoteType.Wow"/> is sent by the enemy.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Reply To Enemy Emotes")>
        <DisplayName("Reply to emote: 'Wow' with:")>
        <Browsable(True)>
        Public Property EmoteToReplyWow() As Bot.EmoteType

#End Region

#Region " Send Emote On Conditions "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets the percentage chance to send an emote on conditions.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' A value between 1% and 100%.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Send Emote On Conditions")>
        <DisplayName("The percentage chance to send an emote on conditions")>
        <Browsable(True)>
        Public Property SendEmoteOnConditionsPercent As Integer
            Get
                Return Me.sendEmoteOnConditionsPercentB
            End Get
            Set(ByVal value As Integer)
                If (value < 1) Then
                    Me.sendEmoteOnConditionsPercentB = 1
                ElseIf (value > 100) Then
                    Me.sendEmoteOnConditionsPercentB = 100
                Else
                    Me.sendEmoteOnConditionsPercentB = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' ( Backing Field )
        ''' <para></para>
        ''' The percentage chance to send an emote on conditions.
        ''' </summary>
        Private sendEmoteOnConditionsPercentB As Integer

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that determine whether an emote should be sent at the very first turn of the game.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Send Emote On Conditions")>
        <DisplayName("Send emote at hero's first turn")>
        <Browsable(True)>
        Public Property EmoteOnFirstTurn As Boolean

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that determine the emote that will be sent 
        ''' when <see cref="EmoteFactoryPluginData.EmoteOnFirstTurn"/> is enabled.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Send Emote On Conditions")>
        <DisplayName("Emote type to send at hero's first turn")>
        <Browsable(True)>
        Public Property EmoteOnFirstTurnType As Bot.EmoteType

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that determine whether an emote should be sent when the bot detects a lethal move.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Send Emote On Conditions")>
        <DisplayName("Send emote when the hero has lethal")>
        <Browsable(True)>
        Public Property EmoteOnLethal As Boolean

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that determine the emote that will be sent 
        ''' when <see cref="EmoteFactoryPluginData.EmoteOnLethal"/> is enabled.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Send Emote On Conditions")>
        <DisplayName("Emote type to send when the hero has lethal")>
        <Browsable(True)>
        Public Property EmoteOnLethalType As Bot.EmoteType

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that determine whether an emote should be sent when the hero is defeated by enemy.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Send Emote On Conditions")>
        <DisplayName("Send emote when the hero is defeated by enemy")>
        <Browsable(True)>
        Public Property EmoteOnDefeat As Boolean

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that determine the emote that will be sent 
        ''' when <see cref="EmoteFactoryPluginData.EmoteOnDefeat"/> is enabled.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Send Emote On Conditions")>
        <DisplayName("Emote type to send when the hero is defeated by enemy")>
        <Browsable(True)>
        Public Property EmoteOnDefeatType() As Bot.EmoteType

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that determine whether an emote should be sent when the bot concedes the game.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Send Emote On Conditions")>
        <DisplayName("Send emote when bot concedes the game")>
        <Browsable(True)>
        Public Property EmoteOnConcede As Boolean

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that determine the emote that will be sent 
        ''' when <see cref="EmoteFactoryPluginData.EmoteOnConcede"/> is enabled.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Send Emote On Conditions")>
        <DisplayName("Emote type to send when bot concedes the game")>
        <Browsable(True)>
        Public Property EmoteOnConcedeType() As Bot.EmoteType

#End Region

#Region " Squelch/Mute Enemy "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets a value that determine whether to squelch/mute the enemy when he sends a emote.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Squelch/Mute Enemy")>
        <DisplayName("Squelch/Mute the enemy when he sends a emote")>
        <Browsable(True)>
        Public Property SquelchEnemny() As Boolean

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets the percentage chance to squelch/mute the enemy when he sends a emote.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' A value between 1% and 100%.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Squelch/Mute Enemy")>
        <DisplayName("The percentage chance to squelch/mute the enemy")>
        <Browsable(True)>
        Public Property SquelchEnemnyPercent() As Integer
            Get
                Return Me.squelchEnemnyPercentB
            End Get
            Set(ByVal value As Integer)
                If value < 1 Then
                    Me.squelchEnemnyPercentB = 1
                ElseIf value > 100 Then
                    Me.squelchEnemnyPercentB = 100
                Else
                    Me.squelchEnemnyPercentB = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' ( Backing Field )
        ''' <para></para>
        ''' The percentage chance to squelch/mute the enemy when he sends a emote.
        ''' </summary>
        Private squelchEnemnyPercentB As Integer

#End Region

#Region " Global Settings "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Gets or sets the maximum delay to send a emote, in milliseconds.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        ''' <value>
        ''' The maximum delay to send a emote, in milliseconds.
        ''' </value>
        ''' ----------------------------------------------------------------------------------------------------
        <Category("Global Settings")>
        <DisplayName("The maximum delay to send any emote, in milliseconds")>
        <Browsable(True)>
        Public Property MaxDelay() As Integer
            Get
                Return Me.maxDelayB
            End Get
            Set(ByVal value As Integer)
                If (value < 2000) Then
                    Me.maxDelayB = 2000
                ElseIf (value > 5000) Then
                    Me.maxDelayB = 5000
                Else
                    Me.maxDelayB = value
                End If
            End Set
        End Property
        ''' <summary>
        ''' ( Backing Field )
        ''' <para></para>
        ''' The maximum delay to send a emote, in milliseconds.
        ''' </summary>
        Private maxDelayB As Integer

#End Region

#End Region

#Region " Constructors "

        ''' ----------------------------------------------------------------------------------------------------
        ''' <summary>
        ''' Initializes a new instance of the <see cref="EmoteFactoryPluginData"/> class.
        ''' </summary>
        ''' ----------------------------------------------------------------------------------------------------
        Public Sub New()
            MyBase.Name = Me.AssemblyInfo.AssemblyName

            Me.EmoteOnFirstTurn = False
            Me.EmoteOnFirstTurnType = Bot.EmoteType.Greetings

            Me.EmoteOnLethal = False
            Me.EmoteOnLethalType = Bot.EmoteType.WellPlayed

            Me.EmoteOnConcede = False
            Me.EmoteOnConcedeType = Bot.EmoteType.WellPlayed

            Me.EmoteOnDefeat = False
            Me.EmoteOnDefeatType = Bot.EmoteType.WellPlayed

            Me.SquelchEnemny = False

            Me.MaxReplies = 5
            Me.ReplyEmotePercent = 25
            Me.SendEmoteOnConditionsPercent = 20
            Me.SquelchEnemnyPercent = 5
            Me.MaxDelay = 4000

            Me.EmoteToReplyGrettings = Bot.EmoteType.Greetings
            Me.EmoteToReplyOops = Bot.EmoteType.Oops
            Me.EmoteToReplyThanks = Bot.EmoteType.Thanks
            Me.EmoteToReplyThreaten = Bot.EmoteType.Threaten
            Me.EmoteToReplyWellPlayed = Bot.EmoteType.WellPlayed
            Me.EmoteToReplyWow = Bot.EmoteType.Wow
        End Sub

#End Region

    End Class

End Namespace

#End Region
