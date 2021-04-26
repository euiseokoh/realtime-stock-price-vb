Public Class Order_List
    Public ID As String
    Public Name As String
    Public LiquidationValue As Double
    Public Type As String
    Public Type2 As String
    Public CurrentPrice As Double
    Public Quantity As Double
    Public LimitPrice As Double

End Class

Public Class Portfolio
    Public ID As String
    Public name As String
    Public industry As String
    Public price As Double
    Public lastprice As Double
    Public custom As String
    Public scope As String
End Class

Public Class Order_Result
    Public 주문번호 As String
    Public 주문구분 As String
    Public 매매구분 As String
    Public 종목코드 As String
    Public 종목명 As String
    Public 주문수량 As String
    Public 주문단가 As String
    Public 체결수량 As String
    Public 체결단가 As String
    Public 매매금액 As String

End Class

