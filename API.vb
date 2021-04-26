Imports System.Runtime.InteropServices

Public NotInheritable Class API
    <DllImport("wmca.dll", charset:=CharSet.Ansi)>
    Public Shared Function wmcaLoad() As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)>
    Public Shared Function wmcaFree() As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)> _
    Public Shared Function wmcaConnect(hWnd As IntPtr, msg As UInteger, MediaType As Char, UserType As Char, _
                                       szID As String, szPW As String, szCertPW As String) As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)> _
    Public Shared Function wmcaDisconnect() As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)> _
    Public Shared Function wmcaSetServer(szServer As String) As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)> _
    Public Shared Function wmcaSetPort(port As Integer) As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)> _
    Public Shared Function wmcaIsConnected() As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)> _
    Public Shared Function wmcaTransact(hWnd As IntPtr, nTRID As Integer, szTRCode As String, szInput As String, _
                                        nInputLen As Integer, Optional nHeadType As Integer = 0, Optional nAccountIndex As Integer = 0) As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)> _
    Public Shared Function wmcaQuery(hWnd As IntPtr, nTRID As Integer, szTRCode As String, szInput As String, _
                                       nInputLen As Integer, Optional nAccountIndex As Integer = 0) As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)> _
    Public Shared Function wmcaReqeust(hWnd As IntPtr, nTRID As Integer, szTRCode As String, szInput As String, _
                                       nInputLen As Integer, Optional szOpenBranchCode As String = "") As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)> _
    Public Shared Function wmcaAttach(hWnd As IntPtr, szBCType As String, szInput As String, nCodeLen As Integer, _
                                       nInputLen As Integer) As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)> _
    Public Shared Function wmcaDetach(hWnd As IntPtr, szBCType As String, szInput As String, nCodeLen As Integer, _
                                       nInputLen As Integer) As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)> _
    Public Shared Function wmcaDetachWindow(hWnd As IntPtr) As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)> _
    Public Shared Function wmcaDetachAll() As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)> _
    Public Shared Function wmcaSetOption(szKey As String, szValue As String) As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)> _
    Public Shared Function wmcaSetAccountIndexPwd(pszHashOut As IntPtr, nAccountIndex As Integer, pszPassword As String) As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)> _
    Public Shared Function wmcaSetOrderPwd(pszHashOut As IntPtr, pszPassword As String) As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)> _
    Public Shared Function wmcaSetAccountNoPwd(pszHashOut As String, pszAccountNo As String, pszPassword As String) As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)> _
    Public Shared Function wmcaSetHashPwd(pszHashOut As String, pszKey As String, pszPassword As String) As Boolean
    End Function

    <DllImport("wmca.dll", charset:=CharSet.Ansi)> _
    Public Shared Function wmcaSetAccountNoByIndex(pszHashOut As String, nAccountIndex As Integer) As Boolean
    End Function

    '//----------------------------------------------------------------------//
    '// WMCA_CONNECTED 로그인 구조체
    '//----------------------------------------------------------------------//
    <StructLayout(LayoutKind.Sequential)> _
    Public Structure ACCOUNTINFO
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=11)> Public szAccountNo As Char()       '계좌번호
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=40)> Public szAccountName As Char()     '계좌명
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=3)> Public act_pdt_cdz3 As Char()       '상품코드
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=4)> Public amn_tab_cdz4 As Char()       '관리점코드
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=8)> Public expr_datez8 As Char()        '위임만기일
        Public granted As Char                                                                  '일괄주문 허용계좌(G:허용)
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=189)> Public filler As Char()           'filler
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure LOGININFO
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=14)> Public szDate As Char()            '접속시각
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=15)> Public szServerName As Char()      '접속서버
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=8)> Public szUserID As Char()           '접속자ID
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=3)> Public szAccountCount As Char()     '계좌수
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=999)> Public accountlist As ACCOUNTINFO() '계좌목록
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure LOGINBLOCK
        Public TrIndex As Integer
        Public pLoginInfo As IntPtr     'LOGININFO *pLoginInfo에 대한 포인터 저장 변수
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure RECEIVED
        Public szBlockName As String
        Public szData As String
        Public nLen As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure RECEIVED2
        Public szBlockName As String
        Public szData As IntPtr
        Public nLen As Integer
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure OUTDATABLOCK
        Public TrIndex As Integer
        Public pData As IntPtr          'RECEIVED* pData에 대한 포인터 저장 변수
    End Structure

    Public Structure MSGHEADER
        Public msg_cd As String
        Public user_msg As String
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Tc8201InBlock        '잔고조회 입력
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=44)> Public pswd_noz44 As Char()           '비밀번호
        Public _pswd_noz44 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public bnc_bse_cdz1 As Char()            '비밀번호
        Public _bnc_bse_cdz1 As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Tc8201OutBlock        '잔고조회 출력
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 예수금 As Char()
        Public _dpsit_amtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 신용융자금 As Char()
        Public _mrgn_amtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 이자미납금 As Char()
        Public _mgint_npaid_amtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 출금가능금액 As Char()
        Public _chgm_pos_amtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 현금증거금 As Char()
        Public _cash_mrgn_amtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 대용증거금 As Char()          '
        Public _subst_mgamt_amtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 담보비율 As Char()          '
        Public _coltr_ratez6 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 현금미수금 As Char()
        Public _rcble_amtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 주문가능금액 As Char()          '
        Public _order_pos_csamtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public ECN주문가능액 As Char()          '
        Public _ecn_pos_csamtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 미상환금 As Char()          '
        Public _nordm_loan_amtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 기타대여금 As Char()          '
        Public _etc_lend_amtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 대용금액 As Char()          '
        Public _subst_amtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 대주담보금 As Char()          '
        Public _sln_sale_amtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 매입원가_계좌합산 As Char()          '
        Public _bal_buy_ttamtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 평가금액_계좌합산 As Char()          '
        Public _bal_ass_ttamtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 순자산액_계좌합산 As Char()          '
        Public _asset_tot_amtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public 활동유형 As Char()          '
        Public _actvt_type10 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 대출금 As Char()          '
        Public _lend_amtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 계좌증거금율 As Char()          '
        Public _accnt_mgamt_ratez6 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 매도증거금 As Char()          '
        Public _sl_mrgn_amtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 주문가능금액20p As Char()          '
        Public _pos_csamt1z16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 주문가능금액30p As Char()          '
        Public _pos_csamt2z16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 주문가능금액40p As Char()          '40%주문가능금액
        Public _pos_csamt3z16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 주문가능금액100p As Char()          '100%주문가능금액
        Public _pos_csamt4z16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 예수금D1 As Char()          '
        Public _dpsit_amtz_d1_16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 예수금D2 As Char()          'D2예수금
        Public _dpsit_amtz_d2_16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=30)> Public 공지사항 As Char()          '
        Public _noticez30 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=18)> Public 총평가손익 As Char()          '
        Public _tot_eal_plsz18 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=15)> Public 수익률 As Char()          '
        Public _pft_rtz15 As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Tc8201OutBlock1        '잔고조회 출력(반복부분, 보유종목 등)
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 종목코드 As Char()          '
        Public _issue_codez6 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=40)> Public 종목명 As Char()         '
        Public _issue_namez40 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 잔고유형 As Char()             '
        Public _bal_typez6 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public 대출일 As Char()           '
        Public _loan_datez10 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 결제잔고 As Char()          '
        Public _bal_qtyz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 미결제량 As Char()          '
        Public _unstl_qtyz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 평균매입가 As Char()          '
        Public _slby_amtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 현재가 As Char()          '
        Public _prsnt_pricez16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 손익_천원 As Char()          '
        Public _lsnpf_amtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 손익율 As Char()          '
        Public _earn_ratez9 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=4)> Public 신용유형 As Char()          '
        Public _mrgn_codez4 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 현재잔고 As Char()          '
        Public _jan_qtyz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public 만기일 As Char()          '
        Public _expr_datez10 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 평가금액 As Char()          '
        Public _ass_amtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 종목증거금율 As Char()          '
        Public _issue_mgamt_ratez6 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 평균매도가 As Char()          '
        Public _medo_slby_amtz16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 매도손익 As Char()          '
        Public _post_lsnpf_amtz16 As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Tc8101InBlock        '주식매도 입력
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=44)> Public 비밀번호 As Char()           '
        Public _pswd_noz8 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 종목코드 As Char()           '
        Public _issue_codez6 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=12)> Public 주문수량 As Char()           '
        Public _order_qtyz12 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public 주문단가 As Char()           '
        Public _order_unit_pricez10 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=2)> Public 매매유형 As Char()           '
        Public _trade_typez2 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 공매도가능여부 As Char()           '
        Public _shsll_pos_flagz1 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=44)> Public 거래비밀번호1 As Char()           '
        Public _trad_pswd_no_1z8 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=44)> Public 거래비밀번호2 As Char()           '
        Public _trad_pswd_no_2z8 As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Tc8101OutBlock     '주식매도 출력
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public 주문번호 As Char()           '
        Public _order_noz10 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=12)> Public 주문수량 As Char()           '
        Public _order_qtyz12 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public 주문단가 As Char()           '
        Public _order_unit_pricez10 As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Tc8102InBlock        '주식매수 입력
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=44)> Public 비밀번호 As Char()           '
        Public _pswd_noz8 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 종목코드 As Char()           '
        Public _issue_codez6 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=12)> Public 주문수량 As Char()           '
        Public _order_qtyz12 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public 주문단가 As Char()           '
        Public _order_unit_pricez10 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=2)> Public 매매유형 As Char()           '
        Public _trade_typez2 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=44)> Public 거래비밀번호1 As Char()           '
        Public _trad_pswd_no_1z8 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=44)> Public 거래비밀번호2 As Char()           '
        Public _trad_pswd_no_2z8 As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Tc8102OutBlock         '주식매수 출력
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public 주문번호 As Char()           '
        Public _order_noz10 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=12)> Public 주문수량 As Char()           '
        Public _order_qtyz12 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public 주문단가 As Char()           '
        Public _order_unit_pricez10 As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Tc1101InBlock        '현재가 조회 입력
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 한영구분 As Char()           '
        Public _formlang As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 종목코드 As Char()           '
        Public _code As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Tc1101OutBlock        '현재가 조회 출력1 : 종목마스타기본자료
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 종목코드 As Char()           '
        Public _code As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=13)> Public 종목명 As Char()           '
        Public _hname As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 현재가 As Char()           '
        Public _price As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 등락부호 As Char()           '
        Public _sign As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 등락폭 As Char()           '
        Public _change As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=5)> Public 등락률 As Char()           '
        Public _chrate As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매도호가 As Char()           '
        Public _offer As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매수호가 As Char()           '
        Public _bid As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 거래량 As Char()           '
        Public _volume As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 거래비율 As Char()           '
        Public _volrate As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=5)> Public 유동주회전율 As Char()           '
        Public _yurate As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 거래대금 As Char()           '
        Public _value As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 상한가 As Char()           '
        Public _uplmtprice As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 장중고가 As Char()           '
        Public _high As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 시가 As Char()           '
        Public _open As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 시가대비부호 As Char()           '
        Public _opensign As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 시가대비등락폭 As Char()           '
        Public _openchange As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 장중저가 As Char()           '
        Public _low As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 하한가 As Char()           '
        Public _dnlmtprice As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=8)> Public 호가시간 As Char()           '
        Public _hotime As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매도1호가 As Char()           '
        Public _offerho As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매도2호가 As Char()           '
        Public _P_offer As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매도3호가 As Char()           '
        Public _S_offer As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매도4차선호가 As Char()           '
        Public _S4_offer As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매도5차선호가 As Char()           '
        Public _S5_offer As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매도6차선호가 As Char()           '
        Public _S6_offer As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매도7차선호가 As Char()           '
        Public _S7_offer As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매도8차선호가 As Char()           '
        Public _S8_offer As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매도9차선호가 As Char()           '
        Public _S9_offer As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매도10차선호가 As Char()           '
        Public _S10_offer As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매수1호가 As Char()           '
        Public _bidho As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매수2호가 As Char()           '
        Public _P_bid As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매수3호가 As Char()           '
        Public _S_bid As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매수4차선호가 As Char()           '
        Public _S4_bid As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매수5차선호가 As Char()           '
        Public _S5_bid As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매수6차선호가 As Char()           '
        Public _S6_bid As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매수7차선호가 As Char()           '
        Public _S7_bid As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매수8차선호가 As Char()           '
        Public _S8_bid As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매수9차선호가 As Char()           '
        Public _S9_bid As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 매수10차선호가 As Char()           '
        Public _S10_bid As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매도1호가잔량 As Char()           '
        Public _offerrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매도2호가잔량 As Char()           '
        Public _P_offerrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매도3호가잔량 As Char()           '
        Public _S_offerrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매도4차선잔량 As Char()           '
        Public _S4_offerrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매도5차선잔량 As Char()           '
        Public _S5_offerrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매도6차선잔량 As Char()           '
        Public _S6_offerrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매도7차선잔량 As Char()           '
        Public _S7_offerrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매도8차선잔량 As Char()           '
        Public _S8_offerrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매도9차선잔량 As Char()           '
        Public _S9_offerrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매도10차선잔량 As Char()           '
        Public _S10_offerrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매수1호가잔량 As Char()           '
        Public _bidrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매수2호가잔량 As Char()           '
        Public _P_bidrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매수3호가잔량 As Char()           '
        Public _S_bidrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매수4차선잔량 As Char()           '
        Public _S4_bidrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매수5차선잔량 As Char()           '
        Public _S5_bidrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매수6차선잔량 As Char()           '
        Public _S6_bidrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매수7차선잔량 As Char()           '
        Public _S7_bidrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매수8차선잔량 As Char()           '
        Public _S8_bidrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매수9차선잔량 As Char()           '
        Public _S9_bidrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매수10차선잔량 As Char()           '
        Public _S10_bidrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 총매도잔량 As Char()           '
        Public _T_offerrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 총매수잔량 As Char()           '
        Public _T_bidrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 시간외매도잔량 As Char()           '
        Public _O_offerrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 시간외매수잔량 As Char()           '
        Public _O_bidrem As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 피봇2차저항 As Char()           '
        Public _pivot2upz7 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 피봇1차저항 As Char()           '
        Public _pivot1upz7 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 피봇가 As Char()           '
        Public _pivotz7 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 피봇1차지지 As Char()           '
        Public _pivot1dnz7 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 피봇2차지지 As Char()           '
        Public _pivot2dnz7 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 코스피코스닥구분 As Char()           '
        Public _sosokz6 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=18)> Public 업종명 As Char()           '
        Public _jisunamez18 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 자본금규모 As Char()           '
        Public _capsizez6 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=18)> Public 결산월 As Char()           '
        Public _output1z16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 시장조치1 As Char()           '
        Public _marcket1z16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 시장조치2 As Char()           '
        Public _marcket2z16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 시장조치3 As Char()           '
        Public _marcket3z16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 시장조치4 As Char()           '
        Public _marcket4z16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 시장조치5 As Char()           '
        Public _marcket5z16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=16)> Public 시장조치6 As Char()           '
        Public _marcket6z16 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public CB구분 As Char()           '
        Public _cbtext As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 액면가 As Char()           '
        Public _parvalue As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public 전일종가타이틀 As Char()           '
        Public _prepricetitlez12 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=9)> Public 전일종가 As Char()           '
        Public _prepricez7 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 대용가 As Char()           '
        Public _subprice As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 공모가 As Char()           '
        Public _gongpricez7 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 고가5일 As Char()           '
        Public _high5 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 저가5일 As Char()           '
        Public _low5 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 고가20일 As Char()           '
        Public _high20 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 저가20일 As Char()           '
        Public _low20 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 최고가52주 As Char()           '
        Public _yhigh As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=4)> Public 최고가일52주 As Char()           '
        Public _yhighdate As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 최저가52주 As Char()           '
        Public _ylow As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=4)> Public 최저가일52주 As Char()           '
        Public _ylowdate As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=8)> Public 유동주식수 As Char()           '
        Public _movlistingz8 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=12)> Public 상장주식수 As Char()           '
        Public _listing As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 시가총액 As Char()           '
        Public _totpricez9 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=5)> Public 시간 As Char()           '
        Public _tratimez5 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 매도거래원1 As Char()           '
        Public _off_tra1 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 매수거래원1 As Char()           '
        Public _bid_tra1 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매도거래량1 As Char()           '
        Public _N_offvolume1 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매수거래량1 As Char()           '
        Public _N_bidvolume1 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 매도거래원2 As Char()           '
        Public _off_tra2 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 매수거래원2 As Char()           '
        Public _bid_tra2 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매도거래량2 As Char()           '
        Public _N_offvolume2 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매수거래량2 As Char()           '
        Public _N_bidvolume2 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 매도거래원3 As Char()           '
        Public _off_tra3 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 매수거래원3 As Char()           '
        Public _bid_tra3 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매도거래량3 As Char()           '
        Public _N_offvolume3 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매수거래량3 As Char()           '
        Public _N_bidvolume3 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 매도거래원4 As Char()           '
        Public _off_tra4 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 매수거래원4 As Char()           '
        Public _bid_tra4 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매도거래량4 As Char()           '
        Public _N_offvolume4 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매수거래량4 As Char()           '
        Public _N_bidvolume4 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 매도거래원5 As Char()           '
        Public _off_tra5 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 매수거래원5 As Char()           '
        Public _bid_tra5 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매도거래량5 As Char()           '
        Public _N_offvolume5 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매수거래량5 As Char()           '
        Public _N_bidvolume5 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매도외국인거래량 As Char()           '
        Public _N_offvolall As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 매수외국인거래량 As Char()           '
        Public _N_bidvolall As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 외국인시간 As Char()           '
        Public _fortimez6 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=5)> Public 외국인지분율 As Char()           '
        Public _forratez5 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=4)> Public 결제일 As Char()           '
        Public _settdatez4 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=5)> Public 잔고비율 As Char()           '
        Public _cratez5 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=4)> Public 유상기준일 As Char()           '
        Public _yudatez4 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=4)> Public 무상기준일 As Char()           '
        Public _mudatez4 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=5)> Public 유상배정비율 As Char()           '
        Public _yuratez5 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=5)> Public 무상배정비율 As Char()           '
        Public _muratez5 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public 외국인변동주수 As Char()           '
        Public _formovolz10 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 자사주 As Char()           '
        Public _jasa As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=8)> Public 상장일 As Char()           '
        Public _listdatez8 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=5)> Public 대주주지분율 As Char()           '
        Public _daeratez5 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 대주주지분일자 As Char()           '
        Public _daedatez6 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 네잎클로버 As Char()           '
        Public _clovergb As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 증거금율 As Char()           '
        Public _depositgb As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 자본금 As Char()           '
        Public _capital As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 전체거래원매도합 As Char()           '
        Public _N_alloffvol As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 전체거래원매수합 As Char()           '
        Public _N_allbidvol As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=21)> Public 종목명2 As Char()           '
        Public _hnamez21 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 우회상장여부 As Char()           '
        Public _detourgb As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 유동주회전율2 As Char()           '
        Public _yuratez6 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 코스피구분 As Char()           '
        Public _sosokz6_1 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=4)> Public 공여율기준일 As Char()           '
        Public _maedatez4 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=5)> Public 공여율 As Char()           '
        Public _lratez5 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=5)> Public PER As Char()           '
        Public _perz5 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 종목별신용한도 As Char()           '
        Public _handogb As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 가중가 As Char()           '
        Public _avgprice As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=12)> Public 상장주식수_주 As Char()           '
        Public _listing2 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=12)> Public 추가상장주수 As Char()           '
        Public _addlisting As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=100)> Public 종목코멘트 As Char()           '
        Public _gicomment As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=9)> Public 전일거래량 As Char()           '
        Public _prevolume As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 전일대비등락부호 As Char()           '
        Public _presign As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=6)> Public 전일대비등락폭 As Char()           '
        Public _prechange As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 연중최고가 As Char()           '
        Public _yhigh2 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=4)> Public 연중최고가일 As Char()           '
        Public _yhighdate2 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=7)> Public 연중최저가 As Char()           '
        Public _ylow2 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=4)> Public 연중최저가일 As Char()           '
        Public _ylowdate2 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=15)> Public 외국인보유주식수 As Char()           '
        Public _forstock As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=5)> Public 외국인한도율 As Char()           '
        Public _forlmtz5 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=5)> Public 매매수량단위 As Char()           '
        Public _maeunit As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 경쟁대량방향구분 As Char()           '
        Public _mass_opt As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 대량매매구분 As Char()           '
        Public _largemgb As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Ts8120InBlock        '주문체결조회
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 조회주체구분 As Char()
        Public _조회주체구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=44)> Public 비밀번호 As Char()
        Public _비밀번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=4)> Public 그룹번호 As Char()
        Public _그룹번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 시장구분 As Char()
        Public _시장구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=8)> Public 주문일자 As Char()
        Public _주문일자 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=12)> Public 종목번호 As Char()
        Public _종목번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=2)> Public 매체구분 As Char()
        Public _매체구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 체결구분 As Char()
        Public _체결구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 조회순서 As Char()
        Public _조회순서 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 정렬구분 As Char()
        Public _정렬구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 매수도구분 As Char()
        Public _매수도구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 신용구분 As Char()
        Public _신용구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 계좌구분 As Char()
        Public _계좌구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public 주문번호 As Char()
        Public _주문번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=56)> Public CTS As Char()
        Public _CTS As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=44)> Public 거래비밀번호1 As Char()
        Public _거래비밀번호1 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=44)> Public 거래비밀번호2 As Char()
        Public _거래비밀번호2 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public ISPAGEUP As Char()
        Public _ISPAGEUP As Char

    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Ts8120OutBlock1       '주문체결조회
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=20)> Public 한글사원성명 As Char()
        Public _한글사원성명 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=30)> Public 한글지점명 As Char()
        Public _한글지점명 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=14)> Public 매수체결수량 As Char()
        Public _매수체결수량 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=19)> Public 매수체결금액 As Char()
        Public _매수체결금액 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=14)> Public 매도체결수량 As Char()
        Public _매도체결수량 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=19)> Public 매도체결금액 As Char()
        Public _매도체결금액 As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Ts8120OutBlock2      '주문체결조회
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=8)> Public 주문일자 As Char()
        Public _주문일자 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public 주문번호 As Char()
        Public _주문번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public 원주문번호 As Char()
        Public _원주문번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=11)> Public 계좌번호 As Char()
        Public _계좌번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=20)> Public 계좌명 As Char()
        Public _계좌명 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=20)> Public 주문구분 As Char()
        Public _주문구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 매매구분번호 As Char()
        Public _매매구분번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=20)> Public 매매구분 As Char()
        Public _매매구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 거래구분번호 As Char()
        Public _거래구분번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=20)> Public 거래구분 As Char()
        Public _거래구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=12)> Public 종목번호 As Char()
        Public _종목번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=40)> Public 종목명 As Char()
        Public _종목명 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public 주문수량 As Char()
        Public _주문수량 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public 체결수량 As Char()
        Public _체결수량 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=12)> Public 주문단가 As Char()
        Public _주문단가 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=12)> Public 체결평균단가 As Char()
        Public _체결평균단가 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public 정정취소수량 As Char()
        Public _정정취소수량 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public 확인수량 As Char()
        Public _확인수량 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=12)> Public 매체구분 As Char()
        Public _매체구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=5)> Public 처리사번 As Char()
        Public _처리사번 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=8)> Public 처리시간 As Char()
        Public _처리시간 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=8)> Public 처리단말 As Char()
        Public _처리단말 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=12)> Public 처리구분 As Char()
        Public _처리구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=5)> Public 거부코드 As Char()
        Public _거부코드 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=10)> Public 정취가능수량 As Char()
        Public _정취가능수량 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public 시장구분 As Char()
        Public _시장구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=20)> Public 공매도구분 As Char()
        Public _공매도구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=8)> Public 비밀번호 As Char()
        Public _비밀번호 As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Ts8120OutBlock3      '주문체결조회
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=56)> Public CTS As Char()
        Public _CTS As Char
        <MarshalAs(UnmanagedType.ByValArray, sizeconst:=1)> Public NEXTBUTTON As Char()
        Public _NEXTBUTTON As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Tc8103InBlock      '주식정정 주문
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=44)> Public 비밀번호 As Char()
        Public _비밀번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> Public 종목번호 As Char()
        Public _종목번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=12)> Public 정정수량 As Char()
        Public _정정수량 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public 정정단가 As Char()
        Public _정정단가 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public 원주문번호 As Char()
        Public _원주문번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1)> Public 정정구분 As Char()
        Public _정정구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=44)> Public 거래비밀1 As Char()
        Public _거래비밀1 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=44)> Public 거래비밀2 As Char()
        Public _거래비밀2 As Char
    End Structure


    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Tc8103OutBlock      '주식정정 주문
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public 원주문번호 As Char()
        Public _원주문번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public 주문번호 As Char()
        Public _주문번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public 모주문번호 As Char()
        Public _모주문번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> Public 후종목번호 As Char()
        Public _후종목번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=12)> Public 정정수량 As Char()
        Public _정정수량 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public 정정단가 As Char()
        Public _정정단가 As Char

    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Tc8104InBlock      '주식취소 주문
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=44)> Public 비밀번호 As Char()
        Public _비밀번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> Public 종목번호 As Char()
        Public _종목번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=12)> Public 취소수량 As Char()
        Public _취소수량 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public 원주문번호 As Char()
        Public _원주문번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1)> Public 취소구분 As Char()
        Public _취소구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=44)> Public 거래비밀번호1 As Char()
        Public _거래비밀번호1 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=44)> Public 거래비밀번호2 As Char()
        Public _거래비밀번호2 As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure Tc8104OutBlock      '주식취소 주문
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public 원주문번호 As Char()
        Public _원주문번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public 주문번호 As Char()
        Public _주문번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public 모주문번호 As Char()
        Public _모주문번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> Public 후종목번호 As Char()
        Public _후종목번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=12)> Public 취소수량 As Char()
        Public _취소수량 As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure Tp8101InBlock      '매도가능 수량
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=44)> Public 비밀번호 As Char
        Public _비밀번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1)> Public 구분 As Char
        Public _구분 As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure Tp8101OutBlock      '매도가능 수량
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=30)> Public 계좌명 As Char
        Public _계좌명 As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure Tp8101OutBlock1     '매도가능 수량
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1)> Public 구분 As Char
        Public _구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> Public 구분명 As Char
        Public _구분명 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=12)> Public 종목코드 As Char
        Public _종목코드 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=30)> Public 종목명 As Char
        Public _종목명 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public 신용구분 As Char
        Public _신용구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public 대출일자 As Char
        Public _대출일자 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public 과세유형 As Char
        Public _과세유형 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=12)> Public 잔고수량 As Char
        Public _잔고수량 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=12)> Public 매도미결제 As Char
        Public _매도미결제 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=12)> Public 매수미결제 As Char
        Public _매수미결제 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=12)> Public 매도가능수량 As Char
        Public _매도가능수량 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=12)> Public 당일매도미체결수량 As Char
        Public _당일매도미체결수량 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=10)> Public 매입단가 As Char
        Public _매입단가 As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure Tp8105InBlock      '매수가능 수량
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=44)> Public 비밀번호 As Char
        Public _비밀번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1)> Public 구분코드 As Char
        Public _구분코드 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1)> Public 매매구분코드 As Char
        Public _매매구분코드 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1)> Public 종목구분 As Char
        Public _종목구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=12)> Public 종목코드 As Char
        Public _종목코드 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1)> Public 호가유형구분 As Char
        Public _호가유형구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Public 호가유형코드 As Char
        Public _호가유형코드 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public 주문가격 As Char
        Public _주문가격 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1)> Public 매체유형코드 As Char
        Public _매체유형코드 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=2)> Public 신용대출코드 As Char
        Public _신용대출코드 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Public 대출일자 As Char
        Public _대출일자 As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure Tp8105OutBlock      '매수가능 수량
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public 예수금 As Char
        Public _예수금 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public 예수금D1 As Char
        Public _예수금D1 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public 예수금D2 As Char
        Public _예수금D2 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public 최대가능금액 As Char
        Public _최대가능금액 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public 최대가능수량 As Char
        Public _최대가능수량 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public 미수발생최대가능수수료 As Char
        Public _미수발생최대가능수수료 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public 현금주문가능금액 As Char
        Public _현금주문가능금액 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public 현금주문가능수량 As Char
        Public _현금주문가능수량 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public 현금수수료 As Char
        Public _현금수수료 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public 신용미수주문가능금액 As Char
        Public _신용미수주문가능금액 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public 신용미수주문가능수량 As Char
        Public _신용미수주문가능수량 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public 신용최대가능수수료 As Char
        Public _신용최대가능수수료 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public 신용주문가능금액 As Char
        Public _신용주문가능금액 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public 신용주문가능수량 As Char
        Public _신용주문가능수량 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public 수수료2 As Char
        Public _수수료2 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public 제비용1 As Char
        Public _제비용1 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=18)> Public 제비용 As Char
        Public _제비용 As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure Tp8104InBlock      '개별주식매도 수량
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=44)> Public 비밀번호 As Char
        Public _비밀번호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> Public 종목코드 As Char
        Public _종목코드 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1)> Public 구분 As Char
        Public _구분 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Public 대출일 As Char
        Public _대출일 As Char
    End Structure

    <StructLayout(LayoutKind.Sequential)>
    Public Structure Tp8104OutBlock      '개별주식매도 수량
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> Public 종목코드 As Char
        Public _종목코드 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=12)> Public 매도가능수량 As Char
        Public _매도가능수량 As Char
    End Structure

    Public Structure Tj8InBlock ' 실시간
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> Public 종목코드 As Char
        Public _종목코드 As Char
    End Structure

    Public Structure Tj8OutBlock ' 출력
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> Public 종목코드 As Char()
        Public _종목코드 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Public 시간 As Char()
        Public _시간 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1)> Public 등락부호 As Char()
        Public _등락부호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> Public 등락폭 As Char()
        Public _등락폭 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Public 현재가 As Char()
        Public _현재가 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=5)> Public 등락률 As Char()
        Public _등락률 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Public 고가 As Char()
        Public _고가 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Public 저가 As Char()
        Public _저가 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Public 매도호가 As Char()
        Public _매도호가 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Public 매수호가 As Char()
        Public _매수호가 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=9)> Public 거래량 As Char()
        Public _거래량 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> Public 거래량전일비 As Char()
        Public _거래량전일비 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Public 변동거래량 As Char()
        Public _변동거래량 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=9)> Public 거래대금 As Char()
        Public _거래대금 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Public 시가 As Char()
        Public _시가 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Public 가중평균가 As Char()
        Public _가중평균가 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1)> Public 장구분 As Char()
        Public _장구분 As Char
    End Structure

    Public Structure Tk8OutBlock ' 출력
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> Public 종목코드 As Char()
        Public _종목코드 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Public 시간 As Char()
        Public _시간 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Public 현재가 As Char()
        Public _현재가 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1)> Public 등락부호 As Char()
        Public _등락부호 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> Public 등락폭 As Char()
        Public _등락폭 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=5)> Public 등락률 As Char()
        Public _등락률 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Public 고가 As Char()
        Public _고가 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Public 저가 As Char()
        Public _저가 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Public 매도호가 As Char()
        Public _매도호가 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Public 매수호가 As Char()
        Public _매수호가 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=9)> Public 거래량 As Char()
        Public _거래량 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=6)> Public 거래량전일비 As Char()
        Public _거래량전일비 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=8)> Public 변동거래량 As Char()
        Public _변동거래량 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=9)> Public 거래대금 As Char()
        Public _거래대금 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Public 시가 As Char()
        Public _시가 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=7)> Public 가중평균가 As Char()
        Public _가중평균가 As Char
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=1)> Public 장구분 As Char()
        Public _장구분 As Char
    End Structure

    Public Structure TR
        Const WM_USER = 1024
        Const CA_WMCAEVENT = WM_USER + 8400
        Const CA_CONNECTED = WM_USER + 110
        Const CA_DISCONNECTED = WM_USER + 120
        Const CA_SOCKETERROR = WM_USER + 130
        Const CA_RECEIVEDATA = WM_USER + 210
        Const CA_RECEIVESISE = WM_USER + 220
        Const CA_RECEIVEMESSAGE = WM_USER + 230
        Const CA_RECEIVECOMPLETE = WM_USER + 240
        Const CA_RECEIVEERROR = WM_USER + 250
        Const TRID_c1101 = 100
        Const TRID_c8201 = 2
        Const TRID_c8102 = 3
        Const TRID_c8101 = 4
        Const TRID_s8120 = 5
        Const TRID_c8104 = 6
        Const Size_HashPW = 44
        Const Size_CTS = 56
    End Structure
End Class



