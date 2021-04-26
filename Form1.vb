Imports System.Runtime.InteropServices
Imports System.IO
Imports System.Net
Imports System.Net.Mail
Imports System.Text
Imports System.Threading


Public Class Form1

    Private AccNames, AccNos As List(Of String)     ' 계좌 명의, 계좌번호
    Private Portfolio As New List(Of Portfolio) ' 체결 결과를 저장하는 리스트
    Private realtimestr As New ArrayList

    Private CurrentPriceNum As Integer = 0
    Private priodThread As Thread
    Private realtimeThread As Thread

    Private stocklimit As String() = {"0", "200", "400", "600", "800", "1000", "1200", "1400", "1600", "1800", "2000"}
    Private stocksearchnum As Integer = 0
    Private threadstartcheck As Integer = 0
    Private stockcount As Integer = 1


    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = API.TR.CA_WMCAEVENT Then
            Select Case m.WParam.ToInt32
                Case API.TR.CA_CONNECTED
                    lbStatus.Items.Add("[ CONNECTED ]")
                    OnConnected(m.LParam)
                Case API.TR.CA_DISCONNECTED
                    lbStatus.Items.Add("[ DISCONNECTED ]")
                Case API.TR.CA_RECEIVEERROR
                    lbStatus.Items.Add("[ ERROR ]")
                Case API.TR.CA_RECEIVECOMPLETE
                    'lbStatus.Items.Add("RECEIVE COMPLETE")
                Case API.TR.CA_RECEIVEDATA
                    Dim _Outdatablock = CType(Marshal.PtrToStructure(m.LParam, GetType(API.OUTDATABLOCK)), API.OUTDATABLOCK)
                    Select Case _Outdatablock.TrIndex
                        Case API.TR.TRID_c8201    '잔고조회

                            'lbStatus.Items.Add("Balance CHECK")
                            lbMsg.TopIndex = lbMsg.Items.Count - 1

                        Case Is >= API.TR.TRID_c1101 '현재가조회
                            'lbStatus.Items.Add("CURRENT PRICE CHECK")
                            OnCurrenPrice(_Outdatablock)
                            lbMsg.TopIndex = lbMsg.Items.Count - 1

                        Case API.TR.TRID_c8102    '매수주문
                            'lbStatus.Items.Add("BUY ORDER")
                            lbMsg.TopIndex = lbMsg.Items.Count - 1

                        Case API.TR.TRID_c8101    '매도주문
                            'lbStatus.Items.Add("Sell ORDER")
                            lbMsg.TopIndex = lbMsg.Items.Count - 1

                        Case API.TR.TRID_s8120 ' 주문/체결조회
                            'lbStatus.Items.Add("Check ORDER")

                            lbMsg.TopIndex = lbMsg.Items.Count - 1
                        Case API.TR.TRID_c8104 ' 주문취소
                            lbMsg.TopIndex = lbMsg.Items.Count - 1
                    End Select
                Case API.TR.CA_RECEIVESISE
                    Dim _Outdatablock = CType(Marshal.PtrToStructure(m.LParam, GetType(API.OUTDATABLOCK)), API.OUTDATABLOCK)
                    OnReceivesise(_Outdatablock)
                Case API.TR.CA_RECEIVEERROR
                    'lbStatus.Items.Add("RECEIVEERROR")
                Case API.TR.CA_RECEIVEMESSAGE
                    OnReceivemessage(m.LParam)
                Case API.TR.CA_RECEIVESISE
                    'lbStatus.Items.Add("RECEIVESISE")
                Case API.TR.CA_SOCKETERROR
                    'lbStatus.Items.Add("SOCKETERROR")
                Case Else
                    'lbStatus.Items.Add("Exceptions!" + m.Msg)
            End Select
            lbStatus.TopIndex = lbStatus.Items.Count - 1
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub OnReceivemessage(LParam As IntPtr)
        Dim _Outdatablock = CType(Marshal.PtrToStructure(LParam, GetType(API.OUTDATABLOCK)), API.OUTDATABLOCK)
        Dim _Received = CType(Marshal.PtrToStructure(_Outdatablock.pData, GetType(API.RECEIVED)), API.RECEIVED)
        Dim _Msgheader = New API.MSGHEADER
        _Msgheader.msg_cd = _Received.szData.Substring(0, 5)
        _Msgheader.user_msg = _Received.szData.Substring(5)

        If _Msgheader.msg_cd = "00000" Then
            'lbStatus.Items.Add(_Msgheader.user_msg)
        Else
            lbStatus.Items.Add("Error : " + _Msgheader.user_msg)
        End If
    End Sub

    Private Sub OnConnected(LParam As IntPtr)
        Dim Login = CType(Marshal.PtrToStructure(LParam, GetType(API.LOGINBLOCK)), API.LOGINBLOCK)
        Dim Loginfo = CType(Marshal.PtrToStructure(Login.pLoginInfo, GetType(API.LOGININFO)), API.LOGININFO)
        Dim AccountCountStr = ChartoString(Loginfo.szAccountCount)
        Dim AccountCount = Convert.ToInt32(AccountCountStr)
        AccNames = New List(Of String)
        AccNos = New List(Of String)

        For i = 0 To AccountCount - 1
            Dim AccNo = ChartoString(Loginfo.accountlist(i).szAccountNo).Trim
            AccNos.Add(AccNo)
            Dim AccName = ChartoString(Loginfo.accountlist(i).szAccountName).Trim
            AccNames.Add(AccName)
        Next
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        CheckForIllegalCrossThreadCalls = False

        tbID.Text = "NH ID"
        tbPW.Text = "NH PW"
        tbPW2.Text = "NH PW"

        API.wmcaConnect(Me.Handle, API.TR.CA_WMCAEVENT, "P"c, "1"c, tbID.Text.Trim, tbPW.Text.Trim, tbPW2.Text.Trim)

        If threadstartcheck = 0 Then

            'If priodThread IsNot Nothing Then
            '    priodThread.Abort()
            'End If

            priodThread = New Thread(AddressOf Me.DailyUpdateThread)
            priodThread.Start()

            threadstartcheck = 1

        End If

    End Sub


    Private Sub btnLogin_Click_1(sender As Object, e As EventArgs) Handles btnLogin.Click

        ' 모든 시세 알람 초기화
        API.wmcaConnect(Me.Handle, API.TR.CA_WMCAEVENT, "P"c, "1"c, tbID.Text.Trim, tbPW.Text.Trim, tbPW2.Text.Trim)
        Thread.Sleep(1000 * 1)
        API.wmcaDetachAll()
        stocksearchnum = 0
        Dim setRealtimeprice = New Thread(AddressOf Me.setRealtimeprice)
        setRealtimeprice.Start()

    End Sub

    Private Function DailyUpdateThread()

        While (True)

            ' 매일 아침 8시 목록 초기화
            Dim CheckTime As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 20, 0)
            Dim UpdateTime As DateTime = New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 20, 10)
            Dim CurrentTime As DateTime = DateTime.Now
            ' Console.WriteLine(CurrentTime)
            If UpdateTime.CompareTo(CurrentTime) = 1 And CheckTime.CompareTo(CurrentTime) = -1 And (DateTime.Now.DayOfWeek <> 0 And DateTime.Now.DayOfWeek <> 6) Then

                API.wmcaConnect(Me.Handle, API.TR.CA_WMCAEVENT, "P"c, "1"c, tbID.Text.Trim, tbPW.Text.Trim, tbPW2.Text.Trim)
                Thread.Sleep(1000 * 1)

                ' 모든 시세 알람 초기화
                API.wmcaDetachAll()
                stocksearchnum = 0
                Dim setRealtimeprice = New Thread(AddressOf Me.setRealtimeprice)
                setRealtimeprice.Start()

            End If

            If (New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 45, 10)).CompareTo(CurrentTime) = 1 And
                (New DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 15, 45, 0)).CompareTo(CurrentTime) = -1 And (DateTime.Now.DayOfWeek <> 0 And DateTime.Now.DayOfWeek <> 6) Then

                API.wmcaConnect(Me.Handle, API.TR.CA_WMCAEVENT, "P"c, "1"c, tbID.Text.Trim, tbPW.Text.Trim, tbPW2.Text.Trim)
                Thread.Sleep(1000 * 1)
                ' 모든 시세 알람 초기화
                API.wmcaDetachAll()

                stocksearchnum = 0
                Dim setRealtimeprice = New Thread(AddressOf Me.setRealtimeprice)
                setRealtimeprice.Start()

            End If



            Thread.Sleep(1000 * 10)

        End While
        Return False

    End Function

    Private Sub setRealtimeprice()

        dgvStockList.Rows.Clear()
        stockcount = 1

        For Each index In stocklimit

            ' Console.WriteLine("CurrentTime_update: " + CurrentTime_update)
            Dim CurrentPriceload = New Thread(AddressOf Me.CurrentPriceload)
            CurrentPriceload.Start()

            Thread.Sleep(1000 * 20)

        Next



    End Sub

    Private Sub CurrentPriceload()


        Portfolio = New List(Of Portfolio)
        Portfolio.Clear()

        If stocksearchnum = 0 Then
            realtimestr = New ArrayList
            realtimestr.Clear()
        End If

        Dim szInput As String = ""
        For Each stockdata In MySqlDao.get_mctoparray(stocklimit(stocksearchnum), "200").Tables(0).Rows


            Dim _potfolio = New Portfolio
            _potfolio.ID = stockdata("code")
            _potfolio.name = stockdata("stock")
            _potfolio.scope = stockdata("market")
            szInput += stockdata("code").ToString + "/"
            Portfolio.Add(_potfolio)

        Next


        realtimestr.Add(szInput)


        CurrentPriceNum = 0
        stocksearchnum += 1



        lbMsg.Items.Add("[" + DateTime.Now.ToString + "] " + stocksearchnum.ToString + "번째 종목들의 현재가를 조회합니다.")

        For i = 0 To Portfolio.Count - 1

            Dim code = "k " + Portfolio(i).ID + " "      ' k:한국어, 6자리 종목코드
            API.wmcaQuery(Me.Handle, i + API.TR.TRID_c1101, "c1101", code, code.Length) ' 해당 종목에대한 현재가 요청

        Next


    End Sub



    ' 매매 종목의 현재가를 수신하여 매매 종목의 수량을 결정한다.
    Private Sub OnCurrenPrice(_outdatablock As API.OUTDATABLOCK)

        Dim _Received = CType(Marshal.PtrToStructure(_outdatablock.pData, GetType(API.RECEIVED2)), API.RECEIVED2)

        If _Received.szBlockName = "c1101OutBlock" Then

            CurrentPriceNum += 1

            Dim PriceData = CType(Marshal.PtrToStructure(_Received.szData, GetType(API.Tc1101OutBlock)), API.Tc1101OutBlock)
            Dim TempIndex = _outdatablock.TrIndex - API.TR.TRID_c1101

            Dim _potfolio = Portfolio(TempIndex)
            _potfolio.price = ChartoDbl(PriceData.현재가)
            _potfolio.lastprice = Convert.ToDouble(ChartoString(PriceData.전일종가).Split("?")(0))
            Dim rate_current = Math.Round(_potfolio.price / _potfolio.lastprice - 1, 4) * 100
            Dim upperprice = ChartoDbl(PriceData.상한가)
            Dim week52top = Convert.ToDouble(ChartoString(PriceData.최고가52주).Split("?")(0))
            Dim stockcode = ChartoString(PriceData.종목코드)

            Console.WriteLine(stockcode + " / " + _potfolio.ID.ToString + " / " + CurrentPriceNum.ToString)

            '정보 업데이트
            MySqlDao.Add("")
            'Console.WriteLine(stocksearchnum.ToString + " : " + Portfolio.Count.ToString + " : " + CurrentPriceNum.ToString)

            'dgvStockList.Rows.Add(stockcount, _potfolio.ID, _potfolio.name, String.Format("{0:N0}", CInt(_potfolio.lastprice)), String.Format("{0:N0}",
            'CInt(_potfolio.price)), rate_current.ToString, _potfolio.industry, _potfolio.scope)

            stockcount += 1
            If (CurrentPriceNum = Portfolio.Count) Then

                lbMsg.Items.Add("[" + DateTime.Now.ToString + "] " + stocksearchnum.ToString + "번째 종목들의 현재가 조회가 완료 되었습니다.")
                lbMsg.TopIndex = lbMsg.Items.Count - 1

                If stocksearchnum = 11 Then

                    For Each szInput In realtimestr

                        Dim transtr = szInput.ToString.Replace("/", "")
                        Console.WriteLine(szInput)
                        Console.WriteLine(transtr)
                        Console.WriteLine((szInput.ToString.Split("/").Count - 1).ToString + " / " + Portfolio.Count.ToString)

                        API.wmcaAttach(Me.Handle, "j8", transtr, 6, 6 * (szInput.ToString.Split("/").Count - 1))    ' 실시간 현재가 데이터 요청(j8)
                        'wmcaAttach(HWND hWnd, const char* szBCType, const char* szInput, Int nCodeLen, Int nInputLen)
                        '윈도우 핸들값 / 실시간 서비스 코드(BC) / 해당 서비스가 요구하는 입력값 / 입력값 개별 길이 / 입력값 전체 길이

                        API.wmcaAttach(Me.Handle, "k8", transtr, 6, 6 * (szInput.ToString.Split("/").Count - 1))    ' 실시간 현재가 데이터 요청(K8)
                        'wmcaAttach(HWND hWnd, const char* szBCType, const char* szInput, Int nCodeLen, Int nInputLen)
                        '윈도우 핸들값 / 실시간 서비스 코드(BC) / 해당 서비스가 요구하는 입력값 / 입력값 개별 길이 / 입력값 전체 길이

                        Thread.Sleep(1000 * 1)

                    Next

                    stocksearchnum = 0
                    stockcount = 1
                End If

            End If
        End If

    End Sub




    ' 실시간 정보 받아오는 부분
    Private Sub OnReceivesise(_outdatablock As API.OUTDATABLOCK)
        Dim _Received = CType(Marshal.PtrToStructure(_outdatablock.pData, GetType(API.RECEIVED2)), API.RECEIVED2)

        If StrComp(_Received.szBlockName.Substring(0, 2), "j8") = 0 Or StrComp(_Received.szBlockName.Substring(0, 2), "k8") = 0 Then

            Dim Data = Nothing
            If StrComp(_Received.szBlockName.Substring(0, 2), "j8") = 0 Then
                Data = CType(Marshal.PtrToStructure(_Received.szData + 3, GetType(API.Tj8OutBlock)), API.Tj8OutBlock)
            ElseIf StrComp(_Received.szBlockName.Substring(0, 2), "k8") = 0 Then
                Data = CType(Marshal.PtrToStructure(_Received.szData + 3, GetType(API.Tk8OutBlock)), API.Tk8OutBlock)
            End If



            Dim rate = ChartoDbl(Data.등락률, 2, Data.등락부호)

            'Console.WriteLine("등락부호 : " + Data.등락부호 + " : " + "등락률 : " + rate.ToString)

            '등락부호 상한 1, 상승 2, 보합 3, 하한 4, 하락  5 
            'If ChartoString(Data.종목코드) = "028040" Then

            '    Console.WriteLine("등락부호 : " + Data.등락부호 + " : " + "등락률 : " + rate.ToString + " : " + ChartoDbl(Data.등락률).ToString + " 실시간 현재가 : " + ChartoString(Data.종목코드) + " : " + ChartoString(Data.현재가))

            'End If

            'If ChartoString(Data.종목코드) = "263690" Then

            '    Console.WriteLine("등락부호 : " + Data.등락부호 + " : " + "등락률 : " + rate.ToString + " : " + ChartoDbl(Data.등락률).ToString + " 실시간 현재가 : " + ChartoString(Data.종목코드) + " : " + ChartoString(Data.현재가))

            'End If


            'Console.WriteLine("등락률 : " + rate.ToString + " : " + ChartoDbl(Data.등락률).ToString + " 실시간 현재가 : " + ChartoString(Data.종목코드) + " : " + ChartoString(Data.현재가))
            'If ChartoString(Data.종목코드) = "092870" Then
            '    Console.WriteLine("등락률 : " + rate.ToString + " : " + ChartoDbl(Data.등락률).ToString + " 실시간 현재가 : " + ChartoString(Data.종목코드) + " : " + ChartoString(Data.현재가))
            'End If
            'Dim open_p = ChartoDbl(Data.시가)
            'Dim high_p = ChartoDbl(Data.고가)
            'Dim low_p = ChartoDbl(Data.저가)

            '실시간 정보 업데이트
            MySqlDao.Add("")


            'For i = 0 To dgvStockList.RowCount - 2

            '    If dgvStockList.Item(1, i).Value = ChartoString(Data.종목코드) Then

            '        If ChartoDbl(Data.현재가) > Convert.ToDouble(dgvStockList.Item(3, i).Value) Then

            '            dgvStockList.Item(4, i).Style.ForeColor = Color.Red
            '            dgvStockList.Item(5, i).Style.ForeColor = Color.Red

            '        ElseIf ChartoDbl(Data.현재가) = Convert.ToDouble(dgvStockList.Item(3, i).Value) Then

            '            dgvStockList.Item(4, i).Style.ForeColor = Color.Green
            '            dgvStockList.Item(5, i).Style.ForeColor = Color.Green

            '        Else

            '            dgvStockList.Item(4, i).Style.ForeColor = Color.Blue
            '            dgvStockList.Item(5, i).Style.ForeColor = Color.Blue

            '        End If

            '        Dim rate = Math.Round(ChartoDbl(Data.현재가) / dgvStockList.Item(3, i).Value - 1, 4) * 100


            '        dgvStockList.Item(5, i).Value = rate.ToString + "%"
            '        dgvStockList.Item(4, i).Value = String.Format("{0:N0}", CInt(ChartoString(Data.현재가)))


            '    End If

            'Next


        End If
    End Sub


    ''----------------------------------------------------------------------------------------------------------''
