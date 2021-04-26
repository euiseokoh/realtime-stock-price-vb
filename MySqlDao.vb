Public Module MySqlDao

    Private dbConn As MySqlDBConn = New MySqlDBConn
    Private sql As String = Nothing

    Public Function getstocklist()

        sql = ""
        'Console.WriteLine(sql)
        Dim ds As DataSet = dbConn.ReadFormDB(sql)

        Return ds

    End Function

    Public Function get_mctoparray(start, limit)

        sql = ""
        'Console.WriteLine(sql)
        Dim ds As DataSet = dbConn.ReadFormDB(sql)

        Return ds

    End Function


    Public Function Add(query)


        'Console.WriteLine(sql)
        dbConn.WriteFormDB(query)

        Return 0

    End Function


End Module
