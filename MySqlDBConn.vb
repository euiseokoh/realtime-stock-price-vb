Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Threading
Imports System.Net
Imports System.Text

Public Class MySqlDBConn

    Public Function getConnection()

        Dim server = ""
        Dim port = "3306"
        Dim catalog = ""
        Dim userId = ""
        Dim userPwd = ""
        Dim CharacterSet = "utf8"
        Dim strConn = "Data Source=" + server + ";Port=" + port + ";Initial Catalog=" + catalog + ";User Id=" + userId + ";Password=" + userPwd + ";Character Set=" + CharacterSet

        Dim conn As MySqlConnection = New MySqlConnection(strConn)

        Return conn


    End Function

    Public Function ReadFormDB(query As String)

        Dim ds As DataSet = Nothing
        Dim myConn As MySqlConnection = Nothing

        Try
            myConn = getConnection()
            Dim adpt As MySqlDataAdapter = New MySqlDataAdapter(query, myConn)
            adpt.SelectCommand.CommandTimeout = 0
            ds = New DataSet()
            adpt.Fill(ds)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        myConn.Close()
        'Console.WriteLine(ds.Tables(0).Rows.Count)
        If ds.Tables.Count = 0 Then
            add_log("sql :" + query + " 문제 발생!!!")
            send_exceptionmail("sql :" + query + " 문제 발생!!!")
            Dim check = 0
            While (check < 5)

                If ds.Tables.Count = 0 Then

                    Dim adpt As MySqlDataAdapter = New MySqlDataAdapter(query, myConn)
                    adpt.SelectCommand.CommandTimeout = 0
                    ds = New DataSet()
                    adpt.Fill(ds)
                    myConn.Close()
                Else
                    Exit While
                End If

                check = check + 1
                Thread.Sleep(100)

            End While

        End If

        Return ds
    End Function

    Public Function getConnection_write()

        Dim server = ""
        Dim port = ""
        Dim catalog = ""
        Dim userId = ""
        Dim userPwd = ""
        Dim CharacterSet = "utf8"
        Dim strConn = "Data Source=" + server + ";Port=" + port + ";Initial Catalog=" + catalog + ";User Id=" + userId + ";Password=" + userPwd + ";Character Set=" + CharacterSet

        Dim conn As MySqlConnection = New MySqlConnection(strConn)

        Return conn


    End Function

    Public Function WriteFormDB(query As String)

        Dim ds As DataSet = Nothing
        Dim myConn As MySqlConnection = Nothing

        Try
            myConn = getConnection_write()
            Dim adpt As MySqlDataAdapter = New MySqlDataAdapter(query, myConn)
            adpt.SelectCommand.CommandTimeout = 0
            ds = New DataSet()
            adpt.Fill(ds)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try

        myConn.Close()
        Return ds
    End Function


    Public Function add_log(msg)
        Dim FileNum As Integer
        Dim FileName As String

        FileNum = FreeFile()
        FileName = System.IO.Directory.GetCurrentDirectory & "\log.txt"

        '내용 추가하기 
        FileOpen(FileNum, FileName, OpenMode.Append, OpenAccess.ReadWrite, OpenShare.Shared)
        Print(FileNum, vbCrLf & "[" + DateTime.Now + "] " + msg)
        FileClose(FileNum)

        Return False
    End Function

    Private Sub send_exceptionmail(content)

        Dim postParams As String = ""
        postParams += "content=" + content.ToString

        Console.WriteLine(postParams)

        Dim encoding As Encoding = Encoding.UTF8
        Dim result = encoding.GetBytes(postParams.ToString())

        ' 타겟이 되는 웹페이지 URL
        Dim Url = ""

        Dim wReqFirst As HttpWebRequest = WebRequest.Create(Url)

        ' HttpWebRequest 오브젝트 설정
        wReqFirst.Method = "POST"
        wReqFirst.ContentType = "application/x-www-form-urlencoded"
        wReqFirst.ContentLength = result.Length

        Dim postDataStream As Stream = wReqFirst.GetRequestStream()
        postDataStream.Write(result, 0, result.Length)
        postDataStream.Close()

        'Dim wRespFirst As HttpWebResponse = wReqFirst.GetResponse()

        '' Response의 결과를 스트림을 생성합니다.
        'Dim respPostStream As Stream = wRespFirst.GetResponseStream()

        '' 반환값 한글 처리를 위해서 인코딩 처리 수행
        'Dim readerPost As StreamReader = New StreamReader(respPostStream, Encoding.GetEncoding("UTF-8"))

        '' 생성한 스트림으로부터 string으로 변환합니다.
        'Dim resultPost = readerPost.ReadToEnd()

        'Console.WriteLine(resultPost)

    End Sub
End Class
