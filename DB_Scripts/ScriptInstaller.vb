﻿Imports pbs.Helper
Imports pbs.Helper.Interfaces

Namespace SO.DB
    Public Class ScriptInstaller
        Implements IScriptInstaller

        Public ReadOnly Property Notes As String Implements IRunable.Notes
            Get
                Return "install db objects"
            End Get
        End Property

        Public Sub Run(args As pbsCmdArgs) Implements IRunable.Run
            Dim msg = New List(Of String)
            Install(msg)
            Dim msgtext = String.Join(Environment.NewLine, msg.ToArray)
            pbs.Helper.UIServices.ConfirmService.Confirm("Installing DB Script for Project Management Module : {0}{1}", Environment.NewLine, msgtext)

        End Sub

        Public Sub Install(ByRef Messages As List(Of String)) Implements IScriptInstaller.Install

            If Context.UseSQLite Then
                InstallSQLite(Messages)
            Else
                InstallSQL(Messages)
            End If

        End Sub

        Public Sub InstallSQL(ByRef Messages As List(Of String))
            'get DBScript from Resources
            Dim ScriptText = My.Resources.DB_Scripts_SO
            Dim xele = XElement.Parse(ScriptText)
            Dim theEntity = Context.CurrentBECode
            Dim scriplist = New List(Of String)

            Dim str As String = String.Empty
            'get contents from Install node, then add contents to list
            For Each dbo In xele...<DBO>
                Dim thename = DNz(dbo.@name, String.Empty).Replace("{XXX}", theEntity)
                pbs.Helper.UIServices.WaitingPanelService.Wait("Install SO Module", thename)


                For Each item In dbo...<Install>
                    Dim scr = DNz(item.Value, String.Empty)
                    Dim decoratedScript = scr.Replace("{XXX}", theEntity)

                    Try
                        pbs.BO.SQLCommander.RunInsertUpdate(decoratedScript)
                        Messages.Add(String.Format("Install SO Module: {0}", thename))
                    Catch ex As Exception
                        Messages.Add(String.Format("Can not install {0}", decoratedScript))
                        Messages.Add(ex.Message)
                    End Try
                    str += decoratedScript
                Next
            Next


            pbs.Helper.UIServices.WaitingPanelService.Done()

        End Sub

        Public Sub InstallSQLite(ByRef Messages As List(Of String))
            'get DBScript from Resources
            Dim ScriptText = My.Resources.DB_Scripts_SO_SQLite
            Dim xele = XElement.Parse(ScriptText)
            Dim theEntity = Context.CurrentBECode
            Dim scriplist = New List(Of String)

            Dim str As String = String.Empty
            'get contents from Install node, then add contents to list
            For Each dbo In xele...<DBO>
                Dim thename = DNz(dbo.@name, String.Empty).Replace("{XXX}", theEntity)
                pbs.Helper.UIServices.WaitingPanelService.Wait("Install Project Management Module", thename)


                For Each item In dbo...<Install>
                    Dim scr = DNz(item.Value, String.Empty)
                    Dim decoratedScript = scr.Replace("{XXX}", theEntity)

                    Try
                        pbs.BO.Lava.SQLiteCommander.RunInsertUpdate(decoratedScript)
                        Messages.Add(String.Format("Install Project Management Module: {0}", thename))
                    Catch ex As Exception
                        Messages.Add(String.Format("Can not install {0}", decoratedScript))
                        Messages.Add(ex.Message)
                    End Try
                    str += decoratedScript
                Next
            Next


            pbs.Helper.UIServices.WaitingPanelService.Done()

        End Sub

    End Class
End Namespace




