<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelWhole = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.lbMsg = New System.Windows.Forms.ListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lbStatus = New System.Windows.Forms.ListBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.dgvStockList = New System.Windows.Forms.DataGridView()
        Me.ColNum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColStock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.전일종가 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColCurrPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.마켓 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.tbPW2 = New System.Windows.Forms.TextBox()
        Me.tbID = New System.Windows.Forms.TextBox()
        Me.tbPW = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.panelWhole.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.dgvStockList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelWhole
        '
        Me.panelWhole.Controls.Add(Me.GroupBox4)
        Me.panelWhole.Controls.Add(Me.GroupBox3)
        Me.panelWhole.Controls.Add(Me.GroupBox6)
        Me.panelWhole.Controls.Add(Me.Panel1)
        Me.panelWhole.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelWhole.Location = New System.Drawing.Point(0, 0)
        Me.panelWhole.Name = "panelWhole"
        Me.panelWhole.Size = New System.Drawing.Size(1041, 815)
        Me.panelWhole.TabIndex = 11
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.lbMsg)
        Me.GroupBox4.ForeColor = System.Drawing.Color.White
        Me.GroupBox4.Location = New System.Drawing.Point(460, 629)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(578, 176)
        Me.GroupBox4.TabIndex = 53
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "로그"
        '
        'lbMsg
        '
        Me.lbMsg.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbMsg.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbMsg.FormattingEnabled = True
        Me.lbMsg.HorizontalScrollbar = True
        Me.lbMsg.ItemHeight = 17
        Me.lbMsg.Location = New System.Drawing.Point(3, 17)
        Me.lbMsg.Name = "lbMsg"
        Me.lbMsg.Size = New System.Drawing.Size(572, 156)
        Me.lbMsg.TabIndex = 54
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lbStatus)
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(6, 630)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(451, 176)
        Me.GroupBox3.TabIndex = 52
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "상태바"
        '
        'lbStatus
        '
        Me.lbStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbStatus.Font = New System.Drawing.Font("맑은 고딕", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.lbStatus.FormattingEnabled = True
        Me.lbStatus.HorizontalScrollbar = True
        Me.lbStatus.ItemHeight = 17
        Me.lbStatus.Location = New System.Drawing.Point(3, 17)
        Me.lbStatus.Name = "lbStatus"
        Me.lbStatus.Size = New System.Drawing.Size(445, 156)
        Me.lbStatus.TabIndex = 52
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.dgvStockList)
        Me.GroupBox6.ForeColor = System.Drawing.Color.Snow
        Me.GroupBox6.Location = New System.Drawing.Point(6, 88)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(1032, 536)
        Me.GroupBox6.TabIndex = 51
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "2. 실시간 종목 탐색"
        '
        'dgvStockList
        '
        Me.dgvStockList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvStockList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvStockList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStockList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColNum, Me.ColCode, Me.ColStock, Me.전일종가, Me.ColCurrPrice, Me.ColAmount, Me.Column1, Me.마켓})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Snow
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvStockList.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvStockList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvStockList.GridColor = System.Drawing.SystemColors.ActiveBorder
        Me.dgvStockList.Location = New System.Drawing.Point(3, 17)
        Me.dgvStockList.Name = "dgvStockList"
        Me.dgvStockList.RowHeadersVisible = False
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.Font = New System.Drawing.Font("굴림", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        Me.dgvStockList.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvStockList.RowTemplate.Height = 23
        Me.dgvStockList.Size = New System.Drawing.Size(1026, 516)
        Me.dgvStockList.TabIndex = 50
        '
        'ColNum
        '
        Me.ColNum.HeaderText = "번호"
        Me.ColNum.Name = "ColNum"
        Me.ColNum.ReadOnly = True
        Me.ColNum.Width = 50
        '
        'ColCode
        '
        Me.ColCode.HeaderText = "종목코드"
        Me.ColCode.Name = "ColCode"
        Me.ColCode.ReadOnly = True
        Me.ColCode.Width = 80
        '
        'ColStock
        '
        Me.ColStock.HeaderText = "종목명"
        Me.ColStock.Name = "ColStock"
        Me.ColStock.ReadOnly = True
        Me.ColStock.Width = 220
        '
        '전일종가
        '
        Me.전일종가.HeaderText = "전일종가(원)"
        Me.전일종가.Name = "전일종가"
        '
        'ColCurrPrice
        '
        Me.ColCurrPrice.HeaderText = "현재가(원)"
        Me.ColCurrPrice.Name = "ColCurrPrice"
        '
        'ColAmount
        '
        Me.ColAmount.HeaderText = "현재 상승률"
        Me.ColAmount.Name = "ColAmount"
        Me.ColAmount.Width = 120
        '
        'Column1
        '
        Me.Column1.HeaderText = "산업명"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 170
        '
        '마켓
        '
        Me.마켓.HeaderText = "마켓"
        Me.마켓.Name = "마켓"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1038, 79)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnLogin)
        Me.GroupBox1.Controls.Add(Me.tbPW2)
        Me.GroupBox1.Controls.Add(Me.tbID)
        Me.GroupBox1.Controls.Add(Me.tbPW)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(3, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1032, 66)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "1. 로그인 및 종목 설정"
        '
        'btnLogin
        '
        Me.btnLogin.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnLogin.Location = New System.Drawing.Point(645, 25)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(140, 23)
        Me.btnLogin.TabIndex = 1
        Me.btnLogin.Text = "시작"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'tbPW2
        '
        Me.tbPW2.Location = New System.Drawing.Point(490, 26)
        Me.tbPW2.Name = "tbPW2"
        Me.tbPW2.Size = New System.Drawing.Size(140, 21)
        Me.tbPW2.TabIndex = 6
        Me.tbPW2.UseSystemPasswordChar = True
        '
        'tbID
        '
        Me.tbID.Location = New System.Drawing.Point(60, 24)
        Me.tbID.Name = "tbID"
        Me.tbID.Size = New System.Drawing.Size(140, 21)
        Me.tbID.TabIndex = 4
        '
        'tbPW
        '
        Me.tbPW.Location = New System.Drawing.Point(269, 24)
        Me.tbPW.Name = "tbPW"
        Me.tbPW.Size = New System.Drawing.Size(140, 21)
        Me.tbPW.TabIndex = 5
        Me.tbPW.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(206, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 12)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "비밀번호: "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(415, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 12)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "공인인증서:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(34, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID: "
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(1041, 815)
        Me.Controls.Add(Me.panelWhole)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "실시간 주가 등록"
        Me.panelWhole.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.dgvStockList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelWhole As Panel
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Timer1 As Timer
    Friend WithEvents FontDialog1 As FontDialog
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents dgvStockList As DataGridView
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents tbPW2 As TextBox
    Friend WithEvents tbID As TextBox
    Friend WithEvents tbPW As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents lbMsg As ListBox
    Friend WithEvents lbStatus As ListBox
    Friend WithEvents ColNum As DataGridViewTextBoxColumn
    Friend WithEvents ColCode As DataGridViewTextBoxColumn
    Friend WithEvents ColStock As DataGridViewTextBoxColumn
    Friend WithEvents 전일종가 As DataGridViewTextBoxColumn
    Friend WithEvents ColCurrPrice As DataGridViewTextBoxColumn
    Friend WithEvents ColAmount As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents 마켓 As DataGridViewTextBoxColumn
End Class