#Region "형 변환 함수들"
    ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '                                           Char() 변환 함수
    ' ChartoString / ChartoDbl / ChartoChar / ChartoNumberFormat (String 타입 반환)
    '                                           Int 변환 함수
    ' InttoStr
    ' ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Private Shared Function ChartoString(chars As Char()) As String
        Dim Result As String = ""
        For i = 0 To UBound(chars)
            Result += chars(i)
        Next
        Return Result
    End Function

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        priodThread.Abort()
        End
    End Sub

    Private Shared Function ChartoDbl(chars As Char()) As Double
        Dim Result As String = ""
        For i = 0 To UBound(chars)
            Result += chars(i)
        Next

        Return Convert.ToDouble(Result)
    End Function

    Private Shared Function ChartoDbl(chars As Char(), sizeof As Int16, plus As String) As Double
        Dim Result As String = ""
        Dim Result2 As String = ""
        Dim plus_minus = 1
        If (plus = "4") Or (plus = "5") Then
            plus_minus = -1
        End If

        For i = 0 To UBound(chars) - sizeof
            Result += chars(i)
        Next

        For i = UBound(chars) - sizeof + 1 To UBound(chars)
            Result2 += chars(i)
        Next

        Return (Convert.ToDouble(Result) + Convert.ToDouble(Result2) * 1 / 100) * plus_minus
    End Function

#End Region
End Class


